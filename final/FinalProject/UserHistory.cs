class UserHistory {
    private string FilePath;
    private List<string> History = new List<string>();

    public UserHistory(int userID) {
        FilePath = $"user{userID}_history.txt";

        if (File.Exists(FilePath)) {
            // Load existing history from file
            using (StreamReader reader = new StreamReader(FilePath)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    History.Add(line);
                }
            }
        }
    }

    public void Add(string bookTitle, string bookAuthor, string action) {
        string entry = $"{bookTitle},{bookAuthor},{action}";
        History.Add(entry);

        // Write new entry to file
        using (StreamWriter writer = new StreamWriter(FilePath, true)) {
            writer.WriteLine(entry);
        }
    }

    public void Show() {
        if (History.Count == 0) {
            Console.WriteLine("No borrowing history found.");
        } else {
            Console.WriteLine("Borrowing history:");
            foreach (string entry in History) {
                Console.WriteLine(entry);
            }
        }
    }
}