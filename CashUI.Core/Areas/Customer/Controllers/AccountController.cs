using AutoMapper;
using Cash.Dto.Dtos.AccountDto;
using Cash.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashUI.Core.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IAccountService accountService, IMapper mapper)
        {
            _userService = userService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var accountList = _mapper.Map<List<AccountListDto>>(await _accountService.GetAccountsWithBanksByUserAsync(user.Id));
            return View(accountList);
        }
    }
}
