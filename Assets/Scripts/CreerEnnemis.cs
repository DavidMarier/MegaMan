using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreerEnnemis : MonoBehaviour
{
    public GameObject ennemiACreer;
    public GameObject personnage;

    public float limiteGauche;
    public float limiteDroite;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DupliquerRoue", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DupliquerRoue()
    {
        if(personnage.transform.position.x > limiteGauche && personnage.transform.position.x < limiteDroite)
        {
            GameObject ennemiCloner = Instantiate(ennemiACreer);
            ennemiCloner.SetActive(true);
            ennemiCloner.transform.position = new Vector2(Random.Range(personnage.transform.position.x -8f, personnage.transform.position.x + 8f), 8f);
        }
    }
}
