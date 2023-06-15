using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midtrans.Payment.Shared.Attributes
{
    public enum EnumHttpRequest
    {
        NoAuth = 1,
        API_Key = 2,
        Bearer = 3,
        JWT_Bearer = 4,
        Basic_Auth = 5
    }   
}
