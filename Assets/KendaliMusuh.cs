using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliMusuh : MonoBehaviour
{
    public GameObject Pemain;

    public float BatasKiri;
    public float BatasKanan;
    public float Akselerasi;
    public bool HadapKanan;

    float NilaiPerubahan;
    float Tujuan;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HadapKanan)
        {
            Tujuan = BatasKanan + 2;
        }

        else
        {
            Tujuan = BatasKiri - 2;
        }

        float PosX = Mathf.SmoothDamp(transform.position.x, Tujuan, ref NilaiPerubahan, Akselerasi);
        transform.position = new Vector2(PosX, transform.position.y);

        if(transform.position.x >= BatasKanan && HadapKanan)
        {
            Berbalik();
        }
        else if (transform.position.x <= BatasKiri && !HadapKanan)
        {
            Berbalik();
        }
    }

    void Berbalik()
    {
        HadapKanan = !HadapKanan;

        Vector3 Skala = transform.localScale;
        Skala.x *= -1;
        transform.localScale = Skala;
    }

    private void OnCollisionEnter2D(Collision2D sentuh)
    {
        if(sentuh.gameObject.name == Pemain.name)
        {
            Pemain.GetComponent<KendaliPemain>().PemainMati();
        }
    }
}
