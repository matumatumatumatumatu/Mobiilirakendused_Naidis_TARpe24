namespace Naidis_TARpe24;

public partial class TripsTrapsTrullPage : ContentPage
{
	Grid gr3x3;
	Image img;
	int player;
    Switch s_pilt;

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
        gr3x3 = new Grid
        {
            Padding = 10,
            ColumnSpacing = 8,
            RowSpacing = 8,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 350,
            HeightRequest = 350
        };
        for (int i = 0; i < 3; i++)
        {
            gr3x3.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gr3x3.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }
    }
}