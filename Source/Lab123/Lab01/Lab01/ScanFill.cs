﻿using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class ScanFill
    {
        //private Polygon polygon;
        private List<Point> ListOfIntersectPoints; //List giao điểm giữa đường quét và các cạnh
        private List<Line> ListOfEdges; //List các cạnh của đa giác
        private List<Point> polygon; //List các điểm của đa giác
        private int point_ymin; //startPoint Scanline
        private int point_ymax; //end point scaline
        public void setFill(List<Point> po)
        {
            this.polygon = po;
            ListOfIntersectPoints = new List<Point>();
            ListOfEdges = new List<Line>();
            point_ymin = 2000;
            point_ymax = 0;
        }

        public bool findIntersectGLPoint(int x1, int y1, int x2, int y2, int y, ref int x) //Tìm giao điểm của dòng quét y và cạnh
        {
            if (y2 == y1)
                return false;
            x = (x2 - x1) * (y - y1) / (y2 - y1) + x1;
            bool isInsideEdgeX;
            bool isInsideEdgeY;
            if (x1 < x2)
                isInsideEdgeX = (x1 <= x) && (x <= x2);
            else
                isInsideEdgeX = (x2 <= x) && (x <= x1);

            if (y1 < y2)
                isInsideEdgeY = (y1 <= y) && (y <= y2);
            else
                isInsideEdgeY = (y2 <= y) && (y <= y1);
            return isInsideEdgeX && isInsideEdgeY;
        }

        public void initEdges()
        {
            if (polygon.Count() > 2)
            {
                //foreach(Point p in polygon)
                //{
                //    if (p)
                //}

                for (int a = 1; a < polygon.Count(); a++) //Tìm point_ymin và point_ymax; Xây dựng list cạnh
                {
                    if (polygon[a - 1].getY() < point_ymin)
                        point_ymin = polygon[a - 1].getY();
                    if (polygon[a - 1].getY() > point_ymax)
                        point_ymax = polygon[a - 1].getY();
                    Line current = new Line(polygon[a - 1], polygon[a]);
                    ListOfEdges.Add(current);
                }
                int i = polygon.Count() - 1;
                if (polygon[i].getY() > point_ymax)
                    point_ymax = polygon[i].getY();
                if (polygon[i].getY() < point_ymin)
                    point_ymin = polygon[i].getY();
                Line last = new Line(polygon[i], polygon[0]);
                ListOfEdges.Add(last);
            }
        }

        public void scanlineFill(OpenGL gl)
        {
            int edgesSize = ListOfEdges.Count();
            for (int i = point_ymin; i <= point_ymax; i++) //Duyệt từng dòng quét
            {
                int intersectX = 0;
                for (int j = 0; j < edgesSize; j++) //Xây dựng danh sách các giao điểm
                {
                    if (findIntersectGLPoint(ListOfEdges[j].getP1().getX(), ListOfEdges[j].getP1().getY(), ListOfEdges[j].getP2().getX(), ListOfEdges[j].getP2().getY(), i, ref intersectX))
                    {
                        Point p = new Point(intersectX, i);
                        if (ListOfEdges[j].getP1().getY() > ListOfEdges[j].getP2().getY())
                        {
                            if (p.getY() == ListOfEdges[j].getP1().getY())
                                continue;
                        }
                        else
                            if (ListOfEdges[j].getP1().getY() < ListOfEdges[j].getP2().getY())
                        {
                            if (p.getY() == ListOfEdges[j].getP2().getY())
                                continue;
                        }
                        ListOfIntersectPoints.Add(p);
                    }
                }
                int intersectSize = ListOfIntersectPoints.Count();
                Point swap = new Point(0, 0);
                for (int a = 0; a < intersectSize - 1; a++)//Sắp xếp các giao điểm lại theo tọa độ x
                    for (int j = i + 1; j < intersectSize; j++)
                    {
                        if (ListOfIntersectPoints[a].getX() > ListOfIntersectPoints[a].getX())
                        {
                            swap = ListOfIntersectPoints[a];
                            ListOfIntersectPoints[a] = ListOfIntersectPoints[j];
                            ListOfIntersectPoints[j] = swap;
                        }
                    }

                int intersectPointsSize = ListOfIntersectPoints.Count();
                for (int j = 1; j < intersectPointsSize; j += 2) //Tô màu
                {

                    gl.Begin(OpenGL.GL_LINES);
                    gl.LineWidth(1);
                    gl.Vertex2sv(new short[] { (short)(ListOfIntersectPoints[j - 1].getX()), (short)ListOfIntersectPoints[j - 1].getY() });
                    gl.Vertex2sv(new short[] { (short)(ListOfIntersectPoints[j].getX()), (short)ListOfIntersectPoints[j].getY() });
                    gl.End();

                }
                ListOfIntersectPoints.Clear();
            }
        }
    }
}
