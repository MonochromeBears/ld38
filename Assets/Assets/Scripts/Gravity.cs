using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Gravity : MonoBehaviour {
 
    public GameObject[] objects;
    public GameObject planet;
 
    public float gravitationalPull;
 
    // void Start() {
    //     objects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    // }

    void FixedUpdate() {
        objects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        //apply spherical gravity to selected objects (set the objects in editor)
        foreach (GameObject o in objects) {
			Rigidbody rb = o.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddForce((planet.transform.position - o.transform.position).normalized * gravitationalPull);
            }
        }
        //or apply gravity to all game objects with rigidbody
        // foreach (GameObject o in UnityEngine.Object.FindObjectsOfType<GameObject>()) {
        //     if(o.rigidbody && o != planet){
        //         o.rigidbody.AddForce((planet.transform.position - o.transform.position).normalized * gravitationalPull);
        //     }
        // }
    }
 
}