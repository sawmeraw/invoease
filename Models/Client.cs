
public class Client
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public string Name { get; set; }
    public string AdminEmail { get; set; }
    public string PhoneNumber { get; set; }
    public string ContactPersonName { get; set; }


    //Navigation
    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    public User User { get; set; }

}