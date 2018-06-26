using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotation : MonoBehaviour
{
    public float speed;
    public bool isOn;
    public bool isClockwise;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isOn)
        { this.transform.Rotate((isClockwise ? Vector3.up: Vector3.down) * Time.deltaTime * speed); }
	}
}
