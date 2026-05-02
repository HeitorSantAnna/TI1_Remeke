using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;

public static class SaveController
{
    //private static string folderName = "./saves/";
    /*
    private static string folderName = Path.Combine(Application.persistentDataPath, "saves");
    private static string fileName = "save";


    public static void SaveGame(int saveNumber)
    {
        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
        }
        DirectoryInfo dir = new DirectoryInfo(folderName);
        string path = Path.Combine(folderName, fileName + saveNumber + ".xml");
        StreamWriter exitfile = new StreamWriter(path);
        XmlSerializer xmlObj = new XmlSerializer(typeof(SaveGame));
        SaveGame newSave = new SaveGame();
        Movimentacao myPlayerRef = GameObject.FindWithTag("Player").GetComponent<Movimentacao>();

        if(myPlayerRef == null)
        {
            Debug.Log("Não existe player");
        }
        else
        {
        myPlayerRef.Sincronize();
        newSave.playerData = myPlayerRef.playerData;
        newSave.initialTime = DateTime.Now;
        xmlObj.Serialize(exitfile.BaseStream, newSave);
        exitfile.Close();
        Debug.Log("Player Saved");
        }
    }

    public static DateTime LoadGame(int saveNumber)
    {
        string path = Path.Combine(folderName, fileName + saveNumber + ".xml");
        if (!File.Exists(path)) return DateTime.MinValue;
        StreamReader enterFile = new StreamReader(path);
        XmlSerializer xmlObj = new XmlSerializer(typeof(SaveGame));
        SaveGame loaded = (SaveGame)xmlObj.Deserialize(enterFile.BaseStream);
        Movimentacao myPlayerRef = GameObject.FindWithTag("Player").GetComponent<Movimentacao>();
        myPlayerRef.Load(loaded.playerData);
        enterFile.Close();
        Debug.Log("Player Loaded");
        return loaded.initialTime;
    }

    public static void DeleteGame(int saveNumber)
    {
        string path = Path.Combine(folderName, fileName + saveNumber + ".xml");
        if (!File.Exists(path)) return;
        File.Delete(path);
    }*/

}
