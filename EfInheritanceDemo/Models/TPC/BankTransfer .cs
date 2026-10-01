namespace EfInheritanceDemo.Models.TPC;

public class BankTransfer : PaymentMethod
{
    public string BankName { get; set; } = string.Empty;
    public string Iban { get; set; } = string.Empty;
}
