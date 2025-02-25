class InvoiceItem
{
    int Id { get; set; }
    int InvoiceId { get; set; }
    string Description { get; set; }
    decimal ItemPrice { get; set; }
    int Quantity { get; set; }
    bool? Cancelled { get; set; }
    bool? IsMiscellaneous { get; set; }
    decimal ItemTotal { get; set; }
    bool? IsRecurring { get; set; }
    List<DayOfWeek> WorkDays { get; set; }

}

