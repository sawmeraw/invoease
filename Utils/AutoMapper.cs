using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Invoice, InvoiceViewModel>();
        CreateMap<InvoiceItem, InvoiceItemViewModel>();
    }
}