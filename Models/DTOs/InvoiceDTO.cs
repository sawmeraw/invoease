public class InvoiceDTO
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public string InvoiceNumber { get; set; }
    public string Description { get; set; }
    public DateOnly IssueDate { get; set; }
    public DateOnly? SendinFutureDate { get; set; }
    public string? EmailDescription { get; set; }
    public DateOnly? DueDate { get; set; }
    public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public bool IsDraft { get; set; }
    public bool Sent { get; set; }
    public decimal TotalExcGST { get; set; }
    public decimal TotalIncGST { get; set; }
    public bool? IsPaid { get; set; }
    public bool? IsRecurring { get; set; }
    public DateTime CreatedDate { get; set; }

}

public class InvoiceItemDTO
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public string Description { get; set; }
    public decimal ItemPrice { get; set; }
    public int Quantity { get; set; }
    public bool? Cancelled { get; set; }
    public bool? IsMiscellaneous { get; set; }
    public decimal ItemTotal { get; set; }
    public bool? IsRecurring { get; set; }
    public List<DayOfWeek> WorkDays { get; set; }
    public DateTime CreatedDate { get; set; }

}