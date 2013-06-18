using System;
using prep.utility;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
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
      return is_published_by(ProductionStudio.Pixar)
        .or(is_published_by(ProductionStudio.Disney));
    }

    public static IMatchA<Movie> is_published_by(ProductionStudio studio)
    {
      return new IsPublishedBy(studio);
    }
  }
}