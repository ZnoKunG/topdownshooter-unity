using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager), true)]
public class PathfindingEditor : Editor
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = (GameManager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Pathfinding"))
        {
            gameManager.GeneratePathfinding();
        }
    }
}
