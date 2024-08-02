using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    new Rigidbody2D rigidbody2D;

    public PlayerUI playerUI;

    void LoadComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        playerUI = FindObjectOfType<PlayerUI>();

    }

    private void Awake()
    {
        LoadComponents();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{collision.gameObject.name}");

            //�÷��̾��� ü���� �������� ����

            // ü���� <=0 ���� �� ������ ���� �޴��� �̵�����, ������ �������� ������ �� �ִ� UI ����.
            // �÷��̾� ü���� �����ؼ�, �÷��̾� ü�°� ��

                    //player = collision.gameObject.GetComponent<PlayerController>();

            // ü�� ���� �ڵ带 ���� ����
            //player.currentHp = player.currentHp - 1;
            //playerUI.SliderValueChange(player.currentHp);
            // ���� �������� üũ �ϴ� ����
            //if (player.currentHp <= 0)
            {
                MainController.instance.GameOver();
            }




        }
    }
}