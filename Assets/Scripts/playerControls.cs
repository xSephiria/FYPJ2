using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {

    float speed;
    const float normalSpeed = 35;
    const float concentrateSpeed = 20;
    [Header("Movement Boundaries")]
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    [Header("Bullet Related")]
    public Transform playerBulletSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                straightShot();
            else
                arcShot();
        }
    }

	void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody2D>();
        Vector3 movement = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speed = concentrateSpeed;
        else
            speed = normalSpeed;

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

    void arcShot()
    {
        //GameObject obj = playerBulletPool.Current.GetPooledObject();
        //if (obj == null)
        //    return;
        //obj.transform.position = new Vector2(0.7f + playerBulletSpawn.position.x, playerBulletSpawn.position.y);
        //obj.transform.rotation = Quaternion.Euler(0, 0, -30);
        //obj.SetActive(true);
        //obj.gameObject.GetComponent<bulletMovement>().movementMode = 1;

        //obj = playerBulletPool.Current.GetPooledObject();
        //if (obj == null)
        //    return;
        //obj.transform.position = new Vector2(-0.7f + playerBulletSpawn.position.x, playerBulletSpawn.position.y);
        //obj.transform.rotation = Quaternion.Euler(0, 0, 30);
        //obj.SetActive(true);
        //obj.gameObject.GetComponent<bulletMovement>().movementMode = 1;
        
        //for (int i = -1; i < 2; i++)
        //{
        //    obj = playerBulletPool.Current.GetPooledObject();

        //    if (obj == null)
        //        return;
        //    obj.transform.position = new Vector2(0.35f * i + playerBulletSpawn.position.x, playerBulletSpawn.position.y);
        //    obj.transform.rotation = playerBulletSpawn.rotation;
        //    obj.SetActive(true);

        //    obj.gameObject.GetComponent<bulletMovement>().movementMode = 1;
        //}
        for (int i = -2; i < 3; i++)
        {
            GameObject obj = playerBulletPool.Current.GetPooledObject();
            if (obj == null)
                return;
            obj.transform.position = new Vector2(0.35f * i + playerBulletSpawn.position.x, playerBulletSpawn.position.y);
            obj.transform.rotation = Quaternion.Euler(0, 0, -10 * i);
            obj.SetActive(true);
            obj.gameObject.GetComponent<bulletMovement>().movementMode = 1;
        }
    }

    void straightShot()
    {
        for (int i = -2; i < 3; i++)
        {
            GameObject obj = playerBulletPool.Current.GetPooledObject();

            if (obj == null)
                return;
            obj.transform.position = new Vector2(0.25f * i + playerBulletSpawn.position.x, playerBulletSpawn.position.y);
            obj.transform.rotation = playerBulletSpawn.rotation;
            obj.SetActive(true);

            obj.gameObject.GetComponent<bulletMovement>().movementMode = 1;
        }
    }
}
