using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public enum EnemyState
	{
		Idle, Move, Attack, Attacked, Destroyed
	}

	public class EnemyController : MonoBehaviour {
		public float speed = 5;
		public float rotationSpeed = 1;

		private EnemyState state = EnemyState.Idle;

		private Dictionary<EnemyState, StrategyInterface> strategies;

		// Use this for initialization
		void Start () {
			this.strategies = new Dictionary<EnemyState, StrategyInterface>() {
				{ EnemyState.Idle, new IdleStrategy() },
				{ EnemyState.Move, new MoveStrategy() }
			};
		}
		
		// Update is called once per frame
		void Update () {
			this.strategies [this.state].move (this);
		}

		public void moveToHarvester(HarvesterController harvester) {
			this.state = EnemyState.Move;
			(this.strategies [this.state] as MoveStrategy).target = harvester;
		}

		public float getSpeed() {
			return this.speed;
		}
	}
}
