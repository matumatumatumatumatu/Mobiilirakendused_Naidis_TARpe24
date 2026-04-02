namespace Naidis_TARpe24;

public partial class TripsTrapsTrullPage : ContentPage
{
	Grid gr3x3;
	Image img;
	int player;
	public TripsTrapsTrullPage()
	{
        img = new Image
        {
            Source = "dotnet_bot.png",
            HorizontalOptions = LayoutOptions.Center
        };
        s_pilt = new Switch
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            IsToggled = true,
            IsEnabled = true
        };
    }
}