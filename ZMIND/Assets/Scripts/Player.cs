using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    public float xPos;
    public float xLimitV = 9.5f;
    [Header("Projectile Settings")]
    public GameObject bullet;
    public Transform firePoint;
    public float impulse = 3;
    public float fireRate = 1f;
    float currentFireRate = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        LimitsControl();
       currentFireRate += Time.deltaTime;

        if (currentFireRate > fireRate)
        {
            currentFireRate = 0;
            GameObject _projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
            _projectile.GetComponent<BulletController>().SetProjectile(Vector2.down, impulse, "Enemy");
        }
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
    void LimitsControl()
    {
        xPos = transform.position.x;
        //Control X

        if (xPos > xLimitV)
        {
            xPos = xLimitV;
        }
        else if (xPos < -xLimitV)
        {
            xPos = -xLimitV;
        }

        transform.position = new Vector3(xPos, 0, 0);
    }
}
