namespace bayesgameanalyis
{
    partial class WeatherLearning
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
            this.tempComboBox = new System.Windows.Forms.ComboBox();
            this.fallingComboBox = new System.Windows.Forms.ComboBox();
            this.snowComboBox = new System.Windows.Forms.ComboBox();
            this.windComboBox = new System.Windows.Forms.ComboBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tempComboBox
            // 
            this.tempComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tempComboBox.FormattingEnabled = true;
            this.tempComboBox.Location = new System.Drawing.Point(85, 51);
            this.tempComboBox.Name = "tempComboBox";
            this.tempComboBox.Size = new System.Drawing.Size(121, 21);
            this.tempComboBox.TabIndex = 0;
            // 
            // fallingComboBox
            // 
            this.fallingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fallingComboBox.FormattingEnabled = true;
            this.fallingComboBox.Location = new System.Drawing.Point(85, 78);
            this.fallingComboBox.Name = "fallingComboBox";
            this.fallingComboBox.Size = new System.Drawing.Size(121, 21);
            this.fallingComboBox.TabIndex = 1;
            // 
            // snowComboBox
            // 
            this.snowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.snowComboBox.FormattingEnabled = true;
            this.snowComboBox.Location = new System.Drawing.Point(85, 105);
            this.snowComboBox.Name = "snowComboBox";
            this.snowComboBox.Size = new System.Drawing.Size(121, 21);
            this.snowComboBox.TabIndex = 2;
            // 
            // windComboBox
            // 
            this.windComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windComboBox.FormattingEnabled = true;
            this.windComboBox.Location = new System.Drawing.Point(85, 132);
            this.windComboBox.Name = "windComboBox";
            this.windComboBox.Size = new System.Drawing.Size(121, 21);
            this.windComboBox.TabIndex = 3;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(15, 159);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(121, 39);
            this.calcButton.TabIndex = 4;
            this.calcButton.Text = "Izračunaj";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Temperatura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Padaline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Snijeg";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Vjetar";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(171, 185);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(64, 25);
            this.result.TabIndex = 9;
            this.result.Text = "label5";
            this.result.Visible = false;
            // 
            // WeatherLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.windComboBox);
            this.Controls.Add(this.snowComboBox);
            this.Controls.Add(this.fallingComboBox);
            this.Controls.Add(this.tempComboBox);
            this.Name = "WeatherLearning";
            this.Text = "Igrati ili ne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tempComboBox;
        private System.Windows.Forms.ComboBox fallingComboBox;
        private System.Windows.Forms.ComboBox snowComboBox;
        private System.Windows.Forms.ComboBox windComboBox;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label result;
    }
}