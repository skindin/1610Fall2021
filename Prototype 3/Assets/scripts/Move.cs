using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction = Vector3.left;
    public static float speed = 20;
    public bool moveBack = false;
    public float moveBackLimit = 55;
    Vector3 startPos;
    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Game.state == gameState.inGame)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

            if (moveBack && Vector2.Distance(startPos, transform.position) > moveBackLimit)
            {
                transform.position = startPos;
            }
        }
    }
}
