using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMindGame2
{

    private int[] secureCode;
    public int[] SecureCode => secureCode;

    private Configuration config = new Configuration();
    private int NumGuesses = 0;


    public Configuration Config => config;

    public void StartMMGame()
    {
        secureCode = new int[config.NumCodePegs];
        for(int i = 0; i < secureCode.Length; i++)
        {
            secureCode[i] = Random.Range(0, config.NumCodeColors);
        }
        NumGuesses = 0;
    }

    public eKeyPeg[] GuessSecureCode(int[] guessColors)
    {
        if (guessColors.Length != config.NumCodePegs) throw new System.ArgumentException("Wrong parameter length");

        NumGuesses++;

        eKeyPeg[] keyPegs = CaluclateKeyPegs(guessColors);

        return keyPegs;
    }


    private eKeyPeg[] CaluclateKeyPegs(int[] guessColors)
    {
        int numOfMatching = 0;
        int numOfRightColors = 0;
        List<int> currCode = new List<int>(guessColors);
        List<int> secureCode = new List<int>(this.secureCode);

        for (int i = secureCode.Count - 1; i >= 0; i--)
        {
            if (secureCode[i] == currCode[i])
            {
                numOfMatching++;
                secureCode.RemoveAt(i);
                currCode.RemoveAt(i);
            }
        }

        for (int i = secureCode.Count - 1; i >= 0; i--)
        {
            if (currCode.Contains(secureCode[i]))
            {
                numOfRightColors++;
                currCode.Remove(secureCode[i]);
            }
        }

        eKeyPeg[] keyPegs = new eKeyPeg[guessColors.Length];
        int cnt = 0;
        for (int i = 0; i < numOfMatching; i++)
        {
            keyPegs[cnt++] = eKeyPeg.matching;
        }
        for (int i = 0; i < numOfRightColors; i++)
        {
            keyPegs[cnt++] = eKeyPeg.color;
        }

        return keyPegs;
    }



    public class Configuration
    {
        public int NumCodeColors = 3;
        public int NumCodePegs = 4;
        public int MaxGuesses = 7;
    }

    public enum eKeyPeg
    {
        wrong,
        color,
        matching,
    }

}
