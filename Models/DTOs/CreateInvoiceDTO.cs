class CreateInvoiceDTO
{
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
    public decimal TotalExcGST { get; set; }
    public decimal TotalIncGST { get; set; }
}