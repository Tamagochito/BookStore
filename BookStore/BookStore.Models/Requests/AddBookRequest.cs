namespace BookStore.Models.Requests
{
    public class AddBookRequest
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Writers { get; set; }
    }
}
