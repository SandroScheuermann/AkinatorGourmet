using System.Diagnostics.CodeAnalysis;

namespace AkinatorGourmet
{
    public class Aspect : IEqualityComparer<Aspect>
    {
        public required string Name { get; set; }

        public bool Is { get; set; } 

        public bool Equals(Aspect? x, Aspect? y)
        {
            return x?.GetHashCode() == y?.GetHashCode();
        }

        public int GetHashCode(Aspect obj)
        {
            return Name.GetHashCode() + Is.GetHashCode();
        }
    }
}
