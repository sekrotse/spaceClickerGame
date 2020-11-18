using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    bool flag = false;
    public int damageCount = 0;
    public int goldCount = 0;
    public int timerCount = 0;
    public int cofUp = 0;
    public int timeBonus = 0;
    public int activeBonus = 0;

    public void Bonus1()
    {
        
        if (GameVar.timer >= timerCount & activeBonus == 1)
        {
            setDamage();
            activeBonus = 0;
        }
    }

    public void Bonus2()
    {
        if (GameVar.timer >= timerCount & activeBonus == 1)
        {
            setGold();
            activeBonus = 0;
        }
    }

    public void Bonus3()
    {
        if (GameVar.timer >= timerCount & activeBonus == 1)
        {
            Player.damageCount *= this.cofUp;
            Player.gold *= this.cofUp;
            GameVar.timerBonus += timeBonus;
            GameVar.tmpCofUp = this.cofUp;
            activeBonus = 0;
            timeBonus = 0;
        }
    }

    public void setDamage() {
        Player.damageCount += this.damageCount;
    }

    public void setGold() {
        Player.gold += this.goldCount;
    }    
}

