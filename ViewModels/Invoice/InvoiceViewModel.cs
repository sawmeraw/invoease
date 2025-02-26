using System.ComponentModel.DataAnnotations;

public class InvoiceViewModel
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }
    [Display(Name = "Invoice Number")]
    public string InvoiceNumber { get; set; }
    public string Description { get; set; }
    [Display(Name = "Issue Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly IssueDate { get; set; }
    [Display(Name = "Send in Future Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public bool IsScheduled { get; set; }
    public DateTime? ScheduledSendDate { get; set; }
    public string EmailDescription { get; set; }
    [Display(Name = "Due Date")]
    public DateOnly? DueDate { get; set; }
    public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();

    public bool IsDraft { get; set; }
    [Display(Name = "Sent to Client")]
    public bool Sent { get; set; }
    [Display(Name = "Total (exc. GST)")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    public decimal TotalExcGST { get; set; }
    [Display(Name = "Total (inc. GST)")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    public decimal TotalIncGST { get; set; }
    public bool IsPaid { get; set; }
    [Display(Name = "Recurring")]
    public bool IsRecurring { get; set; }
    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; }

    public string StatusDisplay
    {
        get
        {
            if (IsPaid) return "Paid";
            if (IsDraft) return "Draft";
            if (Sent) return "Sent";
            return "Pending";
        }
    }

    public string StatusColor
    {
        get
        {
            if (IsPaid) return "bg-green-100 text-green-800";
            if (IsDraft) return "bg-gray-100 text-gray-800";
            if (Sent) return "bg-blue-100 text-blue-800";
            return "bg-yellow-100 text-yellow-100";
        }
    }
    public bool IsOverDue => !IsPaid && DueDate < DateOnly.FromDateTime(DateTime.Now);

}

public class InvoiceItemViewModel
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public string Description { get; set; }
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal ItemPrice { get; set; }
    public int Quantity { get; set; }
    public bool Cancelled { get; set; }
    public bool IsMiscellaneous { get; set; }
    [Display(Name = "Total")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal ItemTotal { get; set; }
    [Display(Name = "Recurring")]
    public bool IsRecurring { get; set; }
    public List<DayOfWeek> WorkDays { get; set; } = new List<DayOfWeek>();
    public DateTime CreatedDate { get; set; }

    public string WorkDaysFormatted => string.Join(", ", WorkDays);

}