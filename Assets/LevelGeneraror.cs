using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneraror : MonoBehaviour
{
    public GameObject BlockPrefab;
    public GameObject FoodPrefab;

    private float segmentLength = 22.32f;
    private float startOffset = 4.3f;
    private float cubeSpace = 1.06f;

    void Awake()
    {
        for (int i = 0; i < 7; i++)
        {
            GenerateSegment(i);
        }
    }

    private void GenerateSegment(int segmentNumber)
    {
        for (int i = 0; i < 20; i++)
        {
            GenerateRow(i, segmentNumber);
        }
        GenerateWall(segmentNumber);

    }

    private void GenerateWall(int segmentNumber)
    {
        System.Random rnd = new System.Random();
        int smallBlockLine = rnd.Next(5);

        for (int i = 0; i < 5; i++)
        {
            Vector3 position = CalculatePosition(i, 20, segmentNumber);
            int maxDurability;

            maxDurability = (i == smallBlockLine) ? 4 : 100;
            GenerateObject(BlockPrefab, position, rnd.Next(1, maxDurability));
        }
    }

    private void GenerateRow(int rowNumber, int segmentNumber)
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = CalculatePosition(i, rowNumber, segmentNumber);
            switch(rnd.Next(30))
            {
                case 0:
                    if (rowNumber != 19 && rowNumber != 0) GenerateObject(BlockPrefab, position, rnd.Next(1, 100)); // condition to prevent big block from appearing around small block
                    break;
                case 1:
                    GenerateObject(FoodPrefab, position, rnd.Next(1, 6));
                    break;
                default:
                    break;
            }
        }
    }

    private void GenerateObject(GameObject prefab, Vector3 position, int durability)
    {
        GameObject jbj = Instantiate(prefab, position, Quaternion.identity, gameObject.transform);
        DurabilityIndicator cmp = jbj.GetComponent(typeof(DurabilityIndicator)) as DurabilityIndicator;
        cmp.durability = durability;
    }

    private Vector3 CalculatePosition(int rowNumber, int lineNumber, int segmentNumber)
    {
        float x = cubeSpace * (-2 + rowNumber); /* middle line is "zero"-line, so left line is "-2nd" */
        float y = 0.5f;
        float z = startOffset + segmentNumber * segmentLength + 0.56f + cubeSpace * lineNumber;

        return new Vector3(x, y, z);
    }
}
