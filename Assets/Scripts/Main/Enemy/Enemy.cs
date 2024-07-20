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

            //플레이어의 체력이 떨어지는 로직

            //체력이 <=0 같을 때 게임을 메인 메뉴로 이동할지, 게임을 종료할지 선택할 수 있는 UI

            MainController.instance.GameOver();
        }

    }
}