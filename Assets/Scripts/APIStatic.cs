using UnityEngine;
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        //取得 靜態名稱

        //類別名稱.靜態屬性名稱
        // 數學 的 PI
        print(Mathf.PI);
        //隨機 的 值
        //"字串" + 其他類型 (串接)
        print("隨機:" + Random.value);

        // 設定 靜態 屬性

        // 類別名稱.靜態屬性名稱 = 值
        //時間 的 時間大小 = 值
        Time.timeScale = 5f;

        //使用 靜態 方法
        int a = Mathf.Abs(-99);
        print("絕對值後的值" + a);

        float atk = Random.Range(50.5f, 100.5f);
        print("隨機攻擊力" + atk);

        int countC = Camera.allCameras.Length;
        print("我有" + countC + "台相機");

        Cursor.visible = false;

        Debug.Log(Mathf.Floor(10.5f));

        //Application.OpenURL("https://docs.unity3d.com/ScriptReference/Application.OpenURL.html");
    }

    private void Update()
    {
        //print("遊戲時間:" + Time.time);
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition);
        }
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("HIHI");
        }
    }
}
