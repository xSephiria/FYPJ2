using UnityEngine;
using System.Collections;

public class Stage1Boss : MonoBehaviour {

    public Transform[] Waypoints;
    public float movementSpeed;
    public int currentWaypoint;
    public bool Patrol = true;
    public Vector2 Target;
    public Vector2 moveDirection;
    public Vector2 velocity;
    
    void Update()
    {
        if (currentWaypoint < Waypoints.Length)
        {
            Target = Waypoints[currentWaypoint].position;
            moveDirection = new Vector2(Target.x - transform.position.x, Target.y - transform.position.y);
            velocity = GetComponent<Rigidbody2D>().velocity;

            if (moveDirection.magnitude < 1)
                currentWaypoint++;
            else
                velocity = moveDirection.normalized * movementSpeed;
        }
        else
        {
            if (Patrol)
                currentWaypoint = 0;
            else
                velocity = Vector2.zero;
        }
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
