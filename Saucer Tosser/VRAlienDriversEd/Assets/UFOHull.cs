using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOHull : MonoBehaviour {

    public Color[] hullColors;
    MeshRenderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer>();
        Color hullColor = hullColors[Random.Range(0,hullColors.Length)];
        rend.material.color = hullColor;
	}
}
