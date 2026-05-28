
namespace Naidis_TARpe24;

public partial class MemoryM2ngPage : ContentPage
{
    Grid gr4x4;
    Image xFire;
    Image yFire;
    Image questionFire;
    Image qFire;
    Image oFire;
    Image gFire;
    Image fFire;
    Image cFire;
    Button firstButton = null;
    int firstValue = -1;
    bool timerRunning = false;
    Button secondButton = null;
    int[,] board = new int[4, 4];
    string[] imageMap = new string[]
{
    "",
    "xfire.jpg",
    "yfire.jpg",
    "questionfire.jpg",
    "qfire.jpg",
    "ofire.jpg",
    "gfire.jpg",
    "ffire.jpg",
    "cfire.jpg"
};
    VerticalStackLayout vsl;

    public MemoryM2ngPage()
    {
        xFire = new Image { Source = "xfire.jpg", HorizontalOptions = LayoutOptions.Center };
        yFire = new Image { Source = "yfire.jpg", HorizontalOptions = LayoutOptions.Center };
        questionFire = new Image { Source = "questionfire.jpg", HorizontalOptions = LayoutOptions.Center };
        qFire = new Image { Source = "qfire.jpg", HorizontalOptions = LayoutOptions.Center };
        oFire = new Image { Source = "ofire.jpg", HorizontalOptions = LayoutOptions.Center };
        gFire = new Image { Source = "gfire.jpg", HorizontalOptions = LayoutOptions.Center };
        fFire = new Image { Source = "ffire.jpg", HorizontalOptions = LayoutOptions.Center };
        cFire = new Image { Source = "cfire.jpg", HorizontalOptions = LayoutOptions.Center };



        gr4x4 = new Grid
        {
            Padding = 10,
            ColumnSpacing = 8,
            RowSpacing = 8,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 350,
            HeightRequest = 350
        };

        for (int i = 0; i < 4; i++)
        {
            gr4x4.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gr4x4.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        Button alusta = new Button
        {
            Text = "Alusta mäng"
        };
        alusta.Clicked += Alusta_Clicked;

        Content = new VerticalStackLayout
        {
            Children = { alusta, gr4x4 }
        };


    }
    private void Alusta_Clicked(object? sender, EventArgs e)
    {
        gr4x4.Children.Clear();

        board = new int[4, 4];
        GenerateBoard();

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                var button = new Button
                {
                    Text = "",
                    BackgroundColor = Colors.Black,
                    BorderColor = Colors.White,
                    BorderWidth = 1,
                    CornerRadius = 0,
                    FontSize = 32
                };


                button.BindingContext = new Tuple<int, int>(row, col);
                if( timerRunning == false)
                {
                    button.Clicked += Button_Clicked;
                }
                else if(timerRunning == true)
                {

                }

                    gr4x4.Add(button, col, row);
            }


        }
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        var button = (Button)sender;
        var pos = (Tuple<int, int>)button.BindingContext;
        int row = pos.Item1;
        int col = pos.Item2;

        int value = board[row, col];
        button.ImageSource = ImageSource.FromFile(imageMap[value]);

        if (firstButton == null)
        {
            
            firstButton = button;
            firstValue = value;
        }
        else
        {
            
            if (firstValue == value)
            {

                firstButton = null;
                secondButton = null;

            }
            else
            {
                secondButton = button;
                timerRunning = true;
                Timer();
                
            }
        }

    }

    private void GenerateBoard()
    {
        var values = new List<int>();
        for (int v = 1; v <= 8; v++)
        {
            values.Add(v);
            values.Add(v);
        }

        var rng = new Random();
        for (int i = values.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (values[i], values[j]) = (values[j], values[i]);
        }

        for (int row = 0; row < 4; row++)
            for (int col = 0; col < 4; col++)
                board[row, col] = values[row * 4 + col];
    }
    private async void Timer()
    {
         Device.StartTimer(TimeSpan.FromSeconds(1), () => {
            secondButton.ImageSource = "";
            firstButton.ImageSource = "";
            firstButton = null;
            secondButton = null;
            firstValue = -1;
             timerRunning = false;
            return false;
        });
    }
}