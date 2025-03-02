public class InvoiceListViewModel
{
    public List<InvoiceList> invoices = new List<InvoiceList>();
}
public class InvoiceList
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public string InvoiceNumber { get; set; }
    public DateOnly IssueDate { get; set; }
    public bool IsScheduled { get; set; } = false;
    public DateTime? ScheduledSendDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool IsDraft { get; set; }
    public bool Sent { get; set; }
    public decimal TotalIncGST { get; set; }
    public bool IsPaid { get; set; } = false;
    public bool IsRecurring { get; set; } = false;
    public DateTime CreatedDate { get; set; }

}