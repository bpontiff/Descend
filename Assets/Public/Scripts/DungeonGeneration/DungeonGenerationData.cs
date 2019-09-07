using UnityEngine;



[ExecuteInEditMode]
[CreateAssetMenu(fileName = "DungeonGenerationData.asset", menuName = "DungeonGenerationData/Dungeon Data")]
public class DungeonGenerationData : ScriptableObject
{
    public int numberOfCrawlers, iterationMin, iterationMax;
    public string levelPrefix;
    public roomGenerationData[] roomChances;
    public float totalSpawnChance;

    private void Start()
    {
    }

    private void OnValidate()
    {
        totalSpawnChance = 0;
        foreach (roomGenerationData room in roomChances)
        {
            totalSpawnChance += room.spawnChance;
        }
    }
}

[System.Serializable]
public class roomGenerationData
{
    public string roomName;

    [Range(0, 100)]
    public float spawnChance;

}
