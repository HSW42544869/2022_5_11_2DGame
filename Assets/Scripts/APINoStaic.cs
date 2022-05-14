using UnityEngine;

public class APINoStaic : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;

    public Transform traA;

    private void Start()
    {
        //取得 非靜態 屬性
        //遊戲物件 A 的 標籤
        print(objA.tag);
        print(objB.layer);
        print(traA.localScale);

        //設定 非靜態 屬性
        //將 遊戲物件B 圖層 改為 5
        objB.layer = 5;
        //將物件尺寸放大
        traA.localScale = new Vector3(3, 3, 3);
    }
    private void Update()
    {
        // 使用 非靜態 語法
        //物件 的 方法(參數)
        //變形物件 的 旋轉(X，Y，Z)
        traA.Rotate(0, 0, 1);
    }
}
