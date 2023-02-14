using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public enum obstacleType { Rock, Oil}
    public obstacleType currentObstacleType = obstacleType.Rock;
    public GameObject Player;

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
                Player.transform.position = new Vector3(0, -1.5f, 0);
            }
            
        }
    }
}
