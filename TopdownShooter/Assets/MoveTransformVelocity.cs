using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character_Base))]
public class MoveTransformVelocity : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 velocityVector;
    private Character_Base characterBase;


    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void Update()
    {
        transform.position += velocityVector * moveSpeed;
    }
}
