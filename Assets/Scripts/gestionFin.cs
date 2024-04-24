using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class gestionFin : MonoBehaviour
{
    public int compteur = 10;

    public TextMeshProUGUI Recommencer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(recommencerPartie());
        GetComponent<TextMeshProUGUI>().text = "Points : " + gestionMegaMan.pointage;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Megaman");
        }
    }

    IEnumerator recommencerPartie()
    {
        while(compteur > 0)
        {
            compteur--;
            Recommencer.text = "Ça recommence dans : " + compteur;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("Megaman");
        gestionMegaMan.pointage = 0;
    }
}
