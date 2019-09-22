using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Public.Scripts;
using Pathfinding;

public class EnemyChaseClosest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Transform closestPlayer = GetClosestPlayer(FindObjectsOfType<Player>());
        this.GetComponent<AIDestinationSetter>().target = closestPlayer;
    }
    Transform GetClosestPlayer(Player[] players)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Player p in players)
        {
            float dist = Vector3.Distance(p.gameObject.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = p.gameObject.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

}
