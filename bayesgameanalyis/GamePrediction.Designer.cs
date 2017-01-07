namespace bayesgameanalyis
{
    partial class GamePrediction
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
            this.homeCombobox = new System.Windows.Forms.ComboBox();
            this.awayCombobox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.overallResult = new System.Windows.Forms.Label();
            this.homeWins = new System.Windows.Forms.TextBox();
            this.homeForm = new System.Windows.Forms.TextBox();
            this.awayWins = new System.Windows.Forms.TextBox();
            this.awayForm = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeCombobox
            // 
            this.homeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.homeCombobox.FormattingEnabled = true;
            this.homeCombobox.Location = new System.Drawing.Point(3, 18);
            this.homeCombobox.Name = "homeCombobox";
            this.homeCombobox.Size = new System.Drawing.Size(103, 21);
            this.homeCombobox.TabIndex = 0;
            // 
            // awayCombobox
            // 
            this.awayCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.awayCombobox.FormattingEnabled = true;
            this.awayCombobox.Location = new System.Drawing.Point(3, 58);
            this.awayCombobox.Name = "awayCombobox";
            this.awayCombobox.Size = new System.Drawing.Size(103, 21);
            this.awayCombobox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Izračunaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // overallResult
            // 
            this.overallResult.AutoSize = true;
            this.overallResult.Location = new System.Drawing.Point(99, 119);
            this.overallResult.Name = "overallResult";
            this.overallResult.Size = new System.Drawing.Size(35, 13);
            this.overallResult.TabIndex = 3;
            this.overallResult.Text = "label1";
            this.overallResult.Visible = false;
            // 
            // homeWins
            // 
            this.homeWins.Location = new System.Drawing.Point(112, 18);
            this.homeWins.Name = "homeWins";
            this.homeWins.Size = new System.Drawing.Size(100, 20);
            this.homeWins.TabIndex = 4;
            // 
            // homeForm
            // 
            this.homeForm.Location = new System.Drawing.Point(221, 18);
            this.homeForm.Name = "homeForm";
            this.homeForm.Size = new System.Drawing.Size(100, 20);
            this.homeForm.TabIndex = 5;
            // 
            // awayWins
            // 
            this.awayWins.Location = new System.Drawing.Point(112, 58);
            this.awayWins.Name = "awayWins";
            this.awayWins.Size = new System.Drawing.Size(100, 20);
            this.awayWins.TabIndex = 6;
            // 
            // awayForm
            // 
            this.awayForm.Location = new System.Drawing.Point(221, 58);
            this.awayForm.Name = "awayForm";
            this.awayForm.Size = new System.Drawing.Size(100, 20);
            this.awayForm.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.Controls.Add(this.awayCombobox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.awayWins, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.awayForm, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.homeForm, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.homeWins, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.homeCombobox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(345, 96);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Forma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label3.Location = new System.Drawing.Point(112, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Broj pobjeda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Domacin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GamePrediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 319);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.overallResult);
            this.Controls.Add(this.button1);
            this.Name = "GamePrediction";
            this.Text = "Predvidi rezultat";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox homeCombobox;
        private System.Windows.Forms.ComboBox awayCombobox;
        private System.Windows.Forms.Label overallResult;
        private System.Windows.Forms.TextBox homeWins;
        private System.Windows.Forms.TextBox homeForm;
        private System.Windows.Forms.TextBox awayWins;
        private System.Windows.Forms.TextBox awayForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button1;
    }
}

