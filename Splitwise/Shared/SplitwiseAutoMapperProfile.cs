using AutoMapper;
using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Services;

public class SplitwiseAutoMapperProfile : Profile
{
    public SplitwiseAutoMapperProfile()
    {
        CreateMap<Expense, ExpenseGetDto>().ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(x => x.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(x => x.PaidBy, opt => opt.MapFrom(src => src.PaidBy))
            .ForMember(x => x.OwedBy, opt => opt.MapFrom(src => src.OwedBy));

        CreateMap<ExpensePostDto, Expense>().ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(x => x.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(x => x.PaidBy, opt => opt.MapFrom(src => src.PaidBy))
            .ForMember(x => x.OwedBy, opt => opt.MapFrom(src => src.OwedBy));

        CreateMap<User, UserGetDto>().ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        
        CreateMap<UserPostDto, User>().ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    }
}