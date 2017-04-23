using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;


public class LaserGun : MonoBehaviour {
	public float fireRate = 0.25f;										// Number in seconds which controls how often the player can fire
	public float weaponRange = 500f;										// Distance in Unity units over which the player can fire
	public float hitForce = 100f;										// Amount of force which will be added to objects with a rigidbody shot by the player
	public GameObject sparkles;
	public GameObject hitLightPrefab;

	private Camera fpsCam;												// Holds a reference to the first person camera
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);	// WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
	private AudioSource gunAudio;										// Reference to the audio source which will play our shooting sound effect
	private LineRenderer laserLine;										// Reference to the LineRenderer component which will display our laserline
	private float nextFire;												// Float to store the time the player will be allowed to fire again, after firing
	private HitLight hitLightInstance;


	void Start () 
	{
		this.hitLightInstance = LaserGun.Instantiate(this.hitLightPrefab).GetComponent<HitLight>();
		// Get and store a reference to our LineRenderer component
		laserLine = GetComponent<LineRenderer>();

		// Get and store a reference to our AudioSource component
		gunAudio = GetComponent<AudioSource>();

		// Get and store a reference to our Camera by searching this GameObject and its parents
		fpsCam = GetComponent<Camera>();
	}
	

	void Update () 
	{
		// Check if the player has pressed the fire button and if enough time has elapsed since they last fired
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
		{
			// Update the time when our player can fire next
			nextFire = Time.time + fireRate;

			// Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine (ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = new Vector3(0.0f, 0.0f, 0.0f);

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;
			// Check if our raycast has hit anything
			if (Physics.Raycast (fpsCam.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)), fpsCam.transform.forward, out hit, weaponRange))
			{
				// Set the end position for our laser line 
				laserLine.SetPosition (1, transform.InverseTransformPoint(hit.point));

				if (hit.collider.tag == "Enemy")
				{
					var enemy = hit.transform.gameObject;
					enemy.GetComponent<EnemyController>().destroy();
//					log.NewActivity("Slime destroyed");
				}
				HarvesterController harvester = hit.collider.gameObject.GetComponent<HarvesterController> ();

				if ((harvester != null) && (!harvester.isAttacked ())) {
					harvester.kill ();
//					log.NewActivity("You destroyed an harvester!");
				}

				Sylo sylo = hit.collider.gameObject.GetComponent<Sylo> ();

				if (sylo != null) {
					LaserGun.Instantiate(this.sparkles, hit.point, hit.transform.rotation);
					sylo.getDamage();
				}

				Vector3 lightPoint = fpsCam.WorldToViewportPoint(hit.point) + new Vector3(0, 0,-0.25f);
				this.hitLightInstance.summon(fpsCam.ViewportToWorldPoint(lightPoint));
//
//				// Get a reference to a health script attached to the collider we hit
//				ShootableBox health = hit.collider.GetComponent<ShootableBox>();
//
//				// If there was a health script attached
//				if (health != null)
//				{
//					// Call the damage function of that script, passing in our gunDamage variable
//					health.Damage (gunDamage);
//				}
//
			}
			else
			{
				laserLine.SetPosition (1, new Vector3(0.0f, 0.0f, 50.0f));
			}
		}
	}


	private IEnumerator ShotEffect()
	{
		// Play the shooting sound effect
		gunAudio.Play ();

		// Turn on our line renderer
		laserLine.enabled = true;

		//Wait for .07 seconds
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
}
