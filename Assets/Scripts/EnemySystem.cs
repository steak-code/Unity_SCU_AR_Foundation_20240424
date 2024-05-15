using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{
    // SerializeField 序列化欄位 : 將此欄位顯示在面板
    // Header 標題 : 在面板上添加標題文字可以使用中文
    // Transform 變形 : 在 Unity 內存放另一物件的座標、角度與尺寸資訊
    [SerializeField, Header("目標")]
    private Transform target;

    private NavMeshAgent agent;
    private Animator ani;
    private string parMove = "移動數值";

    // 喚醒事件 : 遊戲開始時執行一次
    private void Awake()
    {
        // print("哈囉，沃德~");

        // 代理器 = 取得此物件的元件<元件名稱>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // 更新事件 : 一秒執行約 60 次 60 FPS
    private void Update()
    {
        // print("<color=yellow>我是更新事件</color>");
        // 追蹤目標
        // 代理器 的 設定目的地(座標)
        agent.SetDestination(target.position);
    }
}
