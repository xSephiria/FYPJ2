using UnityEngine;
using System.Collections;

public class killBullet : MonoBehaviour {

    void OnEnable()
    {
        Invoke("Destroy", 2.5f);
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
