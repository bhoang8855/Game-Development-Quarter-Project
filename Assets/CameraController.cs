using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = GetComponent<Transform>().position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().position = player.transform.position + offset;
	}
}
