using UnityEngine;
using System.Collections;

public class Stage1BossBullet : MonoBehaviour {
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;
    bool count = false;
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //if (count)
            //{
            //    circlePattern(30, "red");
            //    count = false;
            //}
            //else
            //{
            //    circlePattern(30, "blue");
            //    count = true;
            //}

            sineWave(3, 2, false, "red");
            sineWave(3, 2, true, "blue");
        }
    }

    void circlePattern(float angleToRotate, string colour) // 360 / angleToRotate = number of bullets, use fire rate of 0.4-0.5
    {
        for (float i = 0; i < 360; i+=angleToRotate)
        {
            GameObject bullet = enemyBulletPool.Current.GetPooledObject(colour);
            if (bullet == null)
                return;
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, i);
            bullet.SetActive(true);

            bullet.gameObject.GetComponent<bulletMovement>().movementMode = 1;
        }
    } 

    void sineWave(float freq, float mag, bool flip, string colour) // use fire rate of 0.2 - 0.3, frequency of 2-3, magnitude of 2-3
    {
        GameObject bullet = enemyBulletPool.Current.GetPooledObject(colour);
        if (bullet == null)
            return;
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;
        bullet.SetActive(true);

        bullet.gameObject.GetComponent<bulletMovement>().freq = freq;
        bullet.gameObject.GetComponent<bulletMovement>().mag = mag;
        bullet.gameObject.GetComponent<bulletMovement>().movementMode = 2;
        bullet.gameObject.GetComponent<bulletMovement>().flip = flip;
    }
}
