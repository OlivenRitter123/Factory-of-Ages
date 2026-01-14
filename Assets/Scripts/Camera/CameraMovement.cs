using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float panSpeed = 20f;      // Geschwindigkeit der Kamera beim Scrollen
    public float scrollSpeed = 5f;    // Geschwindigkeit beim Zoomen
    public float minZoom = 2f;        // Minimale Orthographic Size
    public float maxZoom = 10f;       // Maximale Orthographic Size

    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
        if (!cam.orthographic)
        {
            Debug.LogWarning("Camera sollte orthographic sein für 2D XY");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleZoom();
    }
    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;    
    }
    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0f)
        {
            cam.orthographicSize -= scroll * scrollSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
