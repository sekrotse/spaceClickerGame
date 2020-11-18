using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class partShip : MonoBehaviour
{
    public GameObject[] part;

    void Start()
    {
        for (int i = 0; i < GameVar.ship.Length; i++)
        {
            if (GameVar.ship[i] == 1)
               {
                part[i].SetActive(true);
               }
              else
               {
                 part[i].SetActive(false);
               }
        }
    }
}
