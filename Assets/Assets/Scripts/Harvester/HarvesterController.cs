using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		this.deathTime = this.maxDeathTime;

		this.strategies = new Dictionary<State, StrategyInterface>() {
			{ State.Idle, new IdleStrategy() },
			{ State.Move, new MoveStrategy() },
			{ State.Collect, new CollectStrategy() }
		};
	}
	
	// Update is called once per frame
	void Update () {
		this.strategies [this.state].action (this);

	}

	void OnTriggerEnter(Collider other) {
		Resource resource = other.gameObject.GetComponent<Resource>();

		if (resource != null) {
			this.collectResource (resource);
		}
	}

	public void moveToResource(Resource resource) {
		this.state = State.Move;
		(this.strategies [this.state] as MoveStrategy).target = resource;
	}

	public void collectResource(Resource resource) {
		this.state = State.Collect;
		(this.strategies [this.state] as CollectStrategy).resource = resource;
	}

	public float getSpeed() {
		return this.speed;
	}
}
