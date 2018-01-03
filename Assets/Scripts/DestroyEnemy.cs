﻿using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

    public int bulletDamage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemyHealth>().HP -= bulletDamage;
            gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Boss")
        {
            other.GetComponent<bossHealth>().HP -= bulletDamage;
            gameObject.SetActive(false);
        }
    }
}
