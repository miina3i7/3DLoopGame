using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ItemStage : MonoBehaviour
{
    //public
    public List<GameObject> AItem = new List<GameObject>();
    public List<GameObject> BItem = new List<GameObject>();
    public GameObject ADoor;
    public GameObject BDoor;
    public GameObject Respawn;

    //private
    bool OnRespawn;
    bool Acount;
    bool Bcount;

    void Update()
    {
        ADOOR();
        BDOOR();
        RESET();
        
    }

    private void RESET()
    {
        ReSpawn res = Respawn.GetComponent<ReSpawn>();
        if(res.Reset == true)
        {
            AitemAllActive(AItem);
            BitemAllActive(BItem);
            ADoor.SetActive(true);
            BDoor.SetActive(true);
        }
    }
    void AitemAllActive(List<GameObject>AItem)
    {
        foreach(GameObject obj in AItem)
        {
            if(obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
    void BitemAllActive(List<GameObject>BItem)
    {
        foreach(GameObject obj in BItem)
        {
            if(obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
    

    private void ADOOR()
    {
        //ADoor
        if (AreAllObjectsInactive(AItem))
        {Acount = true;}
        else
        {Acount = false;}
        bool AreAllObjectsInactive(List<GameObject> Item)
        {
            foreach (GameObject obj in Item)
            {
                if (obj.activeSelf) 
                {
                    return false;
                }
                else if(!obj.activeSelf)
                {
                    Bcount = false;
                }
            }
            return true; 
        }
        if(Acount && !Bcount)
        {
            ADoor.SetActive(false);
            BDoor.SetActive(true);
        }
    }
        private void BDOOR()
    {
        //BDoor
        if (AreAllObjectsInactive(BItem))
        {Bcount = true;}
        else
        {Bcount = false;}
        bool AreAllObjectsInactive(List<GameObject> Item)
        {
            foreach (GameObject obj in Item)
            {
                if (obj.activeSelf) 
                {
                    return false;
                }
                else if(!obj.activeSelf)
                {
                    Acount = false;
                }
            }
            return true; 
        }
        if(Bcount && !Acount)
        {
            BDoor.SetActive(false);
            ADoor.SetActive(true);
        }
    }
}
