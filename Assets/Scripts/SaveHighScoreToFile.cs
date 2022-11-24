using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHighScoreToFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(HighScoreData data)
    {
        try
        {
            // convert data to json format
            string json = JsonUtility.ToJson(data);

            // Get a file path to save the file in
            //string path = Application.persistentDataPath  //Standard windows location for all apps
            string path = Application.dataPath + "/highscore.txt";

            // The class that will write the text file
            StreamWriter writer = new StreamWriter(path, false);

            // write the json to a file
            writer.Write(json);

            //Always close the file
            writer.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Exception: " + e);
        }
    }
    public HighScoreData Load()
    {
        try
        {
            string path = Application.dataPath + "/highscore.txt";

            // The class that will read the text file
            StreamReader reader = new StreamReader(path);

            // read the whole json at once, i.e. not line by line
            string fileData = reader.ReadToEnd();

            // Read the json data and store it in something useable by us
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(fileData);

            //Always close the file
            reader.Close();

            return data;
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("No Save File: " + e);
            return new HighScoreData();
        }

    }

}
