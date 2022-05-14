using UnityEngine;

public class Car : MonoBehaviour
{
    #region 欄位
    [Header("這是汽車的CC數"), Tooltip("這是汽車的CC數")]
    [Range(500, 5000)]
    public int cc = 2000;
    [Header("這是汽車的重量"), Range(500, 2000)]
    public float weight = 1500.5f;
    public string brand = "BMW";
    [Header("是否有天窗")]
    [Tooltip("勾選代表有天窗，取消代表沒天窗")]
    public bool haveWindow = true;

    //其他類型:顏色、座標、 2~4、遊戲物件、元件(屬性面板上初體字 Rigidbody2D、Collider2D...)

    public Color red = Color.red;
    public Color yellow = Color.yellow;
    public Color myCollor = new Color(0.3f, 0, 0.9f);

    //2維~4維 向量
    public Vector2 pos0 = Vector2.zero;
    public Vector2 pos1 = Vector2.one;
    public Vector2 pos2 = new Vector2(7,9);

    public Vector3 posV3 = Vector3.one;
    public Vector4 posV4 = Vector4.one;

    //遊戲物件與元件 不需要 指定 值
    public GameObject obj;              //可以存放白線條物件與預製物
    public Transform tra;
    public SpriteRenderer sr;
    #endregion
    //事件:開始 - 撥放遊戲時執行一次
    private void Start()
    {
        //輸出訊息(訊息) - 顯示在 Console 版面上
        print("哈囉，沃德");

        //Drive(1);
        shoot(1,2);
        shoot(2, 300);
    }
    //事件:更新 - 約1秒執行60次
    //處理:持續內容或玩家輸入 - 鍵盤、滑鼠與搖桿
    private void Update()
    {
        print("我在更新事件裡面");
        Drive(.1f);
    }

    //方法:
    //定義程式區塊的語法
    //語法:
    //修飾詞 傳回類型 名稱 (參數) { 程式區塊; }
    //參數語法:參數類型 參數名稱(指定 值)
    //有預設值的參數要放在最右邊
    //無傳回 void
    //方法需要被呼叫才會執行
    private void Drive(float speed)
    {
        print("開車中...");
        //位移
        transform.Translate(speed, 0, 0);
    }
    /// <summary>
    /// 發射弓箭的功能
    /// </summary>
    /// <param name="count"></param>
    /// <param name="speed"></param>
    private void shoot(int count,int speed = 500)
    {
        print("發射弓箭:" + count);
        print("弓箭速度:" + speed);
    }
}
