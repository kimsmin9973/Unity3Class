using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    public GameObject enemyPrefab;

    // �� ���� ��ȯ�� ���ΰ�?
    public int spawnCount = 5;
    // �� �ʸ� �ֱ�� ������ ���ΰ�?
    public float spawnCycle = 1f;

    private void Start()
    {
        //InvokeRepeating(nameof(CreateEnemyInstance), spawnCycle, 1);
        StartCoroutine(SpawnEnemy());
    }


    private void OnEnable()
    {
        //InvokeRepeating(nameof(CreateEnemyInstance), spawnCycle, 1);
        StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        // ������ ���۵Ǳ� ���� ���带 �߰��� �� �ֽ��ϴ�.
        // ���� �˸�.
        yield return new WaitForSeconds(1f);

        int repeatTime = 10;

        for (int i = 0; i < repeatTime; i++)
        {
            CreateEnemyInstance(spawnCount);
            yield return new WaitForSeconds(spawnCycle);
        }


    }

    private void CreateEnemyInstance(int count)
    {

        for (int i = 0; i < count; i++)
        {
            float randomValue = Random.Range(-16, 16);
            Vector3 spawnPosition = new Vector3(randomValue, 9, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
