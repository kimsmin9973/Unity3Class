using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� ����
    public static GameManager instance;  // GameManager.instance

    public int difficulty; // 0 : ����, 1 : �븻, 2 : �ϵ�

    public float score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(GameData.Gamedifficulty)) // HasKey "Ű��" ������ false, true
        {
            difficulty = PlayerPrefs.GetInt("GameDifficulty");
        }
    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch (difficulty)
        {
            case 0:
                name = "����";
                break;
            case 1:
                name = "�븻";
                break;
            case 2:
                name = "�ϵ�";
                break;
            default:
                name = $"Ű : {difficulty} �������� �ʴ� Ű ���Դϴ�.";
                break;
        }

        return $"������ ���̵� : {name}";
    }

    public void SaveGameDifficulty()
    {
        PlayerPrefs.SetInt(GameData.Gamedifficulty, difficulty); // GameDifficulty �̸�����. difficulty����(����) ����.

    }
}