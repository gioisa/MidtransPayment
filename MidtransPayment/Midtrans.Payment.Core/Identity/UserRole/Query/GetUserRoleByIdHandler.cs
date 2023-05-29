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

namespace Midtrans.Payment.Core.UserRole.Query
{

    public class GetUserRoleByIdRequest : IRequest<ObjectResponse<UserRoleResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdRequest, ObjectResponse<UserRoleResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserRoleByIdHandler(
            ILogger<GetUserRoleByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<UserRoleResponse>> Handle(GetUserRoleByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<UserRoleResponse> result = new ObjectResponse<UserRoleResponse>();
            try
            {
                var item = await _context.Entity<Midtrans.Payment.Data.Model.UserRole>().Where(d => d.Id == request.Id)
                    .Include(d=>d.IdRoleNavigation)
                    .Include(d=>d.IdUserNavigation).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<UserRoleResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Vleko.Data.Model.UserRole {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail UserRole", request.Id);
                result.Error("Failed Get Detail UserRole", ex.Message);
            }
            return result;
        }
    }
}

