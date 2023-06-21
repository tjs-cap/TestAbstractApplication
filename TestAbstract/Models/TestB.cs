
namespace TestAbstract.Models
{
    public abstract record TestB(int id, string name, string Description) : TestA(id, name);
    
}



