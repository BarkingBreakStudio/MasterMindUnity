using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Text HeadMessage;
    //public MasterMindModel mmm;
    public GameObject UI;


    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //mmm.PlayerWon += Mmm_PlayerWon;
        //mmm.PlayerLost += Mmm_PlayerLost;
    }

    public void OnPlayerLost()
    {
        HeadMessage.text = "Loser xD";
        UI.SetActive(true);
    }

    public void OnPlayerWon()
    {
        HeadMessage.text = "Winner!";
        UI.SetActive(true);
    }

    private void OnDisable()
    {
        //mmm.PlayerWon -= Mmm_PlayerWon;
        //mmm.PlayerLost -= Mmm_PlayerLost;
    }



}
