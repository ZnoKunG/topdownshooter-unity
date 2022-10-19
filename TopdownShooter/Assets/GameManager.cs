using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZnoKunG.Utils;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int gridWidth = 50, gridHeight = 20;
    [SerializeField] private Vector3 startPositionTransform = Vector3.zero;
    [SerializeField] private float cellSize = 0.5f;
    private Pathfinding pathfinding;

    internal void GeneratePathfinding()
    {
        pathfinding = new Pathfinding(gridWidth, gridHeight, startPositionTransform, cellSize);
    }

    private void Awake()
    {
        // level = new Level(5, 5, Vector3.zero, 5f);
        GeneratePathfinding();
        // level.GenerateLevel();
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            RoomNode clickedNode = level.GetGrid().GetGridObject(UtilsClass.GetMouseWorldPosition2D());
            List<RoomNode> adjacentRoomList = clickedNode.GetAdjacentRooms();
            foreach (RoomNode adjacentRoom in adjacentRoomList)
            {
                Debug.Log(adjacentRoom.x.ToString() + "," + adjacentRoom.y.ToString());
            }
        }*/
    }
}
