using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerscript : MonoBehaviour {
    public Text timertext;
    public float times = 300;
	// Use this for initialization
	void Start () {
        timertext = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        times -= Time.deltaTime;
        timertext.text = times.ToString("f2");
	}
}
