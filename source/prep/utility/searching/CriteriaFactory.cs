using System;
using System.Collections.Generic;

namespace prep.utility.searching
{
  public class CriteriaFactory<Target, PropertyType>
  {
    PropertyAccessor<Target, PropertyType> accessor;

    public CriteriaFactory(PropertyAccessor<Target, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<Target> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchA<Target> equal_to_any(params PropertyType[] values)
    {
      return new AnonymousMatch<Target>(x =>
      {
        var value = accessor(x);
        var possible_values = new List<PropertyType>(values);
        return possible_values.Contains(value);
      });
    }

    public IMatchA<Target> not_equal_to(PropertyType value)
    {
        return equal_to(value).Not();
    }
  }

    public static class MatchExtn
    {
        public static IMatchA<T> Not<T>(this IMatchA<T> match)
        {
            return new NotMatches<T>(match);
        }
    }


    public class NotMatches<Item> : IMatchA<Item>
    {
        IMatchA<Item> match;

        public NotMatches(IMatchA<Item> match)
    {
        this.match = match;
    }

    public bool matches(Item item)
    {
        return !match.matches(item);
    }
    }

}