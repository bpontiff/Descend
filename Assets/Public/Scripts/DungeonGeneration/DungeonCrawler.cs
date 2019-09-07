using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawler
{
    public Vector2Int position { get; set; }
    public DungeonCrawler(Vector2Int startPos)
    {
        this.position = position;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);

        position += directionMovementMap[toMove];
        return position;
    }
}
