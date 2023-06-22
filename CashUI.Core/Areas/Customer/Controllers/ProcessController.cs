using AutoMapper;
using Cash.Core.Models;
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
        private readonly IAccountService _accountService;
        private readonly IProcessService _processService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProcessController(IUserService userService, IMapper mapper, IProcessService processService, IAccountService accountService)
        {
            _userService = userService;
            _mapper = mapper;
            _processService = processService;
            _accountService = accountService;
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
        public async Task<IActionResult> CreateProcess()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcess(ProcessAddDto processAddDto)
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var account = await _accountService.GetAccountsByNoAsync(processAddDto.ReceiverNo);
            processAddDto.SenderId = user.Id;
            processAddDto.ReceiverId = account.Id;
            var processInfo = _mapper.Map<Process>(processAddDto);
            await _processService.InsertAsync(processInfo);
            return Redirect("~/Customer/Process/MySendProcess");
        }
    }
}
