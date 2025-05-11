using Xunit;
using MOVIE_APPLICATION_APA1;

namespace MOVIE_APPLICATION_APA1.Tests
{
    public class MovieLibraryTests
    {
        [Fact]
        public void AddMovie_ShouldAddMovieToCollection()
        {
            var library = new MovieLibrary(skipSeedData: true);

            var movie = new Movie { MovieID = "M001", Title = "Inception" };

            library.AddMovie(movie);

            Assert.True(library.MovieLookup.ContainsKey("M001"));
            Assert.Single(library.MovieCollection);
        }

        [Fact]
        public void SearchByTitle_ShouldFindMovie()
        {
            var library = new MovieLibrary(skipSeedData: true);

            library.AddMovie(new Movie { MovieID = "M001", Title = "Batman Begins" });

            var results = library.SearchByTitle("bat");

            Assert.Single(results);
            Assert.Equal("Batman Begins", results[0].Title);
        }

        [Fact]
        public void SortByTitle_ShouldSortAlphabetically()
        {
            var library = new MovieLibrary(skipSeedData: true);

            library.AddMovie(new Movie { MovieID = "M001", Title = "Zebra" });
            library.AddMovie(new Movie { MovieID = "M002", Title = "Alpha" });

            var sorted = library.SortByTitle();

            Assert.Equal("Alpha", sorted[0].Title);
            Assert.Equal("Zebra", sorted[1].Title);
        }

        [Fact]
        public void SortByYear_ShouldSortChronologically()
        {
            var library = new MovieLibrary(skipSeedData: true);

            library.AddMovie(new Movie { MovieID = "M001", Title = "Old", ReleaseYear = 1990 });
            library.AddMovie(new Movie { MovieID = "M002", Title = "New", ReleaseYear = 2020 });

            var sorted = library.SortByYear();

            Assert.Equal(1990, sorted[0].ReleaseYear);
            Assert.Equal(2020, sorted[1].ReleaseYear);
        }

        [Fact]
        public void DuplicateMovieID_ShouldNotBeAdded()
        {
            var library = new MovieLibrary(skipSeedData: true);

            library.AddMovie(new Movie { MovieID = "M001", Title = "A" });
            library.AddMovie(new Movie { MovieID = "M001", Title = "B" });

            Assert.Single(library.MovieCollection);
        }

        [Fact]
        public void BorrowMovie_WhenAvailable_ShouldSucceedAndMarkUnavailable()
        {
            var library = new MovieLibrary(skipSeedData: true);

            var movie = new Movie { MovieID = "M003", Title = "Borrow Me", IsAvailable = true };
            library.AddMovie(movie);

            bool result = library.BorrowMovie("M003", "user1");

            Assert.True(result);
            Assert.False(movie.IsAvailable);
        }

        [Fact]
        public void BorrowMovie_WhenUnavailable_ShouldQueueUser()
        {
            var library = new MovieLibrary(skipSeedData: true);

            var movie = new Movie { MovieID = "M004", Title = "Taken", IsAvailable = false };
            library.AddMovie(movie);

            bool result = library.BorrowMovie("M004", "user2");

            Assert.False(result);
            Assert.Single(library.BorrowQueue["M004"]);
            Assert.Equal("user2", library.BorrowQueue["M004"].Peek());
        }

        [Fact]
        public void ReturnMovie_WithQueue_ShouldNotSetAvailable()
        {
            var library = new MovieLibrary(skipSeedData: true);

            var movie = new Movie { MovieID = "M005", Title = "Queued", IsAvailable = false };
            library.AddMovie(movie);
            library.BorrowQueue["M005"].Enqueue("user3");

            library.ReturnMovie("M005");

            Assert.False(movie.IsAvailable); // next user still needs to borrow it
            Assert.Empty(library.BorrowQueue["M005"]); // user was dequeued
        }

        [Fact]
        public void ReturnMovie_NoQueue_ShouldSetAvailable()
        {
            var library = new MovieLibrary(skipSeedData: true);

            var movie = new Movie { MovieID = "M006", Title = "Free", IsAvailable = false };
            library.AddMovie(movie);

            library.ReturnMovie("M006");

            Assert.True(movie.IsAvailable);
        }



    }
}
