using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void OnMouseUp()
    {
        transform.position = new Vector2(Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f));
    }
    private void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + _dragOffset;
    }
    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
    }
}
