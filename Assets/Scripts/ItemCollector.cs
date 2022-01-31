using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float dirX = -1f;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag("Food"))
        {
            Destroy(collison.gameObject);
        }
    }
}
