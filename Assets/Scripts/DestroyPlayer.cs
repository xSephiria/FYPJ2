﻿using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerInfo.Current.iFrameTimer <= 0)
            {
                other.gameObject.SetActive(false);
                playerInfo.Current.isDead = true;
                playerInfo.Current.iFrameTimer = playerInfo.Current.invunerableTime;
                Time.timeScale = 0;
            }
            gameObject.SetActive(false);
        }
    }
}
