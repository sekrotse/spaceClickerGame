using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPower : MonoBehaviour
{
    public int price;
    public int damage;
    public Text money;
    Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindObjectOfType<Game>();
        money.text = price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = price.ToString();
    }
    public void Buy() {
        game = GameObject.FindObjectOfType<Game>();

        if (Player.gold >= price) {
            Player.gold -= price;
            Player.damageCount += damage;
            Debug.Log("damage = " + Player.damageCount);

            price += 50;
            damage += 5;
        }
    }

    public void BuyII() {
        game = GameObject.FindObjectOfType<Game>();

        if (Player.gold >= price && Player.level >= Constant.levelII && Player.II != true)
        {
            Player.gold -= price;
            game.II = true;
            Player.II = true;
            game.lockII = false;
            Player.lockII = false;
            Debug.Log("Buy II");
        }
    }
}
