using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public int rotationSpeed;
    public string name;

    // Use this for initialization
    void Start ()
    {
        rotation = transform.position;
	}
    public Vector3 rotation;
    public float timer;

	// Update is called once per frame
	void Update ()
    {
        timer += 0.01f * rotationSpeed;
        transform.rotation = Quaternion.Euler(timer, timer / 2f, timer / 4f);
	}
}
