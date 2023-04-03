class ReturnedBook : Book {
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int DaysLate { get; set; }
    public int Rating { get; set; }

    public ReturnedBook(string title, string author, DateTime borrowDate, DateTime returnDate, int daysLate) : base(title, author) {
        BorrowDate = borrowDate;
        ReturnDate = returnDate;
        DaysLate = daysLate;
    }

    public override string GetBookType() {
        return "Returned Book";
    }

    public void RateBook(int rating) {
        if (rating < 1 || rating > 5) {
            Console.WriteLine("Invalid rating. Please enter a number between 1 and 10.");
        } else {
            Rating = rating;
            Console.WriteLine($"You have rated '{Title}' by '{Author}' {Rating} stars.");
        }
    }

    public string GetReturnDateString() {
        return ReturnDate.ToString();
    }

    public string GetBorrowDateString() {
        return BorrowDate.ToString();
    }
}