using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillTheBlood : MonoBehaviour {



    public GameObject particles;
    public float range = 4f;
   
   

    void SpillBloodHere()
    {
        Vector2 pos = Random.insideUnitCircle * 4;
        Vector3 pos3 = new Vector3(pos.x, pos.y, 0);

        GameObject newObj = Instantiate(particles, pos3, Quaternion.identity);
        Destroy(newObj, 2f);
    }

  }


