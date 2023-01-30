using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;

    public Rigidbody2D rb;
    public float speedForce;

    public void clickLeft()
    {
        isLeft = true;
    }

    public void releaseLeft()
    {
        isLeft = false;
    }

    public void clickRight()
    {
        isRight = true;
    }

    public void releaseRight()
    {
        isRight = false;
    }

    void Start()
    {
        
    }

    
    private void FixedUpdate()
    {
        if (isLeft)
        {
            rb.AddForce(new Vector2(-speedForce, 0) * Time.deltaTime);
        }

        if (isRight)
        {
            rb.AddForce(new Vector2(-speedForce, 0) * Time.deltaTime);
        }
    }
}
