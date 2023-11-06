using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameTile currentTile;

    public void UpdatePosition()
    {
        // Play animation instead to lerp until it reaches the correct grid position
        transform.localPosition = currentTile.position;
    }
}
