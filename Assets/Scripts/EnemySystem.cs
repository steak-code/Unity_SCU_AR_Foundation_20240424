using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{
    // SerializeField �ǦC����� : �N�������ܦb���O
    // Header ���D : �b���O�W�K�[���D��r�i�H�ϥΤ���
    // Transform �ܧ� : �b Unity ���s��t�@���󪺮y�СB���׻P�ؤo��T
    [SerializeField, Header("�ؼ�")]
    private Transform target;

    private NavMeshAgent agent;
    private Animator ani;
    private string parMove = "���ʼƭ�";

    // ����ƥ� : �C���}�l�ɰ���@��
    private void Awake()
    {
        // print("���o�A�U�w~");

        // �N�z�� = ���o�����󪺤���<����W��>();
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // ��s�ƥ� : �@������ 60 �� 60 FPS
    private void Update()
    {
        // print("<color=yellow>�ڬO��s�ƥ�</color>");
        // �l�ܥؼ�
        // �N�z�� �� �]�w�ت��a(�y��)
        agent.SetDestination(target.position);
    }
}
