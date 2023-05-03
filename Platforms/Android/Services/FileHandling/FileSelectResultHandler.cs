using FilePickerIssueWorkaround.Platforms.Android;
using Microsoft.Maui.ApplicationModel;
using System;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public class FileSelectResultHandler : IFileSelectResultHandler
    {
        public void SetHandler(EventHandler<string> onFileSelectedDelegate)
        {
            if (Platform.CurrentActivity is not MainActivity currentActivity)
            {
                throw new Exception($"Current activity is not of type {typeof(MainActivity).Name}");
            }

            currentActivity.OnFileSelected += onFileSelectedDelegate;
        }
    }
}
