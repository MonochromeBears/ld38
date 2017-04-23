using System;
using UnityEngine;
using Enemy;

public class AttackedStrategy: StrategyInterface
{
	public EnemyController enemy;

	public void action(HarvesterController harvester) {
		harvester.transform.position = this.enemy.transform.position;

		harvester.damage ();
	}
}
