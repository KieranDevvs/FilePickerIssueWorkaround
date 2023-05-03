using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using System;

namespace FilePickerIssueWorkaround.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public event EventHandler<string?>? OnFileSelected;

    public const int ReadFileResultCode = 1;
    public const int RequestInstallPackage = 2;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Platform.Init(this, savedInstanceState);
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        switch (requestCode)
        {
            case ReadFileResultCode:
                if (data?.Data is not null)
                {
                    OnFileSelected?.Invoke(this, FilesHelper.GetActualPathForFile(data.Data, this));
                }
                break;
        }
    }
}
