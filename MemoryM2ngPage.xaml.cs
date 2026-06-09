using Naidis_TARpe24.Models.Memory;
using Naidis_TARpe24.ViewModels;

namespace Naidis_TARpe24
{
    public partial class MemoryM2ngPage : ContentPage
    {
        private readonly GameViewModel _vm;

        private Grid _grid;
        private Label _timerLabel;
        private Label _statusLabel;
        private Button _startBtn;
        private Picker _themePicker;

        public MemoryM2ngPage()
        {
            _vm = new GameViewModel();

            BindingContext = _vm;

            _vm.PropertyChanged += Vm_PropertyChanged;

            BuildUI();

            ApplyTheme(_vm.CurrentTheme);
        }

        private void Vm_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GameViewModel.CurrentTheme))
            {
                ApplyTheme(_vm.CurrentTheme);
            }
        }

        private void BuildUI()
        {
            _themePicker = new Picker
            {
                ItemsSource = _vm.Themes,
                ItemDisplayBinding = new Binding("Name")
            };

            _themePicker.SelectedIndex = 0;

            _themePicker.SelectedIndexChanged += (_, _) =>
            {
                if (_themePicker.SelectedItem is Theme theme)
                {
                    _vm.CurrentTheme = theme;
                }
            };

            _timerLabel = new Label
            {
                FontSize = 20
            };

            _timerLabel.SetBinding(
                Label.TextProperty,
                nameof(GameViewModel.Elapsed));

            _statusLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center
            };

            _statusLabel.SetBinding(
                Label.TextProperty,
                nameof(GameViewModel.Status));

            _startBtn = new Button
            {
                Text = "Alusta mäng"
            };

            _startBtn.Clicked += OnAlustaClicked;

            _grid = new Grid
            {
                ColumnSpacing = 8,
                RowSpacing = 8,
                WidthRequest = 350,
                HeightRequest = 350,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for (int i = 0; i < 4; i++)
            {
                _grid.RowDefinitions.Add(
                    new RowDefinition
                    {
                        Height = GridLength.Star
                    });

                _grid.ColumnDefinitions.Add(
                    new ColumnDefinition
                    {
                        Width = GridLength.Star
                    });
            }

            Content = new VerticalStackLayout
            {
                Padding = 16,
                Spacing = 10,
                Children =
                {
                    _themePicker,
                    _timerLabel,
                    _statusLabel,
                    _startBtn,
                    _grid
                }
            };
        }

        private void ApplyTheme(Theme theme)
        {
            BackgroundColor = theme.BackgroundColor;

            _timerLabel.TextColor = theme.TextColor;
            _statusLabel.TextColor = theme.TextColor;

            _startBtn.BackgroundColor = theme.AccentColor;
            _startBtn.TextColor = theme.TextColor;

            _themePicker.BackgroundColor = theme.BackgroundColor;
            _themePicker.TextColor = theme.TextColor;

            foreach (var child in _grid.Children)
            {
                if (child is Button btn)
                {
                    btn.BorderColor = theme.CardBorderColor;
                }
            }
        }

        private void OnAlustaClicked(object sender, EventArgs e)
        {
            _vm.StartGame();

            RebuildGrid();

            ApplyTheme(_vm.CurrentTheme);
        }

        private void RebuildGrid()
        {
            _grid.Children.Clear();

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    var btn = new Button
                    {
                        BackgroundColor =
                            _vm.CurrentTheme.BackgroundColor,

                        BorderColor =
                            _vm.CurrentTheme.CardBorderColor,

                        BorderWidth = 1,
                        CornerRadius = 0
                    };

                    btn.BindingContext = (row, col);

                    btn.Clicked += OnCardClicked;

                    _grid.Add(btn, col, row);
                }
            }
        }

        private async void OnCardClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var (row, col) =
                ((int, int))btn.BindingContext;

            await _vm.FlipCard(btn, row, col);

            if (_vm.IsFinished)
            {
                await DisplayAlert(
                    "Mäng lõppes!",
                    $"Aeg: {_vm.Elapsed}\nKäigud: {_vm.Moves}",
                    "OK");
            }
        }
    }
}