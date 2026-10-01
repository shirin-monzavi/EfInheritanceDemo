namespace EfInheritanceDemo.Models.TPC;

public abstract class PaymentMethod
{
    public int Id { get; set; }
    public string OwnerName { get; set; } = string.Empty;
}
