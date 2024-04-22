using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionCam : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;

    void Start()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }
    }
}
