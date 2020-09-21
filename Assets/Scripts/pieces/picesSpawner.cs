using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picesSpawner : MonoBehaviour
{
   // public GameObject pawn;

    public GameObject pawnPref, knightPref, rookPref, bishopPref, kingPref, queenPref;
    GameObject cellSpawn;
    public GameObject[] cells;
    Vector3 cellPosition = new Vector3();
    Vector3 cellLocalPosition = new Vector3();
    int id_vertical, id_horizontal;
    GameObject gameController;


    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("gameController");
        cells = GameObject.FindGameObjectsWithTag("Cell");
        spawnALL();
    }



    public void spawnALL()
    {

        for (int v = 1; v < 9; v++)
        {
            //вертикальное заполнение матрицы

            for (int h = 1; h < 9; h++)
            {
                //горизонтальное заполнение матрицы

                //спавн пешек
                if (v == 2 || v == 7)
                {
                    GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                    cell.GetComponent<cell_Script>().onMe = true;

                    cellPosition = cell.transform.position;
                    GameObject tmpPawn = Instantiate(pawnPref);
                    tmpPawn.GetComponent<pawnScript>().myCell = cell;
                    cell.GetComponent<cell_Script>().myPiece = tmpPawn;
                    tmpPawn.transform.SetParent(this.transform, false);
                    tmpPawn.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z -1);
                    tmpPawn.GetComponent<pawnScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                    tmpPawn.GetComponent<pawnScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                    if(v == 2)
                    {
                        gameController.GetComponent<gameController>().whitePices.Add(tmpPawn);
                        tmpPawn.GetComponent<pawnScript>().white = true;
                        cell.GetComponent<cell_Script>().MyPieceWhite = true;
                    }
                    if (v == 7)
                    {
                        gameController.GetComponent<gameController>().blackPieces.Add(tmpPawn);

                        tmpPawn.GetComponent<pawnScript>().black = true;
                        cell.GetComponent<cell_Script>().MyPieceBlack = true;
                    }

                }
                //белые
                if (v == 1)
                {
                    //спавн тур
                    if (h == 1 || h == 8)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;

                        cell.GetComponent<cell_Script>().MyPieceWhite = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpRook = Instantiate(rookPref);
                        gameController.GetComponent<gameController>().whitePices.Add(tmpRook);

                        tmpRook.GetComponent<rookScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpRook;
                        tmpRook.transform.SetParent(this.transform, false);
                        tmpRook.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpRook.GetComponent<rookScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpRook.GetComponent<rookScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpRook.GetComponent<rookScript>().white = true;
                    }

                    //спавн коней
                    if (h == 2 || h == 7)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceWhite = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpKnight = Instantiate(knightPref);
                        gameController.GetComponent<gameController>().whitePices.Add(tmpKnight);

                        tmpKnight.GetComponent<knightScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpKnight;
                        tmpKnight.transform.SetParent(this.transform, false);
                        tmpKnight.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpKnight.GetComponent<knightScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpKnight.GetComponent<knightScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpKnight.GetComponent<knightScript>().white = true;
                    }

                    //спавн офицеров
                    if (h == 3 || h == 6)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceWhite = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpBishop = Instantiate(bishopPref);
                        gameController.GetComponent<gameController>().whitePices.Add(tmpBishop);

                        tmpBishop.GetComponent<bishopScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpBishop;
                        tmpBishop.transform.SetParent(this.transform, false);
                        tmpBishop.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpBishop.GetComponent<bishopScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpBishop.GetComponent<bishopScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpBishop.GetComponent<bishopScript>().white = true;
                    }

                    //спавн ферзя
                    if (h == 4)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceWhite = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpQueen = Instantiate(queenPref);
                        gameController.GetComponent<gameController>().whitePices.Add(tmpQueen);

                        tmpQueen.GetComponent<queenScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpQueen;
                        tmpQueen.transform.SetParent(this.transform, false);
                        tmpQueen.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpQueen.GetComponent<queenScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpQueen.GetComponent<queenScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpQueen.GetComponent<queenScript>().white = true;
                    }

                    //спавн короля
                    if (h == 5)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceWhite = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpKing = Instantiate(kingPref);
                        tmpKing.GetComponent<kingScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpKing;
                        gameController.GetComponent<gameController>().whitePices.Add(tmpKing);

                        tmpKing.transform.SetParent(this.transform, false);
                        tmpKing.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpKing.GetComponent<kingScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpKing.GetComponent<kingScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpKing.GetComponent<kingScript>().white = true;
                    }
                    

                }
                //черные
                if (v == 8)
                {
                    //спавн тур
                    if (h == 1 || h == 8)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceBlack = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpRook = Instantiate(rookPref);
                        gameController.GetComponent<gameController>().blackPieces.Add(tmpRook);

                        tmpRook.GetComponent<rookScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpRook;
                        tmpRook.transform.SetParent(this.transform, false);
                        tmpRook.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpRook.GetComponent<rookScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpRook.GetComponent<rookScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpRook.GetComponent<rookScript>().black = true;
                    }

                    //спавн коней
                    if (h == 2 || h == 7)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceBlack = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpKnight = Instantiate(knightPref);
                        gameController.GetComponent<gameController>().blackPieces.Add(tmpKnight);

                        tmpKnight.GetComponent<knightScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpKnight;
                        tmpKnight.transform.SetParent(this.transform, false);
                        tmpKnight.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpKnight.GetComponent<knightScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpKnight.GetComponent<knightScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpKnight.GetComponent<knightScript>().black = true;
                    }

                    //спавн офицеров
                    if (h == 3 || h == 6)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceBlack = true;


                        cellPosition = cell.transform.position;
                        GameObject tmpBishop = Instantiate(bishopPref);
                        gameController.GetComponent<gameController>().blackPieces.Add(tmpBishop);

                        tmpBishop.GetComponent<bishopScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpBishop;
                        tmpBishop.transform.SetParent(this.transform, false);
                        tmpBishop.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpBishop.GetComponent<bishopScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpBishop.GetComponent<bishopScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpBishop.GetComponent<bishopScript>().black = true;
                    }

                    //спавн ферзя
                    if (h == 4)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceBlack = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpQueen = Instantiate(queenPref);
                        gameController.GetComponent<gameController>().blackPieces.Add(tmpQueen);

                        tmpQueen.GetComponent<queenScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpQueen;
                        tmpQueen.transform.SetParent(this.transform, false);
                        tmpQueen.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpQueen.GetComponent<queenScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpQueen.GetComponent<queenScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpQueen.GetComponent<queenScript>().black = true;
                    }

                    //спавн короля
                    if (h == 5)
                    {
                        GameObject cell = GameObject.FindGameObjectWithTag("" + h + v);
                        cell.GetComponent<cell_Script>().onMe = true;
                        cell.GetComponent<cell_Script>().MyPieceBlack = true;

                        cellPosition = cell.transform.position;
                        GameObject tmpKing = Instantiate(kingPref);
                        gameController.GetComponent<gameController>().blackPieces.Add(tmpKing);

                        tmpKing.GetComponent<kingScript>().myCell = cell;
                        cell.GetComponent<cell_Script>().myPiece = tmpKing;
                        tmpKing.transform.SetParent(this.transform, false);
                        tmpKing.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 1);
                        tmpKing.GetComponent<kingScript>().id_vertical = cell.GetComponent<cell_Script>().id_vertical;
                        tmpKing.GetComponent<kingScript>().id_horizontal = cell.GetComponent<cell_Script>().id_horizontal;
                        tmpKing.GetComponent<kingScript>().black = true;
                    }


                }
            }
        }

        
    }

}
