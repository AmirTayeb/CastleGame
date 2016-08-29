using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {

	public string Message="Having fun playing Ozu #4kgs #ozu http://4knights.net/contact";
    public GameObject button_sfx;
	void Start()
	{

	}
	public void Web()
    {
        Instantiate(button_sfx);
        Application.OpenURL("http://4knights.net/contact");
    }

    public void FB()
    {
        Instantiate(button_sfx);
        Application.OpenURL("https://www.facebook.com/4knightsgames/?fref=ts");
    }

    public void SoundCloud()
    {
        Instantiate(button_sfx);
        Application.OpenURL("https://soundcloud.com/4knights-game-studio");
    }

    public void Twitter()
    {
        Instantiate(button_sfx);
        Application.OpenURL("https://twitter.com/4knightsgames");
    }

	public void ShareToTwitter()
	{
        Instantiate(button_sfx);
        Application.OpenURL ("https://twitter.com/intent/tweet?text=" + Message + "&amp;lang=en");
	}
}
