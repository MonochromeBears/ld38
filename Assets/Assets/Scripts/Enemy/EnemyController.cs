﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public enum EnemyState
	{
		Idle, Move, Attack, Destroyed, MoveToPoint
	}

	public class EnemyController : MonoBehaviour {
		public GameObject explosion;
		public float speed = 5;
		public float rotationSpeed = 1;

		private float duration = 0f;
		private float limit = 1f;
		private HarvesterController takenHarvester;
		private EnemyState state = EnemyState.Idle;
		private AudioSource deathSound;

		public Vector3 startPoint;

		private Dictionary<EnemyState, StrategyInterface> strategies;

		// Use this for initialization
		void Start () {
			this.strategies = new Dictionary<EnemyState, StrategyInterface>() {
				{ EnemyState.Idle, new IdleStrategy() },
				{ EnemyState.Move, new MoveStrategy() },
				{ EnemyState.Attack, new AttackStrategy() },
				{ EnemyState.Destroyed, new DestroyStrategy() },
				{ EnemyState.MoveToPoint, new MoveToPointStrategy() }
			};

			deathSound = GetComponent<AudioSource>();

//			if (this.startPoint != null) {
//				this.moveToPoint (this.startPoint);
//			}
		}
		
		// Update is called once per frame
		void Update () {
			this.duration += Time.deltaTime;

			if (this.state == EnemyState.Move && this.duration >= this.limit) {
				this.duration = 0f;
				this.goToIdle();
			}

			this.strategies [this.state].move (this);
		}

		public void moveToHarvester(HarvesterController harvester) {
			this.state = EnemyState.Move;
			(this.strategies [this.state] as MoveStrategy).target = harvester;
		}

		public void moveToPoint(Vector3 target) {
			this.state = EnemyState.MoveToPoint;
			(this.strategies [this.state] as MoveToPointStrategy).target = target;
		}

		public void attackHarvester(HarvesterController harvester) {
			this.state = EnemyState.Attack;
			(this.strategies [this.state] as AttackStrategy).target = harvester;
			(this.strategies [this.state] as AttackStrategy).tempDirection = Random.onUnitSphere * 30;
		}

		public bool hasTakenHarvester() {
			return this.takenHarvester != null;
		}

		public void goToIdle() {
			this.takenHarvester = null;
			this.state = EnemyState.Idle;
		}

		public void destroy() {
			this.state = EnemyState.Destroyed;
			(this.strategies [this.state] as DestroyStrategy).explosion = this.explosion;
			this.deathSound.Play ();
		}

		public float getSpeed() {
			return this.speed;
		}

		public HarvesterController getTakenHarvester() {
			return this.takenHarvester;
		}

		void OnCollisionEnter (Collision col)
		{
			if (this.hasTakenHarvester() || this.state == EnemyState.Destroyed) {
				return;
			}
			// if(col.gameObject.name == "prop_powerCube")
			// {
			// 	Destroy(col.gameObject);
			// }

			HarvesterController harvester = col.gameObject.GetComponent<HarvesterController>();

			if (harvester != null) {
				this.takenHarvester = harvester;
				this.attackHarvester(harvester);
			}
		}

		// void OnTriggerEnter(Collider other) {
		// 	HarvesterController harvester = other.gameObject.GetComponent<HarvesterController>();

		// 	if (harvester != null) {
		// 		this.takenHarvester = harvester;
		// 		this.attackHarvester(harvester);
		// 	}
		// }
	}
}
