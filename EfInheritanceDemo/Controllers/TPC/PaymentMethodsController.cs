using EfInheritanceDemo.Data;
using EfInheritanceDemo.Models.TPC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PaymentMethodsController : ControllerBase
{
    private readonly AppDbContext _db;

    public PaymentMethodsController(AppDbContext db)
    {
        _db = db;
    }

    // GET: api/paymentmethods
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payments = await _db.PaymentMethods.ToListAsync();

        return Ok(payments);
    }

    // GET: api/paymentmethods/credit-cards
    [HttpGet("credit-cards")]
    public async Task<IActionResult> GetCreditCards()
    {
        var cards = await _db.CreditCards.ToListAsync();

        return Ok(cards);
    }

    // GET: api/paymentmethods/bank-transfers
    [HttpGet("bank-transfers")]
    public async Task<IActionResult> GetBankTransfers()
    {
        var transfers = await _db.BankTransfers.ToListAsync();

        return Ok(transfers);
    }

    // POST: api/paymentmethods/seed
    [HttpPost("seed")]
    public async Task<IActionResult> Seed()
    {
        var payments = new PaymentMethod[]
        {
            new CreditCard
            {
                OwnerName = "Shirin",
                CardNumber = "1234-5678",
                CardType = "Visa"
            },

            new CreditCard
            {
                OwnerName = "Sara",
                CardNumber = "9876-5432",
                CardType = "MasterCard"
            },

            new BankTransfer
            {
                OwnerName = "Ali",
                BankName = "Melli",
                Iban = "IR123456789"
            },

            new BankTransfer
            {
                OwnerName = "Reza",
                BankName = "Tejarat",
                Iban = "IR987654321"
            }
        };

        await _db.PaymentMethods.AddRangeAsync(payments);

        await _db.SaveChangesAsync();

        return Ok(new
        {
            Message = "Payment methods seeded successfully."
        });
    }
}