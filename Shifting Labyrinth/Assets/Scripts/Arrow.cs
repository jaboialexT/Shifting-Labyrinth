using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Arrow : MonoBehaviour
{
    public Vector2Int mBoardPosition = Vector2Int.zero;
    public Board mBoard = null;
    public RectTransform mRectTransform = null;
    public void Setup(Vector2Int newBoardPosition, Board newBoard)
    {
        mBoardPosition = newBoardPosition;
        mBoard = newBoard;
        mRectTransform = GetComponent<RectTransform>();
    }
    public void Start()
    {
        //GetComponent<Image>().color = new Color32(0,0,0,255);
    }


}
