//using UnityEngine;

//public class Spawner : MonoBehaviour
//{
//    public GameObject prefab;
//    public Transform[] spawnPoints;  // assign multiple points in Inspector
//    public int spawnCount = 5;       // number of prefabs to spawn
//    public float spawnDelay = 1f;    // delay between spawns (optional)

//    private float timer = 0f;
//    private int spawned = 0;

//    void Update()
//    {
//        if (spawned < spawnCount)
//        {
//            timer += Time.deltaTime;
//            if (timer >= spawnDelay)
//            {
//                timer = 0f;
//                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
//                Instantiate(prefab, randomPoint.position, randomPoint.rotation);
//                spawned++;
//            }
//        }
//    }
//}

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int spawnCount = 10;       // number of prefabs to spawn
    public Vector3 areaSize = new Vector3(17f, 0f, 14f);
    // area range
    public float spawnDelay = 1f;

    private float timer = 0f;
    private int spawned = 0;

    void Update()
    {
        if (spawned < spawnCount)
        {
            timer += Time.deltaTime;
            if (timer >= spawnDelay)
            {
                timer = 0f;

                // random position inside defined area relative to the spawner
                Vector3 randomPos = transform.position + new Vector3(
                    Random.Range(-areaSize.x / 2, areaSize.x / 2),
                    areaSize.y,
                    Random.Range(-areaSize.z / 2, areaSize.z / 2)
                );

                Instantiate(prefab, randomPos, Quaternion.identity);
                spawned++;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, areaSize); // shows spawn area in editor
    }
}
