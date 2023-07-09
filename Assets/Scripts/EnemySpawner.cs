using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] GameObject[] Prefabs;
    [SerializeField] float Timer = 0;
    [SerializeField] float timeSpawn = 4f;
    [SerializeField] Vector3 randomRotation;
    [SerializeField] float OffsetX;
    [SerializeField] float OffsetY;
    [SerializeField] int enemyCount = 0;
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            enemyCount++;
            GameObject InstantiatedPrefab = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
            InstantiatedPrefab.name = "Enemy " + enemyCount.ToString();
            InstantiatedPrefab.SetActive(true);
            InstantiatedPrefab.GetComponent<Enemy>().enabled = true; // Enable the Enemy script on the spawned enemy
            Vector3 OffsetVector = new Vector3(Random.Range(-OffsetX, OffsetX), Random.Range(-OffsetY, OffsetY), 0);
            InstantiatedPrefab.transform.position = transforms[Random.Range(0, transforms.Length)].position + OffsetVector;
            Timer = timeSpawn;
        }
    }
}