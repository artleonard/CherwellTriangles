using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace CherwellTriangles.Models
{
    public class Triangle
    {
        private int mV1x;
        private int mV1y;
        private int mV2x;
        private int mV2y;
        private int mV3x;
        private int mV3y;
        private RowColumn mRowColumn;

        public int V1x
        {
            get { return mV1x; }
            set
            {
                if (ValidateValue("Vertex 1 x", value))
                {
                    mV1x = value;
                }
            }
        }

        public int V1y
        {
            get { return mV1y; }
            set
            {
                if (ValidateValue("Vertex 1 y", value))
                {
                    mV1y = value;
                }
            }
        }

        public int V2x
        {
            get { return mV2x; }
            set
            {
                if (ValidateValue("Vertex 2 x", value))
                {
                    mV2x = value;
                }
            }
        }

        public int V2y
        {
            get { return mV2y; }
            set
            {
                if (ValidateValue("Vertex 2 y", value))
                {
                    mV2y = value;
                }
            }
        }

        public int V3x
        {
            get { return mV3x; }
            set
            {
                if (ValidateValue("Vertex 3 x", value))
                {
                    mV3x = value;
                }
            }
        }

        public int V3y
        {
            get { return mV3y; }
            set
            {
                if (ValidateValue("Vertex 3 y", value))
                {
                    mV3y = value;
                }
            }
        }

        public RowColumn GetRowColumn
        {
            get { return mRowColumn; }
        }

        public Triangle(RowColumn mRowColumn)
        {
            this.mRowColumn = mRowColumn;
            CalculateCoordinates();
        }

        public Triangle(int V1x, int V1y, int V2x, int V2y, int V3x, int V3y)
        {
            this.V1x = V1x;
            this.V1y = V1y;
            this.V2x = V2x;
            this.V2y = V2y;
            this.V3x = V3x;
            this.V3y = V3y;
            DeterminePosition();
        }

        private Boolean ValidateValue(string name, int value)
        {
            if (value % 10 != 0 || value > 60 || value < 0)
            {
                throw new ArgumentOutOfRangeException(name, "Value not a positive multiple of 10 or is out of the range of the grid size.");
            }
            return true;
        }

        private Boolean ValidateRowColumn(RowColumn rowColumn)
        {
            if (this.mRowColumn != null)
            {
                Regex regex = new Regex("[A-F]", RegexOptions.IgnoreCase);
                // Validate that the row is within the defined criteria
                if (!regex.IsMatch(this.mRowColumn.Row))
                {
                    throw new ArgumentOutOfRangeException("Row", "Row value must be A - F.");
                }
                // Validate that the column is within the the defined criteria
                if (this.mRowColumn.Column < 1 || this.mRowColumn.Column > 12)
                {
                    throw new ArgumentOutOfRangeException("Column", "Column value must be 1 - 12.");
                }
            }
            else
            {
                throw new ArgumentNullException("RowColumn", "RowColumn cannot be Null");
            }
            return true;
        }

        private void CalculateCoordinates()
        {
            if (ValidateRowColumn(this.mRowColumn))
            {
                int row = this.mRowColumn.Row[0] - 65; // Convert to ascii value and adjust to a value between 0 - 5
                int column = (int)((this.mRowColumn.Column + (this.mRowColumn.Column % 2)) * .5) - 1; // Convert to a column number that spans two triangles
                // Hypotenuse points are same for column pairs
                mV1x = column * 10;
                mV1y = row * 10;
                mV2x = (column + 1) * 10;
                mV2y = (row + 1) * 10;

                if (this.mRowColumn.Column % 2 == 0)
                {
                    // Column is even: horizontal is on top, vertical is on right
                    mV3x = (column + 1) * 10;
                    mV3y = row * 10;
                }
                else
                {
                    // Column is odd: horizontal is on bottom, vertical is on left
                    mV3x = column * 10;
                    mV3y = (row + 1) * 10;
                }
            }
        }

        private void DeterminePosition()
        {
            // Use the lowest y coordinate to determine the row
            int rowInt = Math.Min(V1y, Math.Min(V2y, V3y)) / 10;
            // Convert the row to its character equivalent
            string row = ((char)(rowInt + 65)).ToString();

            int maxX = Math.Max(V1x, Math.Max(V2x, V3x));
            int minX = Math.Min(V1x, Math.Min(V2x, V3x));
            // Get the most occurring x coordinate to determine if the verticle leg is on the left or right side
            int[] list = new int[] { V1x, V2x, V3x };
            int mostOccurring = list.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            int column = mostOccurring / 10 * 2;

            // Vertical leg is on the right
            if (mostOccurring == minX)
            {
                column += 1;
            }

            mRowColumn = new RowColumn(row, column);
        }
    }
}
