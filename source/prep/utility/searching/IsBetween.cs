using System;

namespace prep.utility.searching
{
  public class IsBetween<AttributeType> : IMatchA<AttributeType> where AttributeType : IComparable<AttributeType>
  {
    AttributeType start;
    AttributeType end;

    public IsBetween(AttributeType start, AttributeType end)
    {
      this.start = start;
      this.end = end;
    }

    public bool matches(AttributeType item)
    {
      return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
    }
  }
}