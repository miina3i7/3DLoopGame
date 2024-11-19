using System.Collections.Generic;
using UnityEngine;

public class CoinStage : MonoBehaviour
{
    private int CoinCount = 0;
    private int DCoinCount = 0;

    private bool CoinColli;
    private bool DCoinColli;

    public GameObject Door;

    private void Start()
    {
        CoinColli = false;
        DCoinColli = false;
        CoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        DCoinCount = GameObject.FindGameObjectsWithTag("DCoin").Length;

    }

    private void Update()
    {
        CoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (CoinCount == 0 && !DCoinColli)
        {
            NextStage();
        }
        else
        {
            Stage();
        }

        if(DCoinCount != GameObject.FindGameObjectsWithTag("DCoin").Length)
        {
            DCoinColli = true;
        }
        else
        {
            DCoinColli = false;
        }
    }

    void NextStage()
    {
        Door.SetActive(false);
    }

    void Stage()
    {
        Door.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Coin")
        {
            CoinColli=true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Coin")
        {
            CoinColli = false;
        }

    }
}
