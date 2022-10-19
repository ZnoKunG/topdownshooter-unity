using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomNode
{
    public int x;
    public int y;
    private Grid<RoomNode> grid;
    private bool isExit;
    private List<RoomNode> connectedRoomNodeList;

    private List<RoomNode> neighbourRoomNodeList;
    public RoomNode(Grid<RoomNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isExit = false;
        neighbourRoomNodeList = grid.GetAxisNeighbourGridObjects(x, y);
        connectedRoomNodeList = new List<RoomNode>();
    }

    public List<RoomNode> GetAdjacentRooms()
    {
        return neighbourRoomNodeList;
    }

    public List<RoomNode> GetNeighbourRooms()
    {
        return grid.GetAllNeighbourGridObjects(x, y);
    }
    public Vector3 GetNodeCenterPosition()
    {
        return grid.GetCenterWorldPosition(x, y);
    }
    public void AddConnectedRoom(RoomNode roomNode)
    {
        connectedRoomNodeList.Add(roomNode);
    }

    public List<RoomNode> GetConnectedRoomList()
    {
        return connectedRoomNodeList;
    }
    public void SetExitRoom()
    {
        isExit = true;
    }

    public override string ToString()
    {
        return $"{x},{y}";
    }
}
