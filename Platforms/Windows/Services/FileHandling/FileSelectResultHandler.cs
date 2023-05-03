using System;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public class FileSelectResultHandler : IFileSelectResultHandler
    {
        private readonly FileSelector _windowsFileSelector;
        public FileSelectResultHandler(FileSelector fileSelector)
        {
            _windowsFileSelector = fileSelector;
        }

        public void SetHandler(EventHandler<string?> onFileSelectedDelegate)
        {
            _windowsFileSelector.OnFileSelected += onFileSelectedDelegate;
        }
    }
}
