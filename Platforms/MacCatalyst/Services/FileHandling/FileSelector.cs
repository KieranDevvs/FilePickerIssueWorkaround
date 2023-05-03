using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public class FileSelector : IFileSelector
    {
        public Task SelectAsync()
        {
            throw new FeatureNotSupportedException();
        }
    }
}
