using System.Collections.Generic;

namespace prep.utility.searching
{
  public class IsEqualToAny<T> : IMatchA<T>
  {
    IList<T> possible_values;

    public IsEqualToAny(params  T[] possible_values)
    {
      this.possible_values = new List<T>(possible_values);
    }

    public bool matches(T item)
    {
      return possible_values.Contains(item);
    }
  }
}