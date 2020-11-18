using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/sav.g";
    }
  public void Save() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);
        SaveData save = new SaveData();
        //--------------------------------------------Инициализация переменных для сохранения----------------------------
        save._countBoss = Enemy.countBoss;
        //save._hitEnemyCurrentValue 
        //save._hitEnemyMaxValue
        save._II = Player.II;
        save._levelBarCurrentValue = Player.currentLevel;
        save._levelBarMaxValue = Player.maxLevel;
        save._lockII = Player.lockII;
        save._playerDamage = Player.damageCount;
        save._playerGoldCount = Player.gold;
        save._playerLevel = Player.level;
        //---------------------------------------------------------------------------------------------------------------
        bf.Serialize(fileStream, save);
        fileStream.Close();
        Debug.Log(path);
    }

    public void Load()
    {
        if (!File.Exists(path)) return;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);
        SaveData save = (SaveData)bf.Deserialize(fileStream);
        fileStream.Close();
        //--------------------------------------------Инициализация переменных для загрузки----------------------------
        Enemy.countBoss = save._countBoss;
        //save._hitEnemyCurrentValue 
        //save._hitEnemyMaxValue
        Player.II = save._II;
        Player.currentLevel = save._levelBarCurrentValue;
        Player.maxLevel = save._levelBarMaxValue;
        Player.lockII = save._lockII;
        Player.damageCount = save._playerDamage;
        Player.gold = save._playerGoldCount;
        Player.level = save._playerLevel;
        //---------------------------------------------------------------------------------------------------------------
    }
}
