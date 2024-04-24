using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gestionMegaMan : MonoBehaviour
{
    public float vitesseDeplacement;
    public float forceSaut;
    public float vitesseMaximale;
    public static int pointage;
    public bool finDePartie = false;
    private bool attaque = false;
    private bool tire = false;

    public GameObject balleOriginale;

    public AudioClip SonsMort;
    public AudioClip SonItem;
    public AudioClip SonArme;

    private Vector2 velocitePerso;
    
    public TextMeshProUGUI points;

    void Start()
    {
        pointage = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!finDePartie)
        {
            GestionDeplacementPersonnage();

            GestionAnimationPersonnage();

            GestionTirePersonnage();
        }
    }

// Gestion des balles
    void GestionTirePersonnage(){
        if(Input.GetKeyDown(KeyCode.Return) && !attaque && !Input.GetKeyDown(KeyCode.W) && Physics2D.OverlapCircle(transform.position, 0.25f))
        {
            tire = true;
            GameObject balleClone = Instantiate(balleOriginale);
            balleClone.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(SonArme);
            if(!GetComponent<SpriteRenderer>().flipX){
                balleClone.transform.position= transform.position+ new Vector3(.6f, 1);    
                balleClone.GetComponent<Rigidbody2D>().velocity= new Vector2(25, 0);
            }
            else if(GetComponent<SpriteRenderer>().flipX){
                balleClone.transform.position= transform.position+ new Vector3(-.6f, 1);    
                balleClone.GetComponent<Rigidbody2D>().velocity= new Vector2(-25, 0);
            }
        }
        else if(!Input.GetKeyDown(KeyCode.Return))
        {
            tire = false;
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
            attaque = true;
            vitesseDeplacement = vitesseMaximale;
            Invoke("reinitialisationAttaque", 0.5f);
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
        if(attaque)
        {
        GetComponent<Animator>().SetBool("attaque", true);
        }
        else
        {
        GetComponent<Animator>().SetBool("attaque", false);
        }

        //Animation tire
        if(tire)
        {
        GetComponent<Animator>().SetBool("tire", true);
        }
        else if(Input.GetKeyUp(KeyCode.Return))
        {
        GetComponent<Animator>().SetBool("tire", false);
        }
    }

    void OnCollisionEnter2D(Collision2D infosCollisions)
    {
        if(infosCollisions.gameObject.tag == "ennemie" || infosCollisions.gameObject.name == "Abeille")
        {
            if(!attaque)
            {
                finDePartie = true;
                GetComponent<AudioSource>().PlayOneShot(SonsMort);
                GetComponent<Animator>().SetTrigger("mort");
                Invoke("recommencerJeu", 2f);
                if(infosCollisions.gameObject.tag == "ennemie")
                {
                    infosCollisions.gameObject.GetComponent<gestionRoue>().DestructionRoue();
                }
            }
            else
            {
                if(infosCollisions.gameObject.name == "Abeille")
                {
                    infosCollisions.gameObject.GetComponent<gestionAbeille>().DestructionAbeille();
                }
                else if(infosCollisions.gameObject.tag == "ennemie")
                {
                    infosCollisions.gameObject.GetComponent<gestionRoue>().DestructionRoue();
                }
            }
        }     
    }

    void OnTriggerEnter2D(Collider2D infosCollisions)
    {
        if(infosCollisions.gameObject.name == "trophee")
        {
            SceneManager.LoadScene("finaleGagne");
        }
        else if(infosCollisions.gameObject.name == "colliderChute")
        {
            finDePartie = true;
            GetComponent<AudioSource>().PlayOneShot(SonsMort);
            GetComponent<Animator>().SetTrigger("mort");
            Invoke("recommencerJeu", 2f);
        }
        else if(infosCollisions.gameObject.name.StartsWith("ItemPoint"))
        {
            pointage++;
            Destroy(infosCollisions.gameObject);
            GetComponent<AudioSource>().PlayOneShot(SonItem);
            points.text = pointage.ToString();
        }
    }

    void reinitialisationAttaque()
    {
        attaque = false;
        vitesseDeplacement = 8f;
    }

    void recommencerJeu()
    {
        SceneManager.LoadScene("finaleMort");
        finDePartie = false;
    }
}

