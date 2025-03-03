

using Microsoft.EntityFrameworkCore;

public class InvoeaseDbContext : DbContext
{
    public InvoeaseDbContext(DbContextOptions<InvoeaseDbContext> options) : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Primary Keys
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Client>().HasKey(c => c.Id);
        modelBuilder.Entity<Invoice>().HasKey(i => i.Id);
        modelBuilder.Entity<InvoiceItem>().HasKey(ii => ii.Id);

        modelBuilder.Entity<Invoice>().Property(i => i.TotalExcGST).HasColumnType("decimal(18,4)");
        modelBuilder.Entity<Invoice>().Property(i => i.TotalIncGST).HasColumnType("decimal(18,4)");
        modelBuilder.Entity<InvoiceItem>().Property(i => i.ItemTotal).HasColumnType("decimal(18,4)");
        modelBuilder.Entity<InvoiceItem>().Property(i => i.ItemPrice).HasColumnType("decimal(18,4)");

        //Foreign Keys
        modelBuilder.Entity<User>()
        .HasMany(u => u.Clients)
        .WithOne(c => c.User)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
        .HasMany(u => u.Invoices)
        .WithOne(i => i.User)
        .HasForeignKey(i => i.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Client>()
        .HasMany(c => c.Invoices)
        .WithOne(i => i.Client)
        .HasForeignKey(i => i.ClientId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Invoice>()
        .HasMany(i => i.Items)
        .WithOne(ii => ii.Invoice)
        .HasForeignKey(ii => ii.InvoiceId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Invoice>()
        .Property(i => i.CreatedAt)
        .HasDefaultValueSql("GETDATE()");

        SeedData(modelBuilder);

    }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        //Users
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Name = "Alice Johnson",
            NameOnInvoice = "A. Johnson",
            ABN = "12345678901",
            PhoneNumber = "0412345678",
            Email = "alice.johnson@example.com",
            IsDeleted = false
        },
        new User
        {
            Id = 2,
            Name = "Bob Smith",
            NameOnInvoice = "B. Smith",
            ABN = "98765432109",
            PhoneNumber = "0498765432",
            Email = "bob.smith@example.com",
            IsDeleted = false
        },
        new User
        {
            Id = 3,
            Name = "Charlie Brown",
            NameOnInvoice = "C. Brown",
            ABN = "19283746509",
            PhoneNumber = "0423456789",
            Email = "charlie.brown@example.com",
            IsDeleted = false
        },
        new User
        {
            Id = 4,
            Name = "David Wilson",
            NameOnInvoice = "D. Wilson",
            ABN = "10293847567",
            PhoneNumber = "0434567890",
            Email = "david.wilson@example.com",
            IsDeleted = false
        },
        new User
        {
            Id = 5,
            Name = "Eve White",
            NameOnInvoice = "E. White",
            ABN = "56473829102",
            PhoneNumber = "0445678901",
            Email = "eve.white@example.com",
            IsDeleted = false
        });


        //Clients
        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                Id = 1,
                UserId = 1,
                Name = "Client A",
                AdminEmail = "clientA.admin@example.com",
                PhoneNumber = "0456789012",
                ContactPersonName = "John Doe"
            },
        new Client
        {
            Id = 2,
            UserId = 2,
            Name = "Client B",
            AdminEmail = "clientB.admin@example.com",
            PhoneNumber = "0467890123",
            ContactPersonName = "Jane Smith"
        },
        new Client
        {
            Id = 3,
            UserId = 3,
            Name = "Client C",
            AdminEmail = "clientC.admin@example.com",
            PhoneNumber = "0478901234",
            ContactPersonName = "Alice Green"
        },
        new Client
        {
            Id = 4,
            UserId = 4,
            Name = "Client D",
            AdminEmail = "clientD.admin@example.com",
            PhoneNumber = "0489012345",
            ContactPersonName = "Michael Blue"
        },
        new Client
        {
            Id = 5,
            UserId = 5,
            Name = "Client E",
            AdminEmail = "clientE.admin@example.com",
            PhoneNumber = "0490123456",
            ContactPersonName = "Eve Red"
        }
        );

        //Invoices
        modelBuilder.Entity<Invoice>().HasData(
    new Invoice
    {
        Id = 1,
        ClientId = 1,
        UserId = 1,
        InvoiceNumber = "INV001",
        Description = "Invoice for client A",
        IssueDate = new DateOnly(2023, 1, 1),
        IsScheduled = false,
        DueDate = new DateOnly(2023, 1, 31),
        IsDraft = false,
        Sent = true,
        TotalExcGST = 1000.00m,
        TotalIncGST = 1100.00m,
        IsPaid = false,
        IsRecurring = false,
        CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0)
    },
    new Invoice
    {
        Id = 2,
        ClientId = 2,
        UserId = 2,
        InvoiceNumber = "INV002",
        Description = "Invoice for client B",
        IssueDate = new DateOnly(2023, 1, 1),
        IsScheduled = false,
        DueDate = new DateOnly(2023, 1, 31),
        IsDraft = false,
        Sent = true,
        TotalExcGST = 2000.00m,
        TotalIncGST = 2200.00m,
        IsPaid = false,
        IsRecurring = false,
        CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0)
    },
    new Invoice
    {
        Id = 3,
        ClientId = 3,
        UserId = 3,
        InvoiceNumber = "INV003",
        Description = "Invoice for client C",
        IssueDate = new DateOnly(2023, 1, 1),
        IsScheduled = false,
        DueDate = new DateOnly(2023, 1, 31),
        IsDraft = false,
        Sent = true,
        TotalExcGST = 3000.00m,
        TotalIncGST = 3300.00m,
        IsPaid = false,
        IsRecurring = false,
        CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0)
    },
    new Invoice
    {
        Id = 4,
        ClientId = 4,
        UserId = 4,
        InvoiceNumber = "INV004",
        Description = "Invoice for client D",
        IssueDate = new DateOnly(2023, 1, 1),
        IsScheduled = false,
        DueDate = new DateOnly(2023, 1, 31),
        IsDraft = false,
        Sent = true,
        TotalExcGST = 4000.00m,
        TotalIncGST = 4400.00m,
        IsPaid = false,
        IsRecurring = false,
        CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0)
    },
    new Invoice
    {
        Id = 5,
        ClientId = 5,
        UserId = 5,
        InvoiceNumber = "INV005",
        Description = "Invoice for client E",
        IssueDate = new DateOnly(2023, 1, 1),
        IsScheduled = false,
        DueDate = new DateOnly(2023, 1, 31),
        IsDraft = false,
        Sent = true,
        TotalExcGST = 5000.00m,
        TotalIncGST = 5500.00m,
        IsPaid = false,
        IsRecurring = false,
        CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0)
    }
);

        //InvoiceItems
        modelBuilder.Entity<InvoiceItem>().HasData(
        new InvoiceItem
        {
            Id = 1,
            InvoiceId = 1,
            Description = "Item 1 for Invoice 1",
            ItemPrice = 100.00m,
            Quantity = 1,
            ItemTotal = 100.00m,
        },
        new InvoiceItem
        {
            Id = 2,
            InvoiceId = 2,
            Description = "Item 1 for Invoice 2",
            ItemPrice = 200.00m,
            Quantity = 1,
            ItemTotal = 200.00m,

        },
        new InvoiceItem
        {
            Id = 3,
            InvoiceId = 3,
            Description = "Item 1 for Invoice 3",
            ItemPrice = 300.00m,
            Quantity = 1,
            ItemTotal = 300.00m,
        },
        new InvoiceItem
        {
            Id = 4,
            InvoiceId = 4,
            Description = "Item 1 for Invoice 4",
            ItemPrice = 400.00m,
            Quantity = 1,
            ItemTotal = 400.00m,
        },
        new InvoiceItem
        {
            Id = 5,
            InvoiceId = 5,
            Description = "Item 1 for Invoice 5",
            ItemPrice = 500.00m,
            Quantity = 1,
            ItemTotal = 500.00m,
        }
    );
    }

}