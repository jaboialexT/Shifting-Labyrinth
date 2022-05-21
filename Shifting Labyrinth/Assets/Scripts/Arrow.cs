using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Arrow : MonoBehaviour
{
    public Vector2Int mBoardPosition = Vector2Int.zero;
    public Board mBoard = null;
    public RectTransform mRectTransform = null;
    public Cell tempCell;
    public bool isVertical, isBackwards;
    public void Setup(Vector2Int newBoardPosition, Board newBoard,bool isVertical,bool isBackwards)
    {
        mBoardPosition = newBoardPosition;
        mBoard = newBoard;
        mRectTransform = GetComponent<RectTransform>();
        this.isVertical = isVertical;
        this.isBackwards = isBackwards;
    }
    public void displace()
    {
        if (!isBackwards)
        {
            if (!isVertical)
            {
                tempCell = mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y];
                mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y] = mBoard.mAllCells[7, 7];
                for (int i = 1; i < 7; i++)
                {
                    mBoard.mAllCells[7, 7] = mBoard.mAllCells[i, this.mBoardPosition.y];
                    mBoard.mAllCells[i, this.mBoardPosition.y] = tempCell;
                    tempCell = mBoard.mAllCells[7, 7];
                }
            }
            else
            {
                tempCell = mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y];
                mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y] = mBoard.mAllCells[7, 7];
                for (int i = 1; i < 7; i++)
                {
                    mBoard.mAllCells[7, 7] = mBoard.mAllCells[this.mBoardPosition.x,i];
                    mBoard.mAllCells[this.mBoardPosition.x, i] = tempCell;
                    tempCell = mBoard.mAllCells[7, 7];
                }
            }
        }
        else
        {
            if (!isVertical)
            {
                tempCell = mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y];
                mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y] = mBoard.mAllCells[7, 7];
                for (int i = 5; i >=0; i--)
                {
                    mBoard.mAllCells[7, 7] = mBoard.mAllCells[i, this.mBoardPosition.y];
                    mBoard.mAllCells[i, this.mBoardPosition.y] = tempCell;
                    tempCell = mBoard.mAllCells[7, 7];
                }
            }
            else
            {
                tempCell = mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y];
                mBoard.mAllCells[this.mBoardPosition.x, this.mBoardPosition.y] = mBoard.mAllCells[7, 7];
                for (int i = 5; i >= 0; i--)
                {
                    mBoard.mAllCells[7, 7] = mBoard.mAllCells[this.mBoardPosition.x,i];
                    mBoard.mAllCells[this.mBoardPosition.x, i] = tempCell;
                    tempCell = mBoard.mAllCells[7, 7];
                }
            }
        }
        
    }


}
