using System;
using System.Linq;
using UnityEngine;

public class IdleStrategy: StrategyInterface
{
	public void move(HarvesterController harvester) {
		Resource[] resources = Resources.FindObjectsOfTypeAll<Resource> ();

		if (resources.Count () == 0) {
			return;
		}
		Resource closestResource = resources [0];

		float minDistance = Vector3.Distance (harvester.transform.position, closestResource.transform.position);

		foreach (Resource resource in resources) {
			float distance = Vector3.Distance (harvester.transform.position, resource.transform.position);

			if (distance < minDistance) {
				minDistance = distance;
				closestResource = resource;
			}
		}

		harvester.moveToResource (closestResource);
	}
}
