using System.Collections.Generic;
using System.Linq;

namespace MOVIE_APPLICATION_APA1
{
    public class MovieLibrary
    {
        public LinkedList<Movie> MovieCollection = new();
        public Dictionary<string, Movie> MovieLookup = new();
        public Dictionary<string, Queue<string>> BorrowQueue = new();

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
    }
}
