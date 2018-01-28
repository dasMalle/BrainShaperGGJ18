using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotJudgeMe : MonoBehaviour {

    public StarDestroyLoad load;
    private void OnDestroy()
    {
        load.EasterEgg();   
    }
}
