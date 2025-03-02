using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Invoice, InvoiceViewModel>();
        CreateMap<InvoiceItem, InvoiceItemViewModel>();
        CreateMap<Invoice, InvoiceList>().ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name));
    }
}