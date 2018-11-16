using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Modifier : MonoBehaviour
{
    public Text holderText;
    public string text;
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
            Holder holder = collision.GetComponent<Holder>();
            holder.items++;
            gameObject.isStatic = true;
            holderText.color = Color.green;
            ActivateAbility();
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Holder")
        {
            gameObject.isStatic = false;
            DisableAbility();

            Holder holder = other.GetComponent<Holder>();
            holder.items--;
            if (holder.items == 0)
            {
                holderText.text = "NO MODIFIER EQUIPPED";
                holderText.color = Color.red;
                
            }
        }
    }

    public virtual void ActivateAbility()
    {
        holderText.text = text;
    }

    public virtual void DisableAbility()
    {
    }
}

