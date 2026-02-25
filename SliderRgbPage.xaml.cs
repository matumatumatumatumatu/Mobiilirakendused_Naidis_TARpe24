namespace Naidis_TARpe24;

public partial class SliderRgbPage : ContentPage
{
    Label label;
    Label labelR;
    Label labelG;
    Label labelB;
    Stepper stepper;
    Slider slider1;
    Slider slider2;
    Slider slider3;
    AbsoluteLayout al;
    public SliderRgbPage()
	{
        label = new Label
        {
            Text = "...",
            BackgroundColor = Colors.LightGray,
        };
        slider1 = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.LightGray,
            MaximumTrackColor = Colors.DarkGray,
            ThumbColor = Colors.Gray,
            WidthRequest = 300,
        };
        slider2 = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.LightGray,
            MaximumTrackColor = Colors.DarkGray,
            ThumbColor = Colors.Gray,
            WidthRequest = 300,
        };
        slider3 = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Colors.LightGray,
            MaximumTrackColor = Colors.DarkGray,
            ThumbColor = Colors.Gray,
            WidthRequest = 300,
        };
        slider1.ValueChanged += Slider_Color;
        slider2.ValueChanged += Slider_Color;
        slider3.ValueChanged += Slider_Color;
        al = new AbsoluteLayout { Children = { label,labelR, slider1,labelG,slider2,labelB,slider3 } };
        List<View> controls = new List<View> { label,labelR, slider1,labelG,slider2,labelB,slider3 };
        for (int i = 0; i < controls.Count; i++)
        {
            double yKoht = 0.2 + i * 0.2;
            AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, 300, 60));
            AbsoluteLayout.SetLayoutFlags(controls[i], Microsoft.Maui.Layouts.AbsoluteLayoutFlags.PositionProportional);
        }
        Content = al;
    }
    private void Slider_Color(object? sender, ValueChangedEventArgs e)
    {
        double r = Convert.ToInt32(slider1.Value);
        double g = Convert.ToInt32(slider2.Value);
        double b = Convert.ToInt32(slider3.Value);
        label.BackgroundColor = Color.FromRgb(r, g, b);
        labelR.Text = Convert.ToString(r);
        labelG.Text = Convert.ToString(g);
        labelB.Text = Convert.ToString(b);
    }
}