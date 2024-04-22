using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gestionIntro : MonoBehaviour
{

    public GameObject texteIntro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(clignoterTexte());
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Megaman");
        }
    }

    IEnumerator clignoterTexte()
    {
        while(true)
        {
            texteIntro.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            texteIntro.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            texteIntro.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            texteIntro.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            texteIntro.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            texteIntro.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }
}
