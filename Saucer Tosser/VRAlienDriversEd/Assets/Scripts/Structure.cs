using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{

    GameObject[] children;
    // Use this for initialization
    void Start()
    {
        children = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject child in children)
        {
            child.isStatic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject child in children)
        {
            child.isStatic = false;
        }
    }
}