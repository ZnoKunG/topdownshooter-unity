using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level
{
    private Grid<RoomNode> grid;
    private bool showDebug = true;
    public static Level Instance;
    public Level(int width, int height, Vector3 originPosition, float cellSize = 5f)
    {
        grid = new Grid<RoomNode>(width, height, cellSize, originPosition, (Grid<RoomNode> g, int x, int y) => new RoomNode(g, x, y));
        Instance = this;
    }

    public void GenerateLevel()
    {
        SetAllConnectedRooms();
        if (showDebug) ShowDebugger();
    }

    private void ShowDebugger()
    {
        foreach (RoomNode roomNode in grid.GetAllGridObjectArray())
        {
            foreach (RoomNode connectedRoomNode in roomNode.GetConnectedRoomList())
            {
                Debug.DrawLine(roomNode.GetNodeCenterPosition(), connectedRoomNode.GetNodeCenterPosition());
            }
        }
    }

    private void SetAllConnectedRooms()
    {
        List<RoomNode> allRoomNodeList = grid.GetAllGridObjectArray();

        foreach (RoomNode roomNode in allRoomNodeList) {
            if (roomNode.x == grid.GetWidth() - 1 && roomNode.y == grid.GetHeight() - 1) {
                SetConnectedRoom(roomNode);
                roomNode.SetExitRoom();
            } else {
                SetConnectedRoom(roomNode);
            }
        }
    }

    private void SetConnectedRoom(RoomNode roomNode)
    {
        List<RoomNode> adjacentRoomNodeList = roomNode.GetAdjacentRooms();
        //int connectedRoomNumber = Random.Range(1, adjacentRoomNodeList.Count + 1);
        foreach (RoomNode adjacentRoomNode in adjacentRoomNodeList)
        {
            //int isConnectedRoom = Random.Range(0, 2);
            //if (isConnectedRoom == 1) roomNode.AddConnectedRoom(adjacentRoomNode);
            if (adjacentRoomNode != null) roomNode.AddConnectedRoom(adjacentRoomNode);
            //if (roomNode.GetConnectedRoom().Count >= connectedRoomNumber) break;
        }
    }

    public Grid<RoomNode> GetGrid()
    {
        return grid;
    }
}
