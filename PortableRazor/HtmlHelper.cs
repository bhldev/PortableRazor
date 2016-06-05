using System;
using System.IO;
using System.Reflection;
using System.Text;
using PortableRazor.Web;

namespace PortableRazor.Web.Mvc
{
	public partial class HtmlHelper {
		private TextWriter _writer;

        private dynamic _model;
        public dynamic Model
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model = value;
            }
        }

		public HtmlHelper(TextWriter writer) {
			_writer = writer;
		}

		public IHtmlString Raw(string value) {
			return new HtmlString (value);
		}

		private string GenerateHtmlAttributes(object htmlAttributes) {
			var attrs = new StringBuilder ();
			if (htmlAttributes != null) {
				foreach (var property in htmlAttributes.GetType ().GetRuntimeProperties()) 
					attrs.AppendFormat (@" {0}=""{1}""", property.Name.Replace('_', '-'), property.GetMethod.Invoke (htmlAttributes, null));
			}
			return attrs.ToString ();
		}
	}
}

