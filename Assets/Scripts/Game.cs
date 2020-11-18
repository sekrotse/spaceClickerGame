using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text PlCrystalUI;
    public GameObject EnemyPrefab;
    public GameObject LockII;
    public Slider levelBar;
    public Slider helsEnemyBar;
    public Text level;
    public bool II = false;
    public bool lockII = true;
    string[] imgNames = new string[] { "bg", "bg1", "bg2"};
    int imgNumber, _curentTime, _gameTime;

    void Start()
    {
        InvokeRepeating("Timer", 0, 1);
        level.text = Player.level.ToString();
        II = Player.II;
        PlCrystalUI.text = Player.gold.ToString();
        levelBar.value = Player.currentLevel;
        levelBar.maxValue = Player.maxLevel;
        lockII = Player.lockII;
    }

    void Timer()
    {  
        //для начисленя голды
        _curentTime++;
        if (_curentTime >= 300)
        {
            TakeCrystal(500);
            _curentTime = 0;
        }

        //счетчик для бонусов
        _gameTime = GameVar.timer + 1;
        GameVar.timer = _gameTime;

        //временный бонус
        if (GameVar.timerBonus > 0) {
            GameVar.timerBonus = GameVar.timerBonus - 1;
            Debug.Log(GameVar.timerBonus);
            if (GameVar.timerBonus == 1)
            {
                Player.damageCount /= GameVar.tmpCofUp;
                Player.gold /= GameVar.tmpCofUp;
                GameVar.tmpCofUp = 1;
            }
        }

    }

    void Update()
    {
        PlCrystalUI.text = Player.gold.ToString();
        if (levelBar.value >= Player.maxLevel)
        { 
            Player.level = Player.level + 1;
            level.text = Player.level.ToString();
            Player.maxLevel = (int)(Player.maxLevel * Constant.cofUpLevel);
            Player.currentLevel = (int)(levelBar.value - Player.oldLevel);
            levelBar.value = Player.currentLevel;
            Player.damageCount += (int)Constant.damageEndLevel;
            levelBar.maxValue = Player.maxLevel;
            Player.oldLevel = Player.maxLevel;
        }
        if (!lockII) {
            LockII.SetActive(false);
        }
    }

    public void TakeCrystal(int crystal)
    {
        Player.gold += crystal; 
    }

    public void SpawnEnemy()
    {
        int key = Enemy.countBoss % Constant.whoIsBoss;
        if (key == 0)
        {
            GameObject lediObj = Instantiate(EnemyPrefab);
            Enemy.healsNew = (int)(Enemy.healsNew * Constant.cofEnemyBoss);
            Enemy.health = 0; 
            lediObj.GetComponent<HealsLedi>().Heals = Enemy.healsNew;
            lediObj.GetComponent<HealsLedi>().Crystal = Constant.crystalEnemyBoss;
            lediObj.SetActive(true);
            Player.damageCount += Constant.damageEnemyBoss;
            Enemy.countBoss++;
        }
        if (key != 0)
        {
            GameObject lediObj = Instantiate(EnemyPrefab);
            Enemy.healsNew = (int)(Enemy.healsNew * Constant.cofEnemy);
            Enemy.health = 0;
            lediObj.GetComponent<HealsLedi>().Heals = Enemy.healsNew;
            lediObj.GetComponent<HealsLedi>().Crystal = Constant.crystalEnemy;
            lediObj.SetActive(true);
            Player.damageCount += Constant.damageEnemy;
            Enemy.countBoss++;
            if (Enemy.countBoss == 4) {
                Player.damageCount += 10;
            }
        }
    }

    public void ShowBG() {
        imgNumber = (imgNumber + 1) % imgNames.Length;
        var name = imgNames[imgNumber];
        GameObject.Find("Canvas").GetComponent<Image>().sprite = Resources.Load<Sprite>(name);
    }

}

