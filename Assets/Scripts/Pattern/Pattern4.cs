using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4 : MonoBehaviour
{
    public Transform startPos;  //���� ����� ��ġ
    public int bulletCount;            //ź���� ����
    public float bulletSpeed;          //ź���� �ӵ�
    public GameObject bulletPrefab;    //ź�� ������

    public int MaxBulletCount;         //���� ���Ḧ �ľ��ϱ� ���� ����
    private void Awake()
    {
        MaxBulletCount = bulletCount;
    }

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
        int count = 0;

        yield return new WaitForSeconds(1f); // ���� ��� �ð�

        while (count < MaxBulletCount)
        {
            CircleEmit();
            count++;
            yield return new WaitForSeconds(1f);
        }
        gameObject.SetActive(false);
    }

    void CircleEmit()
    {
        float angle = 360 / (float)bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab,
                startPos.position, Quaternion.identity);

            float bulletAngle = angle * i; //12��, 24��, 36��, ./...
            float x = Mathf.Cos(bulletAngle * Mathf.PI / 180);
            float y = Mathf.Sin(bulletAngle * Mathf.PI / 180);

            //������ ���� �������� �þ� ������ Vector2 ���� ���ϴ� ����

            bullet.GetComponent<MovementTransform2D>().MoveSpeed(bulletSpeed);
            bullet.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));
        }
    }
}
