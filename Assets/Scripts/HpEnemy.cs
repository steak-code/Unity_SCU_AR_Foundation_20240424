using UnityEngine;

public class HpEnemy : HpSystem
{
    // OMD �ƹ��I���ƥ�
    // �����n������P�I������
    private void OnMouseDown()
    {
        Damage(50);
    }

    protected override void Dead()
    {
        base.Dead();
        // �R��������
        Destroy(gameObject);
    }
}
