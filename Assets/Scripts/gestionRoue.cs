using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionRoue : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        if(infoCollision.gameObject.name == "Megaman")
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Destroy(gameObject,0.2f);
        }
    }
}
