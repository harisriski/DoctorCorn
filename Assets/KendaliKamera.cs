using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliKamera : MonoBehaviour
{

    public GameObject Aktor;
    public float AkselerasiX;

    float NilaiPerubahan;
    float XAwal;

    bool Gerak = true;

    void Start()
    {
        XAwal = transform.position.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Gerak)
        {
            float PosX = Mathf.SmoothDamp(transform.position.x, Aktor.transform.position.x, ref NilaiPerubahan, AkselerasiX);
            transform.position = new Vector3(PosX, transform.position.y, transform.position.z);
        }

        if(transform.position.x < XAwal)
        {
            NilaiPerubahan = XAwal;
            Gerak = false;
        }

        if (Aktor.transform.position.x >= XAwal)
        {
            Gerak = true;
        }
    }
}
