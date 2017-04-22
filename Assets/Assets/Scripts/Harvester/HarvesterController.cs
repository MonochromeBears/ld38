using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public enum State
{
	Idle, Move, Collect, Unloading, Attacked, Destroyed
}

public class HarvesterController : MonoBehaviour, MotionInterface {
	public float speed = 5;
	public float rotationSpeed = 1;
	public int maxCapacity = 100;
	public int collectSpeed = 1;
	public int unloadingSpeed = 1;
	public float maxDeathTime = 2;

	private int capacity = 0;
	private float deathTime;

	private State state = State.Idle;

	private Dictionary<State, StrategyInterface> strategies;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().freezeRotation = true;
		this.deathTime = this.maxDeathTime;

		this.strategies = new Dictionary<State, StrategyInterface>() {
			{ State.Idle, new IdleStrategy() },
			{ State.Move, new MoveStrategy() },
			{ State.Collect, new CollectStrategy() },
			{ State.Attacked, new AttackedStrategy() },
			{ State.Unloading, new UnloadingStrategy() }
		};
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isKilled ()) {
			Destroy (this.gameObject, 1);

			return;
		}

		this.strategies [this.state].action (this);

//		var earth = GameObject.Find ("Sphere");
//		this.transform.rotation = 
//			Quaternion.FromToRotation (earth.transform.position, this.transform.position) +
//			;

	}

	void OnTriggerEnter(Collider other) {
		this.checkCollision (other);
	}

	void OnTriggerStay(Collider other) {
		this.checkCollision (other);
	}

	void checkCollision(Collider other) {
		if (!this.isFull ()) {
			Resource resource = other.gameObject.GetComponent<Resource> ();

			if (resource != null) {
				this.collectResource (resource);

				return;
			}
		}

		if (!this.isEmpty ()) {
			Sylo sylo = other.gameObject.GetComponent<Sylo> ();

			if (sylo != null) {
				this.unloading (sylo);
			}
		}
	}

	public void moveTo(MonoBehaviour target) {
		this.state = State.Move;
		(this.strategies [this.state] as MoveStrategy).target = target;
	}

	public void collectResource(Resource resource) {
		this.state = State.Collect;
		(this.strategies [this.state] as CollectStrategy).resource = resource;
	}

	public void unloading(Sylo sylo) {
		this.state = State.Unloading;
		(this.strategies [this.state] as UnloadingStrategy).sylo = sylo;
	}


	public void stay() {
		this.state = State.Idle;
	}

	public float getSpeed() {
		return this.speed;
	}

	public void attackedByEnemy(EnemyController enemy) {
		this.GetComponent<BoxCollider>().enabled = false;

		this.state = State.Attacked;
		(this.strategies [this.state] as AttackedStrategy).enemy = enemy;
	}

	public bool isAttacked() {
		return this.state == State.Attacked;
	}

	public void collect(int capacity) {
		this.capacity += capacity;

		if (this.capacity > this.maxCapacity) {
			this.capacity = this.maxCapacity;
		}
	}

	public void unload(int capacity) {
		this.capacity -= capacity;

		if (this.capacity < 0) {
			this.capacity = 0;
		}
	}

	public bool damage() {
		this.deathTime -= Time.deltaTime;

		if (this.deathTime < 0) {
			this.deathTime = 0;
		}

		Debug.Log ("Time to death: " + this.deathTime);

		return this.isKilled ();
	}

	public bool isFull() {
		return this.capacity >= this.maxCapacity;
	}

	public bool isEmpty() {
		return this.capacity == 0;
	}

	public bool isKilled() {
		return this.deathTime == 0;
	}

	public int getCapacity() {
		return this.capacity;
	}
}
