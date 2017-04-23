using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public float step = 0.25f;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private float currentTime = 0f;
    private float duration = 30f;

    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        Spawn();
		StartSpawning();
    }

    void StartSpawning() {
        this.currentTime = 0;
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
        this.currentTime += Time.deltaTime;
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    
        if (this.currentTime > this.duration) {
            CancelInvoke("Spawn");
            this.spawnTime -= this.step;
            StartSpawning();
        }
    }
}