using UnityEngine;
using UnityEngine.UI;       // �ޥ� ���� UI
/// <summary>
/// �C���޲z��:�޲z�ͩR�B����
/// </summary>
public class GameManager : MonoBehaviour
{
    //�}�C
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
