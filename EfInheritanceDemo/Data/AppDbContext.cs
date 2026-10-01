using EfInheritanceDemo.Models.TPC;
using EfInheritanceDemo.Models.TPH;
using EfInheritanceDemo.Models.TPT;
using Microsoft.EntityFrameworkCore;

namespace EfInheritanceDemo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TPT
        modelBuilder.Entity<Vehicle>()
            .ToTable("Vehicles");

        modelBuilder.Entity<Car>()
            .ToTable("Cars");

        modelBuilder.Entity<ElectricCar>()
            .ToTable("ElectricCars");

        //TPC
        modelBuilder.Entity<PaymentMethod>()
        .UseTpcMappingStrategy();

        modelBuilder.Entity<CreditCard>()
            .ToTable("CreditCards");

        modelBuilder.Entity<BankTransfer>()
            .ToTable("BankTransfers");
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<Designer> Designers => Set<Designer>();


    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<ElectricCar> ElectricCars => Set<ElectricCar>();

    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

    public DbSet<CreditCard> CreditCards => Set<CreditCard>();

    public DbSet<BankTransfer> BankTransfers => Set<BankTransfer>();

}