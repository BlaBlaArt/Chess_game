using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class queenScript : MonoBehaviour
{
    public bool activity = false;

    public int id_vertical, id_horizontal;

    GameObject gameController;

    public GameObject king;

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

        //проверка по горизонтали вправо
        for (int i = id_horizontal; i < 9; i++)
        {
            GameObject cell_hor_up = GameObject.FindGameObjectWithTag("" + i + id_vertical);

            if (cell_hor_up.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_hor_up.GetComponent<cell_Script>().onMe == false)
                {
                    cell_hor_up.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_hor_up);
                }
                else if (cell_hor_up.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_hor_up.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_hor_up.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_hor_up.GetComponent<cell_Script>().myPiece;
                                for(int j = id_horizontal; j < 9; j++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + j + id_vertical);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                 gameController.GetComponent<gameController>().CellsList.Add(cell_hor_up);
                                 cell_hor_up.GetComponent<cell_Script>().ChangeCollor(3);
                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_hor_up.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_hor_up.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int j = id_horizontal; j < 9; j++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + j + id_vertical);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_hor_up);
    
                                cell_hor_up.GetComponent<cell_Script>().ChangeCollor(3);

                            }

                        }
                    }
                    break;
                }
            }
        }
        //влево
        for (int j = id_horizontal; j > 0; j--)
        {
            GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + j + id_vertical);

            if (cell_hor_down.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                {
                    cell_hor_down.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_hor_down);
                }
                else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_hor_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_hor_down.GetComponent<cell_Script>().myPiece;

                                for (int i = id_horizontal; i > 0; i--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + i + id_vertical);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                            gameController.GetComponent<gameController>().CellsList.Add(cell_hor_down);

                            cell_hor_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }

                        }
                    }
                    else if (black)
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_hor_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int i = id_horizontal; i > 0; i--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + i + id_vertical);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_hor_down);

                                cell_hor_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }
        }
        //проверка по вертикали вверх
        for (int u = id_vertical; u < 9; u++)
        {
            GameObject cell_vertical_up = GameObject.FindGameObjectWithTag("" + id_horizontal + u);

            if (cell_vertical_up.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                {
                    cell_vertical_up.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_up);
                }
                else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_vertical_up.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_vertical_up.GetComponent<cell_Script>().myPiece;

                                for (int i = id_vertical; i < 9; i++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + id_horizontal + i);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_up);

                                cell_vertical_up.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_vertical_up.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int i = id_vertical; i < 9; i++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + id_horizontal + i);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_up);

                                cell_vertical_up.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }
        }
        //вниз
        for (int d = id_vertical; d > 0; d--)
        {
            GameObject cell_vertical_down = GameObject.FindGameObjectWithTag("" + id_horizontal + d);

            if (cell_vertical_down.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                {
                    cell_vertical_down.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_down);
                }
                else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_vertical_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_vertical_down.GetComponent<cell_Script>().myPiece;

                                for (int i = id_vertical; i > 0; i--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + id_horizontal + i);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_down);

                                cell_vertical_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_vertical_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int i = id_vertical; i > 0; i--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + id_horizontal + i);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_down);

                                cell_vertical_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }
        }
        //проверка вверx и вправо
        for (int i = id_horizontal, a = id_vertical; i < 9 & a < 9; i++, a++)
        {

            GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + i + a);

            if (cell_up_right.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_up_right.GetComponent<cell_Script>().onMe == false)
                {
                    cell_up_right.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_up_right);
                }
                else if (cell_up_right.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_up_right.GetComponent<cell_Script>().MyPieceBlack)
                        {
                               if (cell_up_right.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_up_right.GetComponent<cell_Script>().myPiece;

                                for (int b = id_horizontal, c = id_vertical; b < 9 & c < 9; b++, c++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_up_right);

                                cell_up_right.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_up_right.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_up_right.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int b = id_horizontal, c = id_vertical; b < 9 & c < 9; b++, c++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_up_right);

                                cell_up_right.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }

        }
        //проверка вверх и влево
        for (int i = id_horizontal, a = id_vertical; i > 0 & a < 9; i--, a++)
        {
            GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + i + a);

            if (cell_hor_down.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                {
                    cell_hor_down.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_hor_down);
                }
                else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_hor_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_hor_down.GetComponent<cell_Script>().myPiece;

                                for (int b = id_horizontal, c = id_vertical; b > 0 & c < 9; b--, c++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_hor_down);

                                cell_hor_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_hor_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int b = id_horizontal, c = id_vertical; b > 0 & c < 9; b--, c++)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_hor_down);

                                cell_hor_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }
        }
        //проверка вниз вправо
        for (int i = id_horizontal, a = id_vertical; i < 9 & a > 0; i++, a--)
        {
            GameObject cell_vertical_up = GameObject.FindGameObjectWithTag("" + i + a);

            if (cell_vertical_up.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                {
                    cell_vertical_up.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_up);
                }
                else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_vertical_up.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_vertical_up.GetComponent<cell_Script>().myPiece;

                                for (int b = id_horizontal, c = id_vertical; b < 9 & c > 0; b++, c--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_up);

                                cell_vertical_up.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_vertical_up.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int b = id_horizontal, c = id_vertical; b < 9 & c > 0; b++, c--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_up);

                                cell_vertical_up.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }
        }
        //проверка вниз влево
        for (int i = id_horizontal, a = id_vertical; i > 0 & a > 0; i--, a--)
        {
            GameObject cell_vertical_down = GameObject.FindGameObjectWithTag("" + i + a);

            if (cell_vertical_down.transform.position == myCell.transform.position)
            {

            }
            else
            {
                if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                {
                    cell_vertical_down.GetComponent<cell_Script>().ChangeCollor(2);
                    gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_down);
                }
                else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                {
                    if (white)
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            if (cell_vertical_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                king = cell_vertical_down.GetComponent<cell_Script>().myPiece;

                                for (int b = id_horizontal, c = id_vertical; b > 0 & c > 0; b--, c--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_down);

                                cell_vertical_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    else if (black)
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().MyPieceWhite)
                        {
                            if (cell_vertical_down.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                for (int b = id_horizontal, c = id_vertical; b > 0 & c > 0; b--, c--)
                                {
                                    GameObject cell_hor_up_check = GameObject.FindGameObjectWithTag("" + b + c);

                                    gameController.GetComponent<gameController>().chekLine.Add(cell_hor_up_check);
                                }
                            }
                            else
                            {
                                gameController.GetComponent<gameController>().CellsList.Add(cell_vertical_down);

                                cell_vertical_down.GetComponent<cell_Script>().ChangeCollor(3);

                            }
                        }
                    }
                    break;
                }
            }
        }



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

}
