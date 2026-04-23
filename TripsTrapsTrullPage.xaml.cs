namespace Naidis_TARpe24;

public partial class TripsTrapsTrullPage : ContentPage
{
    Grid gr3x3;
    Image Ofire;
    Image Xfire;
    int player;
    int[,] board = new int[3, 3];
    Switch s_pilt;
    VerticalStackLayout vsl;

    public TripsTrapsTrullPage()
    {
        Ofire = new Image
        {
            Source = "xfire.jpg",
            HorizontalOptions = LayoutOptions.Center
        };
        Xfire = new Image
        {
            Source = "xfire.jpg",
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
            Text = "Alusta mäng"
        };
        alusta.Clicked += Alusta_Clicked;

        Content = new VerticalStackLayout
        {
            Children = { alusta, gr3x3 }
        };
    }

    private void Alusta_Clicked(object? sender, EventArgs e)
    {
        gr3x3.Children.Clear();

        board = new int[3, 3]; 
        player = 0;            

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                var button = new Button
                {
                    Text = "",
                    BackgroundColor = Colors.White,
                    BorderColor = Colors.Black,
                    BorderWidth = 1,
                    CornerRadius = 0,
                    FontSize = 32
                };

                
                button.BindingContext = new Tuple<int, int>(row, col);
                button.Clicked += Button_Clicked;

                gr3x3.Add(button, col, row);
            }
        }
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        int winner = 0; 
        string winnerString;

        var button = (Button)sender;

        if (button.ImageSource != null) return;

        var pos = (Tuple<int, int>)button.BindingContext;
        int row = pos.Item1;
        int col = pos.Item2;

        if (player == 0)
        {
            button.ImageSource = "xfire.jpg";
            board[row, col] = 1;
            player = 1;
        }
        else
        {
            button.ImageSource = "ofire.png";
            board[row, col] = 2;
            player = 0;
        }

        
        if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != 0)
            winner = board[0, 0];
        else if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 0] != 0)
            winner = board[1, 0];
        else if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 0] != 0)
            winner = board[2, 0];

        
        else if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != 0)
            winner = board[0, 0];
        else if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != 0)
            winner = board[0, 1];
        else if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != 0)
            winner = board[0, 2];

        
        else if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != 0)
            winner = board[0, 0];
        else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != 0)
            winner = board[0, 2];

        if (winner != 0)
        {
            winnerString = winner == 1 ? "X" : "O";
            await DisplayAlert("Teade", "Võitja on: " + winnerString, "OK");
        }
        else
        {
            bool isDraw = true;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (board[r, c] == 0)
                    {
                        isDraw = false;
                        break;
                    }
                }
                if (!isDraw) break;
            }

            if (isDraw)
            {
                await DisplayAlert("Teade", "Viik!", "OK");
            }
        }
    }
}