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
    public partial class RoleResponse: IMapResponse<RoleResponse, Midtrans.Payment.Data.Model.Role>
    {
		public string Id{ get; set; }
		public bool Active{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Name{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Midtrans.Payment.Data.Model.Role, RoleResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}
