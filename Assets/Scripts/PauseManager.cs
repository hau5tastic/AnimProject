using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }
    public bool IsPaused = false;
    public Canvas pauseMenu = null;
    public void Pause()
    {
        pauseMenu.enabled = true;
        IsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.enabled = false;
        IsPaused = false;
    }
}
