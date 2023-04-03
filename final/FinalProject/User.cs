class User {
    public string Name { get; set; }
    public int ID { get; set; }
    public List<BorrowedBook> Books { get; set; }

    public User(string name, int id) {
        Name = name;
        ID = id;
        Books = new List<BorrowedBook>();
    }
}