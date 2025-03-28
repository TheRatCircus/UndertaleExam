using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    public float startSpeed = 2f;
    public float maxSpeed = 10f;
    public float speedIncreaseRate = 0.1f;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    private Vector2 movementDirection;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = startSpeed;
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        // Move the object based on speed and direction
        transform.Translate(movementDirection * currentSpeed * Time.deltaTime);

        // Increase the speed gradually
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedIncreaseRate * Time.deltaTime;
        }

        // Check for boundaries and reverse direction if necessary
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            movementDirection.x = -movementDirection.x;
        }
        if (transform.position.y <= minY || transform.position.y >= maxY)
        {
            movementDirection.y = -movementDirection.y;
        }
    }
}
