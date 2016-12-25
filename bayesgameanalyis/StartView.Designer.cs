namespace bayesgameanalyis
{
    partial class StartView
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
            this.WeatherButton = new System.Windows.Forms.Button();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WeatherButton
            // 
            this.WeatherButton.Location = new System.Drawing.Point(12, 61);
            this.WeatherButton.Name = "WeatherButton";
            this.WeatherButton.Size = new System.Drawing.Size(108, 50);
            this.WeatherButton.TabIndex = 0;
            this.WeatherButton.Text = "Provjeri vrijeme";
            this.WeatherButton.UseVisualStyleBackColor = true;
            this.WeatherButton.Click += new System.EventHandler(this.WeatherButton_Click);
            // 
            // ScoreButton
            // 
            this.ScoreButton.Location = new System.Drawing.Point(164, 61);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(108, 50);
            this.ScoreButton.TabIndex = 1;
            this.ScoreButton.Text = "Pogodi ishod";
            this.ScoreButton.UseVisualStyleBackColor = true;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bayesov klasifikator";
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingLabel.Location = new System.Drawing.Point(96, 131);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(97, 25);
            this.LoadingLabel.TabIndex = 4;
            this.LoadingLabel.Text = "Loading...";
            this.LoadingLabel.Visible = false;
            // 
            // StartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.WeatherButton);
            this.Name = "StartView";
            this.Text = "StartView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WeatherButton;
        private System.Windows.Forms.Button ScoreButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LoadingLabel;
    }
}