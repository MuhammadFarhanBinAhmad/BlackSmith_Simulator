using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSquareLineRenderer : MonoBehaviour
{
    int numOfLine = 0;

    public void CreateRuneLine(Vector3 buttonPosition)
    {   
            this.GetComponent<LineRenderer>().SetPosition(numOfLine, buttonPosition);
            numOfLine++;
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

        this.GetComponent<LineRenderer>().positionCount = 0;
        this.GetComponent<LineRenderer>().positionCount = 4;

        numOfLine = 0;
    }

}
