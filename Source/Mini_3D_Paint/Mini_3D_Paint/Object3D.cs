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
        public Point center = new Point(0, 0, 0);
        //public bool selected = false;
        //Vẽ hình khối
        public virtual void Draw(OpenGL gl, bool selected = false) { }         
        // vẽ viền
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
            /*  gốc toạ độ ở tâm mặt phẳng đáy hình lập phương
             *  
             *    4 -| - - - 5
             *  / |  |     / |
             * 7 - - | - 6   |
             *-|--|--|--|---|----
             * |  0 -| - | - 1
             * |/    O   | /  
             * 3 - - | - 2
             * --a---
            */ 
            
            float x = position.X, y = position.Y, z = position.Z,
               a = 2; // nửa cạnh

            float[][] vertex = new float[][]
            {
                new float[]{ x - a, y - a, z },
                new float[]{ x - a, y + a, z },
                new float[]{ x + a, y + a, z },
                new float[]{ x + a, y - a, z },

                new float[]{ x - a, y - a, z + 2*a },
                new float[]{ x - a, y + a, z + 2*a },
                new float[]{ x + a, y + a, z + 2*a },
                new float[]{ x + a, y - a, z + 2*a }
            };

            

            /*int[] vertexIndex = new int[] {
                0,1,2,3,
                4,5,6,7,
                1,5,6,2,
                0,4,7,3,
                0,1,5,4,
                3,2,6,7
            };*/

            gl.Color(color.R, color.G, color.B);
            gl.PushMatrix();
            gl.Scale(scale.X, scale.Y, scale.Z);
            gl.Rotate(rotation.X, rotation.Y, rotation.Z);
            //Vẽ 6 mặt
            gl.Begin(OpenGL.GL_QUADS);
            //đáy
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[0]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[1]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[2]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[3]);
            gl.End();


            //đỉnh
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[4]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[5]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[6]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[7]);
            gl.End();

            //sau
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[0]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[1]);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[5]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[4]);

            gl.End();

            //trước
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[3]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[2]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[6]);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[7]);
            gl.End();

            //phải
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[1]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[2]);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[6]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[5]);
            gl.End();

            //trái
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[0]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[3]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[7]);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[4]);
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
             * / /   O  \  /  
             * 3 - - - - 2
             * --a--
            */

            float x = position.X, y = position.Y, z = position.Z,
                  a = 2;
            float[][] vertex = new float[][]
            {
                new float[]{ x - a, y - a, z },
                new float[]{ x - a, y + a, z },
                new float[]{ x + a, y + a, z },
                new float[]{ x + a, y - a, z },

                new float[]{ x, y, z + 2*a }
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

            //vẽ các mặt

            //dưới 0123
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[0]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[1]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[2]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[3]);
            gl.End();

            //trái 034
            gl.Begin(OpenGL.GL_TRIANGLES);            
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[0]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[3]);
            gl.TexCoord(0.5f, 1);
            gl.Vertex(vertex[4]);
            gl.End();
            //phải 214
            gl.Begin(OpenGL.GL_TRIANGLES);            
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[2]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[1]);
            gl.TexCoord(0.5f, 1);
            gl.Vertex(vertex[4]);
            gl.End();
            //trước 324
            gl.Begin(OpenGL.GL_TRIANGLES);            
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[3]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[2]);
            gl.TexCoord(0.5f, 1);
            gl.Vertex(vertex[4]); 
            gl.End();
            //sau 104
            gl.Begin(OpenGL.GL_TRIANGLES);            
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[1]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[0]);
            gl.TexCoord(0.5f, 1);
            gl.Vertex(vertex[4]);
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

            float a = 2,
                g = a * (float)(Math.Sqrt(3) / 2),
                x = position.X , y = position.Y, z = position.Z;
            float[][] vertex = new float[][]
            {
                new float[]{ x - a / 2, y - g, z },
                new float[]{ x - a / 2, y + g, z },
                new float[]{ x + a, y, z },

                new float[]{ x - a / 2, y - g, z + 2*a },
                new float[]{ x - a / 2, y + g, z + 2*a },
                new float[]{ x + a, y, z + 2*a },
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

            //vẽ các mặt

            //trên 354
            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[3]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[5]);
            gl.TexCoord(0.5f, 1);
            gl.Vertex(vertex[4]);
            gl.End();

            // dưới 021
            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[0]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[2]);
            gl.TexCoord(0.5f, 1);
            gl.Vertex(vertex[1]);
            gl.End();

            //trái 3520
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[3]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[5]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[2]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[0]);
            gl.End();

            //phải 5412
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[5]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[4]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[1]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[2]);
            gl.End();

            //sau 4301
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0);
            gl.Vertex(vertex[4]);
            gl.TexCoord(1, 0);
            gl.Vertex(vertex[3]);
            gl.TexCoord(1, 1);
            gl.Vertex(vertex[0]);
            gl.TexCoord(0, 1);
            gl.Vertex(vertex[1]);
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
