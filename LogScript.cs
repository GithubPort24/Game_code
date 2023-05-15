using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogScript : MonoBehaviour
{

    public int pattern;
    public int pattern2;
    public int cycle_val;
    public int fail = -1;
    public bool isfail = false;
    public Bar_1_movement Bar1;
    public Bar_2_Movement Bar2;
    public GameObject selected_b1;
    public GameObject selected_b2;
 





    public void fail_update(int val)
    {
        fail = val;
    }

    public void Start()
    {

        selected_b1 = GameObject.FindGameObjectWithTag("Selected_b1");
        selected_b2 = GameObject.FindGameObjectWithTag("Selected_b2");
        selected_b1.SetActive(true);
        selected_b2.SetActive(false);


    }

   

   


    public void check_input()
    {

        //Change this to match bar1 and bar2. 

        pattern = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn_2b>().randspawn1;
        pattern2 = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn_2b>().randspawn2;

        Debug.Log("Patterns: " + pattern + pattern2);
        Debug.Log("Bars index: " + Bar1.currentIndex + Bar2.currentIndex);

        if (Bar1.currentIndex == pattern && Bar2.currentIndex == pattern2)
        {

            Destroy(GameObject.FindGameObjectWithTag("P_1_spawn"));
            Destroy(GameObject.FindGameObjectWithTag("P_2_spawn"));
            Destroy(GameObject.FindGameObjectWithTag("P_3_spawn"));
            Destroy(GameObject.FindGameObjectWithTag("P_4_spawn"));


            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn_2b>().sp_();

           


        }
        else
        {
            isfail = true;
            fail += 1;
            fail_update(fail);
            Debug.Log("Fail" + cycle_val);
        }

        if (fail == 3)
        {
            fail = 0;
            Time.timeScale = 0;
            //Pause scene 

            GameObject.FindGameObjectWithTag("Bar1").SetActive(false);
            GameObject.FindGameObjectWithTag("Bar2").SetActive(false);
            Debug.Log("Failed 3 times");

        }


    }

 
}


