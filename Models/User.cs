class User
{
    int Id { get; set; }
    string Name { get; set; }
    string? NameOnInvoice { get; set; }
    string ABN { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    List<Invoice> Invoices { get; set; } = new List<Invoice>();
    bool? IsDeleted { get; set; }
}