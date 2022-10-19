using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomGridDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    private int roomWidth = 10, roomHeight = 10;
    [SerializeField]
    private int corridorLength = 10;
    [SerializeField]
    private RandomGridSO randomGridParameters;
    [SerializeField]
    private int minRooms = 5;
    [SerializeField]
    private int corridorWidth = 3;
    protected override void RunProceduralGeneration()
    {
        GridRoomGeneration();
    }

    private void GridRoomGeneration()
    {
        HashSet<Vector2Int> roomCentersPosition = new HashSet<Vector2Int>();
        HashSet<Vector2Int> corridorPosition = new HashSet<Vector2Int>();

        CreateRandomCorridors(corridorPosition, roomCentersPosition);
        while (roomCentersPosition.Count < minRooms)
        {
            CreateRandomCorridors(corridorPosition, roomCentersPosition);
        }
        HashSet<Vector2Int> floorsPosition = SetCorridorsWidth(corridorPosition, corridorWidth);
        HashSet<Vector2Int> roomsPosition = CreateRooms(roomCentersPosition);
        floorsPosition.UnionWith(roomsPosition);

        tilemapVisualizer.PaintFloorTiles(floorsPosition);
        WallGenerator.CreateWalls(floorsPosition, tilemapVisualizer);
    }

    private HashSet<Vector2Int> SetCorridorsWidth(HashSet<Vector2Int> corridors, int corridorWidth)
    {
        HashSet<Vector2Int> extendedCorridors = new HashSet<Vector2Int>();
        foreach (Vector2Int corridor in corridors)
        {
            extendedCorridors.Add(corridor);
            HashSet<Vector2Int> addedCorridorWidths = new HashSet<Vector2Int>();
            for (int i = 0; i < corridorWidth - 1; i++)
            {
                foreach (Vector2Int direction in Direction2D.cardinalDirectionsList) // Add all directions to corridor
                {
                    addedCorridorWidths.Add(corridor + direction * i);
                }
            }
            extendedCorridors.UnionWith(addedCorridorWidths);
        }
        return extendedCorridors;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> roomsPosition)
    {
        HashSet<Vector2Int> roomsFloor = new HashSet<Vector2Int>();
        foreach (Vector2Int room in roomsPosition)
        {
            for (int x = 0; x < roomWidth; x++)
            {
                for (int y = 0; y < roomHeight; y++)
                {
                    Vector2Int floor = room + new Vector2Int(x, y) - new Vector2Int(roomWidth / 2, roomHeight / 2);
                    roomsFloor.Add(floor);
                }
            }
        }
        return roomsFloor;
    }

    private void CreateRandomCorridors(HashSet<Vector2Int> floorsPosition, HashSet<Vector2Int> roomsPosition)
    {
        Vector2Int currentPosition = startPosition;
        roomsPosition.Add(currentPosition);
        for (int x = 0; x < randomGridParameters.gridWidth; x++)
        {
            for (int y = 0; y < randomGridParameters.gridHeight; y++)
            {
                List<Vector2Int> corridor = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
                Vector2Int nextPosition = corridor[corridor.Count - 1];
                while (Mathf.Abs(nextPosition.x - startPosition.x) > (randomGridParameters.gridWidth / 2) * corridorLength || Mathf.Abs(nextPosition.y - startPosition.y) > (randomGridParameters.gridHeight / 2) * corridorLength)
                {
                    corridor = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
                    nextPosition = corridor[corridor.Count - 1];
                }
                currentPosition = nextPosition;
                roomsPosition.Add(currentPosition);
                floorsPosition.UnionWith(corridor);
            }
        }
    }

}
