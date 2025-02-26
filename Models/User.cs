class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? NameOnInvoice { get; set; }
    public string ABN { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    public bool? IsDeleted { get; set; }
}