using AutoMapper;
using Cash.Core.Models;
using Cash.Dto.Dtos.AccountDto;
using Cash.Dto.Dtos.ProcessDto;
using Cash.Dto.Dtos.UserDto;
using Cash.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CashUI.Core.Areas.Admin.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IProcessService _processService;
        public DashboardController(IMapper mapper, IUserService userService, IAccountService accountService, IProcessService processService)
        {
            _mapper = mapper;
            _userService = userService;
            _accountService = accountService;
            _processService = processService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var userInfo = _mapper.Map<UserEditDto>(user);
            return View(userInfo);
        }
        [HttpPost]
        public async Task<IActionResult> MyProfile(UserEditDto userEditDto)
        {
            var userInfo = _mapper.Map<User>(userEditDto);
            await _userService.UpdateAsync(userInfo);
            TempData["Success"] = "Your Profile Information Has Been Changed.";
            return View();
        }
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var accountList = _mapper.Map<List<AccountListDto>>(await _accountService.ToListByFilterAsync(x => x.UserId == user.Id));
            return View(accountList);
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
