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

namespace Midtrans.Payment.Core.SubscriptionPack.Query
{

    public class GetSubscriptionPackByIdRequest : IRequest<ObjectResponse<SubscriptionPackResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetSubscriptionPackByIdHandler : IRequestHandler<GetSubscriptionPackByIdRequest, ObjectResponse<SubscriptionPackResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetSubscriptionPackByIdHandler(
            ILogger<GetSubscriptionPackByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<SubscriptionPackResponse>> Handle(GetSubscriptionPackByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<SubscriptionPackResponse> result = new ObjectResponse<SubscriptionPackResponse>();
            try
            {
                var item = await _context.Entity<Midtrans.Payment.Data.Model.RefSubscriptionPack>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<SubscriptionPackResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Midtrans.Payment.Data.Model.RefSubscriptionPack {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail SubscriptionPack", request.Id);
                result.Error("Failed Get Detail SubscriptionPack", ex.Message);
            }
            return result;
        }
    }
}

