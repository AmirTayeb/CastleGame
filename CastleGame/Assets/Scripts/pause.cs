using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

    public GameObject pauseMenu;
    bool trigger=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
       if(Input.GetKeyDown(KeyCode.Escape))
        {

            trigger = !trigger;

            if (trigger)
            {
                Time.timeScale = 0;

                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;

                pauseMenu.SetActive(false);
            }

        }
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        trigger = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

