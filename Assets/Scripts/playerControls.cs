using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {

    float speed = 20;

    [Header("Movement Boundaries")]
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

	void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody2D>();
        Vector3 movement = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speed = 10;
        else
            speed = 20;

        if (Input.GetKey(KeyCode.RightArrow))
            movement.x = 10;
        else if (Input.GetKey(KeyCode.LeftArrow))
            movement.x = -10;
        else if (Input.GetKey(KeyCode.UpArrow))
            movement.y = 10;
        else if (Input.GetKey(KeyCode.DownArrow))
            movement.y = -10;
        else
            movement.Set(0, 0, 0);

        rb.velocity = movement * speed * Time.deltaTime;

        // Prevents the player from moving out of the screen
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, minX, maxX),
            Mathf.Clamp(rb.position.y, minY, maxY),
            0.0f
            );
    }
}
