using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public TerrainBlocks[] terrainBlocks;
    public int maxDepth;
    // Start is called before the first frame update
    void Start()
    {
        maxDepth = 0;
        float value;
        TerrainBlocks blockToSpawn = null;
        float lowestProbability;
        foreach (var block in terrainBlocks)
        {
            if (block.maxDepth > maxDepth)
            {
                maxDepth = block.maxDepth;
            }
        }

        for (int i = 0; i < maxDepth; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                value = Random.value;
                lowestProbability = 1.1f;
                foreach (var block in terrainBlocks)
                {
                    if (i < block.maxDepth)
                    {
                        if (value < block.probability)
                        {
                            if (block.probability < lowestProbability)
                            {
                                lowestProbability = block.probability;
                                blockToSpawn = block;
                            }
                        }
                    }
                }
                Instantiate(blockToSpawn.blockPrefab, new Vector3(j, -i, 0), new Quaternion(), this.gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
