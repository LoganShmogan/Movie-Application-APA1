using Xunit;
using MOVIE_APPLICATION_APA1;

namespace MOVIE_APPLICATION_APA1.Tests
{
    public class MovieLibraryTests
    {
        [Fact]
        public void AddMovie_ShouldAddMovieToCollection()
        {
            var library = new MovieLibrary();
            var movie = new Movie { MovieID = "M001", Title = "Inception" };

            library.AddMovie(movie);

            Assert.True(library.MovieLookup.ContainsKey("M001"));
            Assert.Single(library.MovieCollection);
        }

        [Fact]
        public void SearchByTitle_ShouldFindMovie()
        {
            var library = new MovieLibrary();
            library.AddMovie(new Movie { MovieID = "M001", Title = "Batman Begins" });

            var results = library.SearchByTitle("bat");

            Assert.Single(results);
            Assert.Equal("Batman Begins", results[0].Title);
        }

        [Fact]
        public void SortByTitle_ShouldSortAlphabetically()
        {
            var library = new MovieLibrary();
            library.AddMovie(new Movie { MovieID = "M001", Title = "Zebra" });
            library.AddMovie(new Movie { MovieID = "M002", Title = "Alpha" });

            var sorted = library.SortByTitle();

            Assert.Equal("Alpha", sorted[0].Title);
            Assert.Equal("Zebra", sorted[1].Title);
        }

        [Fact]
        public void SortByYear_ShouldSortChronologically()
        {
            var library = new MovieLibrary();
            library.AddMovie(new Movie { MovieID = "M001", Title = "Old", ReleaseYear = 1990 });
            library.AddMovie(new Movie { MovieID = "M002", Title = "New", ReleaseYear = 2020 });

            var sorted = library.SortByYear();

            Assert.Equal(1990, sorted[0].ReleaseYear);
            Assert.Equal(2020, sorted[1].ReleaseYear);
        }

        [Fact]
        public void DuplicateMovieID_ShouldNotBeAdded()
        {
            var library = new MovieLibrary();
            library.AddMovie(new Movie { MovieID = "M001", Title = "A" });
            library.AddMovie(new Movie { MovieID = "M001", Title = "B" });

            Assert.Single(library.MovieCollection);
        }
    }
}
