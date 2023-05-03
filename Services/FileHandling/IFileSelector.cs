using System.Threading.Tasks;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public interface IFileSelector
    {
        public Task SelectAsync();
    }
}
