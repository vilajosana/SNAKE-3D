using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject floorPrefab;

    // Puedes ajustar estos valores según sea necesario
    public float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFood(); // Spawn the first food immediately
    }

    void SpawnFood()
    {
        Vector3 randomPosition = GetRandomPosition();
        GameObject newFood = Instantiate(foodPrefab, randomPosition, Quaternion.identity);

        // Set the scale of the new food prefab (you can adjust the scale as needed)
        newFood.transform.localScale = Vector3.one;

        // Schedule the next spawn after the specified interval
        Invoke("SpawnFood", spawnInterval);
    }

    Vector3 GetRandomPosition()
    {
        // Get the position of the Floor object inside the floor prefab
        Transform floorObject = floorPrefab.transform.Find("Floor");
        if (floorObject == null)
        {
            Debug.LogError("Floor object not found inside the Floor prefab!");
            return Vector3.zero;
        }

        Vector3 floorPosition = floorObject.position;
        Vector3 floorSize = floorObject.localScale;

        // Calculate the size of the Floor object
        float floorXSize = floorSize.x;
        float floorZSize = floorSize.z;

        // Generate a random position inside the Floor object
        Vector3 randomPoint = new Vector3(
            Random.Range(-floorXSize / 2f + 0.5f, floorXSize / 2f - 0.5f) + floorPosition.x,
            0f,
            Random.Range(-floorZSize / 2f + 0.5f, floorZSize / 2f - 0.5f) + floorPosition.z
        );

        return randomPoint;
    }

    // You can rename this method to avoid the CS0111 error
    Vector3 GetRandomPositionForFood()
    {
        // Get the position of the Floor object inside the floor prefab
        Transform floorObject = floorPrefab.transform.Find("Floor");
        if (floorObject == null)
        {
            Debug.LogError("Floor object not found inside the Floor prefab!");
            return Vector3.zero;
        }

        Vector3 floorPosition = floorObject.position;
        Vector3 floorSize = floorObject.localScale;

        // Calculate the size of the Floor object
        float floorXSize = floorSize.x;
        float floorZSize = floorSize.z;

        // Generate a random position inside the Floor object
        Vector3 randomPoint = new Vector3(
            Random.Range(-floorXSize / 2f + 0.5f, floorXSize / 2f - 0.5f) + floorPosition.x,
            0f,
            Random.Range(-floorZSize / 2f + 0.5f, floorZSize / 2f - 0.5f) + floorPosition.z
        );

        return randomPoint;
    }
}
