using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        rb.linearVelocity = movement * moveSpeed;

        Vector2 clampedPosition = rb.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        rb.position = clampedPosition;
    }
}
