using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

    public int bulletDamage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemyHealth>().HP -= bulletDamage;
            gameObject.SetActive(false);
            Debug.Log(other.GetComponent<enemyHealth>().HP);
        }
    }
}
