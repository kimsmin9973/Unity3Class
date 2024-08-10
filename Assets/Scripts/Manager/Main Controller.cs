using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainController : MonoBehaviour
{
    public static MainController instance;

    public GameObject GameOverPanel;

    [Header("Score")]
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    private float score;

    [Header("Level")]
    public TextMeshProUGUI Level;

    [Header("CountDown")]
    public TextMeshProUGUI startCountText;
    public GameObject StartUIPanel;
    public bool isGameStart;
   
    IEnumerator Countdown()
    {
        startCountText.text = "3";
        yield return new WaitForSeconds(1f);
        startCountText.text = "2";
        yield return new WaitForSeconds(1f); startCountText.text = "1";
        yield return new WaitForSeconds(1f); startCountText.text = "Start";
        yield return new WaitForSeconds(0.5f);
        StartUIPanel.SetActive(false);
    }


    private void Update()
    {
        score = GameManager.instance.score;
        //CurrentScore.text = $"�������� : {GameManager.instance.score}";

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
        
    public void GameOver()
    {
        GameOverPanel.SetActive(true);   // ���� ������ ���� ���� UI Ȱ��ȭ
         //���� ������ �ְ� �������� ���� �� ����
        if (score > PlayerPrefs.GetFloat(GameData.BestScore))
        //{
            PlayerPrefs.SetFloat(GameData.BestScore, score);
            BestScore.text = $"�ְ����� : {GameManager.instance.score}"; 
        //}
        //else  ���� ������ �ְ� �������� ���� ��, ������ �ְ� ������ �ҷ��´�.
        //{
        //    BestScore.text = $"�ְ����� : {PlayerPrefs.GetFloat(GameData.BestScore)}";
        //}

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

}