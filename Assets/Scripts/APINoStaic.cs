using UnityEngine;

public class APINoStaic : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;

    public Transform traA;

    private void Start()
    {
        //���o �D�R�A �ݩ�
        //�C������ A �� ����
        print(objA.tag);
        print(objB.layer);
        print(traA.localScale);

        //�]�w �D�R�A �ݩ�
        //�N �C������B �ϼh �אּ 5
        objB.layer = 5;
        //�N����ؤo��j
        traA.localScale = new Vector3(3, 3, 3);
    }
    private void Update()
    {
        // �ϥ� �D�R�A �y�k
        //���� �� ��k(�Ѽ�)
        //�ܧΪ��� �� ����(X�AY�AZ)
        traA.Rotate(0, 0, 1);
    }
}
