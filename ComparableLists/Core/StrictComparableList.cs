using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class StrictComparableList<T> : ComparableList<T> where T : IComparable, IEquatable<T>
    {
        public static new StrictComparableList<T> Of(IEnumerable<T> source)
        {
            var list = new StrictComparableList<T>();
            list.AddRange(source);
            return list;
        }

        public static new StrictComparableList<T> Of(params T[] source)
        {
            return Of(source as IEnumerable<T>);
        }

        public bool Equals(StrictComparableList<T> other)
        {
            return other?.SequenceEqual(this) ?? false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StrictComparableList<T>);
        }

        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(StrictComparableList<T> a, StrictComparableList<T> b) => a?.Equals(b) ?? Object.ReferenceEquals(b, null);
        public static bool operator !=(StrictComparableList<T> a, StrictComparableList<T> b) => !(a == b);
    }
}
