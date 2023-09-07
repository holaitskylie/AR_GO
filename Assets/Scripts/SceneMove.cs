using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public int SceneNumber;

    public void SceneOpen()
    {
        SceneManager.LoadScene(SceneNumber);   
    }
}
