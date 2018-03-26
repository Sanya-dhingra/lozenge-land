using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class browmianmotion : MonoBehaviour {
    private int s = 0, y = 0,k=0;
    public float health=50f;
    public GameObject gameobject;
    
    private float timer=0.0f;
    // Use this for initialization
    /*void Start()
    {
        gameobject = GetComponent<GameObject>();
    }*/

    // Update is called once per frame
    void Update () {
        k++;
        
        if (s >= 1)
            motion();if (timer <= 0.01f) s = 0;
        timer += Time.deltaTime;
        if(timer>=1.0f)
        { s = 1;timer = 0; }
        //if (Input.GetKeyDown(KeyCode.H)&&y==0)
        //{
            //s++;motion();y = 1;
       // }
        
		
	}
    float getr()
    {
        return Random.Range(-20, 20);
    }
    void motion()
    {
        Vector3 pos = gameobject.transform.position;
        Vector3 ini = transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Mathf.Abs(pos.x - ini.x) <= 1 && Mathf.Abs(pos.z - ini.z) <= 1)
        {
            gameObject.GetComponent<healthbar>().fun(1.0f);
            //gameObject.GetComponent<destroying>().health -= 1;
            //Debug.Log(gameObject.GetComponent<destroying>().health);
            //gameObject.GetComponent<healthbar>().takedamage(1f);
            //rb.velocity = new Vector3(getr(), getr(), getr());
        }
        if (k % 5 != 0)
            rb.velocity = new Vector3(getr(), getr(), getr());
        else {
            rb.velocity = new Vector3((+pos.x - ini.x) , 0, (pos.z - ini.z) ); k = 0;
        }

        
    }
}
