using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public void add(Movie movie)
    {
        if (!movies.Contains(movie))
        {
            movies.Add(movie);
        }
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        return GetSatisfyingMovies(m => m.production_studio == ProductionStudio.Pixar);
    }
     
    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        return GetSatisfyingMovies(m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {       
        return GetSatisfyingMovies(m => m.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {       
        return GetSatisfyingMovies(m => m.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {        
        return GetSatisfyingMovies(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        return GetSatisfyingMovies(m => m.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
        return GetSatisfyingMovies(m => m.genre == Genre.action);
    }

    private IEnumerable<Movie> GetSatisfyingMovies(Predicate<Movie> condition)
    {
        foreach (var movie in movies)
        {
            if (movie.Satisfies(condition))
            {
                yield return movie;
            }
        }
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
        private readonly Func<Movie, Movie, int> _comp;

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