﻿using System;
using UnityEngine;

public class MoveStrategy: StrategyInterface
{
	public MonoBehaviour target;

	public void action(HarvesterController harvester) {
		Vector3 motion = Vector3.MoveTowards (
			harvester.transform.position, 
			this.target.transform.position, 
			Time.deltaTime * harvester.speed
		);

		harvester.transform.LookAt (this.target.transform.position);
		harvester.transform.position = motion;
	}
}
