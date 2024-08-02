using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    public GameObject warningSign;
    public GameObject enemyPrefab;

    public Transform spawnPosition;

    // �� ���� ��ȯ�� ���ΰ�?
    public int spawnCount = 1;
    // �� �ʸ� �ֱ�� ������ ���ΰ�?
    public float spawnCycle = 1f;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(-8.53f, 1.54f, 0);

        GameObject warning = Instantiate(warningSign, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(1f);
        Destroy(warning);
        CreateEnemyInstance(1);

        gameObject.SetActive(false);

    }

    private void CreateEnemyInstance(int count)
    {
        Vector3 spawnPos = new Vector3(-8.53f, 1.54f, 0);
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

}
