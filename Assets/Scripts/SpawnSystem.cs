using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField, Header("要生成的預製物")]
    private GameObject prefabToSpawn;
    [SerializeField, Header("生成點陣列")]
    private Transform[] spawnPoints;
    [SerializeField, Header("生成間隔"), Range(0, 5)]
    private float spawnInterval = 2;

    private void Awake()
    {
        // 重複呼叫(方法名稱，開始時間，間隔)
        InvokeRepeating("Spawn", 0, spawnInterval);
    }

    private void Spawn()
    {
        // 隨機值 = 隨機範圍(0 到 陣列的長度) - 不包含最大值
        int random = Random.Range(0, spawnPoints.Length);
        // 生成(物件，座標，角度)
        Instantiate(prefabToSpawn,
            spawnPoints[random].position, spawnPoints[random].rotation);
    }
}
