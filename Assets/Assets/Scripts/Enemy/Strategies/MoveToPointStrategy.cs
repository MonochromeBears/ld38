using System;
using UnityEngine;

namespace Enemy
{
	public class MoveToPointStrategy: StrategyInterface
	{
		public Vector3 target;

		public void move(EnemyController enemy) {
			if (Vector3.Distance (this.target, enemy.transform.position) < 1.0f) {
				enemy.goToIdle ();

				return;
			}

			Vector3 motion = Vector3.MoveTowards (
				enemy.transform.position, 
				this.target, 
				Time.deltaTime * enemy.speed
			);

			enemy.transform.LookAt (this.target);
			enemy.transform.localPosition = motion;
		}
	}
}

