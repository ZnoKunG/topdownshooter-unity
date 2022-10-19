using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZnoKunG.Utils;

public static class WeaponTracer
{
    public static void Create(Vector3 fromPosition, Vector3 toPosition)
    {
        Material weaponTracerMaterial = GameAssets.Instance.weaponTracerMaterial;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float eulerZ = UtilsClass.GetAngleFromVectorFloat(dir) - 90f;
        float distance = Vector3.Distance(fromPosition, toPosition);
        Vector3 tracerSpawnPosition = fromPosition + dir * distance / 2;
        World_Mesh worldMesh = World_Mesh.Create(tracerSpawnPosition, eulerZ, 6f, distance, weaponTracerMaterial, null, 10000);
    }

}
