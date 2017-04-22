using System;
using UnityEngine;

namespace Enemy
{
	public class MoveStrategy: StrategyInterface
	{
		public MonoBehaviour target;

		public void move(EnemyController enemy) {
			Vector3 motion = Vector3.MoveTowards (
				enemy.transform.position, 
				this.target.transform.position, 
				Time.deltaTime * enemy.speed
			);

			enemy.transform.LookAt (this.target.transform.position);
			enemy.transform.localPosition = motion;
		}
	}
}
