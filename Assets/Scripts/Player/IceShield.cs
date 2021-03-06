﻿using UnityEngine;
using System.Collections;

public class IceShield : MonoBehaviour {

	private GameObject player;
	GameObject iceShield;
	IceShieldAnimation iceScript;		// Fetch the script of IceShield.
	static Rigidbody2D iceShieldAnimation;

	private float shieldStart = -100;	// Initial start value, so player can use spell instantly.
	public float shieldCoolDown = 15;	// 15 seconds
	private float shieldDuration;	// 7 seconds

    private bool shieldOnCooldown; // true if the ability is on cooldown. 

	public string inputKey = "3";
	public Rigidbody2D prefab;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");

        shieldOnCooldown = false;
    }

	void FixedUpdate () {
		if (iceShieldAnimation != null) {
			iceShieldAnimation.position = player.GetComponent<Rigidbody2D> ().position;
		}


	}

	void Update () {
		if ((Input.GetKeyDown (inputKey) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && Time.time > shieldStart + shieldCoolDown) {
			iceShieldAnimation = Instantiate(prefab, player.transform.position, Quaternion.identity) as Rigidbody2D;
			shieldDuration = prefab.GetComponent<IceShieldAnimation>().getDuration();
			shieldStart = Time.time;
		}

    }
    // True if iceshield is currently on cooldown.
    public bool GetShieldOnCooldownStatus()
    {
        return (Time.time < shieldStart + shieldCoolDown);
    }
}