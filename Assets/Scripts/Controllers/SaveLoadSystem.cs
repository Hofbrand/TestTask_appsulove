using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Android;

public class SaveLoadSystem
{
    private SaveData data;
    private string saveFilePath;

    public SaveLoadSystem()
    {
        saveFilePath = Application.persistentDataPath + "/saveData.txt";
    }

    public void SetData(float distance, int points)
    {
        data = new SaveData(distance, points);
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(saveFilePath, FileMode.Create); 

        bf.Serialize(file, data);
        file.Close();
    }

    public SaveData LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);

            file.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
   
[System.Serializable]
public class SaveData
{
    public float distance;
    public int points;

    public SaveData(float distance, int points) {
        this.distance = distance;
        this.points = points;
    }
}