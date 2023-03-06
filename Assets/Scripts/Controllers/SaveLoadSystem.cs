using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Controllers
{
    public class SaveLoadSystem
    {
        private string saveFilePath;

        public Action<SaveData> OnDataLoaded;

        public SaveLoadSystem()
        {
            saveFilePath = Application.persistentDataPath + "/saveData.txt";
        }

        public void SaveData(SaveData data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(saveFilePath, FileMode.Create);

            bf.Serialize(file, data);
            file.Close();
        }

        public void LoadData()
        {
            if (File.Exists(saveFilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(saveFilePath, FileMode.Open);

                SaveData data = (SaveData)bf.Deserialize(file);

                file.Close();
                OnDataLoaded(data);
            }
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public float distance;
        public int points;

        public SaveData(float distance, int points)
        {
            this.distance = distance;
            this.points = points;
        }
    }
}
