using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pawnScript : MonoBehaviour
{
    public bool activity = false;

    public int id_vertical, id_horizontal;
    GameObject cell, celll, cellll;

    GameObject gameController;

    public GameObject queenPref;
    public GameObject myCell;
 //   public string myCall_name;
    public GameObject[] cells;
    public Color event_1, normal;
    public bool white = false;
    public bool black = false;


    public delegate void DISACTIVE();


    private void Start()
    {

        DISACTIVE disactive = disActive;


        gameController = GameObject.FindGameObjectWithTag("gameController");

    
    
    }


    void Update()
    {
      
    }

    public void setActive()
    {
        GetComponent<Image>().color = event_1;
        activity = true;

        if(id_vertical == 2)
        {
            for(int v = 3; v<5; v++)
            {
                GameObject cell = GameObject.FindGameObjectWithTag(""+ id_horizontal + v);

                if(cell.GetComponent<cell_Script>().onMe == false)
                {
                    cell.GetComponent<cell_Script>().ChangeCollor(2);
                }
            }

        }
        else if(white)
        {
            if(id_horizontal + 1 < 9 && id_vertical + 1 < 9)
            {
                GameObject celll = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1));
                if (celll.GetComponent<cell_Script>().onMe && celll.GetComponent<cell_Script>().MyPieceBlack)
                {

                    celll.GetComponent<cell_Script>().ChangeCollor(3);
                    // GameObject piec = celll.GetComponent<cell_Script>().myPiece;

                }
            }
            
            if(id_horizontal - 1 >0 && id_vertical + 1 < 9)
            {
                GameObject cellll = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1));
                if (cellll.GetComponent<cell_Script>().onMe)
                {
                    cellll.GetComponent<cell_Script>().ChangeCollor(3);
                    // GameObject piec = celll.GetComponent<cell_Script>().myPiece;

                }
            }
          


            GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1));
            if (cell.GetComponent<cell_Script>().onMe == false)
            {
                cell.GetComponent<cell_Script>().ChangeCollor(2);
            }
        }
        else if(id_vertical == 7)
        {
            for (int v = 6; v > 4; v--)
            {
                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + v);
                if (cell.GetComponent<cell_Script>().onMe == false)
                {
                    cell.GetComponent<cell_Script>().ChangeCollor(2);
                }
            }
        }
        else if (black)
        {
            GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1));
            if (cell.GetComponent<cell_Script>().onMe == false)
            {
                cell.GetComponent<cell_Script>().ChangeCollor(2);
            }
        }



    }

    public void disActive()
    {
        GetComponent<Image>().color = normal;
        activity = false;


        
        if (id_vertical == 2 && white)
        {
            for (int v = 2; v < 5; v++)
            {
                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + v);
                int cell_color = cell.GetComponent<cell_Script>().myColor;
                cell.GetComponent<cell_Script>().ChangeCollor(cell_color);
            }

        }
        else if(white)
        {
            if(id_vertical + 1 < 9)
            {
                cell = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1));

            }
            if(id_horizontal + 1 < 9 && id_vertical + 1 < 9)
            {
                celll = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1));

            }
            if(id_horizontal - 1 > 0 && id_vertical + 1 < 9)
            {
                cellll = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1));

            }
            if (cell.GetComponent<cell_Script>().id_vertical == 8 && cell != null)
            {
                /*  GameObject tmpQueen = Instantiate(queenPref);
                  tmpQueen.transform.SetParent(GameObject.FindGameObjectWithTag("Pieces").transform, false);
                  tmpQueen.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);

                  Destroy(this.gameObject);*/
                
            }
            else 
            {
                if(cell != null)
                {
                    int cell_color = cell.GetComponent<cell_Script>().myColor;
                    cell.GetComponent<cell_Script>().ChangeCollor(cell_color);

                }
                if(celll != null)
                {
                    int celll_color = celll.GetComponent<cell_Script>().myColor;
                    celll.GetComponent<cell_Script>().ChangeCollor(celll_color);

                }
                if(cellll != null)
                {
                    int cellll_color = cellll.GetComponent<cell_Script>().myColor;
                    cellll.GetComponent<cell_Script>().ChangeCollor(cellll_color);

                }
            }
        }
        else if(id_vertical == 7 && black)
        {
            for (int v = 6; v > 4; v--)
            {
                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + v);
                int cell_color = cell.GetComponent<cell_Script>().myColor;
                cell.GetComponent<cell_Script>().ChangeCollor(cell_color);
            }

        }
        else if (black)
        {
            GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1));
            if (cell.GetComponent<cell_Script>().id_vertical == 8)
            {
                /*  GameObject tmpQueen = Instantiate(queenPref);
                  tmpQueen.transform.SetParent(GameObject.FindGameObjectWithTag("Pieces").transform, false);
                  tmpQueen.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);

                  Destroy(this.gameObject);*/

            }
            else
            {
                int cell_color = cell.GetComponent<cell_Script>().myColor;
                cell.GetComponent<cell_Script>().ChangeCollor(cell_color);
            }
        }
    }

    private void OnMouseDown()
    {

        //  string gameController_pieceScriptName = gameController.GetComponent<gameController>().pieceScriptName;
        if (gameController.GetComponent<gameController>().dis == null)
        {
            gameController.GetComponent<gameController>().dis = disActive;
        }
        else
        {
            gameController.GetComponent<gameController>().dis();
            gameController.GetComponent<gameController>().Cell = myCell;

            gameController.GetComponent<gameController>().Piece = this.gameObject;
            //    gameController.GetComponent<gameController>().pieceScriptName = "pawnScript";
            gameController.GetComponent<gameController>().pieceTag = this.gameObject.tag;
            gameController.GetComponent<gameController>().dis = disActive;
            activity = true;
            setActive();
        }

    }

}
