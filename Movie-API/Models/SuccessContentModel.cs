namespace Movie_API.Models
{
    public class SuccessContentModel<TContent> where TContent : class
    {
        public TContent Result { get; set; }
    }
}
