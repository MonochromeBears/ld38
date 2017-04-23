using System;
using System.Linq;
using UnityEngine;

public class IdleStrategy: StrategyInterface
{
	public void action(HarvesterController harvester) {
		harvester.regenerate();
		harvester.GetComponent<BoxCollider>().enabled = true;

		MonoBehaviour target;
		bool found = false;

		if (!harvester.isFull ()) {
			found = this.tryAndFindNearest (
				Resources
					.FindObjectsOfTypeAll<Resource> ()
					.Where (r => !r.isEmpty ()).ToArray (),
				harvester, out target
			);
		} else {
			found = this.findSylo(harvester, out target);
		}

		if (!found) {
			found = this.findSylo(harvester, out target);
		}

		if (found) {
			harvester.moveTo (target);
		}
	}

	protected bool findSylo(HarvesterController harvester, out MonoBehaviour target) {
		harvester.stopAlarm ();
		bool found = this.tryAndFindNearest (Resources.FindObjectsOfTypeAll<Sylo> (), harvester, out target);

		if (found) {
			Debug.LogWarningFormat (
				"{0} collect {1} amount of resources and move to {2}.",
				harvester.name, harvester.getCapacity (), target.name
			);
		} else {
			Debug.LogWarningFormat (
				"{0} collect {1} amount of resources but cannot find sylo depot.",
				harvester.name, harvester.getCapacity ()
			);
		}

		return found;
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
