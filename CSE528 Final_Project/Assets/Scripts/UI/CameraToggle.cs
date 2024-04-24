using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraToggle : MonoBehaviour
{
    public GameObject cam0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;

    void Start()
    {
        TopDown();
    }

    void Update()
    {
        if(Input.GetKeyDown("0"))
        {
            TopDown();
        }

        if(Input.GetKeyDown("1"))
        {
            T1();
        }

        if (Input.GetKeyDown("2"))
        {
            T2();
        }

        if (Input.GetKeyDown("3"))
        {
            T3();
        }

        if (Input.GetKeyDown("4"))
        {
            T4();
        }
    }

    void TopDown()
    {
        cam0.SetActive(true);
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
    }

    void T1()
    {
        cam0.SetActive(false);
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
    }

    void T2()
    {
        cam0.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
        cam3.SetActive(false);
        cam4.SetActive(false);
    }

    void T3()
    {
        cam0.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);
        cam4.SetActive(false);
    }

    void T4()
    {
        cam0.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(true);
    }
}
