using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void MoveRight()
    {
        rb.velocity = Vector2.right * moveSpeed;
    }
    public void MoveLeft()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }
    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
