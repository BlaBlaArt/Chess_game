using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameController : MonoBehaviour //, IPointerClickHandler
{

    public GameObject Piece, Cell, lastCellPiece, nextCellPiece;
    public List<GameObject> CellsList = new List<GameObject>();
    public GameObject[] MayTurnIn;
    public string pieceTag;
    public string pieceScriptName;
    public delegate void DISactive();
    public DISactive dis;
    List<GameObject> elementList;
    public List<GameObject> whitePicesRemowe, blackPiecesRemove;
    public List<GameObject> MovingCell_check;
    public List<GameObject> whitePicesMowe_CELL, blackPiecesMove_CELL;
    public List<GameObject> whitePices, blackPieces;
    public List<GameObject> allPieces;
    public int turnCount = 0;
    public bool turn = true;
    public bool check = false;
    public List<GameObject> chekLine = new List<GameObject>();

    public void sortDeathPieces()
    {
        foreach (GameObject obj in allPieces)
        {
            if (obj.CompareTag("Pawn"))
            {
                if (obj.GetComponent<pawnScript>().white)
                {
                    whitePicesRemowe.Add(obj);
                }
                else if (obj.GetComponent<pawnScript>().black)
                {
                    blackPiecesRemove.Add(obj);
                }
            }

            if (obj.CompareTag("Rook"))
            {
                if (obj.GetComponent<rookScript>().white)
                {
                    whitePicesRemowe.Add(obj);
                }
                else if (obj.GetComponent<rookScript>().black)
                {
                    blackPiecesRemove.Add(obj);
                }
            }

            if (obj.CompareTag("Knight"))
            {
                if (obj.GetComponent<knightScript>().white)
                {
                    whitePicesRemowe.Add(obj);
                }
                else if (obj.GetComponent<knightScript>().black)
                {
                    blackPiecesRemove.Add(obj);
                }
            }

            if (obj.CompareTag("Bishop"))
            {
                if (obj.GetComponent<bishopScript>().white)
                {
                    whitePicesRemowe.Add(obj);
                }
                else if (obj.GetComponent<bishopScript>().black)
                {
                    blackPiecesRemove.Add(obj);
                }
            }

            if (obj.CompareTag("Queen"))
            {
                if (obj.GetComponent<queenScript>().white)
                {
                    whitePicesRemowe.Add(obj);
                }
                else if (obj.GetComponent<queenScript>().black)
                {
                    blackPiecesRemove.Add(obj);
                }
            }

            if (obj.CompareTag("King"))
            {
                if (obj.GetComponent<kingScript>().white)
                {
                    whitePicesRemowe.Add(obj);
                }
                else if (obj.GetComponent<kingScript>().black)
                {
                    blackPiecesRemove.Add(obj);
                }
            }
        }
    }

    private void Update()
    {
        if (turn)
        {
            foreach (GameObject black in blackPieces)
            {
                if (black != null)
                {
                    black.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            foreach (GameObject white in whitePices)
            {
                if (white != null)
                {
                    white.GetComponent<BoxCollider2D>().enabled = true;
                }

            }


        }
        else if (!turn)
        {
            foreach (GameObject white in whitePices)
            {
                if (white != null)
                {
                    white.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            foreach (GameObject black in blackPieces)
            {
                if (black != null)
                {
                    black.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }

        if (check)
        {
            CheckMate();
        }
    }


    public void Cell_toMove()
    {
        foreach (GameObject white in whitePices)
        {
            if (white.CompareTag("Pawn"))
            {
                int id_vertical = white.GetComponent<pawnScript>().id_vertical;
                int id_horizontal = white.GetComponent<pawnScript>().id_horizontal;

                if (id_vertical == 2)
                {
                    for (int v = 3; v < 5; v++)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + v);

                        if (cell.GetComponent<cell_Script>().onMe == false)
                        {
                            whitePicesMowe_CELL.Add(cell);
                        }
                    }

                }
                else if (white.GetComponent<pawnScript>().white)
                {
                    if (id_horizontal + 1 < 9 && id_vertical + 1 < 9)
                    {
                        GameObject celll = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1));
                        if (celll.GetComponent<cell_Script>().onMe && celll.GetComponent<cell_Script>().MyPieceBlack)
                        {

                            // GameObject piec = celll.GetComponent<cell_Script>().myPiece;

                            whitePicesMowe_CELL.Add(celll);
                                //check = false;
                            

                        }
                    }

                    if (id_horizontal - 1 > 0 && id_vertical + 1 < 9)
                    {
                        GameObject cellll = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1));
                        if (cellll.GetComponent<cell_Script>().onMe && cellll.GetComponent<cell_Script>().MyPieceBlack)
                        {
                            // GameObject piec = celll.GetComponent<cell_Script>().myPiece;

                            whitePicesMowe_CELL.Add(cellll);
                                //check = false;
                            
                        }
                    }



                    GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1));
                    if (cell.GetComponent<cell_Script>().onMe == false)
                    {
                        whitePicesMowe_CELL.Add(cell);
                    }
                }
            }
            
            if (white.CompareTag("Rook"))
            {
                int id_vertical = white.GetComponent<rookScript>().id_vertical;
                int id_horizontal = white.GetComponent<rookScript>().id_horizontal;

                //проверка по горизонтали вправо
                for (int i = id_horizontal; i < 9; i++)
                {
                    GameObject cell_hor_up = GameObject.FindGameObjectWithTag("" + i + id_vertical);
                    GameObject myCell = white.GetComponent<rookScript>().myCell;

                    if (cell_hor_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_hor_up);
                            }
                            else if (white.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_up);
                            }
                        }
                        else if (cell_hor_up.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                if (cell_hor_up.GetComponent<cell_Script>().MyPieceBlack)
                                {
     

                                    whitePicesMowe_CELL.Add(cell_hor_up);
                                        //check = false;
                                    
                                }


                            }

                            break;
                        }
                    }
                }
                //влево
                for (int j = id_horizontal; j > 0; j--)
                {
                    GameObject myCell = white.GetComponent<rookScript>().myCell;
                    GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + j + id_vertical);

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_hor_down);

                            }
                            else if (white.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                if (cell_hor_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
                                }


                            }

                            break;
                        }
                    }
                }
                //проверка по вертикали вверх
                for (int u = id_vertical; u < 9; u++)
                {
                    GameObject myCell = white.GetComponent<rookScript>().myCell;
                    GameObject cell_vertical_up = GameObject.FindGameObjectWithTag("" + id_horizontal + u);

                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_up);

                            }
                            else if (white.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                                {
                                    
                                    whitePicesMowe_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    
                                }


                            }


                            break;
                        }
                    }
                }
                //вниз
                for (int d = id_vertical; d > 0; d--)
                {
                    GameObject myCell = white.GetComponent<rookScript>().myCell;
                    GameObject cell_vertical_down = GameObject.FindGameObjectWithTag("" + id_horizontal + d);

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_down);

                            }
                            else if (white.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }

                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<rookScript>().white)
                            {
                                if (cell_vertical_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    
                                }


                            }



                            break;
                        }
                    }
                }
            }
            
            if (white.CompareTag("Bishop"))
            {
                int id_vertical = white.GetComponent<bishopScript>().id_vertical;
                int id_horizontal = white.GetComponent<bishopScript>().id_horizontal;

                //проверка вверx и вправо
                for (int i = id_horizontal, a = id_vertical; i < 9 & a < 9; i++, a++)
                {

                    GameObject myCell = white.GetComponent<bishopScript>().myCell;

                    GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + i + a);

                    if (cell_up_right.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_up_right.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_up_right);

                            }

                        }
                        else if (cell_up_right.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                if (cell_up_right.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_up_right);
                                        //check = false;
                                    
                                }


                            }
                            else
                             break;

                        }

                    }

                }
                //проверка вверх и влево
                for (int i = id_horizontal, a = id_vertical; i > 0 & a < 9; i--, a++)
                {
                    GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + i + a);
                    GameObject myCell = white.GetComponent<bishopScript>().myCell;

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_hor_down);

                            }
                            else if (white.GetComponent<bishopScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                if (cell_hor_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    
                                    whitePicesMowe_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
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
                    GameObject myCell = white.GetComponent<bishopScript>().myCell;


                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                                    whitePicesMowe_CELL.Add(cell_vertical_up);

                            }
                            else if (white.GetComponent<bishopScript>().black)
                            {
                                if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                                    blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    
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
                    GameObject myCell = white.GetComponent<bishopScript>().myCell;

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_down);

                            }
                            else if (white.GetComponent<bishopScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }
                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<bishopScript>().white)
                            {
                                if (cell_vertical_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    
                                }

                           
                            }

                            break;
                        }
                    }
                }
            }
           
            if (white.CompareTag("Knight"))
            {
                int id_vertical = white.GetComponent<knightScript>().id_vertical;
                int id_horizontal = white.GetComponent<knightScript>().id_horizontal;

                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + id_vertical);
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

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical - 2) > 0 && (id_vertical - 2) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 2)) != null)
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

                foreach (GameObject cel in cellss)
                {
                    if (cel == null)
                    {
                    }
                    else if (cel.GetComponent<cell_Script>().onMe == true)
                    {
                        if (white.GetComponent<knightScript>().white)
                        {
                            if (cel.GetComponent<cell_Script>().MyPieceBlack)
                            {


                                    //check = false;
                                whitePicesMowe_CELL.Add(cel);
                                
                            }


                        }
                    }
                    else
                    {
                        whitePicesMowe_CELL.Add(cel);

                    }

                }

             
            }
  
            if (white.CompareTag("Queen"))
            {
                int id_vertical = white.GetComponent<queenScript>().id_vertical;
                int id_horizontal = white.GetComponent<queenScript>().id_horizontal;

                //проверка вверx и вправо
                for (int i = id_horizontal, a = id_vertical; i < 9 & a < 9; i++, a++)
                {

                    GameObject myCell = white.GetComponent<queenScript>().myCell;

                    GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + i + a);

                    if (cell_up_right.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_up_right.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_up_right);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_up_right);

                            }
                        }
                        else if (cell_up_right.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_up_right.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_up_right);


                                        //check = false;
                                    
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
                    GameObject myCell = white.GetComponent<queenScript>().myCell;

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_hor_down);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_hor_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
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
                    GameObject myCell = white.GetComponent<queenScript>().myCell;


                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_up);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    
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
                    GameObject myCell = white.GetComponent<queenScript>().myCell;

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_down);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }
                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_vertical_down.GetComponent<cell_Script>().MyPieceBlack)
                                {
                                    
                                    whitePicesMowe_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    
                                }
                            }

                            break;
                        }
                    }
                }
                //проверка по горизонтали вправо
                for (int i = id_horizontal; i < 9; i++)
                {
                    GameObject cell_hor_up = GameObject.FindGameObjectWithTag("" + i + id_vertical);
                    GameObject myCell = white.GetComponent<queenScript>().myCell;

                    if (cell_hor_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_hor_up);
                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_up);
                            }
                        }
                        else if (cell_hor_up.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_hor_up.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_hor_up);
                                        //check = false;
                                    
                                }
                            }


                            break;
                        }
                    }
                }
                //влево
                for (int j = id_horizontal; j > 0; j--)
                {
                    GameObject myCell = white.GetComponent<queenScript>().myCell;
                    GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + j + id_vertical);

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_hor_down);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_hor_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_hor_down);
                                        //check = false;
                                    

                                }
                            }

                            break;
                        }
                    }
                }
                //проверка по вертикали вверх
                for (int u = id_vertical; u < 9; u++)
                {
                    GameObject myCell = white.GetComponent<queenScript>().myCell;
                    GameObject cell_vertical_up = GameObject.FindGameObjectWithTag("" + id_horizontal + u);

                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_up);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_vertical_up.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    

                                }
                            }

                            break;
                        }
                    }
                }
                //вниз
                for (int d = id_vertical; d > 0; d--)
                {
                    GameObject myCell = white.GetComponent<queenScript>().myCell;
                    GameObject cell_vertical_down = GameObject.FindGameObjectWithTag("" + id_horizontal + d);

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                whitePicesMowe_CELL.Add(cell_vertical_down);

                            }
                            else if (white.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }

                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {
                            if (white.GetComponent<queenScript>().white)
                            {
                                if (cell_vertical_down.GetComponent<cell_Script>().MyPieceBlack)
                                {

                                    whitePicesMowe_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    
                                }
                            }


                            break;
                        }
                    }
                }
            }
           
            if (white.CompareTag("King"))
            {
                int id_vertical = white.GetComponent<kingScript>().id_vertical;
                int id_horizontal = white.GetComponent<kingScript>().id_horizontal;

                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + id_vertical);
                List<GameObject> cellss = new List<GameObject>();

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1)) != null)
                {
                    GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1));
                    cellss.Add(cell_up_right);
                }

                if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && (id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 1)) != null)
                {
                    GameObject cell_down_left;
                    cellss.Add(cell_down_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 1)));
                }

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 1)) != null)
                {
                    GameObject cell_down_right;
                    cellss.Add(cell_down_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 1)));

                }

                if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && (id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1)) != null)
                {
                    GameObject cell_up_left;
                    cellss.Add(cell_up_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1)));
                }

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + id_vertical) != null)
                {
                    GameObject cell_right;
                    cellss.Add(cell_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + id_vertical));
                }

                if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + id_vertical) != null)
                {
                    GameObject cell_left;
                    cellss.Add(cell_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + id_vertical));

                }

                if ((id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1)) != null)
                {
                    GameObject cell_up;
                    cellss.Add(cell_up = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1)));
                }

                if ((id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1)) != null)
                {
                    GameObject cell_down;
                    cellss.Add(cell_down = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1)));
                }

                foreach (GameObject cel in cellss)
                {
                    if (cel == null)
                    {
                    }
                    else if (cel.GetComponent<cell_Script>().onMe == true)
                    {
                        if (white.GetComponent<kingScript>().white)
                        {
                            if (cel.GetComponent<cell_Script>().MyPieceBlack)
                            {
                                whitePicesMowe_CELL.Add(cel);

                            }
                        }
                    }
                    else
                    {
                        whitePicesMowe_CELL.Add(cel);

                    }
                }
            }

        }

        foreach (GameObject black in blackPieces)
        {
            if (black.CompareTag("Pawn"))
            {
                int id_vertical = black.GetComponent<pawnScript>().id_vertical;
                int id_horizontal = black.GetComponent<pawnScript>().id_horizontal;

                if (id_vertical == 7)
                {
                    for (int v = 6; v > 4; v--)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + v);
                        if (cell.GetComponent<cell_Script>().onMe == false)
                        {
                            blackPiecesMove_CELL.Add(cell);
                        }
                    }
                }
                else if (black.GetComponent<pawnScript>().black)
                {
                    if (id_horizontal + 1 < 9 && id_vertical - 1 > 0)
                    {
                        GameObject celll = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 1));
                        if (celll.GetComponent<cell_Script>().onMe && celll.GetComponent<cell_Script>().MyPieceWhite)
                        {


                            blackPiecesMove_CELL.Add(celll);
                                //check = false;
                            
                            // GameObject piec = celll.GetComponent<cell_Script>().myPiece;

                        }
                    }

                    if (id_horizontal - 1 > 0 && id_vertical - 1 > 0)
                    {
                        GameObject cellll = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 1));
                        if (cellll.GetComponent<cell_Script>().onMe && cellll.GetComponent<cell_Script>().MyPieceWhite)
                        {

                            blackPiecesMove_CELL.Add(cellll);
                                //check = false;
                            
                            // GameObject piec = celll.GetComponent<cell_Script>().myPiece;

                        }
                    }



                    GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1));
                    if (cell.GetComponent<cell_Script>().onMe == false)
                    {
                        blackPiecesMove_CELL.Add(cell);
                    }
                }
            }

            if (black.CompareTag("Rook"))
            {
                int id_vertical = black.GetComponent<rookScript>().id_vertical;
                int id_horizontal = black.GetComponent<rookScript>().id_horizontal;

                //проверка по горизонтали вправо
                for (int i = id_horizontal; i < 9; i++)
                {
                    GameObject cell_hor_up = GameObject.FindGameObjectWithTag("" + i + id_vertical);
                    GameObject myCell = black.GetComponent<rookScript>().myCell;

                    if (cell_hor_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_up.GetComponent<cell_Script>().onMe == false)
                        {
                            if (black.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_up);
                            }

                        }
                        else if (cell_hor_up.GetComponent<cell_Script>().onMe == true)
                        {

                                if (black.GetComponent<rookScript>().black)
                                {
                                    if (cell_hor_up.GetComponent<cell_Script>().MyPieceWhite)
                                    {

                                        blackPiecesMove_CELL.Add(cell_hor_up);
                                        //check = false;
                                    
                                }
                                }

                            break;
                        }
                    }
                }
                //влево
                for (int j = id_horizontal; j > 0; j--)
                {
                    GameObject myCell = black.GetComponent<rookScript>().myCell;
                    GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + j + id_vertical);

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {
    
                            if (black.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {

                                if (black.GetComponent<rookScript>().black)
                                {
                                    if (cell_hor_down.GetComponent<cell_Script>().MyPieceWhite)
                                    {

                                        blackPiecesMove_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
                                }
                                }
                                
                            break;
                        }
                    }
                }
                //проверка по вертикали вверх
                for (int u = id_vertical; u < 9; u++)
                {
                    GameObject myCell = black.GetComponent<rookScript>().myCell;
                    GameObject cell_vertical_up = GameObject.FindGameObjectWithTag("" + id_horizontal + u);

                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {

                                if (black.GetComponent<rookScript>().black)
                                {
                                    if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                                    {

                                        blackPiecesMove_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    

                                }
                                }

                            break;
                        }
                    }
                }
                //вниз
                for (int d = id_vertical; d > 0; d--)
                {
                    GameObject myCell = black.GetComponent<rookScript>().myCell;
                    GameObject cell_vertical_down = GameObject.FindGameObjectWithTag("" + id_horizontal + d);

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<rookScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }

                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<rookScript>().black)
                              {
                                  if (cell_vertical_down.GetComponent<cell_Script>().MyPieceWhite)
                                  {
      
                                      blackPiecesMove_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    

                                }
                              }


                            break;
                        }
                    }
                }
            }

            if (black.CompareTag("Bishop"))
            {
                int id_vertical = black.GetComponent<bishopScript>().id_vertical;
                int id_horizontal = black.GetComponent<bishopScript>().id_horizontal;

                //проверка вверx и вправо
                for (int i = id_horizontal, a = id_vertical; i < 9 & a < 9; i++, a++)
                {

                    GameObject myCell = black.GetComponent<bishopScript>().myCell;

                    GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + i + a);

                    if (cell_up_right.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_up_right.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<bishopScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_up_right);

                            }
                        }
                        else if (cell_up_right.GetComponent<cell_Script>().onMe == true)
                        {


                                if (black.GetComponent<bishopScript>().black)
                                {
                                    if (cell_up_right.GetComponent<cell_Script>().MyPieceWhite)
                                    {

                                        blackPiecesMove_CELL.Add(cell_up_right);
                                        //check = false;
                                    
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
                    GameObject myCell = black.GetComponent<bishopScript>().myCell;

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {
                            if (black.GetComponent<bishopScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<bishopScript>().black)
                                   {
                                       if (cell_hor_down.GetComponent<cell_Script>().MyPieceWhite)
                                       {

                                           blackPiecesMove_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
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
                    GameObject myCell = black.GetComponent<bishopScript>().myCell;


                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<bishopScript>().black)
                            {
                          
                                blackPiecesMove_CELL.Add(cell_vertical_up);
                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {


                            if (black.GetComponent<bishopScript>().black)
                                {
                                    if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                                    {

                                        blackPiecesMove_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    
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
                    GameObject myCell = black.GetComponent<bishopScript>().myCell;

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<bishopScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }
                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<bishopScript>().black)
                               {
                                   if (cell_vertical_down.GetComponent<cell_Script>().MyPieceWhite)
                                   {

                                        //check = false;
                                       blackPiecesMove_CELL.Add(cell_vertical_down);
                                    
                                }
                               }
                            break;
                        }
                    }
                }
            }

            if (black.CompareTag("Knight"))
            {
                int id_vertical = black.GetComponent<knightScript>().id_vertical;
                int id_horizontal = black.GetComponent<knightScript>().id_horizontal;

                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + id_vertical);
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

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical - 2) > 0 && (id_vertical - 2) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 2)) != null)
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

                foreach (GameObject cel in cellss)
                {
                    if (cel == null)
                    {
                    }
                    else if (cel.GetComponent<cell_Script>().onMe == true)
                    {
                        if (black.GetComponent<knightScript>().black)
                        {
                            if (cel.GetComponent<cell_Script>().MyPieceWhite)
                            {

                                blackPiecesMove_CELL.Add(cel);
                                    //check = false;
                                

                            }
                        }
                    }
                    else
                    {
                        blackPiecesMove_CELL.Add(cel);

                    }

                }


            }

            if (black.CompareTag("Queen"))
            {
                int id_vertical = black.GetComponent<queenScript>().id_vertical;
                int id_horizontal = black.GetComponent<queenScript>().id_horizontal;

                //проверка вверx и вправо
                for (int i = id_horizontal, a = id_vertical; i < 9 & a < 9; i++, a++)
                {

                    GameObject myCell = black.GetComponent<queenScript>().myCell;

                    GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + i + a);

                    if (cell_up_right.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_up_right.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_up_right);

                            }
                        }
                        else if (cell_up_right.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                 {
                                     if (cell_up_right.GetComponent<cell_Script>().MyPieceWhite)
                                     {

                                         blackPiecesMove_CELL.Add(cell_up_right);
                                        //check = false;
                                    
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
                    GameObject myCell = black.GetComponent<queenScript>().myCell;

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                  {
                                      if (cell_hor_down.GetComponent<cell_Script>().MyPieceWhite)
                                      {
                                    
                                          blackPiecesMove_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
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
                    GameObject myCell = black.GetComponent<queenScript>().myCell;


                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                  {
                                      if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                                      {

                                          blackPiecesMove_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    
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
                    GameObject myCell = black.GetComponent<queenScript>().myCell;

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }
                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                 {
                                     if (cell_vertical_down.GetComponent<cell_Script>().MyPieceWhite)
                                     {

                                         blackPiecesMove_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    
                                }
                                 }
                            break;
                        }
                    }
                }
                //проверка по горизонтали вправо
                for (int i = id_horizontal; i < 9; i++)
                {
                    GameObject cell_hor_up = GameObject.FindGameObjectWithTag("" + i + id_vertical);
                    GameObject myCell = black.GetComponent<queenScript>().myCell;

                    if (cell_hor_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_up.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_up);
                            }
                        }
                        else if (cell_hor_up.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                 {
                                     if (cell_hor_up.GetComponent<cell_Script>().MyPieceWhite)
                                     {
            
                                         blackPiecesMove_CELL.Add(cell_hor_up);
                                        //check = false;
                                    
                                }
                                 }

                            break;
                        }
                    }
                }
                //влево
                for (int j = id_horizontal; j > 0; j--)
                {
                    GameObject myCell = black.GetComponent<queenScript>().myCell;
                    GameObject cell_hor_down = GameObject.FindGameObjectWithTag("" + j + id_vertical);

                    if (cell_hor_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_hor_down.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_hor_down);

                            }
                        }
                        else if (cell_hor_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                  {
                                      if (cell_hor_down.GetComponent<cell_Script>().MyPieceWhite)
                                      {

                                          blackPiecesMove_CELL.Add(cell_hor_down);
                                        //check = false;
                                    
                                }
                                  }
                                  
                            break;
                        }
                    }
                }
                //проверка по вертикали вверх
                for (int u = id_vertical; u < 9; u++)
                {
                    GameObject myCell = black.GetComponent<queenScript>().myCell;
                    GameObject cell_vertical_up = GameObject.FindGameObjectWithTag("" + id_horizontal + u);

                    if (cell_vertical_up.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_up.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_up);

                            }
                        }
                        else if (cell_vertical_up.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                 {
                                     if (cell_vertical_up.GetComponent<cell_Script>().MyPieceWhite)
                                     {

                                         blackPiecesMove_CELL.Add(cell_vertical_up);
                                        //check = false;
                                    

                                }
                                 }
                                 
                            break;
                        }
                    }
                }
                //вниз
                for (int d = id_vertical; d > 0; d--)
                {
                    GameObject myCell = black.GetComponent<queenScript>().myCell;
                    GameObject cell_vertical_down = GameObject.FindGameObjectWithTag("" + id_horizontal + d);

                    if (cell_vertical_down.transform.position == myCell.transform.position)
                    {

                    }
                    else
                    {
                        if (cell_vertical_down.GetComponent<cell_Script>().onMe == false)
                        {

                            if (black.GetComponent<queenScript>().black)
                            {
                                blackPiecesMove_CELL.Add(cell_vertical_down);

                            }

                        }
                        else if (cell_vertical_down.GetComponent<cell_Script>().onMe == true)
                        {

                            if (black.GetComponent<queenScript>().black)
                                {
                                    if (cell_vertical_down.GetComponent<cell_Script>().MyPieceWhite)
                                    {

                                        blackPiecesMove_CELL.Add(cell_vertical_down);
                                        //check = false;
                                    

                                }
                                }

                            break;
                        }
                    }
                }
            }

            if (black.CompareTag("King"))
            {
                int id_vertical = black.GetComponent<kingScript>().id_vertical;
                int id_horizontal = black.GetComponent<kingScript>().id_horizontal;

                GameObject cell = GameObject.FindGameObjectWithTag("" + id_horizontal + id_vertical);
                List<GameObject> cellss = new List<GameObject>();

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1)) != null)
                {
                    GameObject cell_up_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical + 1));
                    cellss.Add(cell_up_right);
                }

                if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && (id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 1)) != null)
                {
                    GameObject cell_down_left;
                    cellss.Add(cell_down_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical - 1)));
                }

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && (id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 1)) != null)
                {
                    GameObject cell_down_right;
                    cellss.Add(cell_down_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + (id_vertical - 1)));

                }

                if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && (id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1)) != null)
                {
                    GameObject cell_up_left;
                    cellss.Add(cell_up_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + (id_vertical + 1)));
                }

                if ((id_horizontal + 1) > 0 && (id_horizontal + 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + id_vertical) != null)
                {
                    GameObject cell_right;
                    cellss.Add(cell_right = GameObject.FindGameObjectWithTag("" + (id_horizontal + 1) + id_vertical));
                }

                if ((id_horizontal - 1) > 0 && (id_horizontal - 1) < 9 && GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + id_vertical) != null)
                {
                    GameObject cell_left;
                    cellss.Add(cell_left = GameObject.FindGameObjectWithTag("" + (id_horizontal - 1) + id_vertical));

                }

                if ((id_vertical + 1) > 0 && (id_vertical + 1) < 9 && GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1)) != null)
                {
                    GameObject cell_up;
                    cellss.Add(cell_up = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical + 1)));
                }

                if ((id_vertical - 1) > 0 && (id_vertical - 1) < 9 && GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1)) != null)
                {
                    GameObject cell_down;
                    cellss.Add(cell_down = GameObject.FindGameObjectWithTag("" + id_horizontal + (id_vertical - 1)));
                }

                foreach (GameObject cel in cellss)
                {
                    if (cel == null)
                    {
                    }
                    else if (cel.GetComponent<cell_Script>().onMe == true)
                    {
                        if (black.GetComponent<kingScript>().black)
                        {
                            if (cel.GetComponent<cell_Script>().MyPieceWhite)
                            {
                                blackPiecesMove_CELL.Add(cel);

                            }
                        }
                    }
                    else
                    {
                        blackPiecesMove_CELL.Add(cel);

                    }
                }
            }
        }
    }

    public void CheckMate()
    {
        if (!turn)
        {
            foreach (GameObject cel_white in whitePicesMowe_CELL)
            {
                foreach (GameObject cel_black in blackPiecesMove_CELL)
                {
                    if (cel_white.tag == cel_black.tag)
                    {
                        cel_white.GetComponent<cell_Script>().evalebleTo_move = true;
                        //  cel_white.GetComponent<cell_Script>().ChangeCollor(cel_white.GetComponent<cell_Script>().myColor);
                    }
                   /* else
                    {
                        cel_black.GetComponent<cell_Script>().evalebleTo_move = false;
                    }*/
                }
            }

           
        }
    }
}
