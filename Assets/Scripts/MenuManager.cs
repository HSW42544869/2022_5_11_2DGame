using UnityEngine;
using UnityEngine.SceneManagement;      //�ޥγ����޲z API

/// <summary>
/// ���޲z��
/// </summary>
public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.live = 3;       //��_�ͩR�ƶq
    }

    /// <summary>
    /// �}�l�C��
    /// </summary>
    public void StartGame()
    {
        // �����޲z �� ���J����("�����W��")
        SceneManager.LoadScene("���d�@");
    }
    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        // ���ε{�� �� ���}�C��
        Application.Quit();
    }
}
