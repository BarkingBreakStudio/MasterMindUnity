using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMindRow : MonoBehaviour
{
    public CodePegRow CodePegRow;
    public KeyPegArea2 KeyPegArea;
    public RowLocker RowLocker;

    [SerializeField]
    private int rowNumber = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitRow(int rowNumber)
    {
        this.rowNumber = rowNumber;
        CodePegRow.InitRow(rowNumber);
        RowLocker.InitLocker(rowNumber);
    }

    public void SetCodePegColor(int columnNumber, int color)
    {
        CodePegRow.SetColor(columnNumber, color);
    }

    public void SetKeyPegColors(int[] colors)
    {
        KeyPegArea.SetKeyPegColors(colors);
    }

    public void ActiveRowChanged(int activeRow)
    {
        RowLocker.SetVisible(activeRow == rowNumber);
    }

    internal void SetCodePegColors(int[] colors)
    {
        CodePegRow.SetColors(colors);
    }
}
