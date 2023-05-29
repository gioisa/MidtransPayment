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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Midtrans.Payment.Data;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Helper;
using Midtrans.Payment.Core.Request;

namespace Midtrans.Payment.Core.UserRole.Command
{

    #region Request
    public class EditUserRoleMapping: Profile
    {
        public EditUserRoleMapping()
        {
            CreateMap<EditUserRoleRequest, UserRoleRequest>().ReverseMap();
        }
    }
    public class EditUserRoleRequest :UserRoleRequest, IMapRequest<Midtrans.Payment.Data.Model.UserRole, EditUserRoleRequest>,IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<EditUserRoleRequest, Midtrans.Payment.Data.Model.UserRole> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditUserRoleHandler : IRequestHandler<EditUserRoleRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditUserRoleHandler(
            ILogger<EditUserRoleHandler> logger,
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
        public async Task<StatusResponse> Handle(EditUserRoleRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Midtrans.Payment.Data.Model.UserRole>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (existingItems != null)
                {
                    var before = existingItems;
                    var item = _mapper.Map(request, existingItems);
                    
                    
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);
                    return result;
                }
                else
                    result.NotFound($"Id UserRole {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit UserRole", request);
                result.Error("Failed Edit UserRole", ex.Message);
            }
            return result;
        }
    }
}

