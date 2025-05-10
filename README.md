
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
```bash
git clone [your repo]
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
