
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public TextMeshProUGUI levelText;


    private void Update()
    {
        levelText.text = GameManager.instance.ReturnCurrentDifficulty();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1); // 2��° ��ġ�� �մ� ���� �ε��Ѵ�.
                                   // �迭�� 0��°... �迭�� 1�� �ش��ϴ� ���� �ε��ض�.
    }

    public void SwitchMenuTo(GameObject uiMenu)    // ��ư�� �����ų �Լ� �̸�(MainMenu_UI�ݰ�, ���ϴ� UI ����)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false); // MainMenu ������ �ڽĵ��� ���� ��Ȱ��ȭ ���Ѷ�.
        }

        uiMenu.SetActive(true); // ��� ������Ʈ�� Ȱ��ȭ ���Ѷ�
    }

    public void SetGameLevel(int level)
    {
        GameManager.instance.difficulty = level;
        GameManager.instance.SaveGameDifficulty();
    }
}