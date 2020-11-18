using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenuII : MonoBehaviour
{
    public GameObject menuII;

    void OnMouseDown()
    {
        Debug.Log(Player.II.ToString());
        if (Player.II)
        {
            if (menuII.activeSelf)
            {
                menuII.SetActive(false);
            }
            else
            {
                menuII.SetActive(true);
            }
        }
    }
}
