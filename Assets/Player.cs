using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameTile currentTile;
    public GameTile futureTile;
    public bool isMoving = false;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void UpdatePosition()
    {
        isMoving = true;
        StartCoroutine(StartLerpMove());
    }

    public IEnumerator StartLerpMove()
    {
        int elapsedFrames = 0;
        int interpolationFramesCount = 60;
        animator.SetBool("isRunning", true);
        Vector3 toDirection = futureTile.position - currentTile.position;
        float targetAngle = Mathf.Atan2(toDirection.x, toDirection.z) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
        while (Vector3.Distance(transform.localPosition, futureTile.position) > 0.1f)
        {
            yield return new WaitForFixedUpdate();
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            transform.localPosition = Vector3.Lerp(currentTile.position, futureTile.position, interpolationRatio);
            elapsedFrames++;
        }
        animator.SetBool("isRunning", false);
        transform.localPosition = futureTile.position;
        currentTile = futureTile;
        isMoving = false;
    }
}
