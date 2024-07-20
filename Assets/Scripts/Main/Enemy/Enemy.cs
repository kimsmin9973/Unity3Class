using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //
    public SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigidbody2D;


    void LoadComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }







    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{collision.gameObject.name}");

            //�÷��̾��� ü���� �������� ����

            //ü���� <=0 ���� �� ������ ���� �޴��� �̵�����, ������ �������� ������ �� �ִ� UI

            MainController.instance.GameOver();
        }

    }
}