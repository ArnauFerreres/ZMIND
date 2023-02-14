using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public enum obstacleType { Rock, Oil}
    public float yPos = -0.5f;
    public obstacleType currentObstacleType = obstacleType.Rock;
    //public GameObject Player;
    BoxCollider2D box;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
            if(collision.gameObject.tag == "Player")
            {
                if(currentObstacleType == obstacleType.Rock)
                { 
                    Destroy(collision.gameObject);
                }

                if(currentObstacleType == obstacleType.Oil)
                {
                    Debug.Log("Aceitito");
                    collision.gameObject.transform.Translate(Vector2.down);
                    box.GetComponent<BoxCollider2D>().enabled = false;
                    //Player.transform.position = new Vector3(0, +yPos, 0);
                }
            
            }
    }
}
