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

    private static UIManager m_instance; //�̱����� �Ҵ�� ���� 

    public TextMeshProUGUI scoreText;

    private bool isPaused = false; //���� �Ͻ� ���� ���θ� ��Ÿ���� ����

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
        //������ �Ͻ� �����Ǿ� ���� �ʴٸ�
        if (!isPaused)
        {
            //���� �Ͻ� ����
            Time.timeScale = 0f;
            isPaused = true;

            //OptionImageUI Ȱ��ȭ
            OptionImageUI.SetActive(true);
        }
    }

    public void ContinueUI(Button button)
    {
        if (isPaused)
        {
            //���� �簳
            Time.timeScale = 1f;
            isPaused = false;

            OptionImageUI.SetActive(false);
        }
    }
}
