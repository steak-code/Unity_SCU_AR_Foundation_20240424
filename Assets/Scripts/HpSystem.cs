using UnityEngine;

public class HpSystem : MonoBehaviour
{
    // protected 保護修飾詞 : 允許此類別與子類別存取
    // virtual 虛擬修飾詞 : 允許子類別覆寫
    [SerializeField, Header("血量"), Range(0, 500)]
    protected float hp;

    protected virtual void Damage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        print($"<color=#f63>{name} 受傷，血量:{hp}</color>");
        if (hp <= 0) Dead();
    }

    protected virtual void Dead()
    {
        print($"<color=#f63>{name} 死亡</color>");
    }
}
