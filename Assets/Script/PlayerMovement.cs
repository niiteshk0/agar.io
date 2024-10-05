using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    [SerializeField] float increaseSizeSpeed;
    [SerializeField] float scaleSize;
    float currentScale = 1f;
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    
    void PlayerMove()
    {
        float Speed = playerSpeed / transform.localScale.x;   // speed control according to the player size
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, direction, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player size Increase");
        currentScale *= scaleSize;

        // for increase the size when player collid with any food
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), Time.deltaTime * increaseSizeSpeed);

        
        // Spawn everytime when you eat 
        GameManger.instance.SpawnFood();

        Destroy(collision.gameObject);
    }

}
