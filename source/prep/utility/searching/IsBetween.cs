using System;

namespace prep.utility.searching
{
  public class IsBetween<AttributeType> : IMatchA<AttributeType> where AttributeType : IComparable<AttributeType>
  {
    AttributeType start;
    AttributeType end;

    public IsBetween(AttributeType end, AttributeType start)
    {
      this.end = end;
      this.start = start;
    }

    public bool matches(AttributeType item)
    {
      return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
    }
  }
}