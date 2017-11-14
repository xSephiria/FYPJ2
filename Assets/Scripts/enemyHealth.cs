using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public float HP = 200;
    void Update()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
    }
}
