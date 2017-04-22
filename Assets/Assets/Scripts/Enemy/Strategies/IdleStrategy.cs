using System;
using System.Linq;
using UnityEngine;

namespace Enemy
{
	public class IdleStrategy: StrategyInterface
	{
		public void move(EnemyController enemy) {
			HarvesterController[] harvesters = Resources.FindObjectsOfTypeAll<HarvesterController> ();

			if (harvesters.Count() == 0) {
				return;
			}
			HarvesterController closestHarvester = harvesters[0];

			float minDistance = Vector3.Distance(enemy.transform.position, closestHarvester.transform.position);

			foreach (HarvesterController harvester in harvesters) {
				float distance = Vector3.Distance (enemy.transform.position, closestHarvester.transform.position);

				if (distance < minDistance) {
					minDistance = distance;
					closestHarvester = harvester;
				}
			}

			enemy.moveToHarvester(closestHarvester);
		}
	}	
}
