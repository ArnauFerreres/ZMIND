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

        Invoke("Destroy", 2f);
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

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<iTakeItem>() != null)
            other.GetComponent<iTakeItem>().TakeItem();
        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
