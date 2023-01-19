using UnityEngine;

public class SelectingController : MonoBehaviour
{
    private MoveOnTilemap move;
    private SpriteRenderer spr;

    private void Awake()
    {
        move = GetComponent<MoveOnTilemap>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        move.enabled = true;
        spr.color = Color.green;
    }
}
