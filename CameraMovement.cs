using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runMultiplier = 2f;
    public float dragSpeed = 1f;
    public float edgeScrollSpeed = 5f;
    public int edgeSize = 10;

    public float zoomSpeed = 5f;
    public float minZoom = 2f;
    public float maxZoom = 20f;

    [Tooltip("How fast the camera accelerates and decelerates (lower = snappier, higher = smoother)")]
    public float smoothTime = 0.1f;

    private Vector3 dragOrigin;
    private bool isDragging = false;
    private Camera cam;

    private Vector3 currentVelocity = Vector3.zero;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleMouseDrag();
        HandleKeyboardMove();
        HandleEdgeScroll();
        HandleZoom();
    }

    void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = dragOrigin - currentPos;
            transform.position += difference * dragSpeed;
        }
    }

    void HandleKeyboardMove()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) input.y += 1;
        if (Input.GetKey(KeyCode.S)) input.y -= 1;
        if (Input.GetKey(KeyCode.A)) input.x -= 1;
        if (Input.GetKey(KeyCode.D)) input.x += 1;

        float targetSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            targetSpeed *= runMultiplier;

        Vector3 targetVelocity = input.normalized * targetSpeed;

        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime / smoothTime);

        transform.position += currentVelocity * Time.deltaTime;
    }

    void HandleEdgeScroll()
    {
        Vector3 move = Vector3.zero;
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x >= Screen.width - edgeSize) move.x += 1;
        if (mousePos.x <= edgeSize) move.x -= 1;
        if (mousePos.y >= Screen.height - edgeSize) move.y += 1;
        if (mousePos.y <= edgeSize) move.y -= 1;

        if (move != Vector3.zero)
            transform.position += move.normalized * edgeScrollSpeed * Time.deltaTime;
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
