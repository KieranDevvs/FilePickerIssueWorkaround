using System;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public interface IFileSelectResultHandler
    {
        public void SetHandler(EventHandler<string?> onFileSelectedDelegate);
    }
}
