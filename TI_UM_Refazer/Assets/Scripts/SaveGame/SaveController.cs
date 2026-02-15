using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;

public static class SaveController
{
    //private static string folderName = "./saves/";
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
        PlayerController myPlayerRef = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        EnemyController myEnemyRef = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
        DadosColetaveis myColetaveisRef = GameObject.FindWithTag("Coletavel").GetComponent<DadosColetaveis>();

        if(myPlayerRef == null)
        {
            Debug.Log("Não existe player");
        }
        else if(myEnemyRef == null) 
        {
            Debug.Log("Não existe inimigo");
        }
        else if(myColetaveisRef == null)
        {
            Debug.Log("Não existe coletaveis");
        }
        else
        {
        myPlayerRef.Sincronize();
        myEnemyRef.enemySincronize();
        myColetaveisRef.Sincronize();
        newSave.playerData = myPlayerRef.playerData;
        newSave.initialTime = DateTime.Now;
        newSave.enemyData = myEnemyRef.enemyData;
        newSave.coletaveisData = myColetaveisRef.coletaveisInfo;
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
        PlayerController myPlayerRef = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        EnemyController myEnemyRef = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
        DadosColetaveis myColetaveisRef = GameObject.FindWithTag("Coletavel").GetComponent<DadosColetaveis>();
        myPlayerRef.Load(loaded.playerData);
        myEnemyRef.Load(loaded.enemyData);
        myColetaveisRef.Load(loaded.coletaveisData);
        enterFile.Close();
        Debug.Log("Player Loaded");
        return loaded.initialTime;
    }

    public static void DeleteGame(int saveNumber)
    {
        string path = Path.Combine(folderName, fileName + saveNumber + ".xml");
        if (!File.Exists(path)) return;
        File.Delete(path);
    }

}
