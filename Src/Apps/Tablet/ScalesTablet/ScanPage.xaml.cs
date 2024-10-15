using BarcodeScanning;

namespace ScalesTablet;

public partial class ScanPage : ContentPage
{
    public ScanPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await Methods.AskForRequiredPermissionAsync();
        base.OnAppearing();
        Barcode.CameraEnabled = true;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Barcode.CameraEnabled = false;
    }

    private void ContentPage_Unloaded(object sender, EventArgs e)
    {
        Barcode.Handler?.DisconnectHandler();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void CameraView_OnDetectionFinished(object sender, OnDetectionFinishedEventArg e)
    {
        if (e.BarcodeResults.Length == 0) return;
        MessagingCenter.Send(this, "ScanCompleted", e.BarcodeResults[0].DisplayValue);
        Navigation.PopModalAsync();
    }
}