using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldSceneManager : MonoBehaviour
{

    public MastermindBoard mmb;
    public GameOverUI gameOverUI;

    public enum eState
    {
        init,
        playing,
        won,
        lost,
    }

    eState state = eState.init;

    // Start is called before the first frame update
    void Start()
    {
        state = eState.playing;
    }

    void OnEnable()
    {
        mmb.PlayerWon.AddListener(mmb_PlayerWon);
        mmb.PlayerLost.AddListener(mmb_PlayerLost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mmb_PlayerWon()
    {
        if(state == eState.playing)
        {
            state=eState.won;
            gameOverUI.OnPlayerWon();
        }
    }

    void mmb_PlayerLost()
    {
        if (state == eState.playing)
        {
            state = eState.lost;
            gameOverUI.OnPlayerLost();
        }
    }
}
