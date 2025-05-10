
# ✅ Test Plan - Movie Library System

## Framework
- **xUnit 2.5.0**
- Test runner: `dotnet test`

## Tests Performed

### 1. `AddMovie_ShouldAddMovieToCollection()`
- Validates adding a new movie to the library
- Asserts the dictionary and linked list both store the entry

### 2. `SearchByTitle_ShouldFindMovie()`
- Tests case-insensitive search for partial matches in movie titles

### 3. `SortByTitle_ShouldSortAlphabetically()`
- Ensures Bubble Sort orders movies by title in A-Z order

### 4. `SortByYear_ShouldSortChronologically()`
- Validates Merge Sort correctly sorts by `ReleaseYear`

### 5. `DuplicateMovieID_ShouldNotBeAdded()`
- Prevents duplicate movie IDs from being added

## Summary
All tests passed:
```
dotnet test
Total tests: 5. Passed: 5. Failed: 0.
```
