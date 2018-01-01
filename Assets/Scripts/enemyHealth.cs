using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public int HP = 200;
    void Update()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            if (GetComponentInParent<GameObject>().name == "Boss")
                playerInfo.Current.playerScore += 1000;
            else
                playerInfo.Current.playerScore += 100;
            return;
        }
    }
}
