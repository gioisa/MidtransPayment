//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Midtrans.Payment.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Midtrans.Payment.Data.Model;

namespace Midtrans.Payment.Core.Response
{
    public partial class UserRoleResponse: IMapResponse<UserRoleResponse, Midtrans.Payment.Data.Model.UserRole>
    {
		public Guid Id{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string IdRole{ get; set; }
		public Guid IdUser{ get; set; }


        public void Mapping(IMappingExpression<Midtrans.Payment.Data.Model.UserRole, UserRoleResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

