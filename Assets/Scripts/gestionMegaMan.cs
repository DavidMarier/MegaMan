using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionMegaMan : MonoBehaviour
{
    public float vitesseDeplacement;
    public float forceSaut;
    public float vitesseMaximale;
    public bool finDePartie = false;
    public bool peutAttaquer;

    public AudioClip SonsMort;

    private Vector2 velocitePerso;
    
    

    // Update is called once per frame
    void Update()
    {
        if(!finDePartie)
        {
            GestionDeplacementPersonnage();

            GestionAnimationPersonnage();
        }
    }

// Gestion des déplacements
    void GestionDeplacementPersonnage(){
        // Deplacements horizontals
        if (Input.GetKey(KeyCode.D))
        {
            velocitePerso.x = vitesseDeplacement;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocitePerso.x = -vitesseDeplacement;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        {
            velocitePerso.x = 0f;
        }

        // Saut
        if (Input.GetKeyDown(KeyCode.W) && Physics2D.OverlapCircle(transform.position, 0.25f))
        {
            velocitePerso.y = forceSaut;
        }
        else 
        {
            velocitePerso.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        // Attaque
        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.OverlapCircle(transform.position, 0.25f))
        {         
            peutAttaquer = false;
            Invoke("reinitialisationAttaque", 0.5f);
            vitesseDeplacement = vitesseMaximale;
        }

            //On applique les forces sur le rigidbody
        GetComponent<Rigidbody2D>().velocity = velocitePerso;
    }

// Gestion des animations
    void GestionAnimationPersonnage()
    {       
        // Animation déplacements horizontals
           if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.1f)
           {
            GetComponent<Animator>().SetBool("marche",true);
           }
           else
           {
            GetComponent<Animator>().SetBool("marche",false);
           }

        // Animation saut
            if(Physics2D.OverlapCircle(transform.position, 0.25f))
           {
            GetComponent<Animator>().SetBool("saute",false);
           }
           else
           {
            GetComponent<Animator>().SetBool("saute",true);
           }

        // Animation attaque
        //    if(!peutAttaquer)
        //    {
        //     GetComponent<Animator>().SetBool("attaque", true);
        //    }
        //    else
        //    {
        //     GetComponent<Animator>().SetBool("attaque", false);
        //    }
         


    }

    void OnCollisionEnter2D(Collision2D megaman)
    {
        if(megaman.gameObject.name == "roueDentelee" || megaman.gameObject.name == "Abeille")
        {
            if(peutAttaquer)
            {
                finDePartie = true;
                GetComponent<AudioSource>().PlayOneShot(SonsMort);
                GetComponent<Animator>().SetTrigger("mort");
                Invoke("recommencerJeu", 2f);
            }
            else
            {
                
            }
        }     
    }

    void reinitialisationAttaque()
    {
        peutAttaquer = true;
        Debug.Log("triggered");
    }

    void recommencerJeu()
    {
        SceneManager.LoadScene("Megaman");
        finDePartie = false;
    }
}

