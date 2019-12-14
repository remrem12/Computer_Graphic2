
namespace Mini_3D_Paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.grpTransform = new System.Windows.Forms.GroupBox();
            this.tbScaleZ = new System.Windows.Forms.TextBox();
            this.tbScaleY = new System.Windows.Forms.TextBox();
            this.tbRotationZ = new System.Windows.Forms.TextBox();
            this.tbRotationY = new System.Windows.Forms.TextBox();
            this.tbScaleX = new System.Windows.Forms.TextBox();
            this.tbPosionZ = new System.Windows.Forms.TextBox();
            this.tbRotationX = new System.Windows.Forms.TextBox();
            this.tbPosionY = new System.Windows.Forms.TextBox();
            this.tbPosionX = new System.Windows.Forms.TextBox();
            this.lbZ = new System.Windows.Forms.Label();
            this.lbY = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.lbRotation = new System.Windows.Forms.Label();
            this.lbScale = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.grpObject = new System.Windows.Forms.GroupBox();
            this.btPrism = new System.Windows.Forms.Button();
            this.btPyramid = new System.Windows.Forms.Button();
            this.btCubic = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.lstObject = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textureBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.grpTransform.SuspendLayout();
            this.grpObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(12, 36);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(612, 461);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            // 
            // grpTransform
            // 
            this.grpTransform.Controls.Add(this.tbScaleZ);
            this.grpTransform.Controls.Add(this.tbScaleY);
            this.grpTransform.Controls.Add(this.tbRotationZ);
            this.grpTransform.Controls.Add(this.tbRotationY);
            this.grpTransform.Controls.Add(this.tbScaleX);
            this.grpTransform.Controls.Add(this.tbPosionZ);
            this.grpTransform.Controls.Add(this.tbRotationX);
            this.grpTransform.Controls.Add(this.tbPosionY);
            this.grpTransform.Controls.Add(this.tbPosionX);
            this.grpTransform.Controls.Add(this.lbZ);
            this.grpTransform.Controls.Add(this.lbY);
            this.grpTransform.Controls.Add(this.lbX);
            this.grpTransform.Controls.Add(this.lbRotation);
            this.grpTransform.Controls.Add(this.lbScale);
            this.grpTransform.Controls.Add(this.lbPosition);
            this.grpTransform.Location = new System.Drawing.Point(639, 368);
            this.grpTransform.Name = "grpTransform";
            this.grpTransform.Size = new System.Drawing.Size(282, 113);
            this.grpTransform.TabIndex = 2;
            this.grpTransform.TabStop = false;
            this.grpTransform.Text = "Transform";
            // 
            // tbScaleZ
            // 
            this.tbScaleZ.Location = new System.Drawing.Point(202, 79);
            this.tbScaleZ.Name = "tbScaleZ";
            this.tbScaleZ.Size = new System.Drawing.Size(60, 20);
            this.tbScaleZ.TabIndex = 3;
            this.tbScaleZ.TextChanged += new System.EventHandler(this.tbScaleZ_TextChanged);
            // 
            // tbScaleY
            // 
            this.tbScaleY.Location = new System.Drawing.Point(136, 79);
            this.tbScaleY.Name = "tbScaleY";
            this.tbScaleY.Size = new System.Drawing.Size(60, 20);
            this.tbScaleY.TabIndex = 3;
            this.tbScaleY.TextChanged += new System.EventHandler(this.tbScaleY_TextChanged);
            // 
            // tbRotationZ
            // 
            this.tbRotationZ.Location = new System.Drawing.Point(202, 55);
            this.tbRotationZ.Name = "tbRotationZ";
            this.tbRotationZ.Size = new System.Drawing.Size(60, 20);
            this.tbRotationZ.TabIndex = 3;
            this.tbRotationZ.TextChanged += new System.EventHandler(this.tbRotationZ_TextChanged);
            // 
            // tbRotationY
            // 
            this.tbRotationY.Location = new System.Drawing.Point(136, 55);
            this.tbRotationY.Name = "tbRotationY";
            this.tbRotationY.Size = new System.Drawing.Size(60, 20);
            this.tbRotationY.TabIndex = 3;
            this.tbRotationY.TextChanged += new System.EventHandler(this.tbRotationY_TextChanged);
            // 
            // tbScaleX
            // 
            this.tbScaleX.Location = new System.Drawing.Point(70, 79);
            this.tbScaleX.Name = "tbScaleX";
            this.tbScaleX.Size = new System.Drawing.Size(60, 20);
            this.tbScaleX.TabIndex = 3;
            this.tbScaleX.TextChanged += new System.EventHandler(this.tbScaleX_TextChanged);
            // 
            // tbPosionZ
            // 
            this.tbPosionZ.Location = new System.Drawing.Point(202, 30);
            this.tbPosionZ.Name = "tbPosionZ";
            this.tbPosionZ.Size = new System.Drawing.Size(60, 20);
            this.tbPosionZ.TabIndex = 3;
            this.tbPosionZ.TextChanged += new System.EventHandler(this.tbPosionZ_TextChanged);
            // 
            // tbRotationX
            // 
            this.tbRotationX.Location = new System.Drawing.Point(70, 55);
            this.tbRotationX.Name = "tbRotationX";
            this.tbRotationX.Size = new System.Drawing.Size(60, 20);
            this.tbRotationX.TabIndex = 3;
            this.tbRotationX.TextChanged += new System.EventHandler(this.tbRotationX_TextChanged);
            // 
            // tbPosionY
            // 
            this.tbPosionY.Location = new System.Drawing.Point(136, 30);
            this.tbPosionY.Name = "tbPosionY";
            this.tbPosionY.Size = new System.Drawing.Size(60, 20);
            this.tbPosionY.TabIndex = 3;
            this.tbPosionY.TextChanged += new System.EventHandler(this.tbPosionY_TextChanged);
            // 
            // tbPosionX
            // 
            this.tbPosionX.Location = new System.Drawing.Point(70, 30);
            this.tbPosionX.Name = "tbPosionX";
            this.tbPosionX.Size = new System.Drawing.Size(60, 20);
            this.tbPosionX.TabIndex = 3;
            this.tbPosionX.TextChanged += new System.EventHandler(this.tbPosionX_TextChanged);
            // 
            // lbZ
            // 
            this.lbZ.AutoSize = true;
            this.lbZ.Location = new System.Drawing.Point(224, 14);
            this.lbZ.Name = "lbZ";
            this.lbZ.Size = new System.Drawing.Size(14, 13);
            this.lbZ.TabIndex = 2;
            this.lbZ.Text = "Z";
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(159, 14);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(14, 13);
            this.lbY.TabIndex = 2;
            this.lbY.Text = "Y";
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(98, 14);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(14, 13);
            this.lbX.TabIndex = 2;
            this.lbX.Text = "X";
            // 
            // lbRotation
            // 
            this.lbRotation.AutoSize = true;
            this.lbRotation.Location = new System.Drawing.Point(14, 58);
            this.lbRotation.Name = "lbRotation";
            this.lbRotation.Size = new System.Drawing.Size(47, 13);
            this.lbRotation.TabIndex = 1;
            this.lbRotation.Text = "Rotation";
            // 
            // lbScale
            // 
            this.lbScale.AutoSize = true;
            this.lbScale.Location = new System.Drawing.Point(14, 82);
            this.lbScale.Name = "lbScale";
            this.lbScale.Size = new System.Drawing.Size(34, 13);
            this.lbScale.TabIndex = 0;
            this.lbScale.Text = "Scale";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Location = new System.Drawing.Point(14, 33);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(44, 13);
            this.lbPosition.TabIndex = 0;
            this.lbPosition.Text = "Position";
            // 
            // grpObject
            // 
            this.grpObject.Controls.Add(this.btPrism);
            this.grpObject.Controls.Add(this.btPyramid);
            this.grpObject.Controls.Add(this.btCubic);
            this.grpObject.Location = new System.Drawing.Point(639, 24);
            this.grpObject.Name = "grpObject";
            this.grpObject.Size = new System.Drawing.Size(282, 52);
            this.grpObject.TabIndex = 3;
            this.grpObject.TabStop = false;
            this.grpObject.Text = "Draw New Object";
            // 
            // btPrism
            // 
            this.btPrism.Image = global::Mini_3D_Paint.Properties.Resources.prism;
            this.btPrism.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrism.Location = new System.Drawing.Point(182, 21);
            this.btPrism.Name = "btPrism";
            this.btPrism.Size = new System.Drawing.Size(75, 25);
            this.btPrism.TabIndex = 2;
            this.btPrism.Text = "Prism";
            this.btPrism.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPrism.UseVisualStyleBackColor = true;
            this.btPrism.Click += new System.EventHandler(this.btPrism_Click);
            // 
            // btPyramid
            // 
            this.btPyramid.Image = global::Mini_3D_Paint.Properties.Resources.tetrahedron;
            this.btPyramid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPyramid.Location = new System.Drawing.Point(101, 21);
            this.btPyramid.Name = "btPyramid";
            this.btPyramid.Size = new System.Drawing.Size(75, 25);
            this.btPyramid.TabIndex = 1;
            this.btPyramid.Text = "Pyramid";
            this.btPyramid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPyramid.UseVisualStyleBackColor = true;
            this.btPyramid.Click += new System.EventHandler(this.btPyramid_Click);
            // 
            // btCubic
            // 
            this.btCubic.Image = global::Mini_3D_Paint.Properties.Resources.Cube;
            this.btCubic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCubic.Location = new System.Drawing.Point(20, 21);
            this.btCubic.Name = "btCubic";
            this.btCubic.Size = new System.Drawing.Size(75, 25);
            this.btCubic.TabIndex = 0;
            this.btCubic.Text = "Cubic";
            this.btCubic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCubic.UseVisualStyleBackColor = true;
            this.btCubic.Click += new System.EventHandler(this.btCubic_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(639, 109);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(130, 30);
            this.btnColor.TabIndex = 4;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lstObject
            // 
            this.lstObject.FormattingEnabled = true;
            this.lstObject.Location = new System.Drawing.Point(639, 156);
            this.lstObject.Name = "lstObject";
            this.lstObject.Size = new System.Drawing.Size(282, 199);
            this.lstObject.TabIndex = 5;
            this.lstObject.SelectedIndexChanged += new System.EventHandler(this.lstObject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Color";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textureBut
            // 
            this.textureBut.Location = new System.Drawing.Point(775, 109);
            this.textureBut.Name = "textureBut";
            this.textureBut.Size = new System.Drawing.Size(146, 30);
            this.textureBut.TabIndex = 7;
            this.textureBut.Text = "Add Texture";
            this.textureBut.UseVisualStyleBackColor = true;
            this.textureBut.Click += new System.EventHandler(this.textureBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 509);
            this.Controls.Add(this.textureBut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstObject);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.grpObject);
            this.Controls.Add(this.grpTransform);
            this.Controls.Add(this.openGLControl);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.grpTransform.ResumeLayout(false);
            this.grpTransform.PerformLayout();
            this.grpObject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.GroupBox grpTransform;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Label lbScale;
        private System.Windows.Forms.Label lbZ;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbRotation;
        private System.Windows.Forms.TextBox tbScaleZ;
        private System.Windows.Forms.TextBox tbScaleY;
        private System.Windows.Forms.TextBox tbRotationZ;
        private System.Windows.Forms.TextBox tbRotationY;
        private System.Windows.Forms.TextBox tbScaleX;
        private System.Windows.Forms.TextBox tbPosionZ;
        private System.Windows.Forms.TextBox tbRotationX;
        private System.Windows.Forms.TextBox tbPosionY;
        private System.Windows.Forms.TextBox tbPosionX;
        private System.Windows.Forms.GroupBox grpObject;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btPrism;
        private System.Windows.Forms.Button btPyramid;
        private System.Windows.Forms.Button btCubic;
        private System.Windows.Forms.ListBox lstObject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button textureBut;
    }
}

