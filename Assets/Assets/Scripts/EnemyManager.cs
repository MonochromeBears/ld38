using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public float step = 0.25f;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private float currentTime = 0f;
    private float duration = 20f;

    void Start ()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		StartSpawning();
    }

    void StartSpawning() {
        this.currentTime = 0;
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Update() {
        this.currentTime += Time.deltaTime;
    }

    void Spawn ()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    
        if (this.currentTime > this.duration && this.spawnTime >= this.step) {
            CancelInvoke("Spawn");
            this.currentTime = 0f;
            this.spawnTime -= this.step;
            StartSpawning();
        }
    }
}