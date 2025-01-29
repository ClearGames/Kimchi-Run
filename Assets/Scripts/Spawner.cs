using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float minSpawnDelay = 5f;
    [SerializeField] private float maxSpawnDelay = 7f;

    [Header("References")]
    [SerializeField] private GameObject[] gameObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    void OnEnable()
    {
        Spawn();
        //Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
