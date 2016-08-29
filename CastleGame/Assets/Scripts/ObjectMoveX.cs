using UnityEngine;
using System.Collections;

public class ObjectMoveX : MonoBehaviour {

    public float
        min_position = 0.01f, max_position = 0.01f, position_step_x = 0.0005f;

    float  start_position_x, position_target_x, position_y, position_x;

    // Use this for initialization
    void Start () {
        start_position_x = this.gameObject.transform.transform.position.x;

    }

    // Update is called once per frame
    void Update ()
    {
        position_y = this.gameObject.transform.transform.position.y;
        position_x = this.gameObject.transform.transform.position.x;

        // Y move
        if (position_target_x >= position_x)
        {
            position_target_x = start_position_x + max_position;
			this.gameObject.transform.position = new Vector3(position_x + position_step_x, position_y ,this.gameObject.transform.position.z);

        }


        if (position_target_x < position_x)
        {
            position_target_x = start_position_x - min_position;
			this.gameObject.transform.position = new Vector3(position_x - position_step_x, position_y, this.gameObject.transform.position.z);

        }
    }
}
