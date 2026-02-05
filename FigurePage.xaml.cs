namespace Naidis_TARpe24;

public partial class FigurePage : ContentPage
{
	BoxView bw;
	Random rnd = new Random();
	HorizontalStackLayout hsl;
	List<string> buttons = new List<string> { "Tagasi", "Avaleht", "Edasi" };

	public FigurePage(int k)
	{
		int r = rnd.Next(0, 255);
		int g = rnd.Next(0, 255);
		int b = rnd.Next(0, 255);
		bw = new BoxView
		{
			Color = Color.FromRgb(r,g,b,),
			CornerRadius = 20,
			WidthRequest = 200,
			HeightRequest = 200,
			HorizontalOptions=LayoutOptions.Center,
			VerticalOptions=LayoutOptions.Center,
			BackgroundColor=Color.FromRgba(0,0,0,0)
		};
		TapGestureRecognizer tap = new TapGestureRecognizer();
		tap.Tapped += Kliki_boksi_peal;
		bw.GestureRecognizers.Add(tap);
		hsl = new HorizontalStackLayout { };
		for (int i = 0; i < 3; i++)
		{
			Button nupp = new Button
			{
				Text = buttons[i],
				ZIndex = i,
				WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 8.3,
			};
			hsl.Add(nupp);
			nupp.Clicked += Liikumine;
		}
		VerticalStackLayout vsl = new VerticalStackLayout
	}
}