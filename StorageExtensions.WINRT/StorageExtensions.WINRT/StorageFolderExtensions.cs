using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace StorageExtensions.WINRT
{
    public static class StorageFolderExtensions
    {
        public static async Task<bool> ExistsInFolder(this StorageFolder folder, string subPath)
        {
            try
            {
                await folder.GetFolderAsync(subPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
