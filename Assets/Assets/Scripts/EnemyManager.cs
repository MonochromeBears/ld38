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
	private float nextSpawnTime = 0f;
    private float duration = 40f;
	private float durationStep = 40f;
    private int limit = 20;

    void Start ()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    void Update() {
        this.currentTime += Time.deltaTime;
		if (Time.time >= this.nextSpawnTime) {
			this.Spawn ();
		}
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

		this.nextSpawnTime += this.spawnTime;

		if (this.nextSpawnTime > this.duration && this.spawnTime >= this.step) {
            this.spawnTime -= this.step;
			this.duration += this.durationStep;
        }
    }
}