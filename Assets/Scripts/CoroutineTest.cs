using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�׳� ȣ��");
        StartCoroutine(CoTest());
        SubTest();
        Debug.Log("�׳� ȣ��2");

    }

    IEnumerator CoTest()
    {
        Debug.Log("[�ڷ�ƾ] : 01 ȣ��");
        Debug.Log("[�ڷ�ƾ] : 02 ȣ��");

        yield return new WaitForSeconds(1);
        Debug.Log("[�ڷ�ƾ] : 03 ȣ��");
    }

    void SubTest()
    {
        Debug.Log("[���� �׽�Ʈ �Լ�] : 01ȣ��");
        Debug.Log("[���� �׽�Ʈ �Լ�] : 02ȣ��");
        Debug.Log("[���� �׽�Ʈ �Լ�] : 03ȣ��");
    }
}
