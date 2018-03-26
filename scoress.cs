using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoress : MonoBehaviour {
    public Text score;
    
    public float s=0;
    void Start()
    {
        score = GetComponent<Text>();
       // obj = GetComponent<GameObject>();
    }

    /*void Update () {
        string kkk = s.ToString("f0");
        score.text = kkk;
	}*/
}
