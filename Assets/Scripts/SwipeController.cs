using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeController : MonoBehaviour {

    public Vector2 mSwipeStart, mSwipeEnd;
    public Vector3 mSwipePosition;

    public SpriteSlicer slicer;
    public LineRenderer mLineRenderer;

    public GameObject mIndicator;
    public GameObject mTrail;

    bool mTouchingBrain = false;
    bool mDrawingLine = false;

    string message;

    public float mOverlapRadius;

    public LayerMask mBrainLayer;

	// Update is called once per frame
	void Update () 
    {
        CheckForTouch();
	}

    void CheckForTouch()
    {
        if (Input.GetMouseButton(0))
        {

            mSwipePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mSwipePosition.z = 0;
            if (Input.GetMouseButton(0))
            {
                message += "New Position:" + mSwipePosition.ToString() + "\n";
                mTrail.transform.position = mSwipePosition;
                message += "Trail Position:" + mTrail.transform.position.ToString() + "\n";
                mIndicator.transform.position = mSwipePosition;
                mTouchingBrain = Physics2D.OverlapCircle(transform.position, mOverlapRadius, mBrainLayer);
                print(mTouchingBrain);

                //Starting the swipe through the brain
                if(mTouchingBrain && !mDrawingLine)
                {
                    mDrawingLine = true;
                    mSwipeStart = transform.position;
                }
                //Add an endpoint but continue drawing
                if(mTouchingBrain && mDrawingLine)
                {
                    mSwipeEnd = transform.position;
                    DrawLine(mSwipeStart,mSwipeEnd);
                }
                //We are no longer in the brain so stop movin
                if(!mTouchingBrain && mDrawingLine)
                {
                    mDrawingLine = false;
                    mSwipeEnd = transform.position;
                    DrawLine(mSwipeStart,mSwipeEnd);
                    slicer.SliceBrain(mSwipeStart, mSwipeEnd);
                }

            }
            if(Input.GetMouseButtonUp(0))
            {
                print("Mouse Up");
            }
        }

            /*switch(newTouch.phase)
            {
                case TouchPhase.Began:
                    mSwipeStart = newTouch.rawPosition;

                    message += "First Touch raw: " + newTouch.rawPosition + "\n";
                    message += "First Touch: " + newTouch.position + "\n";
                    message += "First Touch World position: " + Camera.main.ScreenToWorldPoint(newTouch.rawPosition) + "\n";

                    Vector3 newPos = Camera.main.ScreenToWorldPoint(newTouch.rawPosition);
                    newPos.z = 0;
                    mTrail.transform.position = newPos;
                    mIndicator.transform.position = newPos;

                    break;
                case TouchPhase.Moved:
                    mSwipeEnd = newTouch.rawPosition;

                    Vector3 movedPos = Camera.main.ScreenToWorldPoint(mSwipeEnd);
                    message += movedPos.ToString();
                    movedPos.z = 0;
					mTrail.transform.position = movedPos;
					mIndicator.transform.position = movedPos;
                    break;
                case TouchPhase.Ended:
                    mSwipeEnd = newTouch.rawPosition;

                    Debug.Log("Last Touch raw :" + newTouch.rawPosition);
                    Debug.Log("Last Touch: " + newTouch.position);
                    Debug.Log("Last Touch World position: " + Camera.main.ScreenToWorldPoint(newTouch.rawPosition));

                    Vector3 endPos = Camera.main.ScreenToWorldPoint(mSwipeEnd);
                    endPos.z = 0;
					mTrail.transform.position = endPos;
					mIndicator.transform.position = endPos;

					message = "";
                    break;
                case TouchPhase.Canceled:
                    mSwipeEnd = newTouch.position;
					Vector3 cancelledPos = Camera.main.ScreenToWorldPoint(mSwipeEnd);
                    cancelledPos.z = 0;
					mTrail.transform.position = cancelledPos;
					mIndicator.transform.position = cancelledPos;

                    break;

            }*/
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        mLineRenderer.positionCount = 2; //Set our positions

        mLineRenderer.SetPosition(0, start); //Start point
        mLineRenderer.SetPosition(1, end); //End point
    }

    void ClearLine()
    {
        mLineRenderer.positionCount = 0;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(20,20, 250,120));
        GUILayout.Label(message);
        GUILayout.EndArea();
    }
}
