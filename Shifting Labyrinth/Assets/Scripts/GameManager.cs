using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Board mBoard;
    
    private void Start()
    {
        mBoard.Create();
    }
}
