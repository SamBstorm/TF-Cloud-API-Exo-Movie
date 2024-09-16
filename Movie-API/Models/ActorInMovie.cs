namespace Movie_API.Models
{
    public class ActorInMovie
    {
        public Person Person { get; set; }
        public IEnumerable<string> CharactersName { get; set; }
    }
}
