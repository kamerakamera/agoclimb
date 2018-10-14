﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingThroughObject : MonoBehaviour {

    bool isTrigger,isMove;
    [SerializeField]
    float limitTime, movePower;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    GameObject ago;
    float timeCount;
	// Use this for initialization
	void Start () {
        timeCount = 0;
        SetIsMove(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isMove) {
            Move();
            CountTime();
        }
	}

    void Move() {
        //transform.position += new Vector3(0.1f, 0, 0);
        rb.velocity = (ago.transform.position - transform.position).normalized * movePower;
    }

    void CountTime() {
        timeCount += Time.deltaTime;
        if(timeCount >= limitTime) {
            DeleteObject();
            timeCount = 0;
        }
    }

    public void SetIsMove(bool _bool) {
        isMove = _bool;
    }

    void DeleteObject() {
        Destroy(gameObject);
    }

}
