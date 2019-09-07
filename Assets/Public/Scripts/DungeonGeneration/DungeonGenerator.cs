using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public DungeonGenerationData dungeonGenerationData;

    private List<Vector2Int> dungeonRooms;

    private void Awake()
    {
        //Check for any null variables that would cause issues. Kill the run if they exist
        if (dungeonGenerationData.levelPrefix == null)
        {
            Debug.LogError("DungeonGenerationData level prefix string is null. Please assign the level prefix inspector before resuming");
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }
        dungeonGenerationData.totalSpawnChance = 0;
        foreach (roomGenerationData room in dungeonGenerationData.roomChances)
        {
            if(room.roomName.Equals(""))
            {
                Debug.LogError("DungeonGenerationData has a room defined with a blank room name. Please put valid room names in the inspector before resuming");
                UnityEditor.EditorApplication.isPlaying = false;
                return;
            }
            dungeonGenerationData.totalSpawnChance += room.spawnChance;
        }
        if (dungeonGenerationData.totalSpawnChance != 100f)
        {
            Debug.LogError("DungeonGenerationData chance to spawn all rooms is less than 100%. Please have the sum of chances equal 100 in the inspector before resuming");
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }
    }

    private void Start()
    {
        //Generate the map locations
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        //Set the dungeon prefix to be loading
        RoomController.instance.dungeonLevelName = dungeonGenerationData.levelPrefix;
        //Spawn the rooms at the set locations
        SpawnRooms(dungeonGenerationData.roomChances, dungeonRooms);
    }

    private void SpawnRooms(roomGenerationData[] roomChances, List<Vector2Int> dungeonRooms)
    {
        string roomName = "Start";
        RoomController.instance.LoadRoom(roomName, 0, 0);
        float roomSpawnNumber;
        float roomValue;
        foreach (Vector2Int roomLocation in dungeonRooms)
        {
            roomSpawnNumber = Random.Range(0, 100);
            roomValue = 0;
            foreach (roomGenerationData room in dungeonGenerationData.roomChances)
            {
                if (roomSpawnNumber >= roomValue && roomSpawnNumber < (room.spawnChance + roomValue))
                {
                    roomName = room.roomName;
                    break;
                }
                roomValue += room.spawnChance;
            }
            RoomController.instance.LoadRoom(roomName, roomLocation.x, roomLocation.y);
        }

    }
}
