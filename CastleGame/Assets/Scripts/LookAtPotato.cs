using UnityEngine;
using System.Collections;

public class LookAtPotato : MonoBehaviour {

    public Transform Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.LookAt(Target);
	}
}
