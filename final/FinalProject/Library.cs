class Library {
    private List<BorrowedBook> BorrowedBooks = new List<BorrowedBook>();
    private string UserName;
    private int UserID;
    private Dictionary<string, List<int>> Ratings = new Dictionary<string, List<int>>();

    public Library(string name, int id) {
        UserName = name;
        UserID = id;
    }

    public void Borrow(string title, string author) {
        BorrowedBook book = new BorrowedBook(title, author, 14);
        BorrowedBooks.Add(book);
    }

    public void Return(string title) {
        BorrowedBook book = BorrowedBooks.FirstOrDefault(b => b.Title == title && b.ReturnDate == null);
        if (book == null) {
            Console.WriteLine($"The book '{title}' is either not borrowed or has already been returned.");
        } else {
            book.Return();
            Console.WriteLine($"You have returned the book '{title}'.");
            Console.Write("Enter a rating for the book (1-5): ");
            int rating;
            if (int.TryParse(Console.ReadLine(), out rating)) {
                if (rating >= 1 && rating <= 5) {
                    if (!Ratings.ContainsKey(title)) {
                        Ratings.Add(title, new List<int>());
                    }
                    Ratings[title].Add(rating);
                    Console.WriteLine($"You have rated '{title}' {rating} stars.");
                } else {
                    Console.WriteLine("Invalid rating. Rating must be a number between 1 and 5.");
                }
            } else {
                Console.WriteLine("Invalid rating. Rating must be a number between 1 and 5.");
            }
        }
    }

    public void ShowHistory() {
        Console.WriteLine($"Borrowing history for {UserName} (ID: {UserID}):");

        // If no books have been borrowed yet, display a message and return
        if (this.BorrowedBooks.Count == 0) {
            Console.WriteLine("No books have been borrowed yet.");
            return;
        }

        // Display the history for each borrowed book
        foreach (BorrowedBook book in this.BorrowedBooks) {
            string returnDateString = book.GetReturnDateString();
            Console.WriteLine("{0}: {1} by {2} - Borrowed on: {3} - Return date: {4}", book.GetBookType(), book.Title, book.Author, book.BorrowDate.ToString(), returnDateString);
        }
    }

    public void ShowRatings() {
        Console.WriteLine($"Ratings for {UserName} (ID: {UserID}):");

        // If no books have been rated yet, display a message and return
        if (this.Ratings.Count == 0) {
            Console.WriteLine("No books have been rated yet.");
            return;
        }

        // Display the ratings for each book
        foreach (KeyValuePair<string, List<int>> rating in this.Ratings) {
            double averageRating = rating.Value.Average();
            Console.WriteLine("{0} ({1} ratings) - Average rating: {2}", rating.Key, rating.Value.Count, averageRating.ToString("0.00"));
        }
    }

 
}


