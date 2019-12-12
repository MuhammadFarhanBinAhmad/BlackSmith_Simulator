using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSquareLineRenderer : MonoBehaviour
{

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateRuneLine(Vector3 buttonPosition)
    {
        int currentPos = lineRenderer.positionCount++;
        lineRenderer.SetPosition(currentPos, buttonPosition);
    }

    public void ClearRuneLine()
    {
        /*
        Vector3 nullVector = new Vector3(0, 0, 0);

        for (int i = 0; i < GetComponent<LineRenderer>().positionCount; i++)
        {
            this.GetComponent<LineRenderer>().SetPosition(i, nullVector);
        }
        */

        lineRenderer.positionCount = 0;
    }

}
