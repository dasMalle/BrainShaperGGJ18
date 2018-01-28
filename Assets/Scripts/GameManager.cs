using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class GameManager : MonoBehaviour {

    float TimeMin = 5f;
    float TimeMax = 12f;
    float time;
    float startTime;

    bool ending = false;

    public PlayableDirector mStartTimeline;
    public PlayableDirector mEndTimeline;
    public GameObject mPlatform, mBoy;


    // Use this for initialization
	void Start () {
        time = Random.Range(TimeMin, TimeMax);
        startTime = Time.time;
        //Adding to time so that we dont need to have an Ienumerator. the Start timeline is finished at 6 seconds, but we cant be bothered to do custom timeline tracks
		time += 6.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time > startTime + time && !ending)
        {
            //insert time line which then loads next scene
            mStartTimeline.Stop();
            mEndTimeline.gameObject.SetActive(true);
            mPlatform.SetActive(false); //make the platform disappear
            mBoy.SetActive(false); //Time to fake it till we make it
            ending = true; //Stop this code repeating
            StartCoroutine(TimelineThenChange()); //Wait for the timeline to finish
        }
            
	}

    IEnumerator TimelineThenChange()
    {
        yield return new WaitForSeconds(5.0f); //Amount of time the second timeline takes;
        SceneManager.LoadScene(2);
    }




}
