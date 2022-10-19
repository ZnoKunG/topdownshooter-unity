using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZnoKunG.Utils;

public class CharacterFollowPlayer : MonoBehaviour
{
    [SerializeField] private float stopDistance;

    private Transform playerTransform;
    private float SEARCH_DELAY = .5f;
    private bool isSearchingPath;
    private MovePositionPathfinding movePositionPathfinding;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        isSearchingPath = false;
        movePositionPathfinding = GetComponent<MovePositionPathfinding>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) >= stopDistance)
        {
            if (!isSearchingPath)
            {
                StartCoroutine(SearchingDelayCoroutine());
                movePositionPathfinding.SetMovePosition(playerTransform.position);
            }
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            GetComponent<MovePositionPathfinding>().SetMovePosition(UtilsClass.GetMouseWorldPosition2D());
        }*/
    }

    private IEnumerator SearchingDelayCoroutine()
    {
        isSearchingPath = true;
        yield return new WaitForSeconds(SEARCH_DELAY);
        isSearchingPath = false;
    }
}
