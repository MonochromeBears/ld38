using System;
using UnityEngine;

public class CollectStrategy: StrategyInterface
{
	public Resource resource;

	public void action(HarvesterController harvester) {
		Debug.Log ("Collect");
	}
}
