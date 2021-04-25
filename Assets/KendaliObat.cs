using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliObat : MonoBehaviour
{
    public GameObject Pemain;

    public void OnTriggerEnter2D(Collider2D sentuh)
    {
        if (sentuh.gameObject.name == Pemain.name)
        {
            Pemain.GetComponent<KendaliPemain>().TambahObat();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
