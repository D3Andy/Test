using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TerrainBlocksScriptableObject", order = 1)]
public class TerrainBlocks : ScriptableObject
{
    public GameObject blockPrefab;
    public BlockType type;
    public int cost;
    public int minDepth;
    public int maxDepth;
    public float probability;
    public int hardnes;

    public enum BlockType
    {
        Dirt,
        Coal,
        Iron,
        Copper,
        Gold,
        Diamond,
        EndBlock
    }
}

