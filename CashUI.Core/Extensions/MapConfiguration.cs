using AutoMapper;
using Cash.Core.Models;
using Cash.Dto.Dtos.AccountDto;
using Cash.Dto.Dtos.ProcessDto;
using Cash.Dto.Dtos.UserDto;

namespace CashUI.Core.Extensions
{
    public class MapConfiguration : Profile
    {
        // Map Configuration

        public MapConfiguration()
        {
            // Mapping Transactions 

            CreateMap<UserListDto, User>().ReverseMap();
            CreateMap<UserEditDto, User>().ReverseMap();

            CreateMap<AccountListDto, Account>().ReverseMap();
            CreateMap<AccountAddDto, Account>().ReverseMap();

            CreateMap<ProcessListDto, Process>().ReverseMap();
            CreateMap<ProcessAddDto, Process>().ReverseMap();
        }
    }
}
