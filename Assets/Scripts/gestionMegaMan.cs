using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestionMegaMan : MonoBehaviour
{
    public float vitesseDeplacement;
    public float forceSaut;
    public bool finDePartie;

    public AudioClip SonsMort;

    private Vector2 velocitePerso;
    
    

    // Update is called once per frame
    void Update()
    {
        //D�placement
        if(finDePartie == false){
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
            //Saut
            if (Input.GetKeyDown(KeyCode.W) && Physics2D.OverlapCircle(transform.position, 0.25f))
            {
                velocitePerso.y = forceSaut;
                GetComponent<Animator>().SetBool("saute", true);
            }
            else 
            {
                velocitePerso.y = GetComponent<Rigidbody2D>().velocity.y;
            }

            //On applique les forces sur le rigidbody
                GetComponent<Rigidbody2D>().velocity = velocitePerso;


            GestionAnimationPersonnage();
          
        
        }
    }

    void GestionAnimationPersonnage()
    {
         // Gestion des animations
           if( Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.1)
           {
            GetComponent<Animator>().SetBool("marche",true);
           }
           else
           {
            GetComponent<Animator>().SetBool("marche",false);
           }

           /*if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0.1){
            GetComponent<Animator>().SetBool("saute",true);
           }
           else{
            GetComponent<Animator>().SetBool("saute",false);
           }*/
    }

    void OnCollisionEnter2D(Collision2D megaman){
        if(Physics2D.OverlapCircle(transform.position, 0.25f)){
            GetComponent<Animator>().SetBool("saute", false);
        }

        if(megaman.gameObject.name == "roueDentelee"){
            finDePartie = true;
            GetComponent<AudioSource>().PlayOneShot(SonsMort);
            GetComponent<Animator>().SetTrigger("mort");
            Invoke("recommencerJeu", 2f);
        }      
    }
    void recommencerJeu(){
        SceneManager.LoadScene("Megaman");
        finDePartie = false;
    }
}

