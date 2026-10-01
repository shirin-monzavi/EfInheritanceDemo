namespace EfInheritanceDemo.Models.TPC;

public class CreditCard : PaymentMethod
{
    public string CardNumber { get; set; } = string.Empty;
    public string CardType { get; set; } = string.Empty;
}