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
    public partial class Form1 : Form
    {
        OpenGL gl;
        List<Geometry> shapes = new List<Geometry>(); //Các hình đã vẽ
        int n_shapes = 0; //Số lượng hình đã vẽ            
        Color currentColor = new Color(255, 255, 255);   //Màu hiện tại  
        int selected = -1;
        Camera camera = new Camera();

        public Form1()
        {
            InitializeComponent();   
            btnColor.BackColor = System.Drawing.Color.White;
            grpTransform.Enabled = false;
            Camera c = new Camera();
        }    

        //=============================================================================

        //Render các hình đã vẽ
        private void renderShape()
        {
            //Reset lại khung vẽ
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            
            //Vẽ lại các hình
            foreach (Geometry s in shapes)
            {
                if (s == shapes[selected])
                    s.Draw(gl, true);
                else s.Draw(gl);
            }

            gl.Flush();
        }
                
        private void addShape(Geometry s)
        {
            s.color.Set(currentColor);
            shapes.Add(s);
            n_shapes++;

            lstObject.Items.Add(s.name);
            lstObject.SelectedIndex = n_shapes - 1;     
            
            s.Draw(gl);

            tbPosionX.Text = s.position.X.ToString();
            tbPosionY.Text = s.position.Y.ToString();
            tbPosionZ.Text = s.position.Z.ToString();

            tbRotationX.Text = s.rotation.X.ToString();
            tbRotationY.Text = s.rotation.Y.ToString();
            tbRotationZ.Text = s.rotation.Z.ToString();

            tbScaleX.Text = s.scale.X.ToString();
            tbScaleY.Text = s.scale.Y.ToString();
            tbScaleZ.Text = s.scale.Z.ToString();

            grpTransform.Enabled = true;
        }


        private void lstObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Geometry s = shapes[lstObject.SelectedIndex];
            selected = lstObject.SelectedIndex;
            tbPosionX.Text = s.position.X.ToString();
            tbPosionY.Text = s.position.Y.ToString();
            tbPosionZ.Text = s.position.Z.ToString();

            tbRotationX.Text = s.rotation.X.ToString();
            tbRotationY.Text = s.rotation.Y.ToString();
            tbRotationZ.Text = s.rotation.Z.ToString();

            tbScaleX.Text = s.scale.X.ToString();
            tbScaleY.Text = s.scale.Y.ToString();
            tbScaleZ.Text = s.scale.Z.ToString();
            
            //this.renderShape();
            s.Draw(gl, true);
        }

        //=============================================================================

        private void btCubic_Click(object sender, EventArgs e)
        {
            addShape(new Cubic());
        }

        private void btPyramid_Click(object sender, EventArgs e)
        {
            addShape(new Pyramid());
        }

        private void btPrism_Click(object sender, EventArgs e)
        {
            addShape(new Prism());           
        }
        
        //=============================================================================

        private void tbPosionX_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = float.Parse(tbPosionX.Text);
                shapes[lstObject.SelectedIndex].position.X = value;                
            }
            catch
            {
                tbPosionX.Text = "0";
            }
            renderShape();
        }

        private void tbPosionY_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = float.Parse(tbPosionY.Text);
                shapes[lstObject.SelectedIndex].position.Y = value;
            }
            catch
            {
                tbPosionY.Text = "0";
            }
            renderShape();
        }

        private void tbPosionZ_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = float.Parse(tbPosionZ.Text);
                shapes[lstObject.SelectedIndex].position.Z = value;
            }
            catch
            {
                tbPosionZ.Text = "0";
            }
            renderShape();
        }

        private void tbRotationX_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = float.Parse(tbRotationX.Text);
                shapes[lstObject.SelectedIndex].rotation.X = value;
            }
            catch
            {
                tbRotationX.Text = "0";
            }
            renderShape();
        }

        private void tbRotationY_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = float.Parse(tbRotationY.Text);
                shapes[lstObject.SelectedIndex].rotation.Y = value;
            }
            catch
            {
                tbRotationY.Text = "0";
            }
            renderShape();
        }

        private void tbRotationZ_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            try
            {
                value = float.Parse(tbRotationZ.Text);
                shapes[lstObject.SelectedIndex].rotation.Z = value;
            }
            catch
            {
                tbRotationZ.Text = "0";
            }
            renderShape();
        }

        private void tbScaleX_TextChanged(object sender, EventArgs e)
        {
            float value = 1;
            try
            {
                value = float.Parse(tbScaleX.Text);
                shapes[lstObject.SelectedIndex].scale.X = value;
            }
            catch
            {
                tbScaleX.Text = "1";
            }
            renderShape();
        }

        private void tbScaleY_TextChanged(object sender, EventArgs e)
        {
            float value = 1;
            try
            {
                value = float.Parse(tbScaleY.Text);
                shapes[lstObject.SelectedIndex].scale.Y = value;
            }
            catch
            {
                tbScaleY.Text = "1";
            }
            renderShape();
        }

        private void tbScaleZ_TextChanged(object sender, EventArgs e)
        {
            float value = 1;
            try
            {
                value = float.Parse(tbScaleZ.Text);
                shapes[lstObject.SelectedIndex].scale.Z = value;
            }
            catch
            {
                tbScaleZ.Text = "1";
            }
            renderShape();           
        }

        //=============================================================================

        private void btnColor_Click(object sender, EventArgs e)
        {
            //Chọn màu tô
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = new Color(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                btnColor.BackColor = colorDialog.Color;
                if (lstObject.SelectedIndex >= 0)
                {
                    shapes[lstObject.SelectedIndex].color.Set(currentColor);
                    shapes[lstObject.SelectedIndex].Draw(gl);
                }
                    
            }
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            gl = openGLControl.OpenGL;
            gl.ClearColor(0.0f, 0.0f, 0.0f, 1f);
            gl.ClearDepth(1);
            camera = new Camera();


            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            gl = openGLControl.OpenGL;
            //set ma tran viewport
            gl.Viewport(
                0, 0,
                openGLControl.Width,
                openGLControl.Height);

            //set ma tran phep chieu
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.Perspective(
                60,
                openGLControl.Width / openGLControl.Height,
                1.0, 10000.0
            );

            //set ma tran model view
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LookAt(
                10,10,10,
                0, 0, 0,
                0, 0, 1);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            gl = openGLControl.OpenGL;
            
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.LookAt(
                camera.viewX, camera.viewY, camera.viewZ,
                0, 0, 0,
                0, 0, 1);

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            this.renderShape();
            this.drawGrid(gl);
            gl.Flush();
        }

        
        private void openGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)        // Mạnh
                camera.zoomIn();
            if (e.KeyCode == Keys.X)
                camera.zoomOut();
            if (e.KeyCode == Keys.Left)     // Nam
                camera.horizontalRotate(10);
            if (e.KeyCode == Keys.Right)     // Phú
                camera.horizontalRotate(-10);
            if (e.KeyCode == Keys.Up)        // Nghĩa
                camera.verticalRotate(-10);
            if (e.KeyCode == Keys.Down)      // Mạnh
                camera.verticalRotate(10);


        }
        
        void drawGrid(OpenGL gl)    // vẽ trục tọa độ
        {
            gl.LineWidth(1.0f);
            int size = 10;
            for (int i = 0; i < size; i++)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(size, i, 0);
                gl.Vertex(-size, i, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(size, -i, 0);
                gl.Vertex(-size, -i, 0);
                gl.End();
            }

            for (int i = 0; i < size; i++)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(i, size, 0);
                gl.Vertex(i, -size, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINES);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                gl.Vertex(-i, size, 0);
                gl.Vertex(-i, -size, 0);
                gl.End();
            }
            // 3 trục tọa độ x(đỏ), y(xanh lá), z(xanh lục)
            gl.LineWidth(3.0f);
            gl.Color(1.0, 0.0, 0.0); // red x
            gl.Begin(OpenGL.GL_LINES);
            // x aix

            gl.Vertex(-4.0, 0.0f, 0.0f);
            gl.Vertex(6.0, 0.0f, 0.0f);

            gl.Vertex(6.0, 0.0f, 0.0f);
            gl.Vertex(5.0, 1.0f, 0.0f);

            gl.Vertex(6.0, 0.0f, 0.0f);
            gl.Vertex(5.0, -1.0f, 0.0f);
            gl.End();

            // y 
            gl.Color(0.0, 1.0, 0.0); // green y
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0.0, -4.0f, 0.0f);
            gl.Vertex(0.0, 6.0f, 0.0f);

            gl.Vertex(0.0, 6.0f, 0.0f);
            gl.Vertex(1.0, 5.0f, 0.0f);

            gl.Vertex(0.0, 6.0f, 0.0f);
            gl.Vertex(-1.0, 5.0f, 0.0f);
            gl.End();

            // z 
            gl.Color(0.0, 0.0, 1.0); // blue z
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0.0, 0.0f, -4.0f);
            gl.Vertex(0.0, 0.0f, 6.0f);


            gl.Vertex(0.0, 0.0f, 6.0f);
            gl.Vertex(0.0, 1.0f, 5.0f);

            gl.Vertex(0.0, 0.0f, 6.0f);
            gl.Vertex(0.0, -1.0f, 5.0f);
            gl.End();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textureBut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aladeen");
        }
    }
    }
