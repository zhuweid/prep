using System;

namespace prep.utility.searching
{
  public static class DateMatchCreationExtensions
  {
    public static IMatchA<Target> greater_than<Target>(
      this IProvideAccessToCreatingMatchers<Target, DateTime> extension_point, int year)
    {
      var date_criteria = Match<DateTime>.attribute(x => x.Year).greater_than(year);

      return extension_point.create_matcher(date_criteria);
    }

  }
}
