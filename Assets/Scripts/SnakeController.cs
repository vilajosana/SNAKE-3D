using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;
    public GameObject FoodPrefab;
    public Joystick moveJoystick;
    public ScoreManager scoreManager;
    public GameObject GreenArea;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input from the Move Joystick
        float horizontalInput = moveJoystick.Horizontal;
        float verticalInput = moveJoystick.Vertical;

        // Move forward
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = horizontalInput;
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Check for collision with food, green area, or snake body parts
        CheckCollision();

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snake's path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snake's path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Insert(0, body);
    }

    private void SpawnFood()
    {
        Vector3 randomPosition = GetRandomPosition();
        Instantiate(FoodPrefab, randomPosition, Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPoint = Random.insideUnitSphere * 10f; // Adjust the radius as needed
        randomPoint.y = 0; // To ensure it's at the same level as the ground
        return randomPoint + transform.position;
    }

    // Método para verificar colisión con green area o partes del cuerpo de la serpiente
    private void CheckCollision()
    {
        // Check for collision with food, green area, or snake body parts
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); // Adjust the radius as needed
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Food"))
            {
                // Snake collided with food
                Destroy(collider.gameObject); // Destroy the food
                GrowSnake(); // Grow the snake
                SpawnFood(); // Spawn new food

                // Increase the score by calling the method in the ScoreManager
                scoreManager.IncreaseScore();
            }
            else if (collider.gameObject == GreenArea || collider.CompareTag("SnakeBody"))
            {
                // GameOver
                GameOver();
            }
        }
    }

    // Método para manejar el Game Over
    private void GameOver()
    {
        // Cargar la escena de Game Over
        SceneManager.LoadScene("GameOverScene");
    }
}
