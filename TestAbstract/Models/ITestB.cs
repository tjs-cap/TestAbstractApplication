namespace TestAbstract.Models
{
    public interface ITestB
    {
        string Description { get; init; }

        void Deconstruct(out string Description);
        bool Equals(object? obj);
        bool Equals(TestA? other);
        bool Equals(TestB? other);
        int GetHashCode();
        string ToString();
    }
}