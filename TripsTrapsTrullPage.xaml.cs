namespace Naidis_TARpe24;

public partial class TripsTrapsTrullPage : ContentPage
{
	Grid gr3x3;
	Image Ofire;
    Image Xfire;
	int player;
    Switch s_pilt;
    VerticalStackLayout vsl;

	public TripsTrapsTrullPage()
	{
        Ofire = new Image
        {
            Source = "Ofire.jpg",
            HorizontalOptions = LayoutOptions.Center
        };
        Xfire = new Image
        {
            Source = "Xfire.jpg",
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
        Button alusta = new Button
        {
            Text="Alusta mäng"
        };
        alusta.Clicked += Alusta_Clicked;


        Content = vsl;

        Content = new VerticalStackLayout
        {
            Children = {alusta, gr3x3}
        };



        
    }

    private void Alusta_Clicked(object? sender, EventArgs e)
    {
        int Moves;
        gr3x3.Children.Clear();
        Moves = 0;
    }
}