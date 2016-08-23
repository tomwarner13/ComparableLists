using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
  /// <summary>
  /// A list which is equatable to another list based on the equality of it's items, regardless of order. 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class ComparableList<T> : List<T>, IEquatable<ComparableList<T>> where T : IComparable, IEquatable<T>
  {
    public static ComparableList<T> Of(IEnumerable<T> source)
    {
      var list = new ComparableList<T>();
      list.AddRange(source);
      return list;
    }

    public static ComparableList<T> Of(params T[] source)
    {
      return Of(source as IEnumerable<T>);
    }

    public bool Equals(ComparableList<T> other)
    {
      return other?.OrderBy(t => t).SequenceEqual(this.OrderBy(t => t)) ?? false;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as ComparableList<T>);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int hashCode = 0;
        foreach (var item in this)
        {
          hashCode = (hashCode * 397) ^ (item?.GetHashCode() ?? 0);
        }
        return hashCode;
      }
    }

    //
    // Equality Operators
    //

    public static bool operator ==(ComparableList<T> a, ComparableList<T> b) => a?.Equals(b) ?? Object.ReferenceEquals(b, null);
    public static bool operator !=(ComparableList<T> a, ComparableList<T> b) => !(a == b);
  }
}