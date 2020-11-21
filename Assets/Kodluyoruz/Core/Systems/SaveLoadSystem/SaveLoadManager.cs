using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public static class SaveLoadManager
{
    const string JSON_PREFIX = "DataJsons_";
    /// <summary>Save Generic Data.
    /// <para>Save file as Object in Persistent Data Path. <see cref="UnityEngine.Application.persistentDataPath"/> for more information.</para>
    /// </summary>
    public static bool SavePDP<T>(T data, string fileName)
    {
        return Save(data, JSON_PREFIX + fileName);
    }

    /// <summary>Save Generic Data.
    /// <para>Save file as Object in custom Path.</para>
    /// </summary>
    private static bool Save<T>(T data, string pathFileName)
    {
        string dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(pathFileName, dataJson);
        PlayerPrefs.Save();
        return true;

    }

    /// <summary>Load Generic Data.
    /// <para>Load file as Object from Persistent Data Path. <see cref="UnityEngine.Application.persistentDataPath"/> for more information.</para>
    /// </summary>
    public static T LoadPDP<T>(string fileName, T _default) where T : new()
    {
        return Load<T>(JSON_PREFIX + fileName, _default);
    }

    /// <summary>Load Generic Data.
    /// <para>Load file as Object from custom Path.</para>
    /// </summary>
    private static T Load<T>(string pathFileName, T _default) where T : new()
    {
        if (!PlayerPrefs.HasKey(pathFileName))
        {
            if (_default != null)
                return _default;
            else return default(T);
        }
        try
        {
            string dataJson = PlayerPrefs.GetString(pathFileName);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(dataJson);
        }
        catch
        {
            if (_default != null)
                return _default;
            else return default(T);

        }
    }

    public static void DeleteFile(string fileName)
    {PlayerPrefs.DeleteKey(JSON_PREFIX + fileName);
    }
}
