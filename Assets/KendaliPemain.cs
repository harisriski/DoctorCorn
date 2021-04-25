using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliPemain : MonoBehaviour{

    Rigidbody2D Body;

    public Collider2D Sensor;
    public Collider2D Lantai;

    public float Kecepatan;
    public float TinggiLompatan;

    public GameObject Portal;
    public int TotalObat;

    bool HadapKanan = true;
    bool Mendarat = true;
    int JumlahObat = 0;

    Vector3 PosisiAwal;

    public void TambahObat()
    {
        JumlahObat += 1;
        Debug.Log(JumlahObat);
    }

    public void UpdatePosisi(Vector3 Posisi)
    {
        PosisiAwal = Posisi;
    }

    // Start is called before the first frame update
    void Start(){
        Body = GetComponent<Rigidbody2D>();
        PosisiAwal = transform.position;
    }

    void Update()
    {
        Mendarat = Physics2D.IsTouching(Sensor, Lantai);
        
        if (Input.GetKeyDown(KeyCode.Space) && Mendarat == true)
        {
            //Body.velocity = new Vector2(0f, TinggiLompatan);
            Body.velocity = Vector2.up * TinggiLompatan;
            //Mendarat = false;
        }

        if(JumlahObat == TotalObat)
        {
            Portal.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        float Akselerasi = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(Akselerasi * Kecepatan, Body.velocity.y);
    
        if(Akselerasi > 0 && HadapKanan == false)
        {
            Berbalik();
        }

        else if(Akselerasi < 0 && HadapKanan == true)
        {
            Berbalik();
        }
    }

    void Berbalik(){
        HadapKanan = !HadapKanan;

        Vector3 Skala = transform.localScale;
        Skala.x *= -1;
        transform.localScale = Skala;
    }

    public void PemainMati()
    {
        transform.position = PosisiAwal;
        Body.velocity = new Vector2(0f, 0f);
}

    private void OnCollisionEnter2D(Collision2D sentuh)
    {
        if(sentuh.gameObject.name == "Sensor Lubang")
        {
            PemainMati();
        }
    }
}
