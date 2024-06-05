using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySystem : MonoBehaviour
{
    // SerializeField �ǦC����� : �N�������ܦb���O
    // Header ���D : �b���O�W�K�[���D��r�i�H�ϥΤ���
    // Transform �ܧ� : �b Unity ���s��t�@���󪺮y�СB���׻P�ؤo��T
    [SerializeField, Header("�ؼ�")]
    private Transform target;
    [SerializeField, Header("�����e�n�ɶ�"), Range(0, 3)]
    private float timeBeforeAttack;
    [SerializeField, Header("�����ɶ�"), Range(0, 3)]
    private float timeAttack;
    [SerializeField, Header("������n�ɶ�"), Range(0, 3)]
    private float timeAfterAttack;
    [SerializeField, Header("�ĤH�����ϰ�")]
    private GameObject attackArea;

    private NavMeshAgent agent;
    private Animator ani;
    private string parMove = "���ʼƭ�";
    private string parAttack = "�k�_��";
    private bool isAttacking;
    private string playerName = "���a����";

    // ����ƥ� : �C���}�l�ɰ���@��
    private void Awake()
    {
        // print("���o�A�U�w~");
        // �ؼ� = �j�M�����W�W�٬� "���a����" ������ �� �ܧθ�T
        target = GameObject.Find(playerName).transform;
        // �N�z�� = ���o�����󪺤���<����W��>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        agent.SetDestination(target.position);
    }

    // ��s�ƥ� : �@������ 60 �� 60 FPS
    private void Update()
    {
        Move();
        attack();
    }

    /// <summary>
    /// ���ʤ�k
    /// </summary>
    private void Move()
    {
        // �N�z�� �� �]�w�ت��a(�y��)
        agent.SetDestination(target.position);
        // �ʵe �� �]�w�B�I��(�ѼƦW�١A�B�I��)
        ani.SetFloat(parMove, agent.velocity.magnitude);
        // print(�T��); �O��X�T���챱��x���O Console
        // print($"�Ѿl�Z�� : {agent.remainingDistance}");
    }

    private void attack() 
    {
        // �p�G �b ������ �N ���X
        if (isAttacking) return;
        // �p�G �Ѿl�Z�� <= ����Z�� �N ����
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // ���b������
            isAttacking = true;
            ani.SetTrigger(parAttack);
            StartCoroutine(StartAttack());
        }
    }

    private IEnumerator StartAttack() 
    {
        // print("<color=#f63>�����e�n</color>");
        yield return new WaitForSeconds(timeBeforeAttack);
        // print("<color=#f63>����</color>");
        attackArea.SetActive(true);     // true �N����ܧ����ϰ�
        yield return new WaitForSeconds(timeAttack);
        // print("<color=#f63>������n</color>");
        attackArea.SetActive(false);     // false �N��?�ç����ϰ�
        yield return new WaitForSeconds(timeAfterAttack);
        // print("<color=#f63>��������</color>");
        isAttacking = false;
    }
}
