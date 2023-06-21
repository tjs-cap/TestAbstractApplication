

namespace TestAbstract.Models
{
    public abstract record TestC(int id, string name, string Description, int age) : TestB(id, name, Description);
}
