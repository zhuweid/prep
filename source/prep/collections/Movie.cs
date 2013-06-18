using System;
using prep.utility;
using prep.utility.searching;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public PropertyType production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

    public bool Equals(Movie other)
    {
      if (ReferenceEquals(this, other)) return true;

      return (this.title.Equals(other.title));
    }

    public static IMatchA<Movie> is_in_genre(Genre genre)
    {
      return new IsInGenre(genre);
    }

    public static IMatchA<Movie> is_published_by_pixar_or_disney()
    {
      return is_published_by(PropertyType.Pixar)
        .or(is_published_by(PropertyType.Disney));
    }

    public static IMatchA<Movie> is_published_by(PropertyType studio)
    {
      return new IsPublishedBy(studio);
    }
  }
}