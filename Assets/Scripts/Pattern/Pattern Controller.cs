using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public GameObject[] patterns;

    // ������ ���� ��ȣ
    [Header("Currnet Pattern Info")]
    public int patternIndex = 0;
    public GameObject currentPattern;

    void Start()
    {
        foreach (var pattern in patterns)
        {
            pattern.gameObject.SetActive(false);
        }

        ChangePattern();
    }

    private void Update()
    {
        if (currentPattern.activeSelf == false)
        {
            ChangePattern();
        }

        // ChangePattern
    }

    // 0 ~ 9  .. ���������� ����Ǵ� �ڵ� ����.
    // 0 ~ 9 �������� �Ѱ��� ����ǵ��� �ϰ� ���� �� �ִ�.

    public void ChangePattern()
    {
        currentPattern = patterns[patternIndex]; // ����s �迭�� ����ִ� ���ӿ�����Ʈ�� ������ �����Ѵ�.
        currentPattern.SetActive(true);

        patternIndex++;

        if (patternIndex >= patterns.Length)
        {
            patternIndex = 0;
        }

    }
}
