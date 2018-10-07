﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ago : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private ArrowManeger arrowManeger;
    [SerializeField]
    GameStateManeger gameStateManeger;
    private float fireRotationZ;
    Vector3 startPos;
    public Vector3 FallVelocity { get; set; }

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Fire() {
        transform.rotation = Quaternion.Euler(arrowManeger.GetFireRotation().eulerAngles + new Vector3(0, 0, 180));
        rb.velocity = transform.up * -1 * arrowManeger.GetFirePower();
    }

    public void AddFallVelocity() {
        FallVelocity += new Vector3(0, -3.0f, 0) * Time.deltaTime;
        rb.velocity += (Vector2)FallVelocity * Time.deltaTime;
    }

    public void ChengeRotation() {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,360 * Mathf.Abs(Mathf.Atan(rb.velocity.y/rb.velocity.x))));
        Debug.Log(Mathf.Atan(rb.velocity.y / rb.velocity.x));
    }

    public void SetZeroFallVelocity() {
        FallVelocity = Vector3.zero;
    }

    public void StuckChin(GameObject stuckObject) {
        rb.velocity = stuckObject.GetComponent<Rigidbody2D>().velocity;
    }

    public void DeadSpin() {
        transform.Rotate(new Vector3(0, 0, 20));
        transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
        if (transform.localScale.z < 0.01f) {
            gameStateManeger.StateChange(4);
        }
    }

    public void RetryAgo() {
        gameObject.SetActive(true);
        transform.position = startPos;
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        SetZeroFallVelocity();
    }
}
