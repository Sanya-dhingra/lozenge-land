using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponSway : MonoBehaviour {
    public float amount=0.02f;
    public float smoothAmount=0.06f;
    public float maxAmount;
    private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
        initialPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        float movementx = -Input.GetAxis("Mouse X")*amount;
        float movementy = -Input.GetAxis("Mouse Y")*amount;
        movementx = Mathf.Clamp(movementx, -maxAmount, maxAmount);
        movementy = Mathf.Clamp(movementy, -maxAmount, maxAmount);
        //float movementz = -Input.GetAxis("Mouse Z");
        Vector3 finalposition = new Vector3(movementx, movementy, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + finalposition, Time.deltaTime * smoothAmount);
    }
}
