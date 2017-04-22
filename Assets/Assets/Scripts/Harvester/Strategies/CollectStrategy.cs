using System;
using UnityEngine;

public class CollectStrategy: StrategyInterface
{
	public Resource resource;

	public void action(HarvesterController harvester) {
		if (this.resource == null) {
			return;
		}

		if (resource.isEmpty () || harvester.isFull()) {
			harvester.stay ();

			return;
		}

		int collected = this.resource.collect (harvester.collectSpeed);
		harvester.collect (collected);

		Debug.Log ("Collect: " + harvester.getCapacity() + "; Left: " + resource.getCapacity());
	}
}
