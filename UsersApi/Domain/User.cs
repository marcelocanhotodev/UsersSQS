namespace UsersApi.Domain
{
    public record User(string Name, string Document, string Email, string Id = null)
    {
        public string Id { get; set; } = Id ?? Guid.NewGuid().ToString();

        public string Name { get; set; } = Name;

        public string Email { get; set; } = Email;

        public string Document { get; set; } = Document;
    }
}
