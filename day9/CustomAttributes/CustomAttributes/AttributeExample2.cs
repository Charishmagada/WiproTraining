using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    internal class AttributeExample2
    {
        [System.AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
        public class VendorAttribute : Attribute
        {
            public string vendorName;
            public double premiumAmount;

            public VendorAttribute(string vendorName)
            {
                this.vendorName = vendorName;
            }
        }
    }
}
