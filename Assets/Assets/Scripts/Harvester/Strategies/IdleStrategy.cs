using System;
using System.Linq;
using UnityEngine;

public class IdleStrategy: StrategyInterface
{
	public void action(HarvesterController harvester) {
		Debug.Log ("I'm stay");

		MonoBehaviour target;
		bool found = false;

		if (harvester.isFull ()) {
			found = this.tryAndFindNearest (Resources.FindObjectsOfTypeAll<Sylo> (), harvester, out target);
		} else {
			found = this.tryAndFindNearest (
				Resources
					.FindObjectsOfTypeAll<Resource> ()
					.Where (r => !r.isEmpty ()).ToArray (),
				harvester, out target
			);
		}


		if (found) {
			harvester.moveTo (target);
		}
	}

	protected bool tryAndFindNearest(MonoBehaviour[] objects, MonoBehaviour from, out MonoBehaviour closestObject) {
		closestObject = null;

		if (objects.Count () == 0) {
			return false;
		}

		closestObject = objects [0];

		float minDistance = Vector3.Distance (from.transform.position, closestObject.transform.position);

		foreach (MonoBehaviour target in objects) {
			float distance = Vector3.Distance (from.transform.position, target.transform.position);

			if (distance < minDistance) {
				minDistance = distance;
				closestObject = target;
			}
		}

		return true;
	}
}
