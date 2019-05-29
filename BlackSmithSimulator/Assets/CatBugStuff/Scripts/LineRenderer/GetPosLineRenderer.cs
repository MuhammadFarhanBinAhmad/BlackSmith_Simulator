using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosLineRenderer : MonoBehaviour
{
    public GameObject theLine;
    public GameObject currentLine;

    public LineRenderer theLineRenderer;

    public List<Vector3> fingerposition;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))//detect first click
        {
            MakeLine();
            //StartCoroutine(LineDestroy());
        }
        if (Input.GetMouseButton(0))//detect if player holding it down
        {
            Vector3 tempfingerpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            if (Vector3.Distance(tempfingerpos,fingerposition[fingerposition.Count - 1]) > .1f)
            {
                UpdateLine(tempfingerpos);
            }
        }
    }

    void MakeLine()
        //will create line, save it into the different variables,it will then set the first 2 points of the line renderer and the edge collider 
    {
        currentLine = Instantiate(theLine, Vector3.zero, Quaternion.identity);
        theLineRenderer =  currentLine.GetComponent<LineRenderer>();
        fingerposition.Clear();//remove last existing line
        fingerposition.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z)));
        fingerposition.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)));
        //set the 2 point for line renderer
        theLineRenderer.SetPosition(0, fingerposition[0]);//start
        theLineRenderer.SetPosition(1, fingerposition[1]);//end

    }
    void UpdateLine(Vector3 newFingerPos)
    {
        fingerposition.Add(newFingerPos);
        theLineRenderer.positionCount++;//increase the size the point
        theLineRenderer.SetPosition(theLineRenderer.positionCount - 1, newFingerPos);//index count start at 0
    }
}