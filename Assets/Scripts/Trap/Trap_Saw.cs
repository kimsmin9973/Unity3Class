using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;       // ��Ϲ����� �̵��� ��ġ�� ������ ����
    public float speed = 5f;
    public int moveIndex = 0;
    public bool OnGoingForward = true;
    public bool IsTrapOn = true;           // MoveTrap�Լ��� �̵� ��ų�� ���� �����ϴ� ����
    public float stopTime = 1f;
    private void Start()
    {
        anim = GetComponent<Animator>();

        isWorking = true;
    }

    private void Update() // ��ǻ�� ���� ������ �޴´�.
    {
        anim.SetBool("isWorking", isWorking);

        // if(���� == true)
        //StartCoroutine(CoMoveTrap());  �ڷ�ƾ�� Update���� �Ժη� ����ϸ� �ȵȴ�.
        // IsTrapon �� ���� MoveTrap�� ���� ��Ű�� ����
        if(IsTrapOn == true)
        {
            MoveTrap();
        }
    }

    IEnumerator CoMoveTrap()
    {
        IsTrapOn = false;
        yield return new WaitForSeconds(stopTime);
        IsTrapOn = true;
    }

    private void MoveTrap()
    {
        // ������� 0.0016 ��
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed * Time.deltaTime);

        // ���ǹ� - ������ ��ǥ�� �������� �����ߴ���?
        if(Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex = moveIndex + 1;
            StartCoroutine(CoMoveTrap());
        }
        // ���� ��ǥ ������ ������.. move Index = 0.
        if(movePositions.Length <= moveIndex)
        {
            moveIndex = 0;
        }
    }


    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
