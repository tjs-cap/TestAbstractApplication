namespace TestAbstract.Models
{
    public record TestD(int id, string name, string Description, int age, string? workingIT) : TestC(id, name, Description, age);
}