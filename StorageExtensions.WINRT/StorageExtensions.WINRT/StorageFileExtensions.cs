using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace StorageExtensions.WINRT
{
	public static class StorageFileExtensions
	{
		public static async Task<bool> FileExistsInPath(string path)
		{
			try
			{
				await StorageFile.GetFileFromPathAsync(path);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public static async Task<bool> FileExistsInApplication(Uri path)
		{
			try
			{
				await StorageFile.GetFileFromApplicationUriAsync(path);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public static async Task<byte[]> ReadFile(this StorageFile file)
		{
			byte[] fileBytes = null;
			using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
			{
				fileBytes = new byte[stream.Size];
				using (DataReader reader = new DataReader(stream))
				{
					await reader.LoadAsync((uint)stream.Size);
					reader.ReadBytes(fileBytes);
				}
			}
			return fileBytes;
		}
	}
}