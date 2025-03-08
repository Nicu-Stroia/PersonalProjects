namespace Macao
{
    partial class GamePlaceForm
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
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.RebuildDrawDeckButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Label.Location = new System.Drawing.Point(264, 199);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(120, 22);
            this.Player1Label.TabIndex = 1;
            this.Player1Label.Text = "Player1 cards";
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Label.Location = new System.Drawing.Point(264, 850);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(120, 22);
            this.Player2Label.TabIndex = 2;
            this.Player2Label.Text = "Player2 cards";
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(1663, 394);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(188, 75);
            this.DrawButton.TabIndex = 4;
            this.DrawButton.Text = "Click to draw a Card";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // RebuildDrawDeckButton
            // 
            this.RebuildDrawDeckButton.Location = new System.Drawing.Point(1663, 516);
            this.RebuildDrawDeckButton.Name = "RebuildDrawDeckButton";
            this.RebuildDrawDeckButton.Size = new System.Drawing.Size(188, 75);
            this.RebuildDrawDeckButton.TabIndex = 5;
            this.RebuildDrawDeckButton.Text = "Click to rebuild draw deck";
            this.RebuildDrawDeckButton.UseVisualStyleBackColor = true;
            this.RebuildDrawDeckButton.Click += new System.EventHandler(this.RebuildDrawDeckButton_Click);
            // 
            // GamePlaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.RebuildDrawDeckButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GamePlaceForm";
            this.Text = "Welcome to macao game!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GamePlaceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button RebuildDrawDeckButton;
    }
}