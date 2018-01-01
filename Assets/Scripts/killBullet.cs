using UnityEngine;
using System.Collections;

public class killBullet : MonoBehaviour {

    public float activeTime = 2.5f; // time the bullet will last before disappearing
    void OnEnable()
    {
        Invoke("Destroy", activeTime);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
