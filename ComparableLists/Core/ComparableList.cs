using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	//fair warning: this comparison is probably grotesquely inefficient, and will sort both lists for you so if you don't want that, sucks to suck
	public class ComparableList<T> : List<T> where T : IComparable
	{
		public static ComparableList<T> Of(IEnumerable<T> source)
		{
			var list = new ComparableList<T>();

			foreach (var item in source)
			{
				list.Add(item);
			}

			return list;
		}

		public static ComparableList<T> Of(params T[] source)
		{
			return Of(source as IEnumerable<T>);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			List<T> other = obj as List<T>;
			if (other == null)
			{
				return false;
			}

			other.Sort();
			Sort();

			int i = 0;
			foreach (var item in this)
			{
				if (Comparer<T>.Default.Compare(item, other[i]) == 0)
				{
					return false;
				}
				i++;
			}

			return true;
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
	}
}