using AutoMapper;
using Cash.Dto.Dtos.ProcessDto;
using Cash.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashUI.Core.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ProcessController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IProcessService _processService;

        public ProcessController(IUserService userService, IMapper mapper, IProcessService processService)
        {
            _userService = userService;
            _mapper = mapper;
            _processService = processService;
        }

        public async Task<IActionResult> MySendProcess()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var processList = _mapper.Map<List<ProcessListDto>>(await _processService.GetListWithAccountBySenderAsync(user.Id));
            return View(processList);
        }
        public async Task<IActionResult> MyReceiveProcess()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var processList = _mapper.Map<List<ProcessListDto>>(await _processService.GetListWithAccountByReceiverAsync(user.Id));
            return View(processList);
        }
    }
}
