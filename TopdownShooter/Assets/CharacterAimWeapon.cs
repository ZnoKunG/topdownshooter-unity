using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using ZnoKunG.Utils;

public abstract class CharacterAimWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform aimTransform;
    private float localScaleX;

    protected virtual void Awake()
    {
        localScaleX = transform.localScale.x;
    }

    protected void RotateAim(Vector3 targetPosition)
    {
        Vector3 aimDirection = (targetPosition - aimTransform.position).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(aimDirection);
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }


}
