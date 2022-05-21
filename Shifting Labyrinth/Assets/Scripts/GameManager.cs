using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public Board mBoard;
    public Cell tempCell = null, mTargetCell=null;
    private Arrow mTargetArrow = null;

    private void Start()
    {
        mBoard.Create();
        mTargetCell = mBoard.mAllCells[7, 7];
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        mTargetCell.rotate();
    }

    public void OnDrag(PointerEventData data)
    {
        
        mTargetCell.transform.position = Input.mousePosition;
        foreach (Arrow arrow in mBoard.mAllArrows)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(arrow.mRectTransform, Input.mousePosition))
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
        mTargetCell.rotation -= 90;
        mTargetCell.mRectTransform.rotation = Quaternion.Euler(0, 0, mTargetCell.rotation);
        if (mTargetArrow != null)
        {
            Debug.Log(mTargetArrow + " clicked!");

            //moves cells across the array
            mTargetArrow.displace();
            //displace cell from array
            mBoard.Display(mBoard.mAllCells);
            //make all arrows visible
            //make target arrow invisible
            //change parents of pieces
            //move pieces along array
            //display new board
            //diplay new piece
        }
        else
        {
            mTargetCell.mRectTransform.anchoredPosition = new Vector2((250), (450));
        }
    }
}
