using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera2 : MonoBehaviour
{
    public GameObject cibleASuivre;

    public float limiteHaut;
    public float limiteBas;
    public float limiteDroite;
    public float limiteGauche;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionASuivre = cibleASuivre.transform.position;
        if(positionASuivre.x > limiteDroite){
            positionASuivre.x = limiteDroite;
        }
        if(positionASuivre.x < limiteGauche){
            positionASuivre.x = limiteGauche;
        }
        if(positionASuivre.y < limiteBas){
            positionASuivre.y = limiteBas;
        }
        if(positionASuivre.y > limiteHaut){
            positionASuivre.y = limiteHaut;
        }

        positionASuivre.z = -10f;

        transform.position = positionASuivre;
    }
}
