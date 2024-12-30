using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Newtonsoft.Json;
using LitJson;
using System.IO;

public class ToolsGendata : MonoBehaviour
{
    public int id;
    public LevelConfig levelConfig;

    [Button]
    private void OnClickButton()
    {
        int sum = 0;
       // TextAsset lvJson = Resources.Load<TextAsset>(string.Format(pathLevel, GameController.Instance.useProfile.CurrentLevelPlay));
        for (int i = 0; i < levelConfig.lsDataLevel.Count; i++) 
        {
            levelConfig.lsDataLevel[i].day = i + 1;
            sum += levelConfig.lsDataLevel[i].dayType.numb;
        }    
        if(sum != levelConfig.dataDifficulty.rewardCoin)
        {
            Debug.LogError("ErorrSum");
        }    
        else
        {
     
            var jsonData = JsonConvert.SerializeObject(levelConfig);
            TextAsset textAsset = new TextAsset(jsonData);
            string folderPath = Path.Combine(Application.dataPath, "Resources/Levels");

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string path = Path.Combine(folderPath, "Level_" + id.ToString() + ".txt");

            // Lưu file
            File.WriteAllText(path, jsonData);
            Debug.LogError("save");
        }
   
    }    
}
