namespace Naidis_TARpe24;

public partial class Pop_Up_Page : ContentPage
{
	public Pop_Up_Page()
	{
		Button alertButton = new Button
		{
			Text="Teade",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertButton.Clicked += AlertButton_Clicked;

		Button alertYesNoButton = new Button
		{
			Text = "Jah või ei",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center,
		};
		alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

		Button alertListButton = new Button
		{
			Text="Valik",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertListButton.Clicked += AlertListButton_Clicked;

		Button alertQuestButton = new Button
		{
			Text = "Küsimus",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertQuestButton.Clicked += AlertQuestButton_Clicked;

		Content = new VerticalStackLayout
		{
			Spacing = 20,
			Padding = new Thickness(0,50,0,0),
			Children = {alertButton,alertYesNoButton,alertListButton,alertQuestButton}
		};
	}
	private async void AlertButton_Clicked(object? sender,EventArgs e)
	{
		await DisplayAlertAsync("Teade", "Teil on uus teade", "OK");
	}

	private async void AlertYesNoButton_Clicked(object? sender,EventArgs e)
	{
		bool result = await DisplayAlertAsync("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");
		await DisplayAlertAsync("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "OK");

	}
	public async void AlertListButton_Clicked(object? sender, EventArgs e)
	{
		string action = await DisplayActionSheetAsync("Mida teha?", "Loobu", "Kustutada", "Tantsida", "Laulda", "Joonestada");
		if (action != null && action != "Loobu")
		{
			await DisplayAlertAsync("Valik", "Sa valisid tegevuse: " + action, "OK");
		}
	}
	public async void AlertQuestButton_Clicked(object? sender,EventArgs e)
	{
		string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore!");
		string result2 = await DisplayPromptAsync("Vasta", "Millega võrdub 5+5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
	}
}