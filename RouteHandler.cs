using System;
using System.Collections.Generic;
using System.Reflection;
using PortableRazor.Web;

namespace PortableRazor
{
	public static class RouteHandler
	{
		private static string defaultControllerName;

		public static Dictionary<string, object> Controllers { get; private set; }

		static RouteHandler ()
		{
			Controllers = new Dictionary<string, object> (StringComparer.OrdinalIgnoreCase);
			defaultControllerName = String.Empty;
		}

		public static void RegisterController(string controllerName, object controller) {
			Controllers.Add (controllerName, controller);
			if (defaultControllerName == String.Empty) 
				defaultControllerName = controllerName;
		}

		public static void SetDefaultController(string controllerName) {
			defaultControllerName = controllerName;
		}

		public static bool HandleRequest(string url) {

			// If the URL is not our own custom scheme, just let the webView load the URL as usual
			var scheme = PortableRazor.ViewBase.UrlScheme;

			if (!url.StartsWith(scheme))
				return false;

			if (url == scheme)
				return false;

			// This handler will treat everything between the protocol and "?"
			// as the method name.  The querystring has all of the parameters.
			var resources = url.Substring(scheme.Length).Split('?');
			var actionName = resources [0];
			var controllerName = defaultControllerName;
			if (actionName.Contains ("/")) {
				var parts = actionName.Split ('/');
				controllerName = parts [0];
				actionName = parts [1];
			}

			var controller = Controllers [controllerName];
			var method = controller.GetType ().GetRuntimeMethod (actionName);

			var parameters = resources.Length > 1 ? HttpUtility.ParseQueryString (resources [1]) : null;

            var methodParams = method.GetParameters();

            // If one length, potentially a model object. Attempt to instantiate and map
            var paramsIn = new object[0];
            if (methodParams.Length == 1)
            {
                try
                {
                    var modelType = methodParams[0].ParameterType;
                    var modelParams = modelType.GetRuntimeProperties();
                    paramsIn = new object[1];
                    var model = Activator.CreateInstance(modelType);
                    foreach (var p in modelParams)
                    {
                        if (parameters != null && parameters.ContainsKey(p.Name))
                        {
                            p.SetValueNullable(model, p.Name, parameters[p.Name]);
                        }
                    }
                    paramsIn[0] = model;
                }
                catch
                {
                    paramsIn = GetControllerParameters(methodParams, parameters);
                }
            }
            // Not a model object. Map and instantiate.
            else
            {
                paramsIn = GetControllerParameters(methodParams, parameters);
            }
            method.Invoke(controller, paramsIn);
            return true;
		}

        private static object[] GetControllerParameters(ParameterInfo[] methodParams, IDictionary<String, String> parameters)
        {
            var paramsIn = new object[methodParams.Length];
            foreach (var p in methodParams)
            {
                if (parameters != null && parameters.ContainsKey(p.Name))
                {
                    paramsIn[Array.IndexOf(methodParams, p)] = Convert.ChangeType(parameters[p.Name], p.ParameterType);
                }
            }
            return paramsIn;
        }

		private static MethodInfo GetRuntimeMethod(this Type type, string name) {
			var methods = type.GetRuntimeMethods ();
			foreach (var method in methods)
				if (method.Name == name)
					return method;
			return null;
		}
	}
}

