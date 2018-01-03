using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public Image Controls;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void showControls(bool show)
    {
        Controls.gameObject.SetActive(show);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
