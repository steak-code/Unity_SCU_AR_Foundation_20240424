using UnityEngine;

public class HpEnemy : HpSystem
{
    [SerializeField, Header("���˯S��")]
    private GameObject effectHit;
    [SerializeField, Header("���`�S��")]
    private GameObject effectDead;
    // OMD �ƹ��I���ƥ�
    // �����n������P�I������
    private void OnMouseDown()
    {
        Damage(50);
        // �ͦ������˯S�� = �ͦ����˯S��
        GameObject tempHit = Instantiate(effectHit, transform.position, transform.rotation);
        // ���� 1.5 ��R���ͦ������˯S��
        Destroy(tempHit, 1.5f);
    }

    protected override void Dead()
    {
        base.Dead();
        // �ͦ������`�S�� = �ͦ����`�S��
        GameObject tempDead = Instantiate(effectDead, transform.position, transform.rotation);
        // ���� 1.5 ��R���ͦ������˯S��
        Destroy(tempDead, 1.5f);
        // �R��������
        Destroy(gameObject);
    }
}
