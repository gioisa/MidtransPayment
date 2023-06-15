//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Midtrans.Payment.Data;
using Midtrans.Payment.Data.Model;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Response;
using Midtrans.Payment.Core.Helper;

namespace Midtrans.Payment.Core.Role.Query
{
    public class GetRoleListRequest : ListRequest,IListRequest<GetRoleListRequest>,IRequest<ListResponse<RoleResponse>>
    {
    }
    internal class GetRoleListHandler : IRequestHandler<GetRoleListRequest, ListResponse<RoleResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetRoleListHandler(
            ILogger<GetRoleListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<RoleResponse>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<RoleResponse> result = new ListResponse<RoleResponse>();
            try
            {
				var query = _context.Entity<Midtrans.Payment.Data.Model.Role>().AsQueryable();

				#region Filter
				Expression<Func<Midtrans.Payment.Data.Model.Role, object>> column_sort = null;
				List<Expression<Func<Midtrans.Payment.Data.Model.Role, bool>>> where = new List<Expression<Func<Midtrans.Payment.Data.Model.Role, bool>>>();
				if (request.Filter != null && request.Filter.Count > 0)
				{
					foreach (var f in request.Filter)
					{
						var obj = ListExpression(f.Search, f.Field, true);
						if (obj.where != null)
							where.Add(obj.where);
					}
				}
				if (where != null && where.Count() > 0)
				{
					foreach (var w in where)
					{
						query = query.Where(w);
					}
				}
				if (request.Sort != null)
                {
					column_sort = ListExpression(request.Sort.Field, request.Sort.Field, false).order!;
					if(column_sort != null)
						query = request.Sort.Type == SortTypeEnum.ASC ? query.OrderBy(column_sort) : query.OrderByDescending(column_sort);
					else
						query = query.OrderBy(d=>d.Id);
				}
				#endregion

				var query_count = query;
				if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
					query = query.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value);
				var data_list = await query.ToListAsync();

				result.List = _mapper.Map<List<RoleResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List Role", request);
                result.Error("Failed Get List Role", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Midtrans.Payment.Data.Model.Role, bool>> where, Expression<Func<Midtrans.Payment.Data.Model.Role, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Midtrans.Payment.Data.Model.Role, object>> result_order = null;
			Expression<Func<Midtrans.Payment.Data.Model.Role, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "id" : 
						if(is_where){
							result_where = (d=>d.Id.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Id);
					break;
					case "active" : 
						if(is_where){
							if (bool.TryParse(search, out var _Active))
								result_where = (d=>d.Active == _Active);
						}
						else
							result_order = (d => d.Active);
					break;
					case "createby" : 
						if(is_where){
							result_where = (d=>d.CreateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.CreateBy);
					break;
					case "createdate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _CreateDate))
								result_where = (d=>d.CreateDate == _CreateDate);
						}
						else
							result_order = (d => d.CreateDate);
					break;
					case "name" : 
						if(is_where){
							result_where = (d=>d.Name.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Name);
					break;
					case "updateby" : 
						if(is_where){
							result_where = (d=>d.UpdateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.UpdateBy);
					break;
					case "updatedate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _UpdateDate))
								result_where = (d=>d.UpdateDate == _UpdateDate);
						}
						else
							result_order = (d => d.UpdateDate);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

