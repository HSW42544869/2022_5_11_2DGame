using UnityEngine;
using UnityEngine.UI;       // 引用 介面 UI
using UnityEngine.SceneManagement;
/// <summary>
/// 遊戲管理器:管理生命、分數
/// </summary>
public class GameManager : MonoBehaviour
{
    //陣列
    [Header("生命物件陣列")]
    public GameObject[] lives;
    [Header("數字文字介面")]
    public Text textScore;
    [Header("結束畫面")]
    public GameObject Fine;
    //死亡後分數歸零
    public static int score;
    // 一般欄位 重新仔入場景 會還原為預設值
    // static => 改為靜態欄位 便不會還原為預設值
    public static int live = 3;
    private void Awake()
    {
        SetCollision();
        SetLive();
        AddScore(0);        //每次重開遊戲分數歸0
    }
    /// <summary>
    /// 添加分數
    /// </summary>
    /// <param name="add">添加多少分數</param>
    public void AddScore(int add)
    {
        score += add;                         //累加分數

        textScore.text = "scoring:" + score;     //更新文字介面
    }
    private void Update()
    {
        BackTomenu();
        QuitGame();
    }
    /// <summary>
    /// 返回選單
    /// </summary>
    private void BackTomenu()
    {
        if(live == 0 && Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("選單");
    }
    private void QuitGame()
    {
        if (live == 0 && Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
    /// <summary>
    /// 玩家死亡
    /// </summary>
    public void PlayerDead()
    {
        live--;

        SetLive();
        if (live == 0) Fine.SetActive(true);
    }
    private void SetLive()
    {
        // 陣列欄位[編號] 的 方法()
        //lives[2].SetActive(false);
        for (int i = 0; i < lives.Length; i++)
        {
            // 判斷式 只有一行敘述時 可以省略 大括號
            if(i >= live) lives[i].SetActive(false);
        }
    }

    /// <summary>
    /// 設定碰撞:所有圖層的碰撞
    /// </summary>
    private void SetCollision()
    {
        //也可用Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家"), LayerMask.NameToLayer("玩家子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("玩家子彈"), LayerMask.NameToLayer("敵人子彈"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("敵人子彈"), LayerMask.NameToLayer("敵人子彈"));
    }
}
