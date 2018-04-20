using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CherwellTriangles.Models
{
    public class RowColumn
    {
        private string mRow;
        private int mColumn;

        public RowColumn(string pRow, int pColumn)
        {
            this.mRow = pRow;
            this.mColumn = pColumn;
        }

        public string Row
        {
            get { return mRow; }
            set { mRow = value; }
        }

        public int Column
        {
            get { return mColumn; }
            set { mColumn = value; }
        }

        public override string ToString()
        {
            return mRow + mColumn.ToString();
        }
    }
}