using System;
using UnityEngine;

namespace Enemy
{
	public class MoveStrategy: StrategyInterface
	{
		public HarvesterController target;

		public void move(EnemyController enemy) {
			if (this.target.isAttacked() || this.target.isKilled()) {
				enemy.goToIdle();

				return;
			}

			Vector3 motion = Vector3.MoveTowards (
				enemy.transform.position, 
				this.target.transform.position, 
				Time.deltaTime * enemy.speed
			);

			enemy.transform.LookAt (this.target.transform.position);
			enemy.transform.position = motion;
		}
	}
}
