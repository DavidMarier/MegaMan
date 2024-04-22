using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class gestionBalle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.25f);
    }
    void OnCollisionEnter2D(Collision2D infosCollisions)
    {
        if(infosCollisions.gameObject.tag == "ennemie")
        {
            Destroy(gameObject, 0.15f);
            infosCollisions.gameObject.GetComponent<gestionRoue>().DestructionRoue();
        }
        else if(infosCollisions.gameObject.name == "Abeille")
        {
            Destroy(gameObject, 0.15f);
            infosCollisions.gameObject.GetComponent<gestionAbeille>().DestructionAbeille();
        }
    }


}
