using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroying : MonoBehaviour {

    public int a = 0;
    public GameObject obj;
    public float health = 100f;
    public void applyDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            health = 0f; obj.GetComponent<scoress>().s += 5;
            string kkk = obj.GetComponent<scoress>().s.ToString("f0");
            //obj.GetComponent<scoress>().score.text = obj.GetComponent<scoress>().s.ToString("f0"); 
            Destroy(gameObject);
            a = 1;
        }
      
    }
   /* public void call()
    {
        if (a == 1)
            //GetComponent<scoress>().s += 5;
    }*/
    void barhealth()
    {
        //GetComponent<healthbar>().hitpoint = health; GetComponent<healthbar>().mahitpoint = 100; GetComponent<healthbar>().updatehealthbar();
    }
}
