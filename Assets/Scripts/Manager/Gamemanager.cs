using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴
    public static GameManager instance;  // GameManager.instance

    public int difficulty; // 0 : 이지, 1 : 노말, 2 : 하드

    public float score;

    private void Update()
    {
        score += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (score > PlayerPrefs.GetFloat(GameData.BestScore)) ;
            PlayerPrefs.SetFloat(GameData.BestScore, score);
        }
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(GameData.Gamedifficulty)) // HasKey "키값" 없으면 false, true
        {
            difficulty = PlayerPrefs.GetInt(GameData.Gamedifficulty);
        }
    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch (difficulty)
        {
            case 0:
                name = "이지";
                break;
            case 1:
                name = "노말";
                break;
            case 2:
                name = "하드";
                break;
            default:
                name = $"키 : {difficulty} 존재하지 않는 키 값입니다.";
                break;
        }

        return $"선택한 난이도 : {name}";
    }

    public void SaveGameDifficulty()
    {
        PlayerPrefs.SetInt(GameData.Gamedifficulty, difficulty); // GameDifficulty 이름으로. difficulty변수(정수) 저장.

    }
}