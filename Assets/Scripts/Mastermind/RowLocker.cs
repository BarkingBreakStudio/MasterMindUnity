using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowLocker : MonoBehaviour
{

    public MeshRenderer mr;
    int rowNumber;

    public delegate void PlayerClickedHandler(int rowNumber);
    public event PlayerClickedHandler PlayerClicked;

    private void Awake()
    {

    }

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
        PlayerClicked?.Invoke(rowNumber);
    }

    public void InitLocker(int rowNumber)
    {
        this.rowNumber = rowNumber;
    }

    public void SetVisible(bool visible)
    {
        mr.enabled = visible;
    }
}
