using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerInfo : MonoBehaviour {

    public static playerInfo Current;
    public int playerScore;
    public Text score;
    public int remainingLives;
    public bool stage1Cleared = false;
    public bool stage2Cleared = false;
    public bool stage3Cleared = false;

    void Awake()
    {
        Current = this;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        score.text = playerScore.ToString();
	}
}
