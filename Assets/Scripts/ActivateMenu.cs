using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ActivateMenu : MonoBehaviour
{
    public GameObject menuPlayer;
    void OnMouseDown()
    {
        if (menuPlayer.activeSelf)
        {
            menuPlayer.SetActive(false);
        }
        else {
            menuPlayer.SetActive(true);
        }
    }
}
