using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePegRow : MonoBehaviour
{

    public CodePeg[] CodePegs = new CodePeg[0];

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
        for (int i = 0; i < CodePegs.Length; i++)
        {
            CodePegs[i].Color = -1;
            CodePegs[i].InitPegPosition(rowNumber, i);
        }
    }

    public void SetColor(int columnNumber, int color)
    {
        CodePegs[columnNumber].Color = color;
    }

    public void SetColors(int[] colors)
    {
        for (int i = 0; i < Math.Min(CodePegs.Length, colors.Length); i++)
        {
            CodePegs[i].Color = colors[i];
        }
    }

    public int[] GetColors()
    {
        int[] colors = new int[CodePegs.Length];
        for (int i = 0;i < CodePegs.Length;i++)
        {
            colors[i] = CodePegs[i].Color;
        }
        return colors;
    }
}
