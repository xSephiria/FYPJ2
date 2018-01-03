using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public int HP = 5;
    void Update()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);    
            playerInfo.Current.playerScore += 100;
            playerInfo.Current.enemiesKilledInStage += 1; 
        }
    }
}
