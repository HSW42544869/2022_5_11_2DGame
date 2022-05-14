using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region ���
    //���ʳt��
    [Header("���ʳt��"), Tooltip("���ʳt��"), Range(0, 1000)]
    public float movespeed = 10.5f;
    //�l�u
    [Header("�l�u"), Tooltip("�l�u")]
    public GameObject bullet;
    //�l�u�ͦ��I
    [Header("�l�u�ͦ��I"), Tooltip("�l�u�ͦ��Ū���")]
    public Transform point;
    //�l�u�t��
    [Header("�l�u�t��"), Range(0, 5000)]
    public int bulletspeed = 3500;
    //�}�j����
    [Header("�}�j����"), Tooltip("�}�j����")]
    public AudioClip shotsound;
    //�l�ܽd��
    [Header("�l�ܽd��"), Range(0, 1000)]
    public float rangeTrack = 10.5f;
    //�����d��
    [Header("�����d��"), Range(0, 1000)]
    public float rangeAttack = 8.5f;
    [Header("�}�j������"), Range(0, 10)]
    public float intervalAttack = 2.5f;
    private float time;
    [Header("���a����")]
    public Transform player;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion

    /// <summary>
    /// �p�ɾ�:�����ɶ�
    /// </summary>
    #region ��k

    /// <summary>
    /// ����
    /// </summary>
    private void Move()
    {
        //���V���a: �p�G���a�� X �j�� �ĤH�� X ���� 0�A�_�h ���� 180
        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        float dis = Vector3.Distance(player.position, transform.position);
        //print("�Z��:" + dis);
        // �p�G �Z�� < ���� : ����
        if (dis < rangeAttack)
        {
            Fire();
        }
        // �p�G �Z�� < �l�� : �l��
        else if (dis < rangeTrack)
        {
            rig.velocity = transform.right * movespeed;
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
        }
    }
    /// <summary>
    /// �}�j
    /// </summary>
    private void Fire()
    {
        rig.velocity = new Vector2(0, rig.velocity.y);


        if (time >= intervalAttack)
        {
            time = 0;
            aud.PlayOneShot(shotsound, Random.Range(0, 0.5f));
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed + transform.up * 100);
        }
        else
        {
            time += Time.deltaTime;     //�֥[�ɶ�
        }

    }
    /// <summary>
    /// ���`
    /// </summary>
    private void Dead()
    {
        enabled = false;
        ani.SetBool("���`�}��", true);
        GetComponent<CapsuleCollider2D>().enabled = false;  //�����I����
        rig.Sleep();                                        //����ε�
        Destroy(gameObject,2.5f);                           //�R������
    }
    #endregion

    #region �ƥ�
    /// <summary>
    /// �l�ܡB�����d��
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }
    private void Awake()
    {
        //���a�ܧ� = �C������.�M��("���a����W��").�ܧ�
        //transform ���ܥL����ƫ��A
        player = GameObject.Find("���a").transform;
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "�l�u")
        {
            Dead();
        }
    }
    #endregion
}
