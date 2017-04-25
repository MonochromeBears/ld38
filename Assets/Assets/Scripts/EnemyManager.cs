using UnityEngine;
using Enemy;

public class EnemyManager : MonoBehaviour
{
    static public int amount = 0;

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public float step = 0.15f;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private float currentTime = 0f;
    private float duration = 40f;
    private int limit = 30;

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
        if (EnemyManager.amount > this.limit) {
            return;
        }
        
        EnemyManager.amount += 1;
        
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		GameObject enemyObject = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    
		EnemyController e = enemyObject.GetComponent<EnemyController> ();

		e.startPoint = Random.onUnitSphere * 5.0f;
        spawnPoints[spawnPointIndex].gameObject.GetComponent<Teleport>().summon();

        if (this.currentTime > this.duration && this.spawnTime >= this.step) {
            CancelInvoke("Spawn");
            this.currentTime = 0f;
            this.spawnTime -= this.step;
            StartSpawning();
        }
    }
}