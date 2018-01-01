using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
