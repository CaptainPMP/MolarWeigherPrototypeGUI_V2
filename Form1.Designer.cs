
namespace MolarWeigherPrototypeGUI_V2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OutputMol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RawEleBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.ListBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ClearBTN = new MolarWeigherPrototypeGUI_V2.RoundedButton();
            this.Calc = new MolarWeigherPrototypeGUI_V2.RoundedButton();
            this.FloatBTN = new MolarWeigherPrototypeGUI_V2.RoundedButton();
            this.IntBTN = new MolarWeigherPrototypeGUI_V2.RoundedButton();
            this.SuspendLayout();
            // 
            // OutputMol
            // 
            this.OutputMol.AutoSize = true;
            this.OutputMol.Font = new System.Drawing.Font("supermarket", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.OutputMol.Location = new System.Drawing.Point(249, 19);
            this.OutputMol.Name = "OutputMol";
            this.OutputMol.Size = new System.Drawing.Size(157, 223);
            this.OutputMol.TabIndex = 0;
            this.OutputMol.Text = "0";
            this.OutputMol.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("supermarket", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(623, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 172);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mol";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RawEleBox
            // 
            this.RawEleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RawEleBox.Location = new System.Drawing.Point(76, 245);
            this.RawEleBox.Name = "RawEleBox";
            this.RawEleBox.Size = new System.Drawing.Size(741, 87);
            this.RawEleBox.TabIndex = 2;
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("supermarket", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.portBox.FormattingEnabled = true;
            this.portBox.ItemHeight = 69;
            this.portBox.Location = new System.Drawing.Point(919, 44);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(254, 142);
            this.portBox.TabIndex = 7;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("supermarket", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(877, 378);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(133, 45);
            this.ErrorLabel.TabIndex = 8;
            this.ErrorLabel.Text = "Error : None";
            // 
            // ClearBTN
            // 
            this.ClearBTN.BackColor = System.Drawing.Color.White;
            this.ClearBTN.Font = new System.Drawing.Font("supermarket", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ClearBTN.ForeColor = System.Drawing.Color.Red;
            this.ClearBTN.Location = new System.Drawing.Point(1019, 483);
            this.ClearBTN.Name = "ClearBTN";
            this.ClearBTN.Size = new System.Drawing.Size(154, 74);
            this.ClearBTN.TabIndex = 12;
            this.ClearBTN.Text = "Clear";
            this.ClearBTN.UseVisualStyleBackColor = false;
            this.ClearBTN.Click += new System.EventHandler(this.ClearBTN_Click_1);
            // 
            // Calc
            // 
            this.Calc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Calc.Font = new System.Drawing.Font("supermarket", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Calc.Location = new System.Drawing.Point(838, 245);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(185, 87);
            this.Calc.TabIndex = 11;
            this.Calc.Text = "แปลงค่า";
            this.Calc.UseVisualStyleBackColor = false;
            this.Calc.Click += new System.EventHandler(this.Calc_Click_1);
            // 
            // FloatBTN
            // 
            this.FloatBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.FloatBTN.Font = new System.Drawing.Font("supermarket", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FloatBTN.Location = new System.Drawing.Point(479, 364);
            this.FloatBTN.Name = "FloatBTN";
            this.FloatBTN.Size = new System.Drawing.Size(338, 113);
            this.FloatBTN.TabIndex = 10;
            this.FloatBTN.Text = "คำนวณโหมดทศนิยม";
            this.FloatBTN.UseVisualStyleBackColor = false;
            this.FloatBTN.Click += new System.EventHandler(this.FloatBTN_Click_1);
            // 
            // IntBTN
            // 
            this.IntBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.IntBTN.Font = new System.Drawing.Font("supermarket", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IntBTN.Location = new System.Drawing.Point(76, 364);
            this.IntBTN.Name = "IntBTN";
            this.IntBTN.Size = new System.Drawing.Size(374, 113);
            this.IntBTN.TabIndex = 9;
            this.IntBTN.Text = "คำนวณโหมดจำนวนเต็ม";
            this.IntBTN.UseVisualStyleBackColor = false;
            this.IntBTN.Click += new System.EventHandler(this.IntBTN_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 583);
            this.Controls.Add(this.ClearBTN);
            this.Controls.Add(this.Calc);
            this.Controls.Add(this.FloatBTN);
            this.Controls.Add(this.IntBTN);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.RawEleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputMol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MolarWeigher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OutputMol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox RawEleBox;
        private System.Windows.Forms.ListBox portBox;
        private System.Windows.Forms.Label ErrorLabel;
        private RoundedButton IntBTN;
        private RoundedButton FloatBTN;
        private RoundedButton Calc;
        private RoundedButton ClearBTN;
    }
}

