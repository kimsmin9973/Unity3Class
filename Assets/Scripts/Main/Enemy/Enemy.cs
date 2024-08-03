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

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            // ü�� ���� �ڵ带 ���� ����
            player.currentHP = player.currentHP - 1;
            playerUI.SliderValueChange(player.currentHP);
            // ���� �������� üũ �ϴ� ����
            if (player.currentHP <= 0)
            {
                MainController.instance.GameOver();
            }




        }
    }
}