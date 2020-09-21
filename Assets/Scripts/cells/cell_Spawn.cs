using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell_Spawn : MonoBehaviour
{
    int cellCount = 64;
    public GameObject cellPref, pawn, knight, bishop, rook, queen, king;
    public Transform parrentPieces;
    GameObject[] Cells;
    public int[] cells_in;

    // Start is called before the first frame update
    void Awake()
    {
        CreateCell();
      
    }
    // Update is called once per frame
    void Update()
    {
      /*  foreach(GameObject cell in Cells)
        {
          //  int cellNumber = cell.GetComponent<cell_Script>().id;
           /* if (cellNumber > 9)
            {

                if (cellNumber % 2 == 1)
                {
                    cell.GetComponent<cell_Script>().ChangeCollor(1);
                }
                if (cellNumber % 2 == 0)
                {
                    cell.GetComponent<cell_Script>().ChangeCollor(0);
                }

               
            }
            
        }*/
    }
        
    public void CreateCell()
    {
        for (int i = 1; i < 9; i++)
        {
            //вертикальное заполнение матрицы

            //GameObject tmpCell_1 = Instantiate(cellPref);
          //  tmpCell_1.GetComponent<cell_Script>().id_horizontal = i;
            //    RaycastHit hit;
            for (int a = 1; a < 9; a++)
            {
                //горизонтальное заполнение матрицы

                //int a = i + 1;
                GameObject tmpCell = Instantiate(cellPref);
                tmpCell.transform.SetParent(this.transform, false);
                int id_horizontal = tmpCell.GetComponent<cell_Script>().id_horizontal = a;
                int id_vertical =  tmpCell.GetComponent<cell_Script>().id_vertical = i;
                tmpCell.gameObject.tag = ("" +a +i);
                //tmpCell.gameObject.tag = ("" + id_horizontal + id_vertical);
             //   parrentPieces = tmpCell.transform;
                if (i%2 == 0)
                {
                    if(a%2 == 0)
                        tmpCell.GetComponent<cell_Script>().ChangeCollor(1);
                    if (a%2 == 1)
                        tmpCell.GetComponent<cell_Script>().ChangeCollor(0);
                }

                if (i%2 == 1)
                {
                    if (a % 2 == 0)
                        tmpCell.GetComponent<cell_Script>().ChangeCollor(0);
                    if (a % 2 == 1)
                        tmpCell.GetComponent<cell_Script>().ChangeCollor(1);
                }

             /*   if(i == 2)
                {
                    GameObject TmpPawn = Instantiate(pawn);
                   // Debug.Log("pawn Spawn");
                    TmpPawn.transform.SetParent(parrentPieces, false);
                    TmpPawn.transform.position = tmpCell.transform.position;
                }
                */
                //tmpCell.GetComponent<cell_Script>().id = i + 1;
                //   tmpCell.GetComponent<cell_Script>().ChangeCollor(0);


               // tmpCell.name = "id" + a;
            }

              
        }
    }
}
