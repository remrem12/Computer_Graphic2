using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace Mini_3D_Paint
{
    //Lớp điểm (tọa độ)
    public class Point
    {
        public float X, Y, Z;

        public Point(float x = 0, float y = 0, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Set(float x, float y, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Set(Point c)
        {
            X = c.X;
            Y = c.Y;
            Z = c.Z;
        }
    }

    //Lớp màu
    public class Color
    {
        public byte R, G, B;

        public Color(byte r = 0, byte g = 0, byte b = 0)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }

        public void Set(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public void Set(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }
    }

    public class Geometry
    {
        public string name = "";
        public Point position = new Point();
        public Point rotation = new Point();
        public Point scale = new Point(1, 1, 1); 
        public Color color = new Color();
        //public bool selected = false;
        //Vẽ hình khối
        public virtual void Draw(OpenGL gl, bool selected = false) { }         
        
        protected void DrawBorder(OpenGL gl, bool selected, float[][] vertex, int[] index)
        {
            if (selected)
            {
                gl.Color((byte)255, (byte)69, (byte)0);
                gl.LineWidth(3);
            }
            else
            {
                gl.Color((byte)0, (byte)0, (byte)0);                
            }
            
            gl.Begin(OpenGL.GL_LINES);
            foreach (int i in index)
            {                
                gl.Vertex(vertex[i]);
            }
            gl.End();

            gl.LineWidth(1);
        }
    }

    public class Cubic : Geometry
    {
        static int id = 0;
        
        public Cubic()
        {
            id++;
            name = "Cubic" + id.ToString();
        }
               
        public override void Draw(OpenGL gl, bool selected = false)
        {
            /* 
             *    2 -  - - - 3
             *  / |        / |
             * 1 - - - - 0   |
             * |  |      |   |
             * |  6 - -  | - 7
             * |/        | /  
             * 5 - - - - 4
            */

            float x = position.X, y = position.Y, z = position.Z,
               a = 3;

            float[][] vertex = new float[][]
            {
                new float[]{ x, y, z },
                new float[]{ x, y - a, z },
                new float[]{ x - a, y - a, z },
                new float[]{ x - a, y, z },

                new float[]{ x, y, z - a },
                new float[]{ x, y - a, z - a },
                new float[]{ x - a, y - a, z - a },
                new float[] {x - a, y, z - a}
            };

            

            int[] vertexIndex = new int[] {
                0,1,2,3,
                4,5,6,7,
                1,5,6,2,
                0,4,7,3,
                0,1,5,4,
                3,2,6,7
            };

            gl.Color(color.R, color.G, color.B);
            gl.PushMatrix();
            gl.Scale(scale.X, scale.Y, scale.Z);
            gl.Rotate(rotation.X, rotation.Y, rotation.Z);

            gl.Begin(OpenGL.GL_QUADS);
            foreach (int i in vertexIndex)
                gl.Vertex(vertex[i]);
            gl.End();
            
            int[] index = new int[]
                {
                0,1,1,2,2,3,3,0,
                4,5,5,6,6,7,7,4,
                0,4,1,5,2,6,3,7
                };
            DrawBorder(gl, selected, vertex, index);
            
            gl.PopMatrix();
        }                
    }

    public class Pyramid : Geometry
    {
        static int id = 0;
        public Pyramid()
        {
            id++;
            name = "Pyramid" + id.ToString();
        }

        public override void Draw(OpenGL gl, bool selected = false)
        {
            /*    
             *      4
             *    / |\ \_
             *   / /  \   \_ 
             *  /  0 - \- - 1
             * / /      \  /  
             * 3 - - - - 2
            */

            float x = position.X, y = position.Y, z = position.Z,
                a = 3, h = 3;
            float[][] vertex = new float[][]
            {
                new float[]{ x - a, y - a, z - a },
                new float[]{ x - a, y, z - a },
                new float[]{ x, y, z - a },
                new float[]{ x, y - a, z - a },

                new float[]{ x - a/2.0f, y - a/2.0f, z }
            };

            int[] vertexIndex = new int[] {
               0,4,3,
               1,4,2,
               0,4,1,
               3,4,2
            };

            gl.Color(color.R, color.G, color.B);
            gl.PushMatrix();
            gl.Scale(scale.X, scale.Y, scale.Z);
            gl.Rotate(rotation.X, rotation.Y, rotation.Z);

            gl.Begin(OpenGL.GL_QUADS);
            for (int i = 0; i < 4; i++)
                gl.Vertex(vertex[i]);
            gl.End();
            gl.Begin(OpenGL.GL_TRIANGLES);
            foreach (int i in vertexIndex)
                gl.Vertex(vertex[i]);
            gl.End();

            int[] index = new int[]
            {
                0,1,1,2,2,3,3,0,
                4,0,4,1,4,2,4,3
            };
            DrawBorder(gl, selected, vertex, index);            

            gl.PopMatrix();
        }
    } 

    public class Prism: Geometry
    {
        static int id = 0; 
        public Prism()
        {
            id++;
            name = "Prism" + id.ToString();
        }
               
        public override void Draw(OpenGL gl, bool selected = false)
        {
            /* 
             * 3 - - - 4
             * | \   / |
             * |   5   |
             * |   |   | 
             * 0 - | - 1
             *   \ | /
             *     2     
            */

            float a = 3,
                h = 3,
                g = a * (float)(Math.Sqrt(3) / 2),
                x = position.X , y = position.Y, z = position.Z;
            float[][] vertex = new float[][]
            {
                new float[]{ x - a, y - a, z - h },
                new float[]{ x - a, y, z - h },
                new float[]{ x - g, y - a/2, z - h },

                new float[]{ x - h, y - h, z },
                new float[]{ x - a, y, z },
                new float[]{ x - g, y - a/2, z },
            };

            int[] vertexIndex = new int[] {
                0,3,5,2,
                2,5,4,1,
                0,3,4,1
            };

            gl.Color(color.R, color.G, color.B);
            gl.PushMatrix();
            gl.Scale(scale.X, scale.Y, scale.Z);
            gl.Rotate(rotation.X, rotation.Y, rotation.Z);

            gl.Begin(OpenGL.GL_QUADS);
            foreach (int i in vertexIndex)
                gl.Vertex(vertex[i]);
            gl.End();

            gl.Begin(OpenGL.GL_TRIANGLES);
            for (int i = 0; i < 6; i++)
                gl.Vertex(vertex[i]);
            gl.End();

            int[] index = new int[]
                {
                0,1,1,2,2,0,
                3,4,4,5,5,3,
                0,3,1,4,2,5
                };
            DrawBorder(gl, selected, vertex, index);
           
            gl.PopMatrix();
        }
    }
}
