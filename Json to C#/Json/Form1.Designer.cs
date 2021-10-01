
namespace Json
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
            this.btnReadData = new System.Windows.Forms.Button();
            this.btnCsharpStyle = new System.Windows.Forms.Button();
            this.btnWebStyle = new System.Windows.Forms.Button();
            this.btnNewtonStyle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(27, 23);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(75, 23);
            this.btnReadData.TabIndex = 0;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnCsharpStyle
            // 
            this.btnCsharpStyle.Location = new System.Drawing.Point(27, 52);
            this.btnCsharpStyle.Name = "btnCsharpStyle";
            this.btnCsharpStyle.Size = new System.Drawing.Size(94, 40);
            this.btnCsharpStyle.TabIndex = 1;
            this.btnCsharpStyle.Text = "C# style Serialization";
            this.btnCsharpStyle.UseVisualStyleBackColor = true;
            this.btnCsharpStyle.Click += new System.EventHandler(this.btnCsharpStyle_Click);
            // 
            // btnWebStyle
            // 
            this.btnWebStyle.Location = new System.Drawing.Point(27, 98);
            this.btnWebStyle.Name = "btnWebStyle";
            this.btnWebStyle.Size = new System.Drawing.Size(94, 40);
            this.btnWebStyle.TabIndex = 2;
            this.btnWebStyle.Text = "Web Style Serialization";
            this.btnWebStyle.UseVisualStyleBackColor = true;
            this.btnWebStyle.Click += new System.EventHandler(this.btnWebStyle_Click);
            // 
            // btnNewtonStyle
            // 
            this.btnNewtonStyle.Location = new System.Drawing.Point(27, 144);
            this.btnNewtonStyle.Name = "btnNewtonStyle";
            this.btnNewtonStyle.Size = new System.Drawing.Size(94, 45);
            this.btnNewtonStyle.TabIndex = 3;
            this.btnNewtonStyle.Text = "Newton Style Serializatoin";
            this.btnNewtonStyle.UseVisualStyleBackColor = true;
            this.btnNewtonStyle.Click += new System.EventHandler(this.btnNewtonStyle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNewtonStyle);
            this.Controls.Add(this.btnWebStyle);
            this.Controls.Add(this.btnCsharpStyle);
            this.Controls.Add(this.btnReadData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Button btnCsharpStyle;
        private System.Windows.Forms.Button btnWebStyle;
        private System.Windows.Forms.Button btnNewtonStyle;
        private System.Windows.Forms.Button button1;
    }
}

