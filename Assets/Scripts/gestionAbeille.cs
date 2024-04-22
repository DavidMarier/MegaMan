using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionAbeille : MonoBehaviour
{
    public AudioClip sonExplosion;
    public void DestructionAbeille()
    {
        GetComponent<AudioSource>().PlayOneShot(sonExplosion);
        GetComponent<Animator>().SetTrigger("explosion");
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,0.3f);
    }
}
