using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActorMovementModel;

public class BasicFollow : MonoBehaviour
{
    public GameObject followTarget;
    private ActorMovementModel playerInstance;
    private float zRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(followTarget == null)
        {
            Debug.LogWarning("Follow target for " + this.ToString() + " is null. Destroying object.");
            Destroy(this.gameObject);
        }
        playerInstance = followTarget.GetComponent<ActorMovementModel>();
        if(playerInstance == null)
        {
            Debug.LogWarning("Follow target for " + this.ToString() + " is not set to a player. Destroying object.");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTarget.transform.position + (transform.position - followTarget.transform.position).normalized * 1;

        Directions followDir = playerInstance.GetDirections();

        if (followDir == Directions.South)
        {
            zRotation = 180;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
        else if (followDir == Directions.North)
        {
            zRotation = 0;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
        else if (followDir == Directions.East)
        {
            zRotation = 90;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
        else if (followDir == Directions.West)
        {
            zRotation = 270;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
    }
}
