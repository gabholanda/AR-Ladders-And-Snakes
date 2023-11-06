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
        player.UpdatePosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int result = die.Roll();
            startPoint = Mathf.Clamp(startPoint + result, 0, tiles.Count - 1);
            if (tiles.Count - 1 >= startPoint)
            {
                if (tiles[startPoint].connectedTilePosition > 0)
                {
                    startPoint = tiles[startPoint].connectedTilePosition;
                    player.currentTile = tiles[startPoint].tile;
                    player.UpdatePosition();
                    return;
                }
                player.currentTile = tiles[startPoint].tile;
                player.UpdatePosition();
            }
        }
    }
}
