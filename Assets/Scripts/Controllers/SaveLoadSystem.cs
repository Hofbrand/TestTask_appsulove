using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadSystem
{
    private SaveData data;
    private string saveFilePath;

    public SaveLoadSystem()
    {
        saveFilePath = Application.persistentDataPath + "/saveData.dat";
    }

    public void SetData(float distance, int points)
    {
        data = new SaveData(distance, points);
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(saveFilePath);

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Data saved to " + saveFilePath);
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
            Debug.Log("Data loaded from " + saveFilePath);
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