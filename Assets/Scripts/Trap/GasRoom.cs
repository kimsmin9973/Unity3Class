using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasRoom : MonoBehaviour
{
    private bool isGasState = false;                        // �ڱ��忡 �� �ִ� ���¶��... �÷��̾��� ü���� 1�� ���� ��Ų��.

    public float checkTime = 2f;
    private float Timer = 0;
    private int PlayerHP = 100;
    private int Damage = 1;

    // Debug.Log(���� ���¸� ����غ��� �ڵ� �ۼ�)
    // Tag�� ����ؼ� Player�� �۵��� �� �ֵ��� �ۼ��غ�����.

    public bool isStayOn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            // Player�� �˾ƾ� �� �ʿ伺�� �ְ���. PlayerController <- �ٸ� Ŭ�������� ���� Ŭ������ ��� ������ ���ΰ�?
            isGasState = true;                            
            Debug.Log($"�÷��̾ ���� ���� ���� ���� : {isGasState}");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = false;                            
            Debug.Log($"�÷��̾ ���� ���� ���� ���� : {isGasState}");
        }
    }

    private void Update() // PlayerController�� Update���� �ۼ��ϴ� �� ������.
    {
        if (isGasState)   // { } ���� �濡 ���� ���� ���� �ۼ��Ѵ�. ü���� ���̴� ������ ���÷� �ۼ��Ͽ���.
        {
            // ���� �ð��� ���� Time.deltaTime
            //checkTime = 2f;
            Timer += Time.deltaTime; // 0.016. ��ǻ�͸��� �ٸ���. 1Frame �����ϴ� �ð�.
            if(Timer >= checkTime)
            {
                Timer = 0;
                PlayerHP = PlayerHP - Damage;
                Debug.Log($"�÷��̾��� ���� ü�� : {PlayerHP}");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            Debug.Log($"�÷��̾ ���� �����̹Ƿ� �÷��̾��� ü���� ���� ��Ű�� �ִ�.");
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"�÷��̾��� ���� ü�� : {PlayerHP}");
        }
    }
}
