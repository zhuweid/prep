using System;

namespace prep.utility.searching
{
  public class IsGreaterThan<AttributeType> : IMatchA<AttributeType> where AttributeType : IComparable<AttributeType>
  {
    AttributeType start;

    public IsGreaterThan(AttributeType start)
    {
      this.start = start;
    }

    public bool matches(AttributeType item)
    {
      return item.CompareTo(start) > 0;
    }
  }
}