using UnityEngine;
using System.Collections;

public class movement_system : MonoBehaviour {

    //public
    public GameObject player;
    public GameObject center_position;
    public GameObject rightup_position;
    public GameObject rightdown_position;
    public GameObject leftup_position;
    public GameObject leftdown_position;
    public float move_speed=20;
    public float jump_power=10;
    public GameObject Ground_Check;
    public bool Grounded =false;
    public float max_ground_distance=0.5f;
    public LayerMask ground_layer;
    public float fall_gravity=200;
    public GameObject uptoenter;

    //private
    int side = 0; // 0 mean center 1 mean right -1 mean left
    bool player_down=false;
    bool player_control=false; // allow player to move left and right and jump
    bool closetoCastle = false;
    // Use this for initialization
    void Start ()
    {
        player.transform.position = center_position.transform.position;
        side = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && player_down == false)
            {
                player.transform.position = rightup_position.transform.position;
                side = 1; //right side
                player_down = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && player_down == false)
            {
                player.transform.position = leftup_position.transform.position;
                side = -1; //left side
                player_down = false;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && player_down == false)
            {
                player.transform.position = center_position.transform.position;
                side = 0; //left side
                player_down = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && side == -1 && player_down == false)
            {
                player.transform.position = leftdown_position.transform.position;
                side = -1; //left side
                player_down = true;
                player_control = true;
                player.gameObject.GetComponent<Rigidbody>().useGravity = true;
                player.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && side == 1 && player_down == false)
            {
                player.transform.position = rightdown_position.transform.position;
                side = 1; //left side
                player_down = true;
                player_control = true;
                player.gameObject.GetComponent<Rigidbody>().useGravity = true;
                player.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }

            if (player_control)
            {
                player.transform.Translate(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * move_speed);


                if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && Grounded && !closetoCastle)
                {
                    player.gameObject.GetComponent<Rigidbody>().AddForce(player.GetComponent<Rigidbody>().velocity.x, jump_power, player.GetComponent<Rigidbody>().velocity.z);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded && closetoCastle && side == 1)
                {
                    player_control = false;
                    player.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    player.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    player.transform.position = rightup_position.transform.position;
                    side = 1; //right side
                    player_down = false;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded && closetoCastle && side == -1)
                {
                    player_control = false;
                    player.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    player.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    player.transform.position = leftup_position.transform.position;
                    side = -1; //left side
                    player_down = false;
                }
            }
        }
    }

    void FixedUpdate()
    {

        RaycastHit hit_info; // assign a variable to obtain the hited object information 
        Ray ground_check = new Ray(Ground_Check.transform.position, Vector3.down); // assign ray start position and direction 
        Debug.DrawRay(Ground_Check.transform.position, Vector3.down * max_ground_distance); // show the ray in scene

        //check if the ray hit a ground object
        if (Physics.Raycast(ground_check, out hit_info, max_ground_distance, ground_layer))
        {

            Grounded = true;
            Physics.gravity = new Vector3(0, -9.8f, 0);
            //Debug.Log (hit_info.collider.name+ " true ");

        }
        else
        {

            Grounded = false;
            Physics.gravity = new Vector3(0, -fall_gravity, 0);

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            uptoenter.SetActive(true);
            closetoCastle = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            uptoenter.SetActive(false);
            closetoCastle = false;
        }
    }
}
