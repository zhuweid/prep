using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      var sortedList = new List<Movie>(movies);
      sortedList.Sort(new MovieComparer((m1, m2) => m2.title.CompareTo(m1.title)));
      foreach (var movie in sortedList)
      {
        yield return movie;
      }
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }

  public class MovieComparer : IComparer<Movie>
  {
    readonly Func<Movie, Movie, int> _comp;

    public MovieComparer(Func<Movie, Movie, int> comp)
    {
      _comp = comp;
    }

    public int Compare(Movie x, Movie y)
    {
      return _comp(x, y);
    }
  }
}