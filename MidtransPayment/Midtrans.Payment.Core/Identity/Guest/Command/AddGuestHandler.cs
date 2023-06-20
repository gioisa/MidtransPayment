//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Midtrans.Payment.Data;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Helper;
using Midtrans.Payment.Core.Request;

namespace Midtrans.Payment.Core.Guest.Command
{

    #region Request
    public class AddGuestMapping: Profile
    {
        public AddGuestMapping()
        {
            CreateMap<AddGuestRequest, GuestRequest>().ReverseMap();
        }
    }
    public class AddGuestRequest :GuestRequest, IMapRequest<Midtrans.Payment.Data.Model.MstGuest, AddGuestRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddGuestRequest, Midtrans.Payment.Data.Model.MstGuest> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddGuestHandler : IRequestHandler<AddGuestRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddGuestHandler(
            ILogger<AddGuestHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(AddGuestRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Midtrans.Payment.Data.Model.MstGuest>(request);
                
                data.CreateDate = DateTime.Now;
                var add = await _context.AddSave(data);
                if (add.Success)
                    result.OK();
                else
                    result.BadRequest(add.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add Guest", request);
                result.Error("Failed Add Guest", ex.Message);
            }
            return result;
        }
    }
}

