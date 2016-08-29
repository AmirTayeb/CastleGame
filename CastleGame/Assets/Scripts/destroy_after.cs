using UnityEngine;
using System.Collections;

public class destroy_after : MonoBehaviour {
    public float time_to_destroy ;



// Update is called once per frame
void Update ()
    {
        Destroy(gameObject, time_to_destroy);
	}
}
