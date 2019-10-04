namespace POE_Task_1
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
            this.components = new System.ComponentModel.Container();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.GbBoxMap = new System.Windows.Forms.GroupBox();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(913, 26);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(76, 20);
            this.lblRound.TabIndex = 1;
            this.lblRound.Text = "Round: 1";
            this.lblRound.Click += new System.EventHandler(this.lblRound_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1045, 409);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(139, 49);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(1045, 464);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(139, 49);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(917, 519);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(267, 257);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.Text = "";
            // 
            // GbBoxMap
            // 
            this.GbBoxMap.Location = new System.Drawing.Point(3, 1);
            this.GbBoxMap.Name = "GbBoxMap";
            this.GbBoxMap.Size = new System.Drawing.Size(814, 748);
            this.GbBoxMap.TabIndex = 5;
            this.GbBoxMap.TabStop = false;
            this.GbBoxMap.Text = "Map";
            // 
            // Ticker
            // 
            this.Ticker.Interval = 1000;
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1266, 796);
            this.Controls.Add(this.GbBoxMap);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRound);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.GroupBox GbBoxMap;
        private System.Windows.Forms.Timer Ticker;
    }
}

