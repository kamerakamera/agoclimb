﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManeger : MonoBehaviour {
    Vector3 agoPos;
    Quaternion shotRotation;
    float shotPower;
    [SerializeField]
    Transform ago;
    [SerializeField]
    GameObject arrowObject;
    // Use this for initialization
    void Start () {
        shotPower = 6;
	}
	
	// Update is called once per frame
	void Update () {
        LookDirection();
	}

    void FixedUpdate() {
        
    }

    public void AgoTracking() {
        transform.position = ago.position;
    }

    public void ArrowDisplayChenge(bool _bool) {
        arrowObject.SetActive(_bool);
    }

    void LookDirection() {
        agoPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        shotRotation = Quaternion.LookRotation(Vector3.forward,Input.mousePosition - agoPos);
        transform.rotation = shotRotation;
    }

    void SetArrowSize() {

    }

    float SetPower() {
        //powerを返す
        return 8;
    }

    public Quaternion GetFireRotation() {
        return transform.rotation;
    }

    public float GetFirePower() {
        return shotPower;
    }

}
