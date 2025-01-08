using Newtonsoft.Json;
using StickyNoteClone.Domain.Usecases;
using StickyNoteClone.Models;
using StickyNoteClone.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace StickyNoteClone.Data.Services;

public class FileStorageService
{
    public readonly StorageFolder LOCAL_FOLDER = ApplicationData.Current.LocalFolder;

    public async Task<bool> SaveData<T>(StorageFolder folder, string filename, T data)
    {
        try
        {
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using Stream stream = await file.OpenStreamForWriteAsync();
            using StreamWriter writer = new StreamWriter(stream);
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await writer.WriteAsync(json);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
        
    }

    public async Task<T> LoadData<T>(StorageFolder folder, string filename)
    {
        try
        {
            StorageFile file = await folder.GetFileAsync(filename);
            using Stream stream = await file.OpenStreamForReadAsync();
            using StreamReader reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return default;
        }
    }
}
