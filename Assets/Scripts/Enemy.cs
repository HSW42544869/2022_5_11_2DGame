using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 欄位
    //移動速度
    [Header("移動速度"), Tooltip("移動速度"), Range(0, 1000)]
    public float movespeed = 10.5f;
    //子彈
    [Header("子彈"), Tooltip("子彈")]
    public GameObject bullet;
    //子彈生成點
    [Header("子彈生成點"), Tooltip("子彈生成空物件")]
    public Transform point;
    //子彈速度
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 3500;
    //開槍音效
    [Header("開槍音效"), Tooltip("開槍音效")]
    public AudioClip shotsound;
    //追蹤範圍
    [Header("追蹤範圍"), Range(0, 1000)]
    public float rangeTrack = 10.5f;
    //攻擊範圍
    [Header("攻擊範圍"), Range(0, 1000)]
    public float rangeAttack = 8.5f;
    [Header("開槍間格秒數"), Range(0, 10)]
    public float intervalAttack = 2.5f;
    private float time;
    [Header("玩家物件")]
    public Transform player;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion

    /// <summary>
    /// 計時器:紀錄時間
    /// </summary>
    #region 方法

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //面向玩家: 如果玩家的 X 大於 敵人的 X 角度 0，否則 角度 180
        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        float dis = Vector3.Distance(player.position, transform.position);
        //print("距離:" + dis);
        // 如果 距離 < 攻擊 : 攻擊
        if (dis < rangeAttack)
        {
            Fire();
        }
        // 如果 距離 < 追蹤 : 追蹤
        else if (dis < rangeTrack)
        {
            rig.velocity = transform.right * movespeed;
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
        }
    }
    /// <summary>
    /// 開槍
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
            time += Time.deltaTime;     //累加時間
        }

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        enabled = false;
        ani.SetBool("死亡開關", true);
        GetComponent<CapsuleCollider2D>().enabled = false;  //關閉碰撞器
        rig.Sleep();                                        //剛體睡著
        Destroy(gameObject,2.5f);                           //刪除物件
    }
    #endregion

    #region 事件
    /// <summary>
    /// 追蹤、攻擊範圍
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
        //玩家變形 = 遊戲物件.尋找("玩家物件名稱").變形
        //transform 改變他的資料型態
        player = GameObject.Find("玩家").transform;
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
        if (collision.gameObject.tag == "子彈")
        {
            Dead();
        }
    }
    #endregion
}
