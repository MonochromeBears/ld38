using System;
using UnityEngine;

namespace Enemy
{
	public class DestroyStrategy: StrategyInterface
	{
		public void move(EnemyController enemy) {
			if (enemy.hasTakenHarvester()) {
				enemy.getTakenHarvester().stay();
			}
			EnemyController.Destroy(enemy.gameObject);		
		}
	}
}
