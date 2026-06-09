using System.ComponentModel;
using System.Runtime.CompilerServices;
using Naidis_TARpe24.Models.Memory;

namespace Naidis_TARpe24.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private static readonly string[] ImageMap =
        {
            "", "xfire.jpg", "yfire.jpg", "questionfire.jpg",
            "qfire.jpg", "ofire.jpg", "gfire.jpg", "ffire.jpg", "cfire.jpg"
        };

        public int[,] Board { get; private set; } = new int[4, 4];

        private Button _firstButton;
        private int _firstValue = -1;
        private bool _isProcessing;
        private int _matchedPairs;

        public int Moves { get; private set; }

        public bool IsFinished => _matchedPairs == 8;

        private string _status = "";
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private string _elapsed = "00:00";
        public string Elapsed
        {
            get => _elapsed;
            set
            {
                _elapsed = value;
                OnPropertyChanged();
            }
        }

        private Theme _currentTheme = Theme.Dark;
        public Theme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                _currentTheme = value;
                OnPropertyChanged();
            }
        }

        public List<Theme> Themes => Theme.AllThemes;

        private DateTime _startTime;
        private IDispatcherTimer _clockTimer;

        public void StartGame()
        {
            _firstButton = null;
            _firstValue = -1;
            _isProcessing = false;
            _matchedPairs = 0;
            Moves = 0;

            Board = GenerateBoard();

            Status = "Leia kõik 8 paari!";

            _clockTimer?.Stop();

            _startTime = DateTime.Now;

            _clockTimer = Application.Current.Dispatcher.CreateTimer();
            _clockTimer.Interval = TimeSpan.FromSeconds(1);

            _clockTimer.Tick += (_, _) =>
            {
                Elapsed = (DateTime.Now - _startTime).ToString(@"mm\:ss");
            };

            _clockTimer.Start();
        }

        public async Task<bool> FlipCard(Button btn, int row, int col)
        {
            if (_isProcessing)
                return false;

            int value = Board[row, col];

            btn.ImageSource = ImageSource.FromFile(ImageMap[value]);

            if (_firstButton == null)
            {
                _firstButton = btn;
                _firstValue = value;
                return false;
            }

            Moves++;
            Status = $"Käigud: {Moves} | Paarid: {_matchedPairs}/8";

            if (_firstValue == value)
            {
                _matchedPairs++;

                _firstButton = null;
                _firstValue = -1;

                if (IsFinished)
                {
                    _clockTimer?.Stop();
                    Preferences.Set("besttime", Elapsed);
                }

                return IsFinished;
            }

            _isProcessing = true;

            var missedFirst = _firstButton;
            var missedSecond = btn;

            _firstButton = null;
            _firstValue = -1;

            await Task.Delay(900);

            missedFirst.ImageSource = null;
            missedSecond.ImageSource = null;

            _isProcessing = false;

            return false;
        }

        private int[,] GenerateBoard()
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

            var board = new int[4, 4];

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    board[row, col] = values[row * 4 + col];
                }
            }

            return board;
        }
    }
}