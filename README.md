
# 🎬 Movie Library Management System

## Overview
This is a WPF-based application developed using .NET 9.0. It allows users to manage a movie library with features like adding, sorting, borrowing, and returning movies.

## Features
- Add new movies to a library
- Search by title or ID
- Sort by title (Bubble Sort)
- Sort by year (Merge Sort)
- Borrow/Return movies
- xUnit tests with 100% coverage

## Technologies Used
- .NET 9.0 SDK (WPF)
- xUnit for unit testing
- C# with LinkedList, Dictionary, Queue data structures

## Getting Started
```
git clone Movie-Application-APA1
cd Movie-Application-APA1
dotnet restore
dotnet build
dotnet run
dotnet test
```

## Project Structure
- `APA1.csproj`: Main WPF application
- `MOVIE_APPLICATION_APA1.Tests.csproj`: xUnit test project
- `MovieLibrary.cs`: Backend logic
- `MainWindow.xaml`: Frontend UI
- `README.md`, `TestPlan.md`: Documentation

## 🧭 How to Use

When you launch the application (`dotnet run` from the APA1 project), the following features are available in the WPF window:

### 🔎 Searching
- **Search by Title**: Type part of a movie title in the first textbox and click "Search Title" to see all matches.
- **Search by ID**: Enter a movie ID (e.g., M001) in the second textbox and click "Search ID" to find a specific movie.

### ➕ Adding Movies
- Click **"Add Movie"** to insert a new movie with default details.
- New movies get auto-generated IDs like M001, M002, etc.

### 🔄 Sorting
- Use **"Sort by Title"** to alphabetically order the movie list.
- Use **"Sort by Year"** to arrange movies by their release year.

### 📚 Borrowing & Returning
- Select a movie row from the list.
- Click **"Borrow Movie"** to mark it as unavailable.
- Click **"Return Movie"** to make it available again.

## ⚙️ How It Works

- `MovieLibrary.cs` manages the data using:
  - `LinkedList<Movie>` for storing movies
  - `Dictionary<string, Movie>` for fast ID lookup
  - `Queue<string>` to simulate a borrow waitlist
- Sorting is done manually with:
  - Bubble Sort (Title)
  - Merge Sort (Year)
- UI is written in `MainWindow.xaml` using WPF components like `DataGrid`, `TextBox`, and `Button`.
