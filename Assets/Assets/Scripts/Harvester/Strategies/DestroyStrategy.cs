using System;
using UnityEngine;
using Enemy;

public class DestroyStrategy: StrategyInterface
{
	public GameObject explosion;
	public bool showExplosion = false;

	private float animationDuration = 1.0f;
	private bool playingDeath = false;
	private GameObject anim;

	public void action(HarvesterController harvester) {
		if (this.showExplosion) {
			this.animationDuration -= Time.deltaTime;

			if (this.animationDuration <= 0) {
				HarvesterController.Destroy (this.anim);
				HarvesterController.Destroy (harvester.gameObject);
				Debug.LogErrorFormat ("{0} has been destroyed", harvester.name);
			}

			if (!this.playingDeath) {
				this.playingDeath = true;
				GameObject model = harvester.transform.Find ("Model").gameObject;
				model.GetComponent< Renderer > ().enabled = false;
				this.anim = HarvesterController.Instantiate (this.explosion, harvester.transform.position, harvester.transform.rotation);
			}
		} else {
			HarvesterController.Destroy (harvester.gameObject);
			Debug.LogErrorFormat ("{0} has been eaten by slime", harvester.name);
		}
	}
}
