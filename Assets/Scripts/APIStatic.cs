using UnityEngine;
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        //���o �R�A�W��

        //���O�W��.�R�A�ݩʦW��
        // �ƾ� �� PI
        print(Mathf.PI);
        //�H�� �� ��
        //"�r��" + ��L���� (�걵)
        print("�H��:" + Random.value);

        // �]�w �R�A �ݩ�

        // ���O�W��.�R�A�ݩʦW�� = ��
        //�ɶ� �� �ɶ��j�p = ��
        Time.timeScale = 5f;

        //�ϥ� �R�A ��k
        int a = Mathf.Abs(-99);
        print("����ȫ᪺��" + a);

        float atk = Random.Range(50.5f, 100.5f);
        print("�H�������O" + atk);

        int countC = Camera.allCameras.Length;
        print("�ڦ�" + countC + "�x�۾�");

        Cursor.visible = false;

        Debug.Log(Mathf.Floor(10.5f));

        //Application.OpenURL("https://docs.unity3d.com/ScriptReference/Application.OpenURL.html");
    }

    private void Update()
    {
        //print("�C���ɶ�:" + Time.time);
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
