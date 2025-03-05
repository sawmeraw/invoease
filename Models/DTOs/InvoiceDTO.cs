public class InvoiceDTO
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
    public bool IsDraft { get; set; }
    public bool Sent { get; set; }
    public decimal TotalExcGST { get; set; }
    public decimal TotalIncGST { get; set; }
    public bool IsPaid { get; set; } = false;
    public bool IsRecurring { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<InvoiceItemDTO> Items { get; set; } = new List<InvoiceItemDTO>();
    public Client Client { get; set; }
    public User User { get; set; }
}

public class InvoiceItemDTO
{
    public int Id { get; set; } = 0;
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

