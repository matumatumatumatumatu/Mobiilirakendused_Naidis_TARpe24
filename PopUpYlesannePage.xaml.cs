using System.Diagnostics.Metrics;

namespace Naidis_TARpe24;

public partial class PopUpYlesannePage : ContentPage
{
	Button eksamButton;
    Random rnd1;
    Random rnd2;
    Random rnd3;
    VerticalStackLayout vsl;

    public PopUpYlesannePage()
	{
        rnd1 = new Random();
        rnd2 = new Random();
        rnd3 = new Random();
        Button eksamButton = new Button
		{
			Text = "Alusta eksamit",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center,
			WidthRequest = 200,
			HeightRequest = 150,
            BackgroundColor = Colors.Green
            
        };

        eksamButton.Clicked += EksamButton_Clicked;





        Content = vsl;
        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(0, 50, 0, 0),
            Children = { eksamButton }
        };
    }
    private async void EksamButton_Clicked(object? sender, EventArgs e)
    {
        int number = 0;
        int trueCounter = 0;
        string equation = "";
        for (int i = 1; i<=10; i++)
        {
            int num1 = rnd1.Next(0, 100);
            int num2 = rnd2.Next(0, 100);
            int num3 = rnd3.Next(0, 3);
            if (num3 == 0)
            {
                number = num1 + num2;
                equation = "+";
            }
            else if(num3 == 1)
            {
                number = num1 - num2;
                equation = "-";
            }
            else if(num3 == 2)
            {
                number = num1 * num2;
                equation = "*";
            }
            string answer = await DisplayPromptAsync("Küsimus "+i, num1+equation+num2, initialValue: "10", keyboard: Keyboard.Numeric);
            if(Convert.ToInt32(answer) == number)
            {
                trueCounter++;
            }
        }
        await DisplayAlertAsync("Tulemus", trueCounter+"/10", "OK");
    }
}