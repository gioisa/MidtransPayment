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
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Midtrans.Payment.Data;
using Midtrans.Payment.Data.Model;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Response;

namespace Midtrans.Payment.Core.Role.Query
{

    public class GetRoleByIdRequest : IRequest<ObjectResponse<RoleResponse>>
    {
        [Required]
        public string Id { get; set; }
    }
    internal class GetRoleByIdHandler : IRequestHandler<GetRoleByIdRequest, ObjectResponse<RoleResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetRoleByIdHandler(
            ILogger<GetRoleByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<RoleResponse>> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<RoleResponse> result = new ObjectResponse<RoleResponse>();
            try
            {
                var item = await _context.Entity<Midtrans.Payment.Data.Model.Role>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<RoleResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Midtrans.Payment.Data.Model.Role {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Role", request.Id);
                result.Error("Failed Get Detail Role", ex.Message);
            }
            return result;
        }
    }
}

