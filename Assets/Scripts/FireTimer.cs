﻿using UnityEngine;
using System.Collections;

public class FireTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 0.08f);
	}
}
