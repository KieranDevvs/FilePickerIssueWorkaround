﻿using Android.OS;
using Android.Provider;
using Android.App;
using Android.Content;
using Android.Net;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using FilePickerIssueWorkaround.Platforms.Android;

namespace FilePickerIssueWorkaround.Services.FileHandling
{
    public class FileSelector : IFileSelector
    {
        public Task SelectAsync()
        {
            var currentActivity = Platform.CurrentActivity;
            if (currentActivity is null)
            {
                throw new System.InvalidOperationException($"Could not get current MAUI activity.");
            }

            if (!Environment.IsExternalStorageManager)
            {
                var uri = Uri.Parse($"package:{Application.Context?.ApplicationInfo?.PackageName}");
                var permissionIntent = new Intent(Settings.ActionManageAppAllFilesAccessPermission, uri);
                currentActivity.StartActivity(permissionIntent);
            }

            var intent = new Intent(Intent.ActionOpenDocument);
            intent.AddCategory(Intent.CategoryOpenable);
            intent.SetType("*/*");

            intent.PutExtra(DocumentsContract.ExtraInitialUri, MediaStore.Downloads.ExternalContentUri);

            currentActivity.StartActivityForResult(intent, MainActivity.ReadFileResultCode);

            return Task.CompletedTask;
        }
    }
}
