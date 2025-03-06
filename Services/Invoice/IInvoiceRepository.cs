namespace Services
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<InvoiceDTO>> GetAll(int pageNumber, int pageSize);
        Task<InvoiceDTO?> GetById(int id);
        Task Update(InvoiceDTO invoice);
        Task Delete(int id);
        Task<InvoiceDTO> Create(InvoiceDTO invoice);

    }
}
