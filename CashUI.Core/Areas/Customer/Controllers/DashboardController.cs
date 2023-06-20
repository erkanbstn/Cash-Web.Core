using AutoMapper;
using Cash.Core.Models;
using Cash.Dto.Dtos.AccountDto;
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
        public DashboardController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
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
            //var accountList = _mapper.Map<AccountListDto>(await _);
            return View();
        }
    }
}
