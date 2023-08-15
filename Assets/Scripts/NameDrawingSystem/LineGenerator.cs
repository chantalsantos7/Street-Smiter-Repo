using NameDrawingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform parentTransform;
    Line activeLine;
    public bool touchActive;
    private TouchManager touchManager;

    private Vector2 startPosition;
    private Vector2 endPosition;
    //public bool touchActive;

    private void Awake()
    {
        touchManager = TouchManager.Instance;
    }

    private void OnEnable()
    {
        touchManager.OnStartTouch += GetStartPos;
        touchManager.OnEndTouch += GetEndPos;
        /*touchManager.OnStartTouch += DrawLineStart;
        touchManager.OnEndTouch += DrawLineEnd;*/
    }

    private void OnDisable()
    {
        /*touchManager.OnStartTouch -= DrawLineStart;
        touchManager.OnEndTouch -= DrawLineEnd;*/
    }

    private void GetStartPos(Vector2 position, bool touchActive)
    {
        this.touchActive = touchActive;
        startPosition = position;
    }

    private void GetEndPos(Vector2 position)
    {
        touchActive = false;
    }

    private void DrawLineStart(Vector2 position)
    {
        startPosition = position;
        Debug.Log(startPosition);
        InstantiateLine();
        activeLine.UpdateLine(startPosition); //must constantly keep track of position
        //startInstantiating line
    }

    private void DrawLineEnd(Vector2 position)
    {
        endPosition = position;
        NullifyActiveLine();
        //stop Instantiating Line
    }

    public void InstantiateLine()
    {
        GameObject newLine = Instantiate(linePrefab);
        activeLine = newLine.GetComponent<Line>();
    }

    public void NullifyActiveLine()
    {
        activeLine = null;
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //inputManager.touchHeld
        {
            //Debug.Log("Held");
            GameObject newLine = Instantiate(linePrefab, parentTransform); //generates around 200 units away from the parent, which is roughly equal to the mousePosition as converted from screen to world point
            activeLine = newLine.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0)) //!inputManager.touchHeld
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            
            activeLine.UpdateLine(mousePosition);
        }
        /*if (touchActive)
        {
            GameObject newLine = Instantiate(linePrefab, parentTransform.transform);
            activeLine = newLine.GetComponent<Line>();
        }
        else
        {
            activeLine = null;
            //touchActive = false;
        }

        if (activeLine != null)
        {
            Debug.Log(touchManager.PrimaryPosition());
            activeLine.UpdateLine(touchManager.PrimaryPosition());
        }*/
    }
}
