using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortableRazor.Web.Mvc
{
    public partial class HtmlHelper
    {
        #region Checkbox
        public IHtmlString CheckBoxFor(Func<dynamic, dynamic> func, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("checkbox", isChecked: result, name: name);
        }

        public IHtmlString CheckBoxFor(Func<dynamic, dynamic> func, IDictionary<String, object> htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("checkbox", isChecked: result, htmlAttributes: UrlHelper.GetObjectFromDict(htmlAttributes), name: name);
        }
        
        public IHtmlString CheckBoxFor(Func<dynamic, dynamic> func, object htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("checkbox", isChecked: result, htmlAttributes: htmlAttributes, name: name);
        }
        #endregion

        #region Hidden
        public IHtmlString HiddenFor(Func<dynamic, dynamic> func, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("checkbox", result, name: name);
        }

        public IHtmlString HiddenFor(Func<dynamic, dynamic> func, IDictionary<String, object> htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("checkbox", func.Invoke(Model), htmlAttributes: UrlHelper.GetObjectFromDict(htmlAttributes), name: name);
        }

        public IHtmlString HiddenFor(Func<dynamic, dynamic> func, object htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("checkbox", result, htmlAttributes: htmlAttributes, name: name);
        }
        #endregion

        #region Password
        public IHtmlString PasswordFor(Func<dynamic, dynamic> func, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("password", result, name: name);
        }

        public IHtmlString PasswordFor(Func<dynamic, dynamic> func, IDictionary<String, object> htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("password", result, htmlAttributes: UrlHelper.GetObjectFromDict(htmlAttributes), name: name);
        }

        public IHtmlString PasswordFor(Func<dynamic, dynamic> func, object htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("password", result, htmlAttributes: htmlAttributes, name: name);
        }
        #endregion

        #region RadioButton
        public IHtmlString RadioButtonFor(Func<dynamic, dynamic> func, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("radio", result, name: name);
        }

        public IHtmlString RadioButtonFor(Func<dynamic, dynamic> func, IDictionary<String, object> htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("radio", result, htmlAttributes: UrlHelper.GetObjectFromDict(htmlAttributes), name: name);
        }

        public IHtmlString RadioButtonFor(Func<dynamic, dynamic> func, object htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("radio", result, htmlAttributes: htmlAttributes, name: name);
        }
        #endregion

        #region TextBox
        public IHtmlString TextBoxFor(Func<dynamic, dynamic> func, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("text", result, name: name);
        }

        public IHtmlString TextBoxFor(Func<dynamic, dynamic> func, IDictionary<String, object> htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("text", result, htmlAttributes: UrlHelper.GetObjectFromDict(htmlAttributes), name: name);
        }

        public IHtmlString TextBoxFor(Func<dynamic, dynamic> func, object htmlAttributes, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return InputFor("text", result, htmlAttributes: htmlAttributes, name: name);
        }

        #endregion

        public IHtmlString InputFor(string inputType, object value = null, string format = "{0}", object htmlAttributes = null, bool isChecked = false, string name = "")
        {
            var formattedValue = value != null ? String.Format(format, value) : null;
            // TODO figure out how to render name dynamically
            // Right now "name" and "id" must be part of the htmlAttributes
            if (!string.IsNullOrEmpty(name))
            {
                return new MvcHtmlString(string.Format("<input type=\"{0}\" name=\"{1}\" {2}{3}{4} />",
                    inputType,
                    name,
                    formattedValue == null ? String.Empty : String.Format("value=\"{0}\"", formattedValue),
                    isChecked ? " checked=\"checked\"" : String.Empty,
                    GenerateHtmlAttributes(htmlAttributes)));
            }
            else
            {
                return new MvcHtmlString(string.Format("<input type=\"{0}\" {1}{2}{3} />",
                    inputType,
                    formattedValue == null ? String.Empty : String.Format("value=\"{0}\"", formattedValue),
                    isChecked ? " checked=\"checked\"" : String.Empty,
                    GenerateHtmlAttributes(htmlAttributes)));
            }
        }

    }
}
