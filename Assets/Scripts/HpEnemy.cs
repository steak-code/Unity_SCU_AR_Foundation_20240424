using UnityEngine;

public class HpEnemy : HpSystem
{
    // OMD 滑鼠點擊事件
    // 必須要有剛體與碰撞物件
    private void OnMouseDown()
    {
        Damage(50);
    }

    protected override void Dead()
    {
        base.Dead();
        // 刪除此物件
        Destroy(gameObject);
    }
}
