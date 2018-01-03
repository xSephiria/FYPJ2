using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bossHealth : MonoBehaviour {

    public int HP = 200;
    public Slider bossHP;

    void Update()
    {
        bossHP.value = HP;
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            bossHP.gameObject.SetActive(false);
            playerInfo.Current.playerScore += 1000;
        }
    }
}
