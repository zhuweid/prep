using System;
using System.Collections.Generic;

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
        return FindMovies(m => true);
    }

    public void add(Movie movie)
    {
        if (FindMovie(movie))
            return;

        this.movies.Add(movie);
    }

    private bool FindMovie(Movie movie)
    {
        foreach (var existingMovie in this.movies)
        {
            if (string.Equals(existingMovie.title, movie.title, StringComparison.CurrentCultureIgnoreCase))
                return true;
        }

        return false;
    }
    
    private IEnumerable<Movie> FindMovies(Predicate<Movie> predicate)
    {
        foreach (var movie in this.movies)
        {
            if (predicate(movie))
                yield return movie;
        }
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        return FindMovies(m => m.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        return FindMovies(m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        return FindMovies(m => m.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        return FindMovies(m =>  m.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        return FindMovies(m => m.date_published.Year >= startingYear && m.date_published.Year<= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        return FindMovies(m => m.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
        return FindMovies(m => m.genre == Genre.action);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
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
}