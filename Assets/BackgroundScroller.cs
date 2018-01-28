using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BackgroundScroller : MonoBehaviour {

    Vector2 startDrag, endDrag;

    public TMP_Text mScoreText, mEndText;

    public GameObject mPanel;

    public float score = 0;
    float endTime;
    bool ending;

	// Use this for initialization
	void Start () {
        endTime = Time.time + Random.Range(5.0f, 10.0f);
        Destroy(GameObject.FindGameObjectWithTag("SFXM"));
        mScoreText.text = "Score: " + score.ToString("F1");
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0) && !ending)
        {
            startDrag = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) && !ending)
        {
            endDrag = Input.mousePosition;
            MoveBackground();
        }

        if(Time.time > endTime && !ending)
        {
            StartCoroutine(EndThenLoad());
        }
	}

    private void OnMouseDown()
    {
		print("MouseDown");
		print(Input.mousePosition);
        startDrag = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        endDrag = Input.mousePosition;
        print("MouseUp");
        print(Input.mousePosition);
        MoveBackground();
    }

    void MoveBackground()
    {
        float power = Mathf.Abs(startDrag.y - endDrag.y);
        power *= 0.1f;
        print(power);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * -power);
        score += Random.Range(0.05f, 1f) * power;
        mScoreText.text = "Score " + score.ToString("F1");
    }

    IEnumerator EndThenLoad()
    {
        mPanel.SetActive(true);
        mEndText.text = "You Scored;\n" + score.ToString("F1");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(0);
    }
}
