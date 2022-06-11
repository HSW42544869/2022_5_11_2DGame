using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region 欄位
    //可讀性、維護性、擴充性
    [Header("移動速度"), Tooltip("移動速度"), Range(0, 1000)]
    public float movespeed = 10.5f;
    [Header("跳躍高度"), Tooltip("跳躍高度"), Range(0, 3000)]
    public int jumphigh = 100;
    [Header("是否在地面上"), Tooltip("是否在地面上")]
    public bool isground = false;
    [Header("子彈"), Tooltip("子彈")]
    public GameObject bullet;
    [Header("子彈生成點"), Tooltip("子彈生成空物件")]
    public Transform point;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 3500;
    [Header("開槍音效"), Tooltip("開槍音效")]
    public AudioClip shotsound;
    [Header("生命數量"), Range(0, 10)]
    public int live = 3;
    [Header("檢查地面位移")]
    public Vector2 offset;
    [Header("檢查地面半徑")]
    public float radius = .3f;

    /// <summary>
    /// 是否在傳送門裡面
    /// </summary>
    public bool inDoor;

    //分數
    private int fraction = 0;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private GameManager gm;
    #endregion
    /// <summary>
    /// 事件:喚醒-在Start 之前執行一次
    /// </summary>
    private void Awake()
    {
        //剛體 = 取得元件<剛體元件>();
        //抓到角色身上的鋼體元件存放到 rig 欄位內
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        // 透過 <類型> 取得物件 
        //僅限於此<類型>在場上只有一個
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        Move();
        Fire();
        Jump();

        NextLevel();
    }
    #region 移動
    /// <summary>
    /// 移動功能
    /// </summary>
    private void Move()
    {
        //水平福點數 = 輸入 的 取得軸向("水平") - 左右AD
        float h = Input.GetAxis("Horizontal");
        //剛體 的 加速度 = 新 二為向量(水平福點數 * 速度，剛體加速的Y)
        rig.velocity = new Vector2(h * movespeed, rig.velocity.y);
        //動畫 的 設定布林值(參數名稱，水平 不等於 0 勾選)
        ani.SetBool("跑步開關", h != 0);
        // KeyCode 列舉(下拉是選單) - 所有輸入的選項 滑鼠、鍵盤、搖桿
        if (Input.GetKeyDown(KeyCode.D))
        {
            // transform 此物件的變形元件
            // eulerAngles 歐拉角度 0 - 180 - 270 - 360
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    #endregion
    #region 跳躍
    /// <summary>
    /// 跳躍功能
    /// </summary>
    private void Jump()
    {
        //如果角色在地面上 並且 按下空白建 才能跳躍
        //isground == true 等同於 isground
        if (isground == true && Input.GetKeyDown(KeyCode.Space))
        {
            isground = false;           //不再地面上了
            rig.AddForce(transform.up * jumphigh);
        }
        //如果 物理 的 圓形範圍 碰到 塗層 8 的地板物件(1<<8(左移運算值))
        else if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + offset, radius, 1 << 8))
        {
            isground = true;
        }
        //沒有碰到地板物件
        else
        {
            isground = false;       //不在地面上了
        }
    }
    #endregion
    #region 開槍
    /// <summary>
    /// 開槍功能
    /// </summary>
    private void Fire()
    {
        //按下左鍵
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(shotsound, Random.Range(.5f, .8f));
            //生成子彈在槍口
            //生成(物件、座標、角度)
            //temp =>暫存物件
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            //讓子彈飛
            //AddForce加速度
            //上 綠 transform.up
            //又 紅 transform.right
            //前 藍 transform.forward
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed + transform.up * 100);
            //開槍音效
        }
    }
    #endregion
    #region 死亡
    /// <summary>
    /// 死亡功能
    /// </summary>
    /// <param name="obj">碰到物件的名稱</param>
    public void Dead(string obj)
    {
        //如果 物件名稱 == 死亡區域
        //等於 ==
        if (obj == "死亡區域" || obj == "敵人子彈" || obj == "陷阱")
        {
            //如果 死亡開關 為 ture 就 跳出
            if (ani.GetBool("死亡開關")) return;

            //enabled = false; 等同於 this.enabled = false;
            enabled = false;        //關閉此腳本
            ani.SetBool("死亡開關", true);

            //延遲呼叫("方法名稱",延遲呼叫)
            //類別名稱.靜態成員.存取
            if(GameManager.live>1)Invoke("Replay", 2);

            //呼叫 GM 處理玩家死亡
            gm.PlayerDead();
        }
    }
    #endregion
    /// <summary>
    /// 重新載入遊戲:重新載入當前關卡
    /// </summary>
    private void Replay()
    {
        // 載入場景(當前場景 的 名稱)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// OCE 碰撞時執行一次的事件
    /// Collision 碰到物件的資訊
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.tag);
    }
    /// <summary>
    /// 觸發事件:
    /// 兩個碰撞物件有其中一個勾選 IsTrigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "傳送門") inDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "傳送門") inDoor = false;
    }
    /// <summary>
    /// 前往下一關
    /// </summary>
    private void NextLevel()
    {
        if (inDoor == true && Input.GetKeyDown(KeyCode.W))                  //如果 在門裡面 並且 按下 W
        {
            //取得現在場景編號
            int livIndex= SceneManager.GetActiveScene().buildIndex;         //取得當前場景編號

            livIndex++;                                                     //當前場景編號加1

            SceneManager.LoadScene(livIndex);                               //載入下一關
        }
    }
    /// <summary>
    /// 繪製圖示:僅顯示於場景面板
    /// 也可使用OnDrawGizmosSelected(需點擊物件才能夠看到)
    /// </summary>
    private void OnDrawGizmos()
    {
        //圖示 顏色
        //也可使用Gizmos.color = Color.red;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //圖示 繪製球體((因是2為向量所以重新名)中心點，半徑)
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y) + offset, radius);
    }
}
