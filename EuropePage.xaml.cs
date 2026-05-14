using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
namespace Naidis_TARpe24;

public partial class EuropePage : ContentPage
{
    Button createRiik;
    CollectionView collectionView;
    ObservableCollection<Riik> riigid = new();
    public EuropePage()
    {
        createRiik = new Button
        {
            Text = "Loo uus riik",
            BackgroundColor = Colors.DarkOliveGreen
        };
        collectionView = new CollectionView
        {
            ItemsSource = riigid,
            SelectionMode = SelectionMode.Single,
            ItemTemplate = new DataTemplate(() =>
            {
                var lipp = new Image { HeightRequest = 60, WidthRequest = 100 };
                lipp.SetBinding(Image.SourceProperty, "Lipp");

                var name = new Label { FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center };
                name.SetBinding(Label.TextProperty, "Nimi");

                var pealinn = new Label { VerticalOptions = LayoutOptions.Center };
                pealinn.SetBinding(Label.TextProperty, "Pealinn");

                var textLayout = new VerticalStackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = { name, pealinn }
                };

                var rowLayout = new HorizontalStackLayout
                {
                    Spacing = 10,
                    Children = { lipp, textLayout }
                };

                var frame = new Frame
                {
                    Content = rowLayout,
                    Margin = 5,
                    BorderColor = Colors.Gray,
                    Padding = 8,
                    InputTransparent = true  
                };

                return frame;
            })
        };

        
        collectionView.SelectionMode = SelectionMode.Single;
        collectionView.SelectionChanged += OnRiikSelected;

       
        riigid.Add(new Riik { Nimi = "Eesti", Pealinn = "Tallinn", Rahvaarv = "1 362 954", Lipp = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Flag_of_Estonia.svg/250px-Flag_of_Estonia.svg.png" });
        riigid.Add(new Riik { Nimi = "Läti", Pealinn = "Riia", Rahvaarv = "1 856 932", Lipp = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Flag_of_Latvia.svg/250px-Flag_of_Latvia.svg.png" });
        riigid.Add(new Riik { Nimi = "Austria", Pealinn = "Viin", Rahvaarv = "8 979 894", Lipp = "https://et.wikipedia.org/wiki/Fail:Flag_of_Austria.svg" });
        riigid.Add(new Riik { Nimi = "Austraalia", Pealinn = "Canberra", Rahvaarv = "27 614 411", Lipp = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Flag_of_Australia.svg/250px-Flag_of_Australia.svg.png" });

        createRiik.Clicked += CreateRiik;

        VerticalStackLayout vsl = new VerticalStackLayout
        {
            Children = { createRiik, collectionView }
        };
        Content = vsl;
    }

    private async void OnRiikSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Riik riik) return;


        bool kusutamine = await DisplayAlertAsync(
            riik.Nimi,
            $"🏛️ Pealinn: {riik.Pealinn}\n👥 Rahvaarv: {riik.Rahvaarv}",
            "Kustuta Riik",
            "Sulge");

            if(kusutamine == true)
        {
            riigid.Remove(riik);
        }
        

        
        collectionView.SelectedItem = null;
    }

    private async void CreateRiik(object? sender, EventArgs e)
    {
        string uusNimi = await DisplayPromptAsync("Nimi", "Sisesta riigi nimi:");
        if (string.IsNullOrWhiteSpace(uusNimi)) return;

        bool riikOnOlemas = riigid.Any(r => r.Nimi.Equals(uusNimi, StringComparison.OrdinalIgnoreCase));
        if (riikOnOlemas)
        {
            await DisplayAlertAsync("Viga!", "Riik on juba olemas", "Ok");
            return;
        }

        var riik = new Riik
        {
            Nimi = uusNimi,
            Pealinn = await DisplayPromptAsync("Pealinn", "Sisesta riigi pealinn:"),
            Rahvaarv = await DisplayPromptAsync("Rahvaarv", "Sisesta riigi rahvaarv:"),
            Lipp = await DisplayPromptAsync("Lipp", "Sisesta lipu link:"),
        };

        riigid.Add(riik);
    }
}

class Riik
{
    public string Nimi { get; set; }
    public string Pealinn { get; set; }
    public string Rahvaarv { get; set; }
    public string Lipp { get; set; }
}
