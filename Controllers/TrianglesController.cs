using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CherwellTriangles.Models;

namespace CherwellTriangles.Controllers
{
    public class TrianglesController : ApiController
    {
        // GET: api/Triangle
        public Triangle GetTriangleCoordinates(string row, int column)
        {
            return new Triangle(new RowColumn(row, column));
        }

        // GET: api/TrianglePosition
        public RowColumn GetTrianglePosition(int V1x, int V1y, int V2x, int V2y, int V3x, int V3y)
        {
            Triangle t = new Triangle(V1x, V1y, V2x, V2y, V3x, V3y);
            return t.GetRowColumn;
        }
    }
}
