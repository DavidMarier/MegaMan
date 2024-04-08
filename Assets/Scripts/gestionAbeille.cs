using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionAbeille : MonoBehaviour
{
    public void DestructionAbeille()
    {
        GetComponent<Animator>().SetTrigger("explosion");
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,0.3f);
    }
}
