using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneController : MonoBehaviour, iTakeItem
{
    public GameObject blood;
    void iTakeItem.TakeItem()
    {
        GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().UpdateTotalCoins();
        //Instantiate(blood).transform.position;
        Destroy(gameObject);
    }
}
