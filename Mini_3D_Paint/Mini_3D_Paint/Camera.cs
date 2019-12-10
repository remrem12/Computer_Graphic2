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
       
        double deg;

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

        public void horizontalRotate()
        {

        }
    }
}
