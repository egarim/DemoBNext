using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBNext.Module.BusinessObjects
{
    public class BusinessKeyAttribute:Attribute
    {
        public string Properties { get; set; }
        public BusinessKeyAttribute(string properties)
        {
            Properties = properties;
        }
    }
}
