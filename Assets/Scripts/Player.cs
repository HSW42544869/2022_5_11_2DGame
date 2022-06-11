using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region ���
    //�iŪ�ʡB���@�ʡB�X�R��
    [Header("���ʳt��"), Tooltip("���ʳt��"), Range(0, 1000)]
    public float movespeed = 10.5f;
    [Header("���D����"), Tooltip("���D����"), Range(0, 3000)]
    public int jumphigh = 100;
    [Header("�O�_�b�a���W"), Tooltip("�O�_�b�a���W")]
    public bool isground = false;
    [Header("�l�u"), Tooltip("�l�u")]
    public GameObject bullet;
    [Header("�l�u�ͦ��I"), Tooltip("�l�u�ͦ��Ū���")]
    public Transform point;
    [Header("�l�u�t��"), Range(0, 5000)]
    public int bulletspeed = 3500;
    [Header("�}�j����"), Tooltip("�}�j����")]
    public AudioClip shotsound;
    [Header("�ͩR�ƶq"), Range(0, 10)]
    public int live = 3;
    [Header("�ˬd�a���첾")]
    public Vector2 offset;
    [Header("�ˬd�a���b�|")]
    public float radius = .3f;

    /// <summary>
    /// �O�_�b�ǰe���̭�
    /// </summary>
    public bool inDoor;

    //����
    private int fraction = 0;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private GameManager gm;
    #endregion
    /// <summary>
    /// �ƥ�:���-�bStart ���e����@��
    /// </summary>
    private void Awake()
    {
        //���� = ���o����<���餸��>();
        //��쨤�⨭�W�����餸��s��� rig ��줺
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        // �z�L <����> ���o���� 
        //�ȭ���<����>�b���W�u���@��
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        Move();
        Fire();
        Jump();

        NextLevel();
    }
    #region ����
    /// <summary>
    /// ���ʥ\��
    /// </summary>
    private void Move()
    {
        //�������I�� = ��J �� ���o�b�V("����") - ���kAD
        float h = Input.GetAxis("Horizontal");
        //���� �� �[�t�� = �s �G���V�q(�������I�� * �t�סA����[�t��Y)
        rig.velocity = new Vector2(h * movespeed, rig.velocity.y);
        //�ʵe �� �]�w���L��(�ѼƦW�١A���� ������ 0 �Ŀ�)
        ani.SetBool("�]�B�}��", h != 0);
        // KeyCode �C�|(�U�ԬO���) - �Ҧ���J���ﶵ �ƹ��B��L�B�n��
        if (Input.GetKeyDown(KeyCode.D))
        {
            // transform �������ܧΤ���
            // eulerAngles �کԨ��� 0 - 180 - 270 - 360
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    #endregion
    #region ���D
    /// <summary>
    /// ���D�\��
    /// </summary>
    private void Jump()
    {
        //�p�G����b�a���W �åB ���U�ťի� �~����D
        //isground == true ���P�� isground
        if (isground == true && Input.GetKeyDown(KeyCode.Space))
        {
            isground = false;           //���A�a���W�F
            rig.AddForce(transform.up * jumphigh);
        }
        //�p�G ���z �� ��νd�� �I�� ��h 8 ���a�O����(1<<8(�����B���))
        else if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + offset, radius, 1 << 8))
        {
            isground = true;
        }
        //�S���I��a�O����
        else
        {
            isground = false;       //���b�a���W�F
        }
    }
    #endregion
    #region �}�j
    /// <summary>
    /// �}�j�\��
    /// </summary>
    private void Fire()
    {
        //���U����
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(shotsound, Random.Range(.5f, .8f));
            //�ͦ��l�u�b�j�f
            //�ͦ�(����B�y�СB����)
            //temp =>�Ȧs����
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            //���l�u��
            //AddForce�[�t��
            //�W �� transform.up
            //�S �� transform.right
            //�e �� transform.forward
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed + transform.up * 100);
            //�}�j����
        }
    }
    #endregion
    #region ���`
    /// <summary>
    /// ���`�\��
    /// </summary>
    /// <param name="obj">�I�쪫�󪺦W��</param>
    public void Dead(string obj)
    {
        //�p�G ����W�� == ���`�ϰ�
        //���� ==
        if (obj == "���`�ϰ�" || obj == "�ĤH�l�u" || obj == "����")
        {
            //�p�G ���`�}�� �� ture �N ���X
            if (ani.GetBool("���`�}��")) return;

            //enabled = false; ���P�� this.enabled = false;
            enabled = false;        //�������}��
            ani.SetBool("���`�}��", true);

            //����I�s("��k�W��",����I�s)
            //���O�W��.�R�A����.�s��
            if(GameManager.live>1)Invoke("Replay", 2);

            //�I�s GM �B�z���a���`
            gm.PlayerDead();
        }
    }
    #endregion
    /// <summary>
    /// ���s���J�C��:���s���J��e���d
    /// </summary>
    private void Replay()
    {
        // ���J����(��e���� �� �W��)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// OCE �I���ɰ���@�����ƥ�
    /// Collision �I�쪫�󪺸�T
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.tag);
    }
    /// <summary>
    /// Ĳ�o�ƥ�:
    /// ��ӸI�����󦳨䤤�@�ӤĿ� IsTrigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "�ǰe��") inDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "�ǰe��") inDoor = false;
    }
    /// <summary>
    /// �e���U�@��
    /// </summary>
    private void NextLevel()
    {
        if (inDoor == true && Input.GetKeyDown(KeyCode.W))                  //�p�G �b���̭� �åB ���U W
        {
            //���o�{�b�����s��
            int livIndex= SceneManager.GetActiveScene().buildIndex;         //���o��e�����s��

            livIndex++;                                                     //��e�����s���[1

            SceneManager.LoadScene(livIndex);                               //���J�U�@��
        }
    }
    /// <summary>
    /// ø�s�ϥ�:����ܩ�������O
    /// �]�i�ϥ�OnDrawGizmosSelected(���I������~����ݨ�)
    /// </summary>
    private void OnDrawGizmos()
    {
        //�ϥ� �C��
        //�]�i�ϥ�Gizmos.color = Color.red;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //�ϥ� ø�s�y��((�]�O2���V�q�ҥH���s�W)�����I�A�b�|)
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y) + offset, radius);
    }
}
