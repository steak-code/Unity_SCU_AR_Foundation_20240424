using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField, Header("�n�ͦ����w�s��")]
    private GameObject prefabToSpawn;
    [SerializeField, Header("�ͦ��I�}�C")]
    private Transform[] spawnPoints;
    [SerializeField, Header("�ͦ����j"), Range(0, 5)]
    private float spawnInterval = 2;

    private void Awake()
    {
        // ���ƩI�s(��k�W�١A�}�l�ɶ��A���j)
        InvokeRepeating("Spawn", 0, spawnInterval);
    }

    private void Spawn()
    {
        // �H���� = �H���d��(0 �� �}�C������) - ���]�t�̤j��
        int random = Random.Range(0, spawnPoints.Length);
        // �ͦ�(����A�y�СA����)
        Instantiate(prefabToSpawn,
            spawnPoints[random].position, spawnPoints[random].rotation);
    }
}
