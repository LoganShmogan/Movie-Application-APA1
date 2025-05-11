using System.Collections.Generic;
using System.Linq;

namespace MOVIE_APPLICATION_APA1
{
    public class MovieLibrary
    {
        public LinkedList<Movie> MovieCollection = new();
        public Dictionary<string, Movie> MovieLookup = new();
        public Dictionary<string, Queue<string>> BorrowQueue = new();

        public MovieLibrary(bool skipSeedData = false)
        {
            if (!skipSeedData)
            {
                SeedSampleData();
            }
        }

        private void SeedSampleData()
        {
            AddMovie(new Movie { MovieID = "M001", Title = "Echoes of the Past", Genre = "Drama", ReleaseYear = 2015, Director = "Sarah Whitmore" });
            AddMovie(new Movie { MovieID = "M002", Title = "Quantum Run", Genre = "Sci-Fi", ReleaseYear = 2022, Director = "David Linhart" });
            AddMovie(new Movie { MovieID = "M003", Title = "Love and Lattes", Genre = "Romance", ReleaseYear = 2019, Director = "Mia Rodriguez" });
            AddMovie(new Movie { MovieID = "M004", Title = "The Crimson Hunt", Genre = "Action", ReleaseYear = 2020, Director = "Marcus Flynn" });
            AddMovie(new Movie { MovieID = "M005", Title = "Whispers in the Fog", Genre = "Mystery", ReleaseYear = 2018, Director = "Evelyn Hart" });
            AddMovie(new Movie { MovieID = "M006", Title = "Pixel Panic", Genre = "Animation", ReleaseYear = 2021, Director = "Tomoko Arai" });
            AddMovie(new Movie { MovieID = "M007", Title = "Behind Closed Doors", Genre = "Thriller", ReleaseYear = 2016, Director = "Gregory Shaw" });
            AddMovie(new Movie { MovieID = "M008", Title = "Notes of Freedom", Genre = "Musical", ReleaseYear = 2017, Director = "Isabelle DuPont" });
            AddMovie(new Movie { MovieID = "M009", Title = "Broken Circuit", Genre = "Cyberpunk", ReleaseYear = 2023, Director = "Kenta Nakamura" });
            AddMovie(new Movie { MovieID = "M010", Title = "Wilderness Bound", Genre = "Adventure", ReleaseYear = 2020, Director = "Laura Chen" });
        }

        public void AddMovie(Movie movie)
        {
            if (!MovieLookup.ContainsKey(movie.MovieID))
            {
                MovieCollection.AddLast(movie);
                MovieLookup[movie.MovieID] = movie;
                BorrowQueue[movie.MovieID] = new Queue<string>();
            }
        }

        public Movie? SearchByID(string id) =>
            MovieLookup.TryGetValue(id, out var movie) ? movie : null;

        public List<Movie> SearchByTitle(string title) =>
            MovieCollection.Where(m => m.Title.ToLower().Contains(title.ToLower())).ToList();

        public List<Movie> SortByTitle()
        {
            var list = MovieCollection.ToList();
            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Count - 1; j++)
                    if (string.Compare(list[j].Title, list[j + 1].Title) > 0)
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
            return list;
        }

        public List<Movie> SortByYear() => MergeSort(MovieCollection.ToList());

        private List<Movie> MergeSort(List<Movie> list)
        {
            if (list.Count <= 1) return list;
            int mid = list.Count / 2;
            var left = MergeSort(list.Take(mid).ToList());
            var right = MergeSort(list.Skip(mid).ToList());
            return Merge(left, right);
        }

        private List<Movie> Merge(List<Movie> left, List<Movie> right)
        {
            var result = new List<Movie>();
            while (left.Any() && right.Any())
            {
                if (left[0].ReleaseYear <= right[0].ReleaseYear)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            result.AddRange(left);
            result.AddRange(right);
            return result;
        }

        public MovieLibrary()
        {
            AddMovie(new Movie { MovieID = "M001", Title = "Echoes of the Past", Genre = "Drama", ReleaseYear = 2015, Director = "Sarah Whitmore" });
            AddMovie(new Movie { MovieID = "M002", Title = "Quantum Run", Genre = "Sci-Fi", ReleaseYear = 2022, Director = "David Linhart" });
            AddMovie(new Movie { MovieID = "M003", Title = "Love and Lattes", Genre = "Romance", ReleaseYear = 2019, Director = "Mia Rodriguez" });
            AddMovie(new Movie { MovieID = "M004", Title = "The Crimson Hunt", Genre = "Action", ReleaseYear = 2020, Director = "Marcus Flynn" });
            AddMovie(new Movie { MovieID = "M005", Title = "Whispers in the Fog", Genre = "Mystery", ReleaseYear = 2018, Director = "Evelyn Hart" });
            AddMovie(new Movie { MovieID = "M006", Title = "Pixel Panic", Genre = "Animation", ReleaseYear = 2021, Director = "Tomoko Arai" });
            AddMovie(new Movie { MovieID = "M007", Title = "Behind Closed Doors", Genre = "Thriller", ReleaseYear = 2016, Director = "Gregory Shaw" });
            AddMovie(new Movie { MovieID = "M008", Title = "Notes of Freedom", Genre = "Musical", ReleaseYear = 2017, Director = "Isabelle DuPont" });
            AddMovie(new Movie { MovieID = "M009", Title = "Broken Circuit", Genre = "Cyberpunk", ReleaseYear = 2023, Director = "Kenta Nakamura" });
            AddMovie(new Movie { MovieID = "M010", Title = "Wilderness Bound", Genre = "Adventure", ReleaseYear = 2020, Director = "Laura Chen" });
        }

        public bool BorrowMovie(string movieID, string user)
        {
            if (MovieLookup.TryGetValue(movieID, out var movie))
            {
                if (movie.IsAvailable)
                {
                    movie.IsAvailable = false;
                    return true;
                }
                else
                {
                    BorrowQueue[movieID].Enqueue(user);
                    return false;
                }
            }
            return false;
        }

        public void ReturnMovie(string movieID)
        {
            if (MovieLookup.TryGetValue(movieID, out var movie))
            {
                if (BorrowQueue[movieID].Any())
                {
                    string nextUser = BorrowQueue[movieID].Dequeue();
                }
                else
                {
                    movie.IsAvailable = true;
                }
            }
        }

    }
}
