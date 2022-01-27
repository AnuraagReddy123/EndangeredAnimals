using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag("Food"))
        {
            Destroy(collison.gameObject);
        }
    }
}
