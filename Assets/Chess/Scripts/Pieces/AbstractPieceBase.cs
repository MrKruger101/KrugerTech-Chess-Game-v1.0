using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPieceBase : MonoBehaviour {

    public int cellNumber { get; set; }
    public int index { get; set; }
    public bool isWhite;

    public void SetPosition(int cellNumber)
    {

        this.cellNumber = cellNumber;
        
    }
    public void SetPosition(int cellNumber, int index)
    {

        this.cellNumber = cellNumber;
        this.index = index;
    }

    public virtual bool PossibleMove(int cellNumber, int index)
    {
        return true;
    }
}
