using System;
using UnityEngine;

namespace Enemy
{
	public class DestroyStrategy: StrategyInterface
	{
		public void move(EnemyController enemy) {
			
			enemy.getTakenHarvester().stay();
			//Destroy(enemy);		
		}
	}
}
