using System.Collections.ObjectModel;

namespace Naidis_TARpe24;

public partial class KontaktandmedPage : ContentPage
{
    Button createContact;
    VerticalStackLayout vsl;
    CollectionView collectionView;

    ObservableCollection<Contact> contacts = new();

    public KontaktandmedPage()
    {
        createContact = new Button
        {
            Text = "Loo kontakt",
            BackgroundColor = Colors.LawnGreen
        };
        createContact.Clicked += CreateContact;

        collectionView = new CollectionView
        {
            ItemsSource = contacts,
            ItemTemplate = new DataTemplate(() =>
            {
                var name = new Label { FontAttributes = FontAttributes.Bold };
                name.SetBinding(Label.TextProperty, "Nimi");

                var email = new Label();
                email.SetBinding(Label.TextProperty, "Email");

                var phone = new Label();
                phone.SetBinding(Label.TextProperty, "Telefon");

                var actions = new Button
                {
                    Text = "Lisad",
                    BackgroundColor = Colors.DimGray
                };
                actions.Clicked += ViewActions;

                var layout = new VerticalStackLayout
                {
                    Children = { name, email, phone, actions }
                };

                return new Frame
                {
                    Content = layout,
                    Margin = 5,
                    BorderColor = Colors.Gray
                };
            })
        };

        vsl = new VerticalStackLayout
        {
            Children = { createContact, collectionView }
        };

        Content = vsl;
    }

    private async void CreateContact(object? sender, EventArgs e)
    {
        var contact = new Contact
        {
            Nimi = await DisplayPromptAsync("Nimi", "Sisesta nimi:"),
            Foto = await DisplayPromptAsync("Foto", "Sisesta foto aadress:"),
            Email = await DisplayPromptAsync("Email", "Sisesta email:"),
            Telefon = await DisplayPromptAsync("Telefon", "Sisesta telefoni nr:"),
            Kirjeldus = await DisplayPromptAsync("Kirjeldus", "Sisesta kirjeldus:")
        };

        contacts.Add(contact);
    }

    private async void ViewActions(object? sender, EventArgs e)
    {
        var button = sender as Button;
        var contact = button.BindingContext as Contact;

        string action = await DisplayActionSheet(
            "Lisad",
            "Loobu",
            null,
            "Saada sms",
            "Helista",
            "Saada meil"
        );

        if (action == "Saada sms")
        {
            string phone = contact.Telefon;
            var message = "Tere tulemast! Saadan sõnumi";

            SmsMessage sms = new SmsMessage(message, phone);

            if (phone != null && Sms.Default.IsComposeSupported)
            {
                await Sms.Default.ComposeAsync(sms);
            }
        }
        else if (action == "Helista")
        {
            if (!string.IsNullOrWhiteSpace(contact.Telefon))
            {
                await Launcher.Default.OpenAsync($"tel:{contact.Telefon}");
            }
        }
        else if (action == "Saada meil")
        {
            if (string.IsNullOrWhiteSpace(contact.Email))
                return;

            var message = "Tere tulemast! Saadan email";

            EmailMessage e_mail = new EmailMessage
            {
                Subject = contact.Email,
                Body = message,
                BodyFormat = EmailBodyFormat.PlainText,
                To = new List<string> { contact.Email }
            };

            if (Email.Default.IsComposeSupported)
            {
                await Email.Default.ComposeAsync(e_mail);
            }
            else
            {
                await DisplayAlert("Viga", "E-maili saatmine pole selles seadmes toetatud", "OK");
            }
        }
    }
}

class Contact
{
    public string Nimi { get; set; }
    public string Foto { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public string Kirjeldus { get; set; }
}