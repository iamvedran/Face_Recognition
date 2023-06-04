namespace Face_Recognition
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
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(13, 13);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(640, 520);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(761, 13);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(127, 41);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Start capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(761, 76);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(127, 42);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "Detect face";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(757, 259);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(131, 20);
            this.txtPersonName.TabIndex = 3;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(757, 370);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(131, 44);
            this.btnTrain.TabIndex = 5;
            this.btnTrain.Text = "Recognize";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // picDetected
            // 
            this.picDetected.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picDetected.Location = new System.Drawing.Point(761, 124);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(124, 110);
            this.picDetected.TabIndex = 7;
            this.picDetected.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(757, 285);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(131, 47);
            this.btnAddPerson.TabIndex = 8;
            this.btnAddPerson.Text = "Add person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 553);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Face recognition demo";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.Button btnAddPerson;
    }
}

