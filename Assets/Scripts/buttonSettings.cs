using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSettings : MonoBehaviour
{
    public GameObject pieces;

    public void PiecesSpawner_activate()
    {
      //  pieces =  GameObject.FindGameObjectWithTag("Pieces");
        pieces.SetActive(true);
    }

}
