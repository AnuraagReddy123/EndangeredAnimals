using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //setting player as child of platform on collision and then removing after exiting collision
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Player"){
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.name == "Player"){
            collision.gameObject.transform.SetParent(null);
        }
    }
}

