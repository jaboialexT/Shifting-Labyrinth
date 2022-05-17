using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public Vector2Int mBoardPosition = Vector2Int.zero;
    public Board mBoard = null;
    public RectTransform mRectTransform = null;
    private int rotation = 0;
    

    private Arrow mTargetArrow = null;
    
   
    public void Setup(Vector2Int newBoardPosition,Board newBoard)
    {
        mBoardPosition = newBoardPosition;
        mBoard = newBoard;
        mRectTransform = GetComponent<RectTransform>();
    }
    
    public void rotate()
    {
        rotation += 90;
        mRectTransform.rotation = Quaternion.Euler(0,0,rotation);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        rotate();   
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
        foreach(Arrow arrow in mBoard.mAllArrows)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(arrow.mRectTransform,Input.mousePosition))
            {
                mTargetArrow = arrow;
                Debug.Log(mTargetArrow + "hovered");
                break;
            }
            else
            {
            mTargetArrow = null;
            }
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        rotation -= 90;
        mRectTransform.rotation = Quaternion.Euler(0, 0, rotation);
        if(mTargetArrow != null)
        {
            Debug.Log(mTargetArrow+" clicked!");
            //move cell into array
            //displace cell from array
            //make all arrows visible
            //make target arrow invisible
            //change parents of pieces
            //move pieces along array
            //display new board
            //diplay new piece
        }
        else
        {
            mRectTransform.anchoredPosition = new Vector2((250), (450));
        }
    }



}
