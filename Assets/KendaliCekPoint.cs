using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliCekPoint : MonoBehaviour
{

    public GameObject Pemain;

    public void OnTriggerEnter2D(Collider2D sentuh)
    {
        if(sentuh.gameObject.name == Pemain.name)
        {
            Pemain.GetComponent<KendaliPemain>().UpdatePosisi(Pemain.transform.position);
            Destroy(this.gameObject, 0.2f);
        }
    }
}
