namespace Naidis_TARpe24;

public partial class ItaaliaK66kPage : ContentPage
{
    public CarouselView carouselView;
    public List<CarouselItem> items;
    private int position = 0;
    private Image _flagImage;

    public class CarouselItem
    {
        public string TitleKey { get; set; }
        public string DescKey { get; set; }
        public string RecipeKey { get; set; }
        public string Image { get; set; }

        public string Title => LocalizationManager.Get(TitleKey);
        public string Description => LocalizationManager.Get(DescKey);
        public string Recipe => LocalizationManager.Get(RecipeKey);
    }

    private readonly List<CarouselItem> _itemDefs = new()
    {
        new CarouselItem { Image="carbonara.jpg",  TitleKey="CarbTitle",  DescKey="CarbDesc",  RecipeKey="CarbRecipe"  },
        new CarouselItem { Image="margherita.jpg", TitleKey="PizzaTitle", DescKey="PizzaDesc", RecipeKey="PizzaRecipe" },
        new CarouselItem { Image="tiramisu.jpg",   TitleKey="TirTitle",   DescKey="TirDesc",   RecipeKey="TirRecipe"   },
        new CarouselItem { Image="risotto.jpg",    TitleKey="RisTitle",   DescKey="RisDesc",   RecipeKey="RisRecipe"   },
        new CarouselItem { Image="lasagna.jpg",    TitleKey="LasTitle",   DescKey="LasDesc",   RecipeKey="LasRecipe"   },
    };

    public ItaaliaK66kPage()
    {
        BuildUI();
    }

    private void BuildUI()
    {
        carouselView = new CarouselView
        {
            ItemsSource = _itemDefs,
            HeightRequest = 300,
            IsBounceEnabled = true,
            IsScrollAnimated = true,
            Loop = true,
        };

        carouselView.ItemTemplate = new DataTemplate(() =>
        {
            var frame = new Frame
            {
                CornerRadius = 20,
                HasShadow = true,
                Padding = 0,
                Margin = new Thickness(10),
                BackgroundColor = Colors.Transparent
            };

            var grid = new Grid();

            var image = new Image { Aspect = Aspect.AspectFit };
            image.SetBinding(Image.SourceProperty, "Image");

            var gradient = new BoxView
            {
                Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 1),
                    EndPoint = new Point(0, 0),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.Black.WithAlpha(0.6f), 0),
                        new GradientStop(Colors.Transparent, 1)
                    }
                },
                Opacity = 0.7
            };

            var label = new Label
            {
                TextColor = Colors.White,
                FontSize = 24,
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Start
            };
            label.SetBinding(Label.TextProperty, "Title");

            var tap = new TapGestureRecognizer();
            tap.Tapped += async (s, e) =>
            {
                var tappedItem = ((Frame)s).BindingContext as CarouselItem;
                await DisplayAlert(tappedItem.Title, tappedItem?.Recipe ?? "?", "OK");
            };
            frame.GestureRecognizers.Add(tap);

            grid.Children.Add(image);
            grid.Children.Add(gradient);
            grid.Children.Add(label);
            frame.Content = grid;
            return frame;
        });

        var indicatorView = new IndicatorView
        {
            IndicatorColor = Colors.Gray,
            SelectedIndicatorColor = Colors.Blue,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 10)
        };
        carouselView.IndicatorView = indicatorView;

        _flagImage = new Image
        {
            Source = LocalizationManager.CurrentLanguage == "et" ? "briti.png" : "eesti.jpg",
            HeightRequest = 40,
            WidthRequest = 60,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 0, 10, 10)
        };

        var flagTap = new TapGestureRecognizer();
        flagTap.Tapped += OnLanguageToggle;
        _flagImage.GestureRecognizers.Add(flagTap);

        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            if (_itemDefs.Count == 0) return false;
            int next = (carouselView.Position + 1) % _itemDefs.Count;
            carouselView.ScrollTo(index: next, animate: true, position: ScrollToPosition.MakeVisible);
            return true;
        });

        Content = new StackLayout
        {
            Padding = 20,
            Children = { _flagImage, carouselView, indicatorView }
        };
    }

    private void OnLanguageToggle(object sender, EventArgs e)
    {
        string next = LocalizationManager.CurrentLanguage == "en" ? "et" : "en";
        LocalizationManager.SetLanguage(next);
        BuildUI();
    }
}