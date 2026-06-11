using Naidis_TARpe24.Models.Retsept;
using Naidis_TARpe24.Models;
using Naidis_TARpe24.Services;

namespace Naidis_TARpe24;

public partial class MinuRetseptidPage : ContentPage
{
    public MinuRetseptidPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LaeRetseptid();
    }

    private void LaeRetseptid()
    {
        var kõikRetseptid = RetseptFileService.LoeRetseptid();

        var grupid = kõikRetseptid
            .GroupBy(r => r.Kategooria)
            .OrderBy(g => g.Key)
            .Select(g => new RetseptKategooria(g.Key, g.ToList()))
            .ToList();

        Dispatcher.Dispatch(() =>
        {
            RetseptidListView.ItemsSource = null;
            RetseptidListView.ItemsSource = grupid;
        });
    }
    private async void Nupp_Clicked(object? sender, EventArgs e)
    {
        Button navigateButton = sender as Button;
        await Navigation.PushAsync(new UusRetseptPage());
    }
}