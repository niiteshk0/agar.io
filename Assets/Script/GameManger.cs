using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 yRange;

    [SerializeField] GameObject ballsCollection;
    [SerializeField] List<GameObject> collectableBalls = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        for(int i=0; i<200; i++)
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        Vector2 spawanPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);

        GameObject balls = Instantiate(ballPrefab, spawanPosition, Quaternion.identity);

        // Adding in the list which are instantiate in scene
        collectableBalls.Add(balls);
        balls.transform.parent = ballsCollection.transform;

        balls.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.9f, 1f, 0.9f, 1f);
    }
    private void OnDrawGizmos()
    {
        Vector3 topLeft = new Vector3(xRange.x, yRange.y, 0);  // Top left corner
        Vector3 topRight = new Vector3(xRange.y, yRange.y, 0); // Top right corner
        Vector3 bottomRight = new Vector3(xRange.y, yRange.x, 0); // Bottom right corner
        Vector3 bottomLeft = new Vector3(xRange.x, yRange.x, 0);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
