using UnityEngine;
using UnityEngine.SceneManagement;      //�ޥγ����޲z API

public class MenuManager : MonoBehaviour
{
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
