using UnityEngine;
using UnityEngine.UI;       // 引用 介面 UI
/// <summary>
/// 遊戲管理器:管理生命、分數
/// </summary>
public class GameManager : MonoBehaviour
{
    //陣列
    public GameObject[] lives;

    public Text textScore;
    private void Awake()
    {
        SetCollision();
        SetLive();
    }
    private void SetLive()
    {
        lives[2].SetActive(false);
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
