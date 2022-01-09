using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePeg : MonoBehaviour
{

    public MastermindViewSettingsSo vs;

    int rowNumber = -1;
    int columnNumber = -1;
    public delegate void PlayerClickedHandler(int rowNumber, int columnNumber);
    public event PlayerClickedHandler PlayerClicked;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int color;
    public int Color {
        get{ return color; }
        set
        {
            color = value;
            var renderer = GetComponent<MeshRenderer>();
            if (Color >= 0)
            {
                renderer.sharedMaterial = vs.CodePegMaterials[color];
                renderer.enabled = true;
            }
            else
            {
                renderer.enabled = false;
            }
        }
    }

    [ContextMenu("SetColor-1")]
    private void SetColorm1()
    {
        Color = -1;
    }

    [ContextMenu("SetColor0")]
    private void SetColor0()
    {
        Color = 0;
    }

    [ContextMenu("SetColor1")]
    private void SetColor1()
    {
        Color = 1;
    }

    [ContextMenu("SetColor2")]
    private void SetColor2()
    {
        Color = 2;
    }


    [ContextMenu("SetColor3")]
    private void SetColor3()
    {
        Color = 3;
    }

    void OnMouseDown()
    {
        PlayerClicked?.Invoke(rowNumber, columnNumber);
    }

    public void InitPegPosition(int rowNumber, int columnNumber)
    {
        this.rowNumber = rowNumber;
        this.columnNumber = columnNumber;
    }

}
