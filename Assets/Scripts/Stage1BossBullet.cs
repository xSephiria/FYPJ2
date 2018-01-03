using UnityEngine;
using System.Collections;

public class Stage1BossBullet : MonoBehaviour {
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;
    bool count = false;
    float timer;
    int hp;
    void Update()
    {
        timer += Time.deltaTime;
        hp = GetComponentInParent<bossHealth>().HP;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (hp > 100)
            {
                if (count)
                {
                    circlePattern(30, "red", 2.5f);
                    count = false;
                }
                else
                {
                    circlePattern(30, "blue", 2.5f);
                    count = true;
                }
            }
            else if (hp > 50 && hp <= 100)
            {
                sineWave(3, 2, false, "red", 2.5f);
                sineWave(3, 2, true, "blue", 2.5f);
                GetComponentInParent<moveAlongWaypoint>().Patrol = false;
            }
            else if (hp <= 50 && hp > 0)
                flowerPattern("red", "blue", 1.5f);
            else
                playerInfo.Current.stage1Cleared = true;
        }
    }

    void circlePattern(float angleToRotate, string colour, float activeTime) // 360 / angleToRotate = number of bullets, use fire rate of 0.4-0.5
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

            if (activeTime > 0)
                bullet.gameObject.GetComponent<killBullet>().activeTime = activeTime;
        }
    } 

    void sineWave(float freq, float mag, bool flip, string colour, float activeTime) // use fire rate of 0.2 - 0.3, frequency of 2-3, magnitude of 2-3
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
        if (activeTime > 0)
            bullet.gameObject.GetComponent<killBullet>().activeTime = activeTime;
    }

    void spiral(string colour, bool direction, float activeTime)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = enemyBulletPool.Current.GetPooledObject(colour);
            if (bullet == null)
                return;
            bullet.transform.position = bulletSpawn.position;
            if (direction)
                bullet.transform.rotation = Quaternion.Euler(0, 0, bulletSpawn.rotation.z + (timer * 20) + (i * 90));
            else
                bullet.transform.rotation = Quaternion.Euler(0, 0, -(bulletSpawn.rotation.z + (timer * 20) + (i * 90)));
            bullet.SetActive(true);

            bullet.gameObject.GetComponent<bulletMovement>().movementMode = 1;

            if (activeTime > 0)
                bullet.gameObject.GetComponent<killBullet>().activeTime = activeTime;
        }
    }
    void flowerPattern(string colour1, string colour2, float activeTime)
    {
        spiral(colour1, true, activeTime);
        spiral(colour2, false, activeTime);
    }
}
