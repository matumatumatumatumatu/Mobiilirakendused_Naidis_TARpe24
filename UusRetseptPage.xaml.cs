using Naidis_TARpe24.Models.Retsept;
using Naidis_TARpe24.Services;


namespace Naidis_TARpe24;

public partial class UusRetseptPage : ContentPage
{
    public UusRetseptPage()
    {
        InitializeComponent();
    }

    private async void SalvestaBtn_Clicked(object sender, EventArgs e)
    {
        string nimi = NimiEntry.Text?.Trim() ?? string.Empty;
        string kategooria = KategooriaEntry.Text?.Trim() ?? string.Empty;
        string pildiLink = PildiLinkEntry.Text?.Trim() ?? string.Empty;

        
        if (string.IsNullOrEmpty(nimi) ||
            string.IsNullOrEmpty(kategooria) ||
            string.IsNullOrEmpty(pildiLink))
        {
            await DisplayAlert(
                " Puuduvad andmed",
                "Palun täida kõik väljad enne salvestamist.",
                "OK");
            return;
        }

        var uusRetsept = new Retsept
        {
            Nimi = nimi,
            Kategooria = kategooria,
            PildiLink = pildiLink
        };

        RetseptFileService.SalvestaRetsept(uusRetsept);

        
        NimiEntry.Text = string.Empty;
        KategooriaEntry.Text = string.Empty;
        PildiLinkEntry.Text = string.Empty;

        await DisplayAlert("Salvestatud!", $"'{nimi}' on edukalt lisatud.", "OK");
    }

    private async void Nupp_Clicked(object? sender, EventArgs e)
    {
        Button navigateButton = sender as Button;
        await Navigation.PushAsync(new MinuRetseptidPage());
    }
}