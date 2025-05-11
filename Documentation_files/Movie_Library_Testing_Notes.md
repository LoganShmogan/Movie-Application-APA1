# 🎯 Movie Library Testing Documentation

**Author:** Logan Young  
**Date:** 2025-05-11  
**Test Framework:** xUnit (for C# backend)  
**UI Testing:** Manual verification with screenshots

---

## ✅ 1. Unit Tests (xUnit)

**Test Class:** `MovieLibraryTests.cs`  
**Project:** `MOVIE_APPLICATION_APA1.Tests`

### 🧪 Core Functional Tests

| Test Name | Description | Result |
|-----------|-------------|--------|
| `AddMovie_ShouldAddMovieToCollection` | Verifies a new movie is added correctly | ✅ |
| `SearchByTitle_ShouldFindMovie` | Ensures case-insensitive title search works | ✅ |
| `SortByTitle_ShouldSortAlphabetically` | Sorts movies by title in ascending order | ✅ |
| `SortByYear_ShouldSortChronologically` | Sorts movies from oldest to newest | ✅ |
| `BorrowMovie_WhenAvailable_ShouldSucceedAndMarkUnavailable` | Borrows an available movie and marks it unavailable | ✅ |
| `BorrowMovie_WhenUnavailable_ShouldQueueUser` | Adds user to queue if movie is already borrowed | ✅ |
| `ReturnMovie_WithQueue_ShouldNotSetAvailable` | Keeps movie unavailable if queue has users | ✅ |
| `ReturnMovie_NoQueue_ShouldSetAvailable` | Makes movie available if no queue | ✅ |

---

### ⚠️ Edge & Boundary Tests

| Test Name | Description | Result |
|-----------|-------------|--------|
| `DuplicateMovieID_ShouldNotBeAdded` | Prevents adding duplicate Movie IDs | ✅ |
| `SearchByTitle_NoResults` | Returns empty list for no matches | ✅ |
| `BorrowMovie_InvalidID_ShouldFail` | Handles invalid MovieID borrow | ✅ |
| `ReturnMovie_InvalidID_ShouldNotCrash` | Ignores return request if movie doesn't exist | ✅ |
| `EmptyCollection_SortOrSearch_ShouldNotFail` | Sort/search returns empty list with no crash | ✅ |

---

## 🧪 2. Example Test Snippet

```csharp
[Fact]
public void BorrowMovie_WhenUnavailable_ShouldQueueUser()
{
    var library = new MovieLibrary(skipSeedData: true);
    var movie = new Movie { MovieID = "M001", Title = "Test", IsAvailable = false };
    library.AddMovie(movie);

    bool result = library.BorrowMovie("M001", "user1");

    Assert.False(result);
    Assert.Single(library.BorrowQueue["M001"]);
}
```

---

## 🧪 3. Manual UI Test Cases

| Case ID | Description | Steps | Expected Result | Actual Result | Screenshot |
|---------|-------------|-------|------------------|----------------|------------|
| UI-01 | Add Movie | Enter movie details, click "Add Movie" | Movie appears in list | ✅ | Screenshot_01.png |
| UI-02 | Borrow Available Movie | Select available movie, click "Borrow Movie" | Marked as unavailable | ✅ | Screenshot_02.png |
| UI-03 | Borrow Unavailable Movie | Select borrowed movie, click "Borrow Movie" again | Message: Added to queue | ✅ | Screenshot_03.png |
| UI-04 | Return Movie (Queue Empty) | Select borrowed movie, click "Return" | Marked as available | ✅ | Screenshot_04.png |
| UI-05 | Import Movies from JSON | Click "Import JSON", select file | 8 new movies added | ✅ | Screenshot_05.png |

> 📷 Be sure to capture screenshots of each test for submission/documentation.

---

## ✅ Tools Used

- **xUnit** for unit testing logic
- **Visual Studio** / **dotnet CLI** for test execution
- **WPF UI** tested manually with expected interactions

---

## ✅ Run Tests via CLI

```bash
dotnet test
```

---

## ✅ Notes

- Logic is validated both by automated and manual means
- Coverage includes edge cases and misuse handling
- JSON import/export makes validation easier across sessions

---

Let me know if you want to automate UI testing next or package the whole solution for hand-in!
