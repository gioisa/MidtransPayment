using Microsoft.AspNetCore.Mvc;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Notification.Query;
using Midtrans.Payment.Core.Request;
using Midtrans.Payment.Core.Notification.Command;

namespace Midtrans.Payment.API.Controllers
{
    public partial class NotificationController : BaseController<NotificationController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetNotificationByIdRequest() { Id = id }));
        }

        [HttpGet(template: "count/{id_user}/{is_open}")]
        public async Task<IActionResult> GetCount(Guid id_user, bool is_open)
        {
            return Wrapper(await _mediator.Send(new GetNotificationCountRequest
            {
                IdUser = id_user,
                IsOpen = is_open
            }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetNotificationListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] NotificationRequest request)
        {
            var add_request = _mapper.Map<AddNotificationRequest>(request);
            add_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(add_request));
        }

        [HttpPut(template: "open/{id}")]
        public async Task<IActionResult> Open(Guid id)
        {
            return Wrapper(await _mediator.Send(new OpenNotificatioRequest() { Id = id }));
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteNotificationRequest() { Id = id, Inputer = Inputer }));
        }

        [HttpPost(template: "push_notif")]
        public async Task<IActionResult> PushNotif([FromBody] PushNotifMainAppRequest request)
        {
            return Wrapper(await _mediator.Send(request));
        }
    }
}
