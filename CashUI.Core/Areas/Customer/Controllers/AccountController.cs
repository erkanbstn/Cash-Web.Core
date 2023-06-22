using AutoMapper;
using Cash.Core.Models;
using Cash.Dto.Dtos.AccountDto;
using Cash.Dto.Dtos.ProcessDto;
using Cash.Repository.DataAccess;
using Cash.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CashUI.Core.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IBankService _bankService;
        private readonly IProcessService _processService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService, IAccountService accountService, IMapper mapper, IBankService bankService, IProcessService processService)
        {
            _userService = userService;
            _accountService = accountService;
            _mapper = mapper;
            _bankService = bankService;
            _processService = processService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            var accountList = _mapper.Map<List<AccountListDto>>(await _accountService.GetAccountsWithBanksByUserAsync(user.Id));
            return View(accountList);
        }
        public async Task<IActionResult> NewAccount()
        {
            ViewBag.Banks = (from x in await _bankService.ToListAsync() select new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewAccount(AccountAddDto accountAddDto)
        {
            var user = await _userService.FindByUserNameAsync(User.Identity.Name);
            accountAddDto.UserId = user.Id;
            var accountInfo = _mapper.Map<Account>(accountAddDto);
            await _accountService.InsertAsync(accountInfo);
            return Redirect(nameof(Index));
        }
        public async Task<IActionResult> MyAccountTransactionDetail(int id)
        {
            var processInfo = _mapper.Map<List<ProcessListDto>>(await _processService.GetListWithAccountAsync(id));
            return View(processInfo);
        }
    }
}
