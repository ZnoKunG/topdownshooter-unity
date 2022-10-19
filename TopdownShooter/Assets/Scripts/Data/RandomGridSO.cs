using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RandomGridParameters_", menuName = "PDG/RandomGridData")]
public class RandomGridSO : ScriptableObject
{
    public int gridWidth = 3, gridHeight = 3;
    public int roomMin = 6, roomMax = 9;
}
