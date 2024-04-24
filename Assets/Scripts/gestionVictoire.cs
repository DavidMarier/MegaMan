using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class gestionVictoire : MonoBehaviour
{
    public AudioClip musiqueGagne;
    public GameObject trophe;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(musiqueVictoire(musiqueGagne));
        GetComponent<TextMeshProUGUI>().text = "Points : " + gestionMegaMan.pointage;
        if (gestionIntro.pointageABattre < gestionMegaMan.pointage)
        {
            gestionIntro.pointageABattre = gestionMegaMan.pointage;
        }

        if (gestionIntro.pointageABattre <= gestionMegaMan.pointage)
        {
            trophe.SetActive(true);
        }
        else if (gestionIntro.pointageABattre > gestionMegaMan.pointage)
        {
            trophe.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("introduction");
        }
    }

    IEnumerator musiqueVictoire(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("introduction");
    }
}
