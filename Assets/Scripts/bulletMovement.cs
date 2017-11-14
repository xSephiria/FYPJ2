using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour {

    public float speed = 6;
    // 1 for straight
    // 2 for sine/cosine wave
    public int movementMode = 1;

    public float freq = 1f;
    public float mag = 1f;
    public bool flip = false;
    Vector2 axis;
    Vector2 pos;
    //void Start()
    //{
    //    switch (movementMode)
    //    {
    //        case 1:
    //            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    //            break;
    //        case 2:
    //            pos = transform.position;
    //            DestroyObject(gameObject, 1.0f);
    //            axis = transform.right;
    //            break;
    //    }
    //}

    void Update()
    {
        switch (movementMode)
        {
            case 1:
                break;
            case 2:
                pos += (Vector2)transform.up * Time.deltaTime * -speed;
                if (!flip)
                    transform.position = pos + axis * (Mathf.Sin(Time.time * freq) * mag);
                else
                    transform.position = pos + axis * -(Mathf.Sin(Time.time * freq) * mag);
                break;
        }
    }

    void OnEnable()
    {
        switch (movementMode)
        {
            case 1:
                GetComponent<Rigidbody2D>().velocity = transform.up * speed;
                break;
            case 2:
                pos = transform.position;
                axis = transform.right;
                break;
        }
    }
}
