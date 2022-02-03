using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Text Finalscore;
    [SerializeField] private TextMeshProUGUI CurrentLevel;
    private SpriteRenderer sprite;
    private float dirX = -1f;
    private int collectibles = 0;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Finalscore.text = "0";
        CurrentLevel.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

    }

    // if player hits the food, make the food disappear
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag("Food"))
        {
            Destroy(collison.gameObject);
            collectibles += 1;
            score.text = collectibles.ToString();
            Finalscore.text = score.text;
        }
    }
}
