using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZnoKunG.Utils;

public class PlayerAimWeapon : CharacterAimWeapon
{
    private void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition2D();
        RotateAim(mousePosition);
    }
}
