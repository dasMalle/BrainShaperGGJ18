using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    public PlayableDirector mStartTimeLine;

    public float mTimelineLength;
   
    private void OnMouseDown()
    {
        mStartTimeLine.Play();
        StartCoroutine(LoadNextSceneAfterTimeline());
    }

    IEnumerator LoadNextSceneAfterTimeline()
    {
        yield return new WaitForSeconds(mTimelineLength);

        SceneManager.LoadScene(1);
    }
}
