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
        modelBuilder.Entity<Vehicle>()
            .ToTable("Vehicles");

        modelBuilder.Entity<Car>()
            .ToTable("Cars");

        modelBuilder.Entity<ElectricCar>()
            .ToTable("ElectricCars");
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<Designer> Designers => Set<Designer>();


    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<ElectricCar> ElectricCars => Set<ElectricCar>();
}