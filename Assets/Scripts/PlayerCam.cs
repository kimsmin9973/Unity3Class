using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // ������ �������� ����

    Vector3 offset;                            // ī�޶�� �÷��̾��� ��ġ ����
    public Transform playerTransform;          // �÷��̾��� ���� ��ġ (�÷��̾ ������ �� ����ǰ�, ī�޶� �ش� ��ġ�� ���̸�ŭ �Ѿư�)
    public float fixedYPosition;               // ī�޶��� Y ��ġ�� ������Ű�� ���� ���� ��
    [Range(0f, 1f)]                            // �Ʒ� ������ ũ�⸦ �����ϴ� ����. <- C# Attribute
    public float smoothValue;                  // ī�޶��� ���� ����(�ε巯�� ������ ����) �� ��ġ ���̿� ��� ���� Percent �̵��� ����..

    // Start is called before the first frame update
    void Start()
    {
        // transform = ī�޶�, ������ ��, ����  ->   A - B :   B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ 
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }

    public void SetOffset()
    {
        offset = transform.position - playerTransform.position;
    }

    // Lerp.  Linear Interpolation ���� ����
    // �� ������ �� ��, �� �� ������ ������ ��ġ�� ���� �ľ��ϱ� ���� ������ ����.
    // �� ��(Point) -(Vector3). ī�޶��� ���� ��ġ. �̵� �ϰ� ���� ��ġ , ī�޶� -> ( Point )-> ��ǥ

    // �÷��̾��� ������ Update ����� �Ŀ� ī�޶� �ѾƼ� �����̱� ���ؼ�.
    // Vector3.Lerp�Լ� ������ �Ǿ� �ֽ��ϴ�.
    void LateUpdate()
    {
        // �÷��̾ ������ �̴ϴ�.
        //offset = transform.position - playerTransform.position; 

        Vector3 targetPosition = playerTransform.position + offset;   // ������ �� �������� ī�޶��� ��ġ�� ���Ѵ�.
        targetPosition.y = fixedYPosition;                            // ī�޶��� Y(����)�� ������Ų��.0
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);
        // ������ �� 
        transform.position = smoothPosition;                         // ������ �÷��̾��� x�������θ� ����ٴϰ�, Y�� ������Ų ������ ī�޶� �̵���Ų��.
    }
}
