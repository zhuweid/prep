using prep.utility;
using prep.utility.searching;

namespace prep.collections
{
  public class IsPublishedBy : IMatchA<Movie>
  {
    PropertyType studio;

    public IsPublishedBy(PropertyType studio)
    {
      this.studio = studio;
    }

    public bool matches(Movie movie)
    {
      return movie.production_studio == studio;
    } 
  }
}