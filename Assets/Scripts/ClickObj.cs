using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObj : MonoBehaviour
{
    private bool move;
    private Vector2 randomVector;
    void Update()
    {
        if (!move) return;
        transform.Translate(randomVector * Time.deltaTime);
    }

    public void StartMotion(int scoreDamage)
    {
        GetComponent<Text>().text = "+" + scoreDamage;
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        move = true;     
    }

}
