using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableRazor.Web.Mvc
{
    public partial class HtmlHelper
    {
        public IHtmlString TextAreaFor(Func<dynamic, dynamic> func, object htmlAttributes = null, string name = "")
        {
            // TODO figure out how to get name out of Func<dynamic, dynamic>
            // Can't get it with Expression<Func<dynamic, dynamic>>
            // var name = "";
            var result = func.Invoke(Model);
            return TextAreaFor(name, result, htmlAttributes: htmlAttributes);
        }
        
        public IHtmlString TextAreaFor(string name, string value = "", int rows = -1, int columns = -1, object htmlAttributes = null)
        {
            return new HtmlString(string.Format("<textarea name=\"{1}\" id=\"{1}\"{2}{3}{4}>{0}</textarea>",
                value,
                name,
                rows > -1 ? String.Format("rows=\"{0}\"", rows) : String.Empty,
                columns > -1 ? String.Format("cols=\"{0}\"", columns) : String.Empty,
                GenerateHtmlAttributes(htmlAttributes)));
        }
    }
}
