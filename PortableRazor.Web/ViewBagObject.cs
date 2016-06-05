using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableRazor.Web.Mvc
{
    /// <summary>
    /// Represents ASP.NET MVC ViewBag Dynamic Object
    /// </summary>
    public class ViewBagObject : DynamicObject
    {
        private readonly Dictionary<string, object> values
            = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            values.TryGetValue(binder.Name, out result);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            values[binder.Name] = value;
            return true;
        }
    }
}
