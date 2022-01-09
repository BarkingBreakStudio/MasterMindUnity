using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MastermindBoard : MonoBehaviour
{

    public MastermindViewSettingsSo mmvs;

    public MasterMindRow[] mmrows = new MasterMindRow[0];
    public SecureCodeArea SecureCodeArea;

    public MasterMindGame2 mmg = new MasterMindGame2();

    private int activeRow;

    //events
    public UnityEvent PlayerWon;
    public UnityEvent PlayerLost;


    private void Awake()
    {
        activeRow = 0;

        mmg.StartMMGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartNewGame();
        /*
        var clickAreas = GetComponentsInChildren<PegClickArea2>();
        foreach (var clickArea in clickAreas)
        {
            clickArea.UserClick += ClickArea_UserClick;
        }*/
        var codePegs = GetComponentsInChildren<CodePeg>();
        foreach (var codePeg in codePegs)
        {
            codePeg.PlayerClicked += ClickArea_UserClick;
        }

        var rowLockers = GetComponentsInChildren<RowLocker>();
        foreach (var rowLocker in rowLockers)
        {
            rowLocker.PlayerClicked += RowLocker_PlayerClicked;
        }
    }

    private void RowLocker_PlayerClicked(int rowNumber)
    {
        if (rowNumber == activeRow)
        {
            int[] CodePegsColor = mmrows[rowNumber].CodePegRow.GetColors();
            var keyPegs = mmg.GuessSecureCode(CodePegsColor);

            int[] keyPegColors = new int[keyPegs.Length];
            for (int i = 0; i < keyPegs.Length; i++)
            {
                switch (keyPegs[i])
                {
                    case MasterMindGame2.eKeyPeg.wrong:
                        keyPegColors[i] = -1;
                        break;
                    case MasterMindGame2.eKeyPeg.color:
                        keyPegColors[i] = 0;
                        break;
                    case MasterMindGame2.eKeyPeg.matching:
                        keyPegColors[i] = 1;
                        break;
                }
            }

            mmrows[rowNumber].SetKeyPegColors(keyPegColors);

            //check if player won
            if (keyPegs.Count(x => x == MasterMindGame2.eKeyPeg.matching) == keyPegs.Length)
            {
                PlayerWon?.Invoke();
            }
            else
            {
                //move to next row
                activeRow++;
                for (int i = 0; i < mmrows.Length; i++)
                {
                    mmrows[i].ActiveRowChanged(activeRow);
                }

                if (activeRow < mmrows.Length) //set up next row
                {
                    mmrows[activeRow].SetCodePegColors(CodePegsColor);
                }
                else //no row left - play lost
                {
                    PlayerLost?.Invoke();
                }
            }
        }
    }

    private void ClickArea_UserClick(int rowNumber, int columnNumber)
    {
        Debug.Log($"clicked on peg click area {rowNumber} {columnNumber}");
        if (rowNumber == activeRow)
        {
            int[] CodePegsColor = mmrows[rowNumber].CodePegRow.GetColors();
            int currentColor = CodePegsColor[columnNumber];

            currentColor = currentColor < mmg.Config.NumCodeColors - 1 ? currentColor + 1 : 0;
            SetPegColor(rowNumber, columnNumber, currentColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        for (int i = 0; i < mmrows.Length; i++)
        {
            mmrows[i].InitRow(i);
            mmrows[i].ActiveRowChanged(activeRow);
        }
        mmrows[0].SetCodePegColors(new int[mmg.Config.NumCodePegs]);

        SecureCodeArea.SetColors(mmg.SecureCode);
    }

    public void SetPegColor(int rowNumber, int columnNumber, int color)
    {
        mmrows[rowNumber].SetCodePegColor(columnNumber, color);
    }

}
