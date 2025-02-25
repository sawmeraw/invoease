public class Invoice
{
    int Id { get; set; }
    int ClientId { get; set; }
    int UserId { get; set; }
    string InvoiceNumber { get; set; }
    string Description { get; set; }
    DateOnly IssueDate { get; set; }
    DateOnly? SendinFutureDate { get; set; }
    string? EmailDescription { get; set; }
    DateOnly? DueDate { get; set; }
    List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    bool IsDraft { get; set; }
    bool Sent { get; set; }
    decimal TotalExcGST { get; set; }
    decimal TotalIncGST { get; set; }
    bool? IsPaid { get; set; }
    bool? IsRecurring { get; set; }

}