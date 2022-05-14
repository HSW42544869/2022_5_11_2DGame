using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("�ؼ�")]
    public Transform targrt;
    [Header("�l�ܳt��"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("��v���W��P�U�譭��")]
    public Vector2 limit = new Vector2(1.5f, 4.5f);
    /* �{�Ѵ���
    public float a = 0;
    public float b = 100;

    public Vector2 V2A = new Vector2(0, 0);
    public Vector2 V2B = new Vector2(100, 100);
    private void Start()
    {
        //����
        //���o���I�����Y�ӭ�
        //0 - 10 ���o 50% ���� 5
        print(Mathf.Lerp(0, 100, .7f));
    }
    private void Update()
    {
        a = Mathf.Lerp(a, b, .1f);

        V2A = Vector2.Lerp(V2A, V2B, .1f);
    }*/
    /// <summary>
    /// �l��
    /// </summary>
    private void Track()
    {
        
        Vector3 posA = transform.position;      // ���o��v���y��
        Vector3 posB = targrt.position;         // ���o�ؼЮy��
        
        posB.z = -10;                           //�T�w Z �b

        posB.y = Mathf.Clamp(posB.y, limit.x, limit.y);      //�N Y �b���b����d��
        
        // Time.deltaTime �@�ժ��ɶ�
        posA = Vector3.Lerp(posA, posB, .6f * Time.deltaTime); //����
        
        transform.position = posA;              // ��v�� �y�� = A�I
    }
    private void LateUpdate()
    {
        Track();
    }
}
