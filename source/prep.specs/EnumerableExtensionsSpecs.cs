using System.Collections.Generic;
using Machine.Specifications;
using prep.collections;
using prep.utility;
using prep.utility.searching;

namespace prep.specs
{
    public class EnumerableExtensionsSpecs
    {
        Establish e = () =>
        {
            movie1 = new Movie { title = "prasad" };
            movie2 = new Movie { title = "steve" };
            movies = new List<Movie>
                                                       {
                                                           movie1,
                                                           movie2
                                                       };
        };

        public class when_all_items_are_matching
        {
            private Establish c = () =>
                                      {
                                          match = new AnonymousMatch<Movie>(x => true);
                                      };

            private Because b = () =>
                                result = movies.all_items_matching(match);

            private It should_return_all_matching_movies = () =>
                                                           result.ShouldContain(movie1, movie2);
            
            static IEnumerable<Movie> result; 
        }

        public class when_no_item_is_matching
        {
            private Establish c = () =>
            {
                match = new AnonymousMatch<Movie>(x => false);
            };

            private Because b = () =>
                                result = movies.all_items_matching(match);

            private It should_return_all_matching_movies = () =>
                                                           result.ShouldNotContain(movie1, movie2);

            static IEnumerable<Movie> result;
        }

        static Movie movie1;
        static Movie movie2;
        static List<Movie> movies;
        static IMatchA<Movie> match;
    }
}
