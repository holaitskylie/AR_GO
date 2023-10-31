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

    private bool isPaused = false; //게임 일시 정지 여부를 나타내는 변수

    public GameObject gameoverUI;
    public GameObject RestartUI;
    public GameObject MainUI;
    public GameObject OptionImageUI;

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

    public void OptionUI(Button button)
    {
        //게임이 일시 정지되어 있지 않다면
        if (!isPaused)
        {
            //게임 일시 정지
            Time.timeScale = 0f;
            isPaused = true;

            //OptionImageUI 활성화
            OptionImageUI.SetActive(true);
        }
    }

    public void ContinueUI(Button button)
    {
        if (isPaused)
        {
            //게임 재개
            Time.timeScale = 1f;
            isPaused = false;

            OptionImageUI.SetActive(false);
        }
    }
}
