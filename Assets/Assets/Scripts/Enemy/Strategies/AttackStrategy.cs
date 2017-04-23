using System;
using UnityEngine;

namespace Enemy
{
	public class AttackStrategy: StrategyInterface
	{
		public HarvesterController target;
		public Vector3 tempDirection;

		public void move(EnemyController enemy) {

			if (!this.target.isAttacked()) {
				this.target.attackedByEnemy(enemy);

				Debug.LogErrorFormat ("{0} attacked by slime", this.target.name);
			}
			
			Vector3 motion = Vector3.MoveTowards (
				enemy.transform.position, 
				tempDirection, 
				Time.deltaTime * enemy.speed
			);

			enemy.transform.LookAt (tempDirection);
			enemy.transform.localPosition = motion;
		}
	}
}
