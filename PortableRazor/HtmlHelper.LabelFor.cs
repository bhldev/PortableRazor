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

        public IHtmlString LabelFor(Func<dynamic, dynamic> expression, object htmlAttributes = null, string name = "", string label = "")
        {
            // TODO figure out how to get name out of System.ComponentModel.DataAnnotations
            return LabelFor(label, name, htmlAttributes: htmlAttributes);
        }

        public IHtmlString LabelFor(string labelText, string labelFor = "", object htmlAttributes = null)
        {
            return new MvcHtmlString(string.Format("<label for=\"{0}\"{1}>{2}</label>",
                labelFor,
                GenerateHtmlAttributes(htmlAttributes),
                labelText));
        }

    }
}
