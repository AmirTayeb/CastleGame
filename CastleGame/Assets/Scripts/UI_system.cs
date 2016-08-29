using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // needed to use the new SceneManger
using UnityEngine.EventSystems; // to get the name of clicked button

public class UI_system : MonoBehaviour {

	/* private Variables المتغيرات الخاصة */


	/* public Variables المتغيرات العامة */
	public GameObject creditpanel;
	public GameObject black_BG; // UI element that cover the BG of pop-up UI with Transparent Black make other UI un-clickable
    public string first_lvl_name;
    public GameObject button_sfx;
	// static variables متغيرات ثابته
	public static bool debug_UI_s = false; // used for debug mode


	//UI function used to go to selected level
	public void load_Level()
	{
        Instantiate(button_sfx);

		//Debug.Log ("enterd load_Level Function Loading Scene "+first_lvl_name+".....");

		//used to Switch to level scene
		SceneManager.LoadScene(first_lvl_name);
	}

	public void Credit()
	{
        Instantiate(button_sfx);
        creditpanel.SetActive (true);
		black_BG.SetActive (true);
	}

	public void Back()
	{
        Instantiate(button_sfx);
        creditpanel.SetActive (false);
		black_BG.SetActive (false);
	}

	//use to Exit game
	public void Exit()
	{
        Instantiate(button_sfx);
        Application.Quit ();
	}
}
