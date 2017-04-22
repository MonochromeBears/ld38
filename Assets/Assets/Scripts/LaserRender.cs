using UnityEngine;
using System.Collections;

public class LaserRender : MonoBehaviour {

	public float weaponRange = 50f;                       // Distance in Unity units over which the Debug.DrawRay will be drawn

	private Camera fpsCam;                                // Holds a reference to the first person camera


	void Start () 
	{
		// Get and store a reference to our Camera by searching this GameObject and its parents
		fpsCam = GetComponentInParent<Camera>();
	}


	void Update () 
	{
		// Create a vector at the center of our camera's viewport
//		Vector3 lineOrigin = fpsCam.transform.position;
//
//		Debug.logger.Log (lineOrigin);
	}
}
