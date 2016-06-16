# ComparableLists
.NET list types use reference equality as the default equality check. In certain situations, you may not want that; for example, in a unit test, you may wish to make sure that a list built by the function getting tested contains the same elements as the list which you know should be the correct output. 
Right now, ComparableList confirms that any two lists getting compared contain the same elements in any order; to do that, it sorts both lists first. In the future, I plan to add another type which confirms that the lists contain the same elements in the same sequence; this will make for a slightly faster comparison.

**Fair Warning:** checking for equality will be grotesquely ineffecient on large lists. Use at your own risk.
