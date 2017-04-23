using System;
using UnityEngine;

public class MoveStrategy: StrategyInterface
{
	public MonoBehaviour target;

	public void action(HarvesterController harvester) {
		if (this.target == null) {
			harvester.stay ();

			return;
		}

		Vector3 motion = Vector3.MoveTowards (
			harvester.transform.position, 
			this.target.transform.position, 
			Time.deltaTime * harvester.speed
		);


		var earth = GameObject.Find ("Sphere");
		Vector3 sphereUp = harvester.transform.position - earth.transform.position;
		harvester.transform.LookAt (motion, sphereUp);
		harvester.transform.rotation = Quaternion.FromToRotation(
			harvester.transform.up,
			harvester.transform.position - earth.transform.position) * harvester.transform.rotation;

		harvester.setOldPosition (harvester.transform.position);

		harvester.transform.position = motion;

	}
}
