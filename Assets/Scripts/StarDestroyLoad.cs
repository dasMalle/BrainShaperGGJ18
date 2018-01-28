using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarDestroyLoad : MonoBehaviour {



   public void EasterEgg()
    {
        StartCoroutine(SliceThenChange());
    }



    IEnumerator SliceThenChange()
    {
        yield return new WaitForSeconds(0.8f); //Amount of time the second timeline takes;
        SceneManager.LoadScene(3);
    }
}
