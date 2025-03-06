
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services;

class InvoiceRespository : IInvoiceRepository
{
    private readonly InvoeaseDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<InvoiceRespository> _logger;

    public InvoiceRespository(InvoeaseDbContext context, IMapper mapper, ILogger<InvoiceRespository> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<InvoiceDTO> Create(InvoiceDTO invoiceDTO)
    {
        try
        {
            invoiceDTO.Items ??= new List<InvoiceItemDTO>();

            if (invoiceDTO.Items.Count == 0 && !invoiceDTO.IsDraft)
            {
                throw new ArgumentException("Invoice that isn't set a draft must contain at least one item");
            }
            var newInvoice = _mapper.Map<Invoice>(invoiceDTO);

            foreach (var itemDTO in invoiceDTO.Items)
            {
                if (itemDTO.Id == 0)
                {
                    var newItem = _mapper.Map<InvoiceItem>(itemDTO);
                    newInvoice.Items.Add(newItem);
                    await _context.InvoiceItems.AddAsync(newItem);
                }
                else
                {
                    var existingItem = await _context.InvoiceItems.FindAsync(itemDTO.Id);
                    if (existingItem != null)
                    {
                        newInvoice.Items.Add(existingItem);
                    }
                }
            }
            await _context.Invoices.AddAsync(newInvoice);
            await _context.SaveChangesAsync();
            var outgoingDTO = _mapper.Map<InvoiceDTO>(newInvoice);
            return outgoingDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating an invoice.");
            throw;
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                throw new KeyNotFoundException($"Invoice with id {id} not found.");
            }
            else
            {
                invoice.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting invoice.");
        }
    }

    public async Task<IEnumerable<InvoiceDTO>> GetAll(int pageNumber, int pageSize)
    {
        try
        {
            if (pageNumber == 0 || pageSize == 0)
            {
                throw new ArgumentException("Pagesize filter error.");
            }

            var invoices = await _context.Invoices.Include(i => i.Client).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var outgoingDTO = _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
            return outgoingDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching invoices.");
            throw;
        }
    }

    public async Task<InvoiceDTO?> GetById(int id)
    {
        try
        {
            if (id == 0)
            {
                throw new ArgumentException("Id cannot be null or 0");
            }
            else
            {
                var invoice = await _context.Invoices.FindAsync(id);
                if (invoice == null)
                {
                    throw new KeyNotFoundException($"Invoice with {id} not found.");
                }
                var outgoingDTO = _mapper.Map<InvoiceDTO>(invoice);
                return outgoingDTO;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error fetching invoice with id {id}");
            throw;
        }

    }

    public async Task Update(InvoiceDTO invoiceDTO)
    {
        try
        {
            var existingInvoice = await _context.Invoices.Include(i => i.Items).FirstOrDefaultAsync(i => i.Id == invoiceDTO.Id);
            if (existingInvoice == null)
            {
                throw new KeyNotFoundException($"Invoice with id {invoiceDTO.Id} not found in the database.");
            }
            _mapper.Map(invoiceDTO, existingInvoice);

            foreach (var itemDTO in invoiceDTO.Items)
            {
                if (itemDTO.Id == 0)
                {
                    var newItem = _mapper.Map<InvoiceItem>(itemDTO);
                    existingInvoice.Items.Add(newItem);
                    await _context.InvoiceItems.AddAsync(newItem);
                }
                else
                {
                    var existingItem = existingInvoice.Items.FirstOrDefault(ii => ii.Id == itemDTO.Id);
                    if (existingItem != null)
                    {
                        _mapper.Map(itemDTO, existingItem);
                    }
                    else
                    {
                        var newItem = _mapper.Map<InvoiceItem>(itemDTO);
                        existingInvoice.Items.Add(newItem);
                        await _context.InvoiceItems.AddAsync(newItem);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the invoice with id {invoiceDTO.Id}");
            throw;
        }
    }
}