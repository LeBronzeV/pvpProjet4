﻿using UnityEngine;
using System.Collections;

public class rotationLifeBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.rotation = Quaternion.identity;
	}
}
