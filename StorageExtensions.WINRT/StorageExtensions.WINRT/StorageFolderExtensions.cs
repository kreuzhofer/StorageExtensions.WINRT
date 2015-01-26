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

        public static async Task<IStorageItem> TryGetItemAsync(this StorageFolder folder, string itemName)
        {
            try
            {
                return await folder.GetItemAsync(itemName);

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
