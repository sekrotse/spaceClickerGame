using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewPage : MonoBehaviour
{
    public void NextPage(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
