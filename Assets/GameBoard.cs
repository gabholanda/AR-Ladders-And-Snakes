using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public Player player;
    public Die die;
    public List<GameTileWrapper> tiles;
    public int startPoint = 0;
    private void Awake()
    {
        player.currentTile = tiles[startPoint].tile;
        player.transform.localPosition = player.currentTile.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !player.isMoving && !die.isRolling)
        {
            die.Roll();
        }
    }

    public void TriggerPlayerMovement()
    {
        startPoint = Mathf.Clamp(startPoint + die.result, 0, tiles.Count - 1);
        if (tiles.Count - 1 >= startPoint)
        {
            if (tiles[startPoint].connectedTilePosition > 0)
            {
                startPoint = tiles[startPoint].connectedTilePosition;
                player.futureTile = tiles[startPoint].tile;
                player.UpdatePosition();
                return;
            }
            player.futureTile = tiles[startPoint].tile;
            player.UpdatePosition();
        }
    }
}
