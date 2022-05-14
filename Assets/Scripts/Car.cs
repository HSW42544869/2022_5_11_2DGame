using UnityEngine;

public class Car : MonoBehaviour
{
    #region ���
    [Header("�o�O�T����CC��"), Tooltip("�o�O�T����CC��")]
    [Range(500, 5000)]
    public int cc = 2000;
    [Header("�o�O�T�������q"), Range(500, 2000)]
    public float weight = 1500.5f;
    public string brand = "BMW";
    [Header("�O�_���ѵ�")]
    [Tooltip("�Ŀ�N���ѵ��A�����N��S�ѵ�")]
    public bool haveWindow = true;

    //��L����:�C��B�y�СB 2~4�B�C������B����(�ݩʭ��O�W����r Rigidbody2D�BCollider2D...)

    public Color red = Color.red;
    public Color yellow = Color.yellow;
    public Color myCollor = new Color(0.3f, 0, 0.9f);

    //2��~4�� �V�q
    public Vector2 pos0 = Vector2.zero;
    public Vector2 pos1 = Vector2.one;
    public Vector2 pos2 = new Vector2(7,9);

    public Vector3 posV3 = Vector3.one;
    public Vector4 posV4 = Vector4.one;

    //�C������P���� ���ݭn ���w ��
    public GameObject obj;              //�i�H�s��սu������P�w�s��
    public Transform tra;
    public SpriteRenderer sr;
    #endregion
    //�ƥ�:�}�l - ����C���ɰ���@��
    private void Start()
    {
        //��X�T��(�T��) - ��ܦb Console �����W
        print("���o�A�U�w");

        //Drive(1);
        shoot(1,2);
        shoot(2, 300);
    }
    //�ƥ�:��s - ��1�����60��
    //�B�z:���򤺮e�Ϊ��a��J - ��L�B�ƹ��P�n��
    private void Update()
    {
        print("�ڦb��s�ƥ�̭�");
        Drive(.1f);
    }

    //��k:
    //�w�q�{���϶����y�k
    //�y�k:
    //�׹��� �Ǧ^���� �W�� (�Ѽ�) { �{���϶�; }
    //�Ѽƻy�k:�Ѽ����� �ѼƦW��(���w ��)
    //���w�]�Ȫ��Ѽƭn��b�̥k��
    //�L�Ǧ^ void
    //��k�ݭn�Q�I�s�~�|����
    private void Drive(float speed)
    {
        print("�}����...");
        //�첾
        transform.Translate(speed, 0, 0);
    }
    /// <summary>
    /// �o�g�}�b���\��
    /// </summary>
    /// <param name="count"></param>
    /// <param name="speed"></param>
    private void shoot(int count,int speed = 500)
    {
        print("�o�g�}�b:" + count);
        print("�}�b�t��:" + speed);
    }
}
