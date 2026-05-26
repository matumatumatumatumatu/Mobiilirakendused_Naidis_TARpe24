namespace Naidis_TARpe24;

public partial class ItaaliaK66kPage : ContentPage
{
	public CarouselView carouselView;
	public List<CarouselItem> items;
	private int position = 0;
	public class CarouselItem
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Recipe { get; set; }
		public string Image { get; set; }
	}
	public ItaaliaK66kPage()
	{
		var items = new List<CarouselItem>
		{
			new CarouselItem {Title = "Pasta Carbonara",Description="Klassikaline Rooma pastaroog",Recipe=""},
			new CarouselItem{Title=""}
		};
	}
}