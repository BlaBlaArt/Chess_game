using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class knightScript : MonoBehaviour
{
    public bool activity = false;

    public int id_vertical, id_horizontal;

    GameObject gameController;
    GameObject cell;
    public GameObject myCell;
    public string myCall_name;
    public GameObject[] cells;
    public Color event_1, normal;
    int myCell_horizontal;
    int myCell_vertical;
    public bool white = false;
    public bool black = false;

    public delegate void DISACTIVE();


    private void Start()
    {
        DISACTIVE disactive = disActive;
        gameController = GameObject.FindGameObjectWithTag("gameController");
    }



    public void setActive()
    {
        GetComponent<Image>().color = event_1;
        activity = true;

        //вверх
        Moves();

    }

    public void disActive()
    {
        GetComponent<Image>().color = normal;
        activity = false;

        foreach (GameObject cel in gameController.GetComponent<gameController>().CellsList)
        {
            int cell_color = cel.GetComponent<cell_Script>().myColor;

            cel.GetComponent<cell_Script>().ChangeCollor(cell_color);
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

    void Moves()
    {
        cell = GameObject.FindGameObjectWithTag("" + id_horizontal + id_vertical);
        List<GameObject> cellss = new List<GameObject>();

        if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical + 2) > 0 && (id_vertical + 2) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 2)) != null)
        {
            GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 2));
            cellss.Add(cell_up_right);
        }

        if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && (id_vertical + 2) > 0 && (id_vertical + 2) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 2)) != null)
        {
            GameObject cell_up_left;
            cellss.Add(cell_up_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 2)));
        }

        if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical - 2) > 0 && (id_vertical - 2) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 2)) != null )
        {
            GameObject cell_down_right;
            cellss.Add(cell_down_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 2)));

        }

        if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && (id_vertical - 2) > 0 && (id_vertical - 2) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 2)) != null)
        {
            GameObject cell_down_left;
            cellss.Add(cell_down_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 2)));
        }

        if ((id_horizontal + 2) > 0 && (id_horizontal + 2) < 9 && (id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 2) + (id_vertical + 1)) != null)
        {
            GameObject cell_right_up;
            cellss.Add(cell_right_up = GameObject.FindGameObjectWithTag("" + (id_horizontal + 2) + (id_vertical + 1)));
        }

        if ((id_horizontal + 2) > 0 && (id_horizontal + 2) < 9 && (id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 2) + (id_vertical - 1)) != null)
        {
            GameObject cell_right_down;
            cellss.Add(cell_right_down = GameObject.FindGameObjectWithTag("" + (id_horizontal + 2) + (id_vertical - 1)));
        }

        if ((id_horizontal - 2) > 0 && (id_horizontal - 2) < 9 && (id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 2) + (id_vertical + 1)) != null)
        {
            GameObject cell_left_up;
            cellss.Add(cell_left_up = GameObject.FindGameObjectWithTag("" + (id_horizontal - 2) + (id_vertical + 1)));

        }

        if ((id_horizontal - 2) > 0 && (id_horizontal - 2) < 9 && (id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 2) + (id_vertical - 1)) != null)
        {
            GameObject cell_left_down;
            cellss.Add(cell_left_down = GameObject.FindGameObjectWithTag("" + (id_horizontal - 2) + (id_vertical - 1)));
        }

  

        foreach(GameObject cel in cellss)
        {
            if (cel == null)
            {
            }
            else if(cel.GetComponent<cell_Script>().onMe == true)
            {
                if (white)
                {
                    if (cel.GetComponent<cell_Script>().MyPieceBlack)
                    {
                        gameController.GetComponent<gameController>().CellsList.Add(cel);

                        cel.GetComponent<cell_Script>().ChangeCollor(3);
                    }
                }
                else if (black)
                {
                    if (cel.GetComponent<cell_Script>().MyPieceWhite)
                    {
                        gameController.GetComponent<gameController>().CellsList.Add(cel);

                        cel.GetComponent<cell_Script>().ChangeCollor(3);
                    }
                }
            }
            else
            {
                cel.GetComponent<cell_Script>().ChangeCollor(2);
                gameController.GetComponent<gameController>().CellsList.Add(cel);
            }
        }

        
    }

}


