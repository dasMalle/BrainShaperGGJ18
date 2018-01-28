using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {

    public GameObject[] Stars;
    public AudioClip[] StarSounds;
    public AudioSource audioSource;
    public Sprite GoldStar;
    public float timeBetweenStars = 1.0f;
    public bool RiggedVersion;

    public GameObject[] mParticles; //The confetti to enable

    int starIndex;
    int earnedStars;

    // Use this for initialization
	void Start () {
        if (RiggedVersion)
            earnedStars = 3;
        else{
            float rand = Random.value;
        if (rand > 0.9f)
            earnedStars = 3;
        else if (rand < 0.3f)
            earnedStars = 1;
        else
            earnedStars = 2;        
        }
        starIndex = 0;
        StartCoroutine(SetStars());
	}
	
    IEnumerator SetStars()
    {
        for (int i = 0; i < earnedStars; i++)
        {
            Stars[i].GetComponent<SpriteRenderer>().sprite = GoldStar;
            audioSource.PlayOneShot(StarSounds[i]);
            mParticles[i].SetActive(true);
            yield return new WaitForSeconds(timeBetweenStars);
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(0);
    }

}
