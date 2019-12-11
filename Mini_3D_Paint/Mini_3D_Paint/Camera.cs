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
            double oldViewX = viewX, oldViewY = viewY;
            viewX = oldViewX * Math.Cos(radians) - oldViewY * Math.Sin(radians);
            viewY = oldViewX * Math.Sin(radians) + oldViewY * Math.Cos(radians);
    
        }

        public void verticalRotate(int deg)
        {
            double radians = deg * Math.PI / 180.0f;
            double oldViewX = viewX, oldViewY = viewY;
            viewX = oldViewX * Math.Cos(radians) - oldViewY * Math.Sin(radians);
            viewY = oldViewY * Math.Sin(radians) + oldViewX * Math.Cos(radians);
        }
    }
}
