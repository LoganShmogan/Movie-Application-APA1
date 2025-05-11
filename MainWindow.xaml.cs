using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace MOVIE_APPLICATION_APA1
{
    public partial class MainWindow : Window
    {
        private readonly MovieLibrary _library = new();
        private MovieLibrary movieLibrary = new MovieLibrary();


        public MainWindow()
        {
            InitializeComponent();
            RefreshMovieGrid();
        }

        private void RefreshMovieGrid()
        {
            MovieGrid.ItemsSource = null;
            MovieGrid.ItemsSource = new List<Movie>(_library.MovieCollection);
        }

        private void SearchByTitle_Click(object sender, RoutedEventArgs e)
        {
            var results = _library.SearchByTitle(SearchTitleBox.Text);
            MovieGrid.ItemsSource = results;
        }

        private void SearchByID_Click(object sender, RoutedEventArgs e)
        {
            var movie = _library.SearchByID(SearchIDBox.Text);
            MovieGrid.ItemsSource = movie != null ? new List<Movie> { movie } : new();
        }

        private void SortByTitle_Click(object sender, RoutedEventArgs e)
        {
            MovieGrid.ItemsSource = _library.SortByTitle();
        }

        private void SortByYear_Click(object sender, RoutedEventArgs e)
        {
            MovieGrid.ItemsSource = _library.SortByYear();
        }

        private void AddMovie_Click(object sender, RoutedEventArgs e)
        {
            var movie = new Movie
            {
                MovieID = "M" + (_library.MovieCollection.Count + 1).ToString("D3"),
                Title = "New Movie",
                Director = "Unknown",
                Genre = "Drama",
                ReleaseYear = 2024
            };
            _library.AddMovie(movie);
            RefreshMovieGrid();
        }

        private void BorrowMovie_Click(object sender, RoutedEventArgs e)
        {
            if (MovieGrid.SelectedItem is Movie selectedMovie)
            {
                string currentUser = "demoUser"; // Replace with real user input if needed
                bool success = movieLibrary.BorrowMovie(selectedMovie.MovieID, currentUser);
                MessageBox.Show(success ? "Movie borrowed successfully!" : "Movie is already borrowed. You've been added to the queue.");
                RefreshMovieList();
            }
        }

        private void ReturnMovie_Click(object sender, RoutedEventArgs e)
        {
            if (MovieGrid.SelectedItem is Movie selectedMovie)
            {
                movieLibrary.ReturnMovie(selectedMovie.MovieID);
                MessageBox.Show("Movie returned.");
                RefreshMovieList();
            }
        }

        private void RefreshMovieList()
        {
            MovieGrid.ItemsSource = null;
            MovieGrid.ItemsSource = movieLibrary.MovieCollection.ToList();
        }

    }
}
