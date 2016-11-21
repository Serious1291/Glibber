using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour {

    // does not work every time - their are ways into the cube...
    public Rigidbody rb;
	void OnCollisionEnter (Collision col)
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnCollisionExit (Collision col)
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
