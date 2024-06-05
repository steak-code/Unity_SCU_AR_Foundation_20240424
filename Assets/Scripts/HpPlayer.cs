using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : HpSystem
{
    [SerializeField, Header("�Ϥ����")]
    private Image imgHP;
    [SerializeField, Header("�e��")]
    private GameObject goCanvas;

    private string enemyAttackAreaName = "�ĤH�����ϰ�";

    private float hpMax;

    private void Awake()
    {
        hpMax = hp;
    }

    // OTE �ֳt����
    // Ĳ�o�ƥ� : �Q�Ŀ� Is Trigger ����I��ɷ|����@��
    // other �Ѽ��x�s�I�쪫�󪺸I����T
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
        // ��s����Ϥ�����
        // �Ϥ���� �� �񺡪��� = ��q / ��q�̤j��
        imgHP.fillAmount = hp / hpMax;
    }

    protected override void Dead()
    {
        base.Dead();
        // �e�� �Ұʳ]�w(���)
        goCanvas.SetActive(true);
    }
}
