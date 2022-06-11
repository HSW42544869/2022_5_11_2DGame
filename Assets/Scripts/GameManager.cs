using UnityEngine;
using UnityEngine.UI;       // �ޥ� ���� UI
using UnityEngine.SceneManagement;
/// <summary>
/// �C���޲z��:�޲z�ͩR�B����
/// </summary>
public class GameManager : MonoBehaviour
{
    //�}�C
    [Header("�ͩR����}�C")]
    public GameObject[] lives;
    [Header("�Ʀr��r����")]
    public Text textScore;
    [Header("�����e��")]
    public GameObject Fine;
    //���`������k�s
    public static int score;
    // �@����� ���s�J�J���� �|�٭쬰�w�]��
    // static => �אּ�R�A��� �K���|�٭쬰�w�]��
    public static int live = 3;
    private void Awake()
    {
        SetCollision();
        SetLive();
        AddScore(0);        //�C�����}�C�������k0
    }
    /// <summary>
    /// �K�[����
    /// </summary>
    /// <param name="add">�K�[�h�֤���</param>
    public void AddScore(int add)
    {
        score += add;                         //�֥[����

        textScore.text = "scoring:" + score;     //��s��r����
    }
    private void Update()
    {
        BackTomenu();
        QuitGame();
    }
    /// <summary>
    /// ��^���
    /// </summary>
    private void BackTomenu()
    {
        if(live == 0 && Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("���");
    }
    private void QuitGame()
    {
        if (live == 0 && Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
    /// <summary>
    /// ���a���`
    /// </summary>
    public void PlayerDead()
    {
        live--;

        SetLive();
        if (live == 0) Fine.SetActive(true);
    }
    private void SetLive()
    {
        // �}�C���[�s��] �� ��k()
        //lives[2].SetActive(false);
        for (int i = 0; i < lives.Length; i++)
        {
            // �P�_�� �u���@��ԭz�� �i�H�ٲ� �j�A��
            if(i >= live) lives[i].SetActive(false);
        }
    }

    /// <summary>
    /// �]�w�I��:�Ҧ��ϼh���I��
    /// </summary>
    private void SetCollision()
    {
        //�]�i��Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("���a"), LayerMask.NameToLayer("���a�l�u"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("�ĤH"), LayerMask.NameToLayer("�ĤH�l�u"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("���a�l�u"), LayerMask.NameToLayer("�ĤH�l�u"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("�ĤH�l�u"), LayerMask.NameToLayer("�ĤH�l�u"));
    }
}
