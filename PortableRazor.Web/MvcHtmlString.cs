using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableRazor.Web.Mvc
{
    public class MvcHtmlString : HtmlString
    {
        protected string value;

        public MvcHtmlString(string value) : base(value)
        {
            this.value = value;
        }
        
        public static bool IsNullOrEmpty(MvcHtmlString value)
        {
            return String.IsNullOrEmpty(value.value);
        }

    }
}
