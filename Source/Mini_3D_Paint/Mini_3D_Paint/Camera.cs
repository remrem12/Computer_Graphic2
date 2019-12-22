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
            // khoảng cách từ O đến camera khi chiếu camera lên Oxy
            double hypoXY = Math.Sqrt(viewX * viewX + viewY * viewY);
            // khoảng cách từ O đến camera
            double hypoXYZ = Math.Sqrt(hypoXY * hypoXY + viewZ * viewZ);
            //if (viewX < 0 && viewY < 0) hypoXY = -hypoXY;
            // góc ban đầu tạo bởi OCamera với mặt Oxy
            double rootAngle = Math.Acos(hypoXY / hypoXYZ); // radians
            double cosX = viewX / hypoXY;
            double cosY = viewY / hypoXY;
            // đổi sang độ
            double rootDeg = rootAngle * 180 / Math.PI;
            // cập nhật lại góc khi nhận vào thay đổi
            rootDeg += deg;
            // tính lại tọa độ camera từ góc mới cập nhật
            double radians = rootDeg * Math.PI / 180;
            hypoXY = hypoXYZ * Math.Cos(radians);
            viewX = hypoXY * cosX;
            viewY = hypoXY * cosY;
            viewZ = hypoXYZ * Math.Sin(radians);



            /*if (rootDeg >= 0 && rootDeg <= 90)
            {
                double radians = rootDeg * Math.PI / 180;
                hypoXY = hypoXYZ * Math.Cos(radians);
                viewX = hypoXY * cosX;
                viewY = hypoXY * cosY;
                viewZ = hypoXYZ * Math.Sin(radians);
            }

            if (rootDeg > 90 && rootDeg <= 180) {
                rootDeg = 180 - rootDeg;
                double radians = rootDeg * Math.PI / 180;
                hypoXY = hypoXYZ * Math.Cos(radians);
                viewX = hypoXY * cosX;
                viewY = hypoXY * cosY;
                viewZ = hypoXYZ * Math.Sin(radians);
            }
            if (rootDeg < 0 && rootDeg >= -90)
            {
                rootDeg = -rootDeg;
                double radians = rootDeg * Math.PI / 180;
                hypoXY = hypoXYZ * Math.Cos(radians);
                viewX = hypoXY * cosX;
                viewY = hypoXY * cosY;
                viewZ = -hypoXYZ * Math.Sin(radians);
            }
            else
            {
                double radians = rootDeg * Math.PI / 180;
                hypoXY = hypoXYZ * Math.Cos(radians);
                viewX = hypoXY * cosX;
                viewY = hypoXY * cosY;
                viewZ = -hypoXYZ * Math.Sin(radians);
            }*/
        }
    }
}
