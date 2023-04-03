class BookReview {
    public int Rating { get; set; }
    public string Comment { get; set; }

    public BookReview(int rating, string comment) {
        Rating = rating;
        Comment = comment;
    }
}