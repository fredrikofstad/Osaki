using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string filename = "SaveFile.sav";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        string json = JsonUtility.ToJson(so, true);
        File.WriteAllText(dir + filename, json);
    }
    public static SaveObject Load()
    {
        SaveObject so = new SaveObject();

        if (SaveFileExists())
        {
            string json = File.ReadAllText(GetFullPath());
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }
        return so;
    }
    public static bool SaveFileExists()
    {
        return File.Exists(GetFullPath());
    }
    private static string GetFullPath()
    {
        return Application.persistentDataPath + directory + filename;
    }
}
