using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    private SpriteRenderer sprite;
    private float dirX = -1f;
    private int cherries = 0;

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
            cherries += 1;
            score.text = cherries.ToString();
        }
    }
}
