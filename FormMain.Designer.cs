namespace ShockRing
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxActivateTimestamp = new TextBox();
            textBoxActivate = new TextBox();
            buttonStop = new Button();
            buttonStart = new Button();
            labelActive = new Label();
            SuspendLayout();
            // 
            // textBoxActivateTimestamp
            // 
            textBoxActivateTimestamp.Enabled = false;
            textBoxActivateTimestamp.Location = new Point(12, 12);
            textBoxActivateTimestamp.Name = "textBoxActivateTimestamp";
            textBoxActivateTimestamp.ReadOnly = true;
            textBoxActivateTimestamp.Size = new Size(66, 23);
            textBoxActivateTimestamp.TabIndex = 0;
            textBoxActivateTimestamp.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxActivate
            // 
            textBoxActivate.Enabled = false;
            textBoxActivate.Location = new Point(84, 12);
            textBoxActivate.Name = "textBoxActivate";
            textBoxActivate.ReadOnly = true;
            textBoxActivate.Size = new Size(285, 23);
            textBoxActivate.TabIndex = 1;
            // 
            // buttonStop
            // 
            buttonStop.BackColor = Color.LightCoral;
            buttonStop.Location = new Point(12, 136);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 2;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonStart
            // 
            buttonStart.BackColor = Color.LightGreen;
            buttonStart.Location = new Point(294, 136);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 3;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelActive
            // 
            labelActive.Location = new Point(1, 125);
            labelActive.Name = "labelActive";
            labelActive.Size = new Size(381, 44);
            labelActive.TabIndex = 4;
            labelActive.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 171);
            Controls.Add(buttonStart);
            Controls.Add(buttonStop);
            Controls.Add(textBoxActivate);
            Controls.Add(textBoxActivateTimestamp);
            Controls.Add(labelActive);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "ShockRing";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxActivateTimestamp;
        private TextBox textBoxActivate;
        private Button buttonStop;
        private Button buttonStart;
        private Label labelActive;
    }
}