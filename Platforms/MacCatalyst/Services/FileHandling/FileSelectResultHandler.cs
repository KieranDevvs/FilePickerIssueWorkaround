using Microsoft.Maui.ApplicationModel;
using System;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public class FileSelectResultHandler : IFileSelectResultHandler
    {
        public void SetHandler(EventHandler<string?> onFileSelectedDelegate)
        {
            throw new FeatureNotSupportedException();
        }
    }
}
