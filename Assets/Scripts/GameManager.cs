using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 設為 public 公開可以讓按鈕呼叫
    public void Replay()
    {
        // 場景管理器 的 載入場景(場景名稱)
        SceneManager.LoadScene("守塔遊戲");
    }

    public void Quit()
    {
        // 在執行檔才有作用
        // 應用程式 的 離開遊戲
        Application.Quit();
    }
}
