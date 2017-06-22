using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Pull : MonoBehaviour {
    [Tooltip("The pivot point of our climbing")]
    public GameObject TrackedObject;

    [Tooltip("The snow the comes when we collide")]
    public ParticleSystem snow;

    [HideInInspector]
    public Vector3 prevpos;

    [HideInInspector]
    public bool cangrip;

	// Use this for initialization
	void Start () {
        prevpos = TrackedObject.transform.position;
	}

    public Vector3 Delta() {
        return prevpos - TrackedObject.transform.position;
    }

    private void LateUpdate() {
        // keep track of previous positions in order to calculate deltas
        prevpos = TrackedObject.transform.position;
    }

    void OnTriggerEnter(Collider other) {
        Vector3 velocity = Delta() / Time.fixedDeltaTime;

        if (velocity.magnitude > 5f && other.tag == "Climbable") { //only climb climbable objects
            snow.Emit(20);
            cangrip = true;
        }
    }


    void OnTriggerExit(Collider other) {
        if (other.tag == "Climbable") //only climb climbable objects
            cangrip = false;
    }
}
