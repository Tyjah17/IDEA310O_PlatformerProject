using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 3f;
    public float destroyAfter = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBox), 1f, spawnDelay);
    }

    void SpawnBox()
    {
        GameObject box = Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(box, destroyAfter);
    }
}