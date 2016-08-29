using UnityEngine;
using System.Collections;

public class SwitchMusic : MonoBehaviour {

    public GameObject MusicBG;
    bool toggle = true;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            toggle = !toggle;
            MusicBG.SetActive(toggle);
        }
    }
}
