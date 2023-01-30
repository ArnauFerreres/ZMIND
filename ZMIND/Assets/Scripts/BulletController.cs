using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    [Range(1, 5)]
    public float impulse = 3;
    [Range(1, 5)]
    public int damage = 1;
    string tagName;

    Vector2 direction;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke("Destroy", 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.Translate(direction*impulse*Time.fixedDeltaTime);
    }

    public void SetProjectile(Vector2 _direction, float _impulse, string _tag)
    {
        direction = _direction;
        impulse = _impulse;
        tagName = _tag;
    }

    ////private void OnTriggerEnter2D(Collider2D collision)
    ////{
    ////  

    ////    Destroy();
    //}
    void Destroy()
    {
        Destroy(gameObject);
    }
}
