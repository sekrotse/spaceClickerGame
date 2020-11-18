using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealsLedi : MonoBehaviour
{
    public int Heals = 100;
    public int Crystal = 50;
    public GameObject ClickText;
    
    Game _gameHelper;
    ClickObj clickTextPool;

    public float value = 10;
    public float speed = 2;

    int randomPart = 0;
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<Game>();
        _gameHelper.helsEnemyBar.maxValue = Heals;
        _gameHelper.helsEnemyBar.value = Heals;
        clickTextPool = GameObject.FindObjectOfType<ClickObj>();
        if (Enemy.oldHealth > 0) {
            Heals = Enemy.oldHealth;
            Debug.Log("Health enemy = " + Heals);
        }
    }

    void Update()
    {
        if (_gameHelper.II)
        {
            autoClick();
        }
    }       

    public void GetHit(int damage)
    {
        int healsnew = Heals - damage;
        GameObject canvas = GameObject.Find("Canvas");
        clickTextPool = Instantiate(ClickText, canvas.transform).GetComponent<ClickObj>();
        clickTextPool.StartMotion(damage);
        Destroy(clickTextPool.gameObject, 3f);

        if (healsnew <= 0)
        {
            _gameHelper.TakeCrystal(Crystal);
            Destroy(gameObject);
            Debug.Log("Destroy " + Enemy.countBoss);
            _gameHelper.SpawnEnemy();
            int num = Enemy.countBoss % Constant.whoIsBoss; 
            if (num == 0) {
                _gameHelper.ShowBG();
            }
            Player.currentLevel += (int)(Player.maxLevel * Constant.cofLevel); 
            _gameHelper.levelBar.value = Player.currentLevel;

            randomPart = Random.Range(0, 5);
            Debug.Log(randomPart);
            GameVar.ship[randomPart] = 1;
        }
        Heals = healsnew;
        _gameHelper.helsEnemyBar.value = Heals;
        Enemy.health = healsnew;
        Enemy.oldHealth = healsnew;
    }

    void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Damage");
        GetHit(Player.damageCount);
    }

    void autoClick() {
        value -= Time.deltaTime * speed;
        if (value < 0)
        {
            GetComponent<Animator>().SetTrigger("Damage");
            GetHit(Player.damageCount);
            value = 10;
        }
    }
}
