public class InvoiceItem
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
    public List<DayOfWeek> WorkDays { get; set; } = new List<DayOfWeek>();
    public DateTime CreatedDate { get; set; }

    public InvoiceItem()
    {
        CreatedDate = DateTime.Now;
    }

}

