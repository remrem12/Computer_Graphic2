using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;

namespace Mini_3D_Paint
{
    class Camera
    {
        static int id = 0;
        public string name;
        
        public double viewX;
        public double viewY;
        public double viewZ;
       

        public Camera()
        {
            id++;
            name = "Camera" + id.ToString();
            viewX = 8;
            viewY = 8;
            viewZ = 8;
        }

        public void zoomIn()
        {
            viewX /= 1.1;
            viewY /= 1.1;
            viewZ /= 1.1;
        }

        public void zoomOut()
        {
            viewX *= 1.1;
            viewY *= 1.1;
            viewZ *= 1.1;
        }

        public void horizontalRotate(double deg)  // xoay ngang
        {
            // transform to radians
            double radians = deg * Math.PI / 180.0f;
            double oldviewX = viewX, oldviewY = viewY;
            viewX = oldviewX * Math.Cos(radians) - oldviewY * Math.Sin(radians);
            viewY = oldviewX * Math.Sin(radians) + oldviewY * Math.Cos(radians);
    
        }

        public void verticalRotate(double deg)
        {
            /*double radians = deg * Math.PI / 180.0f;
            double oldviewX = viewX, oldviewY = viewY, oldviewZ = viewZ;
            viewZ = oldviewZ * Math.Cos(radians) + oldviewY * Math.Sin(radians);
            viewY = oldviewY * Math.Cos(radians) - oldviewZ * Math.Sin(radians);*/

            double x = 0, z = 0, y = 0;
            if (viewX <= 1 && viewY <= 1)
            {
                x = 0;
            }

            int flag = 1;
            //if(viewX <=0 )flag = -1;
            double t = (1 * viewX) / Math.Sqrt(viewX * viewX + viewY * viewY);
            double alpha = Math.Acos(t);



            //double sina = Math.Sqrt(1 - cosa * cosa);
            if ((viewX >= 0 && viewY >= 0 || viewX < 0 && viewY >= 0))
            {
                if (flag == 1)
                    alpha = 2 * Math.PI - alpha;
            }

            x = viewX;
            y = viewY;


            viewX = x * Math.Cos(alpha) - y * Math.Sin(alpha);
            viewY = x * Math.Sin(alpha) + y * Math.Cos(alpha);
            
            //quay quanh y
            deg = deg * Math.PI / 180;
            z = viewZ;
            x = viewX;

            viewX = x * Math.Cos(deg) + z * Math.Sin(deg);
            viewZ = -x * Math.Sin(deg) + z * Math.Cos(deg);

            alpha = -alpha;

            x = viewX;
            y = viewY;


            viewX = x * Math.Cos(alpha) - y * Math.Sin(alpha);
            viewY = x * Math.Sin(alpha) + y * Math.Cos(alpha);
        }
    }
}
