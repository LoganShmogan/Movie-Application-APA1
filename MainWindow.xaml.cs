using System.Collections.Generic;
using System.Windows;

namespace MOVIE_APPLICATION_APA1
{
    public partial class MainWindow : Window
    {
        private readonly MovieLibrary _library = new();

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
            if (MovieGrid.SelectedItem is Movie selected && selected.IsAvailable)
            {
                selected.IsAvailable = false;
                RefreshMovieGrid();
            }
        }

        private void ReturnMovie_Click(object sender, RoutedEventArgs e)
        {
            if (MovieGrid.SelectedItem is Movie selected && !selected.IsAvailable)
            {
                selected.IsAvailable = true;
                RefreshMovieGrid();
            }
        }
    }
}
