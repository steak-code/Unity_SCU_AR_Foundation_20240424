using UnityEngine;

public class HpEnemy : HpSystem
{
    [SerializeField, Header("受傷特效")]
    private GameObject effectHit;
    [SerializeField, Header("死亡特效")]
    private GameObject effectDead;
    // OMD 滑鼠點擊事件
    // 必須要有剛體與碰撞物件
    private void OnMouseDown()
    {
        Damage(50);
        // 生成的受傷特效 = 生成受傷特效
        GameObject tempHit = Instantiate(effectHit, transform.position, transform.rotation);
        // 延遲 1.5 秒刪除生成的受傷特效
        Destroy(tempHit, 1.5f);
    }

    protected override void Dead()
    {
        base.Dead();
        // 生成的死亡特效 = 生成死亡特效
        GameObject tempDead = Instantiate(effectDead, transform.position, transform.rotation);
        // 延遲 1.5 秒刪除生成的受傷特效
        Destroy(tempDead, 1.5f);
        // 刪除此物件
        Destroy(gameObject);
    }
}
