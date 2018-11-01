using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Modifier : MonoBehaviour
{
    public Text holderText;
    //public Light holderLight;

    private void Start()
    {
        //holderText = GameObject.FindGameObjectWithTag("HolderText").GetComponent<Text>();
        holderText.color = Color.red;

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Holder")
        {
            gameObject.isStatic = true;
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            holderText.color = Color.green;
            ActivateAbility();
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Holder")
        {
            gameObject.isStatic = false;
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            holderText.text = "NO MODIFIER EQUIPPED";
            holderText.color = Color.red;
            DisableAbility();
        }
    }

    public virtual void ActivateAbility()
    {
        holderText.text = "NICK IS AWESOME";
    }

    public virtual void DisableAbility()
    {
    }
}

