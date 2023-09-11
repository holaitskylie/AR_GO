using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }

    private static UIManager m_instance; //싱글턴이 할당된 변수 

    public TextMeshProUGUI scoreText;

    public GameObject gameoverUI;
    public GameObject RestartUI;
    public GameObject MainUI;

    public int sceneNumber;

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }

    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

    public void SetActiveRestartUI(bool active)
    {
        RestartUI.SetActive(active);
    }

    public void SetActiveMainUI(bool active)
    {
        MainUI.SetActive(active);
    }

    public void GameRestart(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

}
