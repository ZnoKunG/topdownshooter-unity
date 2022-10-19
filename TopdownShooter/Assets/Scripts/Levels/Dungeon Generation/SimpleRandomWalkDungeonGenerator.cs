using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZnoKunG.Utils;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField] protected SimpleRandomWalkSO randomWalkParameters;
    // Debugger
    private TextMesh[,] debugTextArray;
    private GameObject textMeshGroup;
    private bool isDebug = false;

    private void Awake()
    {
        textMeshGroup = new GameObject("TextMeshDebugger");
        debugTextArray = new TextMesh[randomWalkParameters.iterations * randomWalkParameters.walkLength, randomWalkParameters.iterations * randomWalkParameters.walkLength];
    }
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);

        if (isDebug) {
            ShowRandomWalkDebugger(floorPositions);
        }
    }

    public void ShowRandomWalkDebugger(HashSet<Vector2Int> floorPositions)
    {
        if (textMeshGroup.transform.childCount > 0) { // If there is any element in textMeshGroup
            ResetTextMeshGameObject();
        }
        for (int i = 0; i < floorPositions.Count; i++) {
            int x = floorPositions.ElementAt(i).x;
            int y = floorPositions.ElementAt(i).y;
            CreateWorldTextDebugger(x, y, floorPositions.ElementAt(i));
        }
    }

    private void ResetTextMeshGameObject()
    {
        Destroy(textMeshGroup);
        textMeshGroup = new GameObject("TextMeshDebugger");
    }

    private void CreateWorldTextDebugger(int x, int y, Vector2Int position)
    {
        debugTextArray[x, y] = UtilsClass.CreateWorldText(x.ToString() + "," + y.ToString(), textMeshGroup.transform, (Vector3Int)position, 10, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
    {
        Vector2Int currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            HashSet<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);
            floorPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration) { // Set Current position to Random Position on already created floors
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }

}
