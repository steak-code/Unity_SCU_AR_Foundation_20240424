using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : HpSystem
{
    [SerializeField, Header("圖片血條")]
    private Image imgHP;
    [SerializeField, Header("畫布")]
    private GameObject goCanvas;

    private string enemyAttackAreaName = "敵人攻擊區域";

    private float hpMax;

    private void Awake()
    {
        hpMax = hp;
    }

    // OTE 快速完成
    // 觸發事件 : 被勾選 Is Trigger 物件碰到時會執行一次
    // other 參數儲存碰到物件的碰撞資訊
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == enemyAttackAreaName)
        {
            Damage(50);
        }
    }

    protected override void Damage(float damage)
    {
        base.Damage(damage);
        // 更新血條圖片介面
        // 圖片血條 的 填滿長度 = 血量 / 血量最大值
        imgHP.fillAmount = hp / hpMax;
    }

    protected override void Dead()
    {
        base.Dead();
        // 畫布 啟動設定(顯示)
        goCanvas.SetActive(true);
    }
}
