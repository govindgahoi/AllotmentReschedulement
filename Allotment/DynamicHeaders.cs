using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DynamicHeaders
{
    List<DynamicHeader> Headers;
    int HeaderRows;
    int HeaderCols;

    public DynamicHeaders(String Header)
    {
        Headers = new List<DynamicHeader>();
        String[] HeaderParts = Header.Split(',');
        foreach (String tmpHeaderPart in HeaderParts)
            Headers.Add(new DynamicHeader(tmpHeaderPart));

        HeaderCols = Headers.Count;
        HeaderRows = Headers.Max(H => H.HeaderDepth);
        ParseHeader();
    }

    public ArrayList ParseHeader()
    {
        //Creating an Array with the headings
        Array HeaderCells = Array.CreateInstance(typeof(DynamicHeaderCell), HeaderRows, HeaderCols);
        for (int i = 0; i < Headers.Count; i++)
        {
            DynamicHeader tmpDynamicHeader = Headers[i];
            for (int j = 0; j < tmpDynamicHeader.Headers.Length; j++)
            {
                String HeaderString = tmpDynamicHeader.Headers[j];
                HeaderCells.SetValue(new DynamicHeaderCell(HeaderString), j, i);
            }
        }

        //Marge the columns
        for (int i = 0; i < HeaderRows; i++)
        {
            for (int j = 0; j < HeaderCols; j++)
            {
                DynamicHeaderCell HeaderCell1 = (DynamicHeaderCell)HeaderCells.GetValue(i, j);
                if (HeaderCell1 == null)
                    continue;
                for (int k = j + 1; k < HeaderCols; k++)
                {
                    DynamicHeaderCell HeaderCell2 = (DynamicHeaderCell)HeaderCells.GetValue(i, k);
                    if (HeaderCell2 == null)
                        continue;
                    if (HeaderCell1.Header.Equals(HeaderCell2.Header))
                    {
                        HeaderCell1.ColSpan++;
                        HeaderCells.SetValue(null, i, k);
                    }
                }
            }
        }

        //Marge the Rows
        for (int j = 0; j < HeaderCols; j++)
        {
            for (int i = 0; i < HeaderRows; i++)
            {
                DynamicHeaderCell HeaderCell1 = (DynamicHeaderCell)HeaderCells.GetValue(i, j);
                if (HeaderCell1 == null)
                    continue;

                for (int k = i + 1; k < HeaderRows; k++)
                {
                    DynamicHeaderCell HeaderCell2 = (DynamicHeaderCell)HeaderCells.GetValue(k, j);
                    if (HeaderCell2 == null)
                    {
                        HeaderCell1.RowSpan++;
                        HeaderCells.SetValue(null, k, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        //Creating an Arraylist. 
        //This will contain List of DynamicHeaderCell for each row
        //GridView will render these
        ArrayList DynHeaderCells = new ArrayList();
        for (int i = 0; i < HeaderRows; i++)
        {
            List<DynamicHeaderCell> RowHeaderCells = new List<DynamicHeaderCell>();
            for (int j = 0; j < HeaderCols; j++)
            {
                DynamicHeaderCell HeaderCell = (DynamicHeaderCell)HeaderCells.GetValue(i, j);
                if (HeaderCell == null)
                    continue;
                RowHeaderCells.Add(HeaderCell);
            }
            DynHeaderCells.Add(RowHeaderCells);
        }
        return DynHeaderCells;
    }
}
