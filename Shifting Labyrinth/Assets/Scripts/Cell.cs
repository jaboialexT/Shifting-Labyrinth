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
    public float rotation;
    private Cell tempCell = null;

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
                Debug.Log(mTargetArrow + "hovered" );
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
            
            //moves cells across the array
            switch (mTargetArrow.name)
            {
                case ("10"):
                    tempCell = mBoard.mAllCells[0, 1];
                    mBoard.mAllCells[0,1] = mBoard.mAllCells[7,7];
                    for (int i = 1; i < 7 ; i++)
                    {
                        mBoard.mAllCells[7, 7] = mBoard.mAllCells[i, 1];
                        mBoard.mAllCells[i, 1] = tempCell;
                        tempCell = mBoard.mAllCells[7,7];
                    }
                    break;
                case ("30"):
                    break;
                case ("50"):
                    break;
                case ("11"):
                    break;
                case ("31"):
                    break;
                case ("51"):
                    break;
                case ("12"):
                    break;
                case ("32"):
                    break;
                case ("52"):
                    break;
                case ("13"):
                    break;
                case ("33"):
                    break;
                case ("53"):
                    break;
            }

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
            mRectTransform.anchoredPosition = new Vector2((250), (450));
        }
    }



}
