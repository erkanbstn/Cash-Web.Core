using AutoMapper;
using Cash.Core.Models;
using Cash.Dto.Dtos.UserDto;
using Cash.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashUI.Core.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProfileController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var userInfo = _mapper.Map<UserEditDto>(user);
            return View(userInfo);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            var userInfo = _mapper.Map<User>(userEditDto);
            await _userService.UpdateAsync(userInfo);
            TempData["Success"] = "Your Profile Information Has Been Changed.";
            return View();
        }
    }
}
