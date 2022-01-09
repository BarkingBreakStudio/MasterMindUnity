using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegClickArea2 : MonoBehaviour
{
    int rowNumber;
    int columnNumber;

    public event Action<int,int> UserClick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseDown()
    {
        UserClick?.Invoke(rowNumber, columnNumber);
    }

    internal void InitArea(int rowNumber, int columnNumber)
    {
        this.rowNumber = rowNumber;
        this.columnNumber = columnNumber;
    }
}
