using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySystem : MonoBehaviour
{
    // SerializeField 序列化欄位 : 將此欄位顯示在面板
    // Header 標題 : 在面板上添加標題文字可以使用中文
    // Transform 變形 : 在 Unity 內存放另一物件的座標、角度與尺寸資訊
    [SerializeField, Header("目標")]
    private Transform target;
    [SerializeField, Header("攻擊前搖時間"), Range(0, 3)]
    private float timeBeforeAttack;
    [SerializeField, Header("攻擊時間"), Range(0, 3)]
    private float timeAttack;
    [SerializeField, Header("攻擊後搖時間"), Range(0, 3)]
    private float timeAfterAttack;
    [SerializeField, Header("敵人攻擊區域")]
    private GameObject attackArea;

    private NavMeshAgent agent;
    private Animator ani;
    private string parMove = "移動數值";
    private string parAttack = "右鉤拳";
    private bool isAttacking;
    private string playerName = "玩家物件";

    // 喚醒事件 : 遊戲開始時執行一次
    private void Awake()
    {
        // print("哈囉，沃德~");
        // 目標 = 搜尋場景上名稱為 "玩家物件" 的物件 的 變形資訊
        target = GameObject.Find(playerName).transform;
        // 代理器 = 取得此物件的元件<元件名稱>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        agent.SetDestination(target.position);
    }

    // 更新事件 : 一秒執行約 60 次 60 FPS
    private void Update()
    {
        Move();
        attack();
    }

    /// <summary>
    /// 移動方法
    /// </summary>
    private void Move()
    {
        // 代理器 的 設定目的地(座標)
        agent.SetDestination(target.position);
        // 動畫 的 設定浮點數(參數名稱，浮點數)
        ani.SetFloat(parMove, agent.velocity.magnitude);
        // print(訊息); 是輸出訊息到控制台面板 Console
        // print($"剩餘距離 : {agent.remainingDistance}");
    }

    private void attack() 
    {
        // 如果 在 攻擊中 就 跳出
        if (isAttacking) return;
        // 如果 剩餘距離 <= 停止距離 就 攻擊
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // 正在攻擊中
            isAttacking = true;
            ani.SetTrigger(parAttack);
            StartCoroutine(StartAttack());
        }
    }

    private IEnumerator StartAttack() 
    {
        // print("<color=#f63>攻擊前搖</color>");
        yield return new WaitForSeconds(timeBeforeAttack);
        // print("<color=#f63>攻擊</color>");
        attackArea.SetActive(true);     // true 代表顯示攻擊區域
        yield return new WaitForSeconds(timeAttack);
        // print("<color=#f63>攻擊後搖</color>");
        attackArea.SetActive(false);     // false 代表?藏攻擊區域
        yield return new WaitForSeconds(timeAfterAttack);
        // print("<color=#f63>攻擊結束</color>");
        isAttacking = false;
    }
}
