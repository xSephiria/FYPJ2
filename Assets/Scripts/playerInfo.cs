using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerInfo : MonoBehaviour {

    public static playerInfo Current;
    public int playerScore;
    public Text score;
    public int remainingLives = 3;
    public Text lives;
    public bool stage1Cleared = false;
    public bool stage2Cleared = false;
    public bool stage3Cleared = false;
    public int enemiesKilledInStage = 0;
    public bool isDead = false;
    public float invunerableTime = 3.0f;
    public float iFrameTimer = 0;
    public GameObject zToRespawn;
    public GameObject playerDeco;
    public GameObject player;
    void Awake()
    {
        Current = this;
    }
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            if (remainingLives <= 0)
                zToRespawn.GetComponentInChildren<Text>().text = "Out of Lives!\nPress Z to return\nto Main Menu";
            zToRespawn.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (remainingLives > 0)
                {
                    isDead = false;
                    player.SetActive(true);
                    StartCoroutine(Blink(invunerableTime));
                    remainingLives -= 1;
                    Time.timeScale = 1;
                }
                else
                {
                    remainingLives = 3;
                    playerScore = 0;
                    stage1Cleared = false;
                    stage2Cleared = false;
                    stage3Cleared = false;
                    enemiesKilledInStage = 0;
                    SceneManager.LoadScene("MainMenu");
                    Time.timeScale = 1;
                }
            }
        }
        else
            zToRespawn.SetActive(false);

        if (iFrameTimer > 0 && !isDead)
            iFrameTimer -= Time.deltaTime;

        score.text = playerScore.ToString();
        lives.text = remainingLives.ToString();
	}

    private IEnumerator Blink(float seconds)
    {
        var endTime =Time.time + seconds;
        while(Time.time < endTime)
        {
            player.GetComponent<Renderer>().enabled = false;
            playerDeco.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.05f);
            player.GetComponent<Renderer>().enabled = true;
            playerDeco.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.05f);
        }   
    }
}
