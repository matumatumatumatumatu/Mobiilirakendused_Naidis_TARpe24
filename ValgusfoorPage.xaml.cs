

namespace Naidis_TARpe24;

public partial class ValgusfoorPage : ContentPage
{
    BoxView boxView1;
	BoxView boxView2;
	BoxView boxView3;
    Button sisse;
    Button valja;
    VerticalStackLayout vsl;
    Label label;
    bool bool1 = false;
    public ValgusfoorPage()
	{
        label = new Label
        {

        };
        boxView1 = new BoxView
        {
            Color = Color.FromRgb(128, 128, 128),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 200,
            
        };
        boxView2 = new BoxView
        {
            Color = Color.FromRgb(128, 128, 128),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 200,
        };
        boxView3 = new BoxView
        {
            Color = Color.FromRgb(128, 128, 128),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 200,
        };





        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { boxView1,boxView2,boxView3,sisse,valja },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;

        sisse = new Button
        {
            Text = "Sisse",
            FontSize = 28,
            FontFamily = "Luffio",
            TextColor = Colors.Chocolate,
            BackgroundColor = Colors.Beige,
            CornerRadius = 10,
            HeightRequest = 50,
        };
        valja = new Button
        {
            Text="Välja",
            FontSize = 28,
            FontFamily = "Luffio",
            TextColor = Colors.Chocolate,
            BackgroundColor = Colors.Beige,
            CornerRadius = 10,
            HeightRequest = 50,
        };
        sisse.Clicked += Sisse;
        

        
    }
    private void Sisse(object? sender, EventArgs e)
    {
        bool1 = true;
        boxView1.Color = Color.FromRgb(255, 0, 0);
        boxView2.Color = Color.FromRgb(255, 255, 0);
        boxView3.Color = Color.FromRgb(0, 255,0);
    }
}