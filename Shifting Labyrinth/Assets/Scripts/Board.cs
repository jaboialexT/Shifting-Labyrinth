using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab,mArrowPrefab;
    public Sprite straight,t,corner;
    public Cell[,] mAllCells = new Cell[8, 8];
    public Canvas parent;
    public Arrow[,] mAllArrows = new Arrow[3, 4];
    private int arrowXCount = 0, arrowYCount = 0;
    public void Create()
    {
        #region Extra Tile
        GameObject newCell = Instantiate(mCellPrefab,transform);
        RectTransform rectTransform = newCell.GetComponent<RectTransform>();
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
            GameObject newArrow = Instantiate(mArrowPrefab, transform);
            mAllArrows[arrowYCount , 0] = newArrow.GetComponent<Arrow>();
            GameObject secArrow = Instantiate(mArrowPrefab, transform);
            mAllArrows[arrowYCount, 1] = secArrow.GetComponent<Arrow>();
            RectTransform Arrowtransform = newArrow.GetComponent<RectTransform>();
            RectTransform secArrowtransform = secArrow.GetComponent<RectTransform>();

            Arrowtransform.anchoredPosition = new Vector2(-50,((y)*100)+50);
            Arrowtransform.rotation = Quaternion.Euler(0, 0, 0);
            secArrowtransform.anchoredPosition = new Vector2(750,((y)*100)+50);
            secArrowtransform.rotation = Quaternion.Euler(0, 0, 180);

            mAllArrows[arrowYCount, 0].Setup(new Vector2Int(0, y), this);
            mAllArrows[arrowYCount, 1].Setup(new Vector2Int(1, y), this);
            arrowYCount++;
        }
        
        for (int x = 1; x < 7; x +=2)
        {
            GameObject newArrow = Instantiate(mArrowPrefab, transform);
            mAllArrows[arrowXCount, 2] = newArrow.GetComponent<Arrow>();
            GameObject secArrow = Instantiate(mArrowPrefab, transform);
            mAllArrows[arrowXCount, 3] = newArrow.GetComponent<Arrow>();
            RectTransform Arrowtransform = newArrow.GetComponent<RectTransform>();
            RectTransform secArrowtransform = secArrow.GetComponent<RectTransform>();

            Arrowtransform.anchoredPosition = new Vector2((x*100)+50,-50);
            Arrowtransform.rotation = Quaternion.Euler(0, 0, 90);
            secArrowtransform.anchoredPosition = new Vector2((x * 100) + 50, 750);
            secArrowtransform.rotation = Quaternion.Euler(0, 0, 270);

            mAllArrows[arrowXCount, 2].Setup(new Vector2Int(x, 2), this);
            mAllArrows[arrowXCount, 3].Setup(new Vector2Int(x, 3), this);
            arrowXCount++;
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

    
}
