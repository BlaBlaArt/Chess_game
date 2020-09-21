using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cell_Script : MonoBehaviour
{

    //int id_number;
    public Color white, black, active, toBattle, test;
    public bool setActive;

    public bool evalebleTo_move = true;

    bool a;
  
    public bool attack
    {
        set
        {
            a = value;
            if(a == true)
            {
                if(myPiece != null)
                {
                    myPiece.GetComponent<BoxCollider2D>().enabled = false;

                }
            }
            else if( a == false)
            {
                if (myPiece != null)
                {
                    myPiece.GetComponent<BoxCollider2D>().enabled = true;

                }
            }
        }

        get
        {
            return a;
        }
    }

    public GameObject gameController;
    public GameObject myPiece;
    public bool onMe;
    public int myColor;
    public bool MyPieceWhite, MyPieceBlack;

    public int id_vertical, id_horizontal;
    

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("gameController");

        if (id_horizontal == 1)
            this.transform.name = ("a" + id_vertical);
        if (id_horizontal == 2)
            this.transform.name = ("b" + id_vertical);
        if (id_horizontal == 3)
            this.transform.name = ("c" + id_vertical);
        if (id_horizontal == 4)
            this.transform.name = ("d" + id_vertical);
        if (id_horizontal == 5)
            this.transform.name = ("e" + id_vertical);
        if (id_horizontal == 6)
            this.transform.name = ("f" + id_vertical);
        if (id_horizontal == 7)
            this.transform.name = ("g" + id_vertical);
        if (id_horizontal == 8)
            this.transform.name = ("h" + id_vertical);
    }



    public void ChangeCollor(int coll)
    {
        if(coll == 1)
        {
            myColor = 1;
            GetComponent<Image>().color = white;
            setActive = false;
            attack = false;
            //    Debug.Log("white");
        }

        if(coll == 0)
        {
            myColor = 0;
            GetComponent<Image>().color = black;
            setActive = false;
            attack = false;
            //  Debug.Log("black");
        }

        if(coll == 2)
        {
            if (evalebleTo_move)
            {
                GetComponent<Image>().color = active;
                setActive = true;
                attack = false;
            }

        }

        if(coll == 3)
        {
            if (evalebleTo_move)
            {
                GetComponent<Image>().color = active;
                setActive = true;
                attack = false;
            }
        }

        if (coll == 4)
        {
            GetComponent<Image>().color = test;
            setActive = false;
        }
    }

    private void OnMouseDown()
    {
        if(setActive)
        {
            

            if (attack)
            {
                gameController.GetComponent<gameController>().allPieces.Add(myPiece);
                Destroy(myPiece);
               // gameController.GetComponent<gameController>().sortDeathPieces();
            }

            if (id_vertical < 9)
            {

                GameObject PIECE = gameController.GetComponent<gameController>().Piece;
                PIECE.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                myPiece = PIECE;
                gameController.GetComponent<gameController>().turn = !gameController.GetComponent<gameController>().turn; 
                
                onMe = true;
                gameController.GetComponent<gameController>().Cell.GetComponent<cell_Script>().onMe = false;
                gameController.GetComponent<gameController>().Cell.GetComponent<cell_Script>().myPiece = null;
                gameController.GetComponent<gameController>().Cell.GetComponent<cell_Script>().MyPieceBlack = false;
                gameController.GetComponent<gameController>().Cell.GetComponent<cell_Script>().MyPieceWhite = false;
                gameController.GetComponent<gameController>().dis();

                if (PIECE.CompareTag("Pawn"))
                {
                    PIECE.GetComponent<pawnScript>().myCell = this.gameObject;

                    if (PIECE.GetComponent<pawnScript>().white)
                    {
                        MyPieceWhite = true;
                        MyPieceBlack = false;
                    }
                    else if (PIECE.GetComponent<pawnScript>().black)
                    {
                        MyPieceWhite = false;
                        MyPieceBlack = true;
                    }

                    PIECE.GetComponent<pawnScript>().id_horizontal = id_horizontal;
                    PIECE.GetComponent<pawnScript>().id_vertical = id_vertical;
                }

                if (PIECE.CompareTag("Rook"))
                {
                    PIECE.GetComponent<rookScript>().myCell = this.gameObject;

                    if (PIECE.GetComponent<rookScript>().white)
                    {
                        MyPieceWhite = true;
                        MyPieceBlack = false;
                    }
                    else if (PIECE.GetComponent<rookScript>().black)
                    {
                        MyPieceWhite = false;
                        MyPieceBlack = true;
                    }

                    PIECE.GetComponent<rookScript>().id_horizontal = id_horizontal;
                    PIECE.GetComponent<rookScript>().id_vertical = id_vertical;
                }

                if (PIECE.CompareTag("Knight"))
                {
                    PIECE.GetComponent<knightScript>().myCell = this.gameObject;

                    if (PIECE.GetComponent<knightScript>().white)
                    {
                        MyPieceWhite = true;
                        MyPieceBlack = false;
                    }
                    else if (PIECE.GetComponent<knightScript>().black)
                    {
                        MyPieceWhite = false;
                        MyPieceBlack = true;
                    }

                    PIECE.GetComponent<knightScript>().id_horizontal = id_horizontal;
                    PIECE.GetComponent<knightScript>().id_vertical = id_vertical;
                }

                if (PIECE.CompareTag("Bishop"))
                {
                    PIECE.GetComponent<bishopScript>().myCell = this.gameObject;

                    if (PIECE.GetComponent<bishopScript>().white)
                    {
                        MyPieceWhite = true;
                        MyPieceBlack = false;
                    }
                    else if (PIECE.GetComponent<bishopScript>().black)
                    {
                        MyPieceWhite = false;
                        MyPieceBlack = true;
                    }

                    PIECE.GetComponent<bishopScript>().id_horizontal = id_horizontal;
                    PIECE.GetComponent<bishopScript>().id_vertical = id_vertical;
                }

                if (PIECE.CompareTag("Queen"))
                {
                    PIECE.GetComponent<queenScript>().myCell = this.gameObject;

                    if (PIECE.GetComponent<queenScript>().white)
                    {
                        MyPieceWhite = true;
                        MyPieceBlack = false;
                    }
                    else if (PIECE.GetComponent<queenScript>().black)
                    {
                        MyPieceWhite = false;
                        MyPieceBlack = true;
                    }

                    PIECE.GetComponent<queenScript>().id_horizontal = id_horizontal;
                    PIECE.GetComponent<queenScript>().id_vertical = id_vertical;
                }

                if (PIECE.CompareTag("King"))
                {
                    PIECE.GetComponent<kingScript>().myCell = this.gameObject;

                    if (PIECE.GetComponent<kingScript>().white)
                    {
                        MyPieceWhite = true;
                        MyPieceBlack = false;
                    }
                    else if (PIECE.GetComponent<kingScript>().black)
                    {
                        MyPieceWhite = false;
                        MyPieceBlack = true;
                    }

                    PIECE.GetComponent<kingScript>().id_horizontal = id_horizontal;
                    PIECE.GetComponent<kingScript>().id_vertical = id_vertical;
                }

             
            }
            else if(id_vertical == 8)
            {

            }

       

            if (gameController.GetComponent<gameController>().turn)
            {
                gameController.GetComponent<gameController>().blackPiecesMove_CELL.Clear();
                gameController.GetComponent<gameController>().whitePicesMowe_CELL.Clear();

                gameController.GetComponent<gameController>().Cell_toMove();
                gameController.GetComponent<gameController>().check = false;



                foreach (GameObject cel in gameController.GetComponent<gameController>().whitePicesMowe_CELL)
                {
                    // cel.GetComponent<cell_Script>().ChangeCollor(4);
                    if (cel != null)
                    {
                        if (cel.GetComponent<cell_Script>().onMe)
                        {
                            if (cel.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                gameController.GetComponent<gameController>().check = true;
                            }

                        }

                    }

                }
                
                foreach (GameObject cel in gameController.GetComponent<gameController>().blackPiecesMove_CELL)
                {
                    // cel.GetComponent<cell_Script>().ChangeCollor(4);
                    if (cel != null)
                    {
                        if (cel.GetComponent<cell_Script>().onMe)
                        {
                            if (cel.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                gameController.GetComponent<gameController>().check = true;
                            }
                 
                        }

                    }
                }
                
            }
            if (!gameController.GetComponent<gameController>().turn)
            {
                gameController.GetComponent<gameController>().blackPiecesMove_CELL.Clear();
                gameController.GetComponent<gameController>().whitePicesMowe_CELL.Clear();

                gameController.GetComponent<gameController>().Cell_toMove();
                gameController.GetComponent<gameController>().check = false;


                foreach (GameObject cel in gameController.GetComponent<gameController>().whitePicesMowe_CELL)
                {
                    // cel.GetComponent<cell_Script>().ChangeCollor(4);
                    if (cel != null)
                    {
                        if (cel.GetComponent<cell_Script>().onMe)
                        {
                            if (cel.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                gameController.GetComponent<gameController>().check = true;
                            }
                        }

                    }
                }
                
                foreach (GameObject cel in gameController.GetComponent<gameController>().blackPiecesMove_CELL)
                {
                    //  cel.GetComponent<cell_Script>().ChangeCollor(4);
                    if (cel != null)
                    {
                        if (cel.GetComponent<cell_Script>().onMe)
                        {
                            if (cel.GetComponent<cell_Script>().myPiece.CompareTag("King"))
                            {
                                gameController.GetComponent<gameController>().check = true;
                            }
                        }

                    }
                }
                
            }

        }
    }



}
