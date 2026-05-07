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
			Text="Loo uus riik",
			BackgroundColor = Colors.DarkOliveGreen
		};

		collectionView = new CollectionView
		{
			ItemsSource = riigid,
            ItemTemplate = new DataTemplate(() =>
            {
				var lipp = new Image { HeightRequest=100,WidthRequest=150};
				lipp.SetBinding(Image.SourceProperty, "Lipp");

                var name = new Label { FontAttributes = FontAttributes.Bold };
                name.SetBinding(Label.TextProperty, "Nimi");

                var pealinn = new Label();
                pealinn.SetBinding(Label.TextProperty, "Pealinn");


                var layout = new VerticalStackLayout
                {
                    Children = { name, pealinn, lipp }
                };

                return new Frame
                {
                    Content = layout,
                    Margin = 5,
                    BorderColor = Colors.Gray
                };
            })

        };
		//algsed andmed
		Riik eesti = new Riik
		{
			Nimi="Eesti",
			Pealinn="Tallinn",
			Rahvaarv= "1 362 954",
			Lipp= "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Flag_of_Estonia.svg/250px-Flag_of_Estonia.svg.png"
        };
		Riik l2ti = new Riik
		{
			Nimi="Läti",
			Pealinn="Riia",
			Rahvaarv= "1 856 932",
			Lipp= "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Flag_of_Latvia.svg/250px-Flag_of_Latvia.svg.png"
        };
		Riik austria = new Riik
		{
			Nimi="Austria",
			Pealinn="Viin",
			Rahvaarv= "8 979 894",
			Lipp= "https://et.wikipedia.org/wiki/Fail:Flag_of_Austria.svg"
        };
		Riik austraalia = new Riik
		{
			Nimi="Austraalia",
			Pealinn="Canberra",
			Rahvaarv= "27 614 411",
			Lipp= "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Flag_of_Australia.svg/250px-Flag_of_Australia.svg.png"
        };
		riigid.Add(eesti);
		riigid.Add(l2ti);
		riigid.Add(austria);
		riigid.Add(austraalia);

		//algsed andmed
		createRiik.Clicked += CreateRiik;


        VerticalStackLayout vsl = new VerticalStackLayout
        {
            Children = { createRiik, collectionView }
        };

        Content = vsl;
    }

	private async void CreateRiik(object? sender, EventArgs e)
	{
		string uusNimi = await DisplayPromptAsync("Nimi", "Sisesta riigi nimi:");
        bool riikOnOlemas = riigid.Any(r => r.Nimi.Equals(uusNimi, StringComparison.OrdinalIgnoreCase));
		var riik = new Riik
		{
			Nimi = uusNimi,
			Pealinn = await DisplayPromptAsync("Pealinn", "Sisesta riigi pealinn:"),
			Rahvaarv = await DisplayPromptAsync("Rahvaarv", "Sisesta riigi rahvaarv:"),
			Lipp = await DisplayPromptAsync("Lipp", "Sisesta lipu link:"),
		};
		if (riikOnOlemas == true)
		{
			DisplayAlertAsync("Viga!", "Riik on juba olemas", "Ok");
		}
		else
		{
            riigid.Add(riik);
        }
			
    }
}

	class Riik
	{
		public string Nimi { get; set; }
		public string Pealinn { get; set; }
		public string Rahvaarv { get; set; }
		public string Lipp { get; set; }
	}
