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
		if (this.showExplosion == false) {
			HarvesterController.Destroy(harvester.gameObject);
		} else {
			this.animationDuration -= Time.deltaTime;

			if (this.animationDuration <= 0) {
				HarvesterController.Destroy(this.anim);
				HarvesterController.Destroy(harvester.gameObject);
			}

			if (this.playingDeath == false) {
				this.playingDeath = true;
				GameObject model = harvester.transform.Find("Model").gameObject;
				model.GetComponent< Renderer >().enabled = false;
				this.anim = HarvesterController.Instantiate(this.explosion, harvester.transform.position, harvester.transform.rotation);
			}
		}
	}
}
