using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
	public ChessUiEngine uiEngine;
	public Text cell;
	public Transform brightSquare;
	// Use this for initialization
	void Start () {
		uiEngine.SpawnAllChessPieces ();
	}

	void FixedUpdate () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
		int cellNumber = uiEngine.RaycastCell (ray);
		if (!IsValidCell(cellNumber)) {
			return;
		}
		cell.text = ChessUiEngine.GetCellString(cellNumber);
		PlaceBrightSquare (cellNumber);

        if (Input.GetMouseButtonDown(0))
        {

            // pieceWorldPoint = ChessUiEngine.ToWorldPoint(cellNumber);

            if (uiEngine.piecePosition[cellNumber] == null)
            {
                UnityEngine.Debug.Log("Null No game object on this cell");
            }
            else
            {
                UnityEngine.Debug.Log("Hit Game Object  " + uiEngine.piecePosition[cellNumber].ToString() + "  Cell Text " + cell.text + " World point (X,Y,Z)" + ChessUiEngine.ToWorldPoint(cellNumber).ToString());
            }
        }
        }

	void PlaceBrightSquare (int cellNumber)
	{
		brightSquare.position = ChessUiEngine.ToWorldPoint (cellNumber);
	}

	bool IsValidCell (int cellNumber)
	{
		return cellNumber >= 0 && cellNumber < 64;
	}
}
