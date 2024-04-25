using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class gestionBalle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D infosCollisions)
    {
        if(infosCollisions.gameObject.tag == "ennemie")
        {
            
            infosCollisions.gameObject.GetComponent<gestionRoue>().DestructionRoue();
            GetComponent<Animator>().SetBool("explose", true);
            Destroy(gameObject, 0.15f);
        }
        else if(infosCollisions.gameObject.name == "Abeille")
        {
            
            infosCollisions.gameObject.GetComponent<gestionAbeille>().DestructionAbeille();
            GetComponent<Animator>().SetBool("explose", true);
            Destroy(gameObject, 0.15f);
        }
        else if (infosCollisions.gameObject)
        {
            GetComponent<Animator>().SetBool("explose", true);
            Destroy(gameObject, 0.15f);
        }
    }


}
