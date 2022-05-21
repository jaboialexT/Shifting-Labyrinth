using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public RectTransform rectTransform, Arrowtransform;
    public GameObject mCellPrefab,mArrowPrefab,newCell,newArrow;
    public Sprite straight,t,corner;
    public Cell[,] mAllCells = new Cell[8, 8];
    public Canvas parent;
    public Arrow[,] mAllArrows = new Arrow[3, 4];
    private int arrowYCount = 0;
    private float rotation;
    public void Create()
    {
        #region Extra Tile
        newCell = Instantiate(mCellPrefab,transform);
        rectTransform = newCell.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2((-200), (350));
        mAllCells[7, 7] = newCell.GetComponent<Cell>();
        mAllCells[7, 7].Setup(new Vector2Int(7, 7), this);
        switch (Random.Range(0, 3))
        {
            case 0:
                mAllCells[7, 7].GetComponent<Image>().sprite = straight;
                break;
            case 1:
                mAllCells[7, 7].GetComponent<Image>().sprite = t;
                break;
            case 2:
                mAllCells[7, 7].GetComponent<Image>().sprite = corner;
                break;

        }
        newCell.transform.SetParent(parent.transform);
        #endregion

        for (int y = 0 ; y < 7 ;  y++)
        {
            for(int x = 0 ; x < 7 ; x++)
            {
                newCell = Instantiate(mCellPrefab, transform);

                rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);
                rectTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0,5)*90);

                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x,y].rotation = rectTransform.localEulerAngles.z;
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);
                
                switch (Random.Range(0, 3))
                {
                    case 0:
                        mAllCells[x, y].GetComponent<Image>().sprite = straight;    
                        break;
                    case 1:
                        mAllCells[x, y].GetComponent<Image>().sprite = t;  
                        break;
                    case 2:
                        mAllCells[x, y].GetComponent<Image>().sprite = corner;
                        break;
                }
            }
        }

        for(int y = 1; y < 7; y +=2)
        {
            newArrow = Instantiate(mArrowPrefab, transform);
            newArrow.name = y+"0";
            mAllArrows[arrowYCount , 0] = newArrow.GetComponent<Arrow>();
            Arrowtransform = newArrow.GetComponent<RectTransform>();
            Arrowtransform.anchoredPosition = new Vector2(-50,((y)*100)+50);
            Arrowtransform.rotation = Quaternion.Euler(0, 0, 0);
            
            newArrow = Instantiate(mArrowPrefab, transform);
            mAllArrows[arrowYCount, 1] = newArrow.GetComponent<Arrow>();
            newArrow.name = y + "1";
            Arrowtransform = newArrow.GetComponent<RectTransform>();
            Arrowtransform.anchoredPosition = new Vector2(750,((y)*100)+50);
            Arrowtransform.rotation = Quaternion.Euler(0, 0, 180);

            newArrow = Instantiate(mArrowPrefab, transform);
            newArrow.name = y + "2";
            mAllArrows[arrowYCount, 2] = newArrow.GetComponent<Arrow>();
            Arrowtransform = newArrow.GetComponent<RectTransform>();
            Arrowtransform.anchoredPosition = new Vector2((y*100)+50,-50);
            Arrowtransform.rotation = Quaternion.Euler(0, 0, 90);
            
            newArrow = Instantiate(mArrowPrefab, transform);
            newArrow.name = y + "3";
            mAllArrows[arrowYCount, 3] = newArrow.GetComponent<Arrow>();
            Arrowtransform = newArrow.GetComponent<RectTransform>();
            Arrowtransform.anchoredPosition = new Vector2((y * 100) + 50, 750);
            Arrowtransform.rotation = Quaternion.Euler(0, 0, 270);

            mAllArrows[arrowYCount, 0].Setup(new Vector2Int(0, y), this,false,false);
            mAllArrows[arrowYCount, 1].Setup(new Vector2Int(6, y), this,false,true);
            mAllArrows[arrowYCount, 2].Setup(new Vector2Int(y, 0), this,true,false);
            mAllArrows[arrowYCount, 3].Setup(new Vector2Int(y, 6), this,true,true);
            arrowYCount++;
        }
        



        mAllCells[0, 0].GetComponent<Image>().color = new Color32(210, 169,65, 255);
        mAllCells[0, 0].GetComponent<Image>().sprite = corner;
        mAllCells[0, 0].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,270);
        
        mAllCells[6, 6].GetComponent<Image>().color = new Color32(210, 94, 63, 255);
        mAllCells[6, 6].GetComponent<Image>().sprite = corner;
        mAllCells[6, 6].GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
       
        mAllCells[6, 0].GetComponent<Image>().color = new Color32(79, 123, 159, 255);
        mAllCells[6, 0].GetComponent<Image>().sprite = corner;
        mAllCells[6, 0].GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        
        mAllCells[0, 6].GetComponent<Image>().color = new Color32(83, 161, 79, 255);
        mAllCells[0, 6].GetComponent<Image>().sprite = corner;
        mAllCells[0, 6].GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);

    }
    public void Display(Cell[,] allCells)
    {
        
        for(int y = 0; y < 7; y++)
        {
            for(int x = 0; x < 7; x++)
            {
                RectTransform rectTransform = allCells[x,y].GetComponent<RectTransform>();
                allCells[x, y].transform.SetParent(this.transform);
                rectTransform.anchoredPosition = new Vector3((x * 100) + 50, (y * 100) + 50,allCells[x,y].rotation);
            }
        }
        allCells[7,7].transform.SetParent(parent.transform);
        allCells[7,7].GetComponent<RectTransform>().anchoredPosition = new Vector2((250), (450));
    }
}
