# ComparableLists
.NET list types use reference equality as the default equality check. In certain situations, you may not want that; for example, in a unit test, you may wish to make sure that a list built by the function getting tested contains the same elements as the list which you know should be the correct output. 
Right now, ComparableList confirms that any two lists getting compared contain the same elements in any order. There is a derived type called StrictComparableList which checks whether both lists contain the same elements in the same order.

**Fair Warning:** checking for equality will be grotesquely ineffecient on large lists. Use at your own risk.
