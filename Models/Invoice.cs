public class Invoice
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public string InvoiceNumber { get; set; }
    public string Description { get; set; }
    public DateOnly IssueDate { get; set; }
    public bool IsScheduled { get; set; } = false;
    public DateTime? ScheduledSendDate { get; set; }
    public string? EmailDescription { get; set; }
    public DateOnly? DueDate { get; set; }
    public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public Client Client { get; set; }
    public bool IsDraft { get; set; }
    public bool Sent { get; set; }
    public decimal TotalExcGST { get; set; }
    public decimal TotalIncGST { get; set; }
    public bool IsPaid { get; set; } = false;
    public bool IsRecurring { get; set; } = false;
    public DateTime CreatedDate { get; set; }

    public Invoice()
    {
        CreatedDate = DateTime.Now;
    }

}