using System;
using UnityEngine;

namespace Enemy
{
	public class DestroyStrategy: StrategyInterface
	{
		public GameObject explosion;

		private float animationDuration = 1.0f;
		private bool playingDeath = false;
		private GameObject anim;

		public void move(EnemyController enemy) {
			if (enemy.hasTakenHarvester()) {
				enemy.getTakenHarvester().stay();
			}

			this.animationDuration -= Time.deltaTime;

			if (this.animationDuration <= 0) {
				EnemyController.Destroy(this.anim);
				EnemyController.Destroy(enemy.gameObject);
			}

			if (this.playingDeath == false) {
				this.playingDeath = true;
				enemy.GetComponent< Renderer >().enabled = false;
				this.anim = EnemyController.Instantiate(this.explosion, enemy.transform.position, enemy.transform.rotation);
			}
			
		}
	}
}
