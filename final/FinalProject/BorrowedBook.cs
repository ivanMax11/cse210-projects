class BorrowedBook : Book {
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int DaysToReturn { get; set; }
    public BookReview Review { get; set; }

    public BorrowedBook(string title, string author, int daysToReturn) : base(title, author) {
        DaysToReturn = daysToReturn;
        BorrowDate = DateTime.Now;
    }

    public override string GetBookType() {
        return "Borrowed Book";
    }

    public void Return(BookReview review = null) {
        ReturnDate = DateTime.Now;
        if (review != null) {
           Review = review; 
        }
    }

    public string GetReturnDateString() {
        return ReturnDate.HasValue ? ReturnDate.Value.ToString() : "not returned yet";
    }
}
