using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    GameObject obj;
    public Animator ani;

    private void OnEnable()
    {
        ani.SetBool("isOn", true);
    }
    // Use this for initialization
    void Start ()
    {
        ani.SetBool("isOn", true);
	}

    private void OnDisable()
    {
        ani.SetBool("isOn", false);
    }
}

public interface IDriver
{
    void SetBool(bool isOn);
}
