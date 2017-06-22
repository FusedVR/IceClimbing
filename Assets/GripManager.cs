using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class GripManager : MonoBehaviour {
    public Rigidbody Body;

    public Pull left;
    public Pull right;

    void FixedUpdate() {
        bool isGripped = left.cangrip || right.cangrip; //whether either ice pick is hitting an object
        if (isGripped) {
            Vector3 posOffset = Vector3.zero; //keeps track of total offset
            if (left.cangrip) { //move based on left controller
                Body.useGravity = false;
                Body.isKinematic = true;
                posOffset += left.Delta();
            }


            if (right.cangrip) { //move based on right controller
                Body.useGravity = false;
                Body.isKinematic = true;
                posOffset += right.Delta();
            }
            Body.transform.position += posOffset;
        } else {
            //if no grips then enable real world physics
            // we assume that rotations are locked to avoid awkward falling
            Body.useGravity = true;
            Body.isKinematic = false;
        }

    }
}