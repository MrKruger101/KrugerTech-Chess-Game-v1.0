using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessUiEngine : MonoBehaviour
{
    //enum Piece {King=0, Queen=1, Rook=2, Knight=3, Bishop=4, Pawn=5};
    //private Piece[] setup = new Piece[] {Piece.Rook, Piece.Knight, Piece.Bishop, Piece.Queen, Piece.King, Piece.Bishop, Piece.Knight, Piece.Rook};
    public BoxCollider bounds;
    private const int totalCells = 64;
    public List<Transform> whitePiecePrefabs;
    public List<Transform> blackPiecePrefabs;


    private List<Transform> activeChessPieces = new List<Transform>();
    public AbstractPieceBase[,] whiteChessPieces { get; set; }
    public AbstractPieceBase[,] blackChessPieces { get; set; }
    public AbstractPieceBase[] piecePosition { get; set; }
    public int RaycastCell(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 point = hit.point + new Vector3(-16, 0, 16);
            int i = (int)-point.x / 4;
            int j = (int)point.z / 4;
            return i * 8 + j;
        }
        return -1;
    }

    public void SpawnAllChessPieces()
    {
        activeChessPieces = new List<Transform>();
        whiteChessPieces = new AbstractPieceBase[totalCells, 16];
        blackChessPieces = new AbstractPieceBase[totalCells, 16];
        piecePosition = new AbstractPieceBase[totalCells];

        for (int i = 0; i < 8; i++)
        {
            WhiteChessPieces(i, i);
            BlackChessPieces(i + 56, i);
        }

        for (int i = 8; i < 16; i++)
        {
            WhiteChessPieces(i, 8);//Pawn
            BlackChessPieces(i + 40, 8);//Pawn
        }

    }
    public void WhiteChessPieces(int cellNumber, int index)
    {
        Transform whitePiece = GameObject.Instantiate(whitePiecePrefabs[index]);
        Vector3 worldPoint = ToWorldPoint(cellNumber);
        whitePiece.position = new Vector3(worldPoint.x, whitePiece.position.y, worldPoint.z);
        whiteChessPieces[cellNumber, index] = whitePiece.GetComponent<AbstractPieceBase>();
        whiteChessPieces[cellNumber, index].SetPosition(cellNumber, index);

        piecePosition[cellNumber] = whitePiece.GetComponent<AbstractPieceBase>();
        piecePosition[cellNumber].ToString();
        activeChessPieces.Add(whitePiece);
    }

    public void BlackChessPieces(int cellNumber, int index)
    {
        Transform blackPiece = GameObject.Instantiate(blackPiecePrefabs[index]);
        Vector3 worldPoint = ToWorldPoint(cellNumber);
        blackPiece.position = new Vector3(worldPoint.x, blackPiece.position.y, worldPoint.z);
        whiteChessPieces[cellNumber, index] = blackPiece.GetComponent<AbstractPieceBase>();
        whiteChessPieces[cellNumber, index].SetPosition(cellNumber, index);

        piecePosition[cellNumber] = blackPiece.GetComponent<AbstractPieceBase>();
        piecePosition[cellNumber].ToString();
        activeChessPieces.Add(blackPiece);
    }

    public static string GetCellString(int cellNumber)
    {
        int j = cellNumber % 8;
        int i = cellNumber / 8;
        return char.ConvertFromUtf32(j + 65) + "" + (i + 1);
    }

    public static Vector3 ToWorldPoint(int cellNumber)
    {
        int x = cellNumber % 8;
        int y = cellNumber / 8;
        return new Vector3(y * -4 + 14, 1, x * 4 - 14);
    }
}
