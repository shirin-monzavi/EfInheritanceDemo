namespace EfInheritanceDemo.Models.TPH;

public abstract class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }
}