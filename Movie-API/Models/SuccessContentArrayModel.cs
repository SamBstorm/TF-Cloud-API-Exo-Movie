namespace Movie_API.Models
{
    public class SuccessContentArrayModel<TContent,T> where TContent : IEnumerable<T> where T : class
    {
        public int Length { get => Result.Count(); }
        public TContent Result { get; set; }
    }
}
