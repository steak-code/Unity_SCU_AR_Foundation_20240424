using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �]�� public ���}�i�H�����s�I�s
    public void Replay()
    {
        // �����޲z�� �� ���J����(�����W��)
        SceneManager.LoadScene("�u��C��");
    }

    public void Quit()
    {
        // �b�����ɤ~���@��
        // ���ε{�� �� ���}�C��
        Application.Quit();
    }
}
