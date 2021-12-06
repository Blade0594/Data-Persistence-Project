using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;

    public InputField inputName;
    public Text BestScore;
    public string playerName;
    public string bestPlayer;
    public int highScore;

    private void Awake()
    {
        // Start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // End of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInputName();
    }

    public void SetPlayerName()
    {
        playerName = inputName.text;
    }


    [System.Serializable]
    class SaveData 
    {
        //public InputField inputName;
        public string playerName;
        public int highScore;
    }

    public void SaveInputName() 
    {
        // First, you created a new instance of the save data and filled its team color class member
        // with the TeamColor variable saved in the MainManager:
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        // Next, you transformed that instance to JSON with JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);

        // Finally, you used the special method File.WriteAllText to write a string to a file: 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); 
    }

    // This method is a reversal of the SaveColor method: 
    public void LoadInputName() 
    {
        // It uses the method File.Exists to check if a .json file exists.
        // --If it doesn’t, then nothing has been saved, so no further action is needed.
        // --If the file does exist, then the method will read its content with File.ReadAllText: 
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            // It will then give the resulting text to JsonUtility.FromJson to transform it back into a SaveData instance:
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            // Finally, it will set the TeamColor to the color saved in that SaveData: 
            //inputName = data.inputName;
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
