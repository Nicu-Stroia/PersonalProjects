namespace Macao
{
    partial class ChooseColorForm
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
            this.ClubButton = new System.Windows.Forms.Button();
            this.DiamondButton = new System.Windows.Forms.Button();
            this.HeartButton = new System.Windows.Forms.Button();
            this.SpadeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClubButton
            // 
            this.ClubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClubButton.Location = new System.Drawing.Point(61, 177);
            this.ClubButton.Name = "ClubButton";
            this.ClubButton.Size = new System.Drawing.Size(96, 52);
            this.ClubButton.TabIndex = 0;
            this.ClubButton.Text = "Club";
            this.ClubButton.UseVisualStyleBackColor = true;
            this.ClubButton.Click += new System.EventHandler(this.ClubButton_Click);
            // 
            // DiamondButton
            // 
            this.DiamondButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiamondButton.Location = new System.Drawing.Point(242, 177);
            this.DiamondButton.Name = "DiamondButton";
            this.DiamondButton.Size = new System.Drawing.Size(116, 52);
            this.DiamondButton.TabIndex = 1;
            this.DiamondButton.Text = "Diamond";
            this.DiamondButton.UseVisualStyleBackColor = true;
            this.DiamondButton.Click += new System.EventHandler(this.DiamondButton_Click);
            // 
            // HeartButton
            // 
            this.HeartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartButton.Location = new System.Drawing.Point(425, 177);
            this.HeartButton.Name = "HeartButton";
            this.HeartButton.Size = new System.Drawing.Size(96, 52);
            this.HeartButton.TabIndex = 2;
            this.HeartButton.Text = "Heart";
            this.HeartButton.UseVisualStyleBackColor = true;
            this.HeartButton.Click += new System.EventHandler(this.HeartButton_Click);
            // 
            // SpadeButton
            // 
            this.SpadeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpadeButton.Location = new System.Drawing.Point(607, 177);
            this.SpadeButton.Name = "SpadeButton";
            this.SpadeButton.Size = new System.Drawing.Size(96, 52);
            this.SpadeButton.TabIndex = 3;
            this.SpadeButton.Text = "Spade";
            this.SpadeButton.UseVisualStyleBackColor = true;
            this.SpadeButton.Click += new System.EventHandler(this.SpadeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose the color you want change";
            // 
            // ChooseColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 345);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpadeButton);
            this.Controls.Add(this.HeartButton);
            this.Controls.Add(this.DiamondButton);
            this.Controls.Add(this.ClubButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseColorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseColor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClubButton;
        private System.Windows.Forms.Button DiamondButton;
        private System.Windows.Forms.Button HeartButton;
        private System.Windows.Forms.Button SpadeButton;
        private System.Windows.Forms.Label label1;
    }
}