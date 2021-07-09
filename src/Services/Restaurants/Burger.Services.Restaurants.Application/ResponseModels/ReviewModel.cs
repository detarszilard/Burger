namespace Burger.Services.Restaurants.Application.ResponseModels
{
    public class ReviewModel
    {
        public string Description { get; set; }

        public string? PictureUrl { get; set; }

        public int Taste { get; set; }

        public int Texture { get; set; }

        public int VisualPresentation { get; set; }
    }
}
