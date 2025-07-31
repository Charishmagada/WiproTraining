using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomAttributes.AttributeExample2;

namespace CustomAttributes
{

    [Vendor(vendorName: "Zomato"), Vendor("AK Tifinis", premiumAmount = 88323.44)]
    public class Anubhav
    {
    }
}
