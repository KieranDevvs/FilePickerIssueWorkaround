using Microsoft.Maui;
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public class FileSelector : IFileSelector
    {
        public event EventHandler<string?>? OnFileSelected;

        public async Task SelectAsync()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add("*");

            var appCurrent = Microsoft.Maui.Controls.Application.Current;
            if (appCurrent is null)
            {
                throw new InvalidOperationException($"Could not get current MAUI app instance.");
            }

            var mauiWinUIWindow = appCurrent.Windows[0].Handler.PlatformView as MauiWinUIWindow;
            if (mauiWinUIWindow is null)
            {
                throw new InvalidOperationException($"Could not get windows platform view.");
            }

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, mauiWinUIWindow.WindowHandle);

            var result = await filePicker.PickSingleFileAsync();

            if (result is not null)
            {
                OnFileSelected?.Invoke(this, result.Path);
            }
        }
    }
}
