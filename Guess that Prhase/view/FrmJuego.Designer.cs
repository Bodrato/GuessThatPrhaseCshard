namespace Guess_that_Prhase.view
{
    partial class FrmJuego
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblFraseSecreta = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.txtFrase = new System.Windows.Forms.TextBox();
            this.btnLetra = new System.Windows.Forms.Button();
            this.btnFrase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTurno.ForeColor = System.Drawing.Color.Teal;
            this.lblTurno.Location = new System.Drawing.Point(89, 28);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(0, 21);
            this.lblTurno.TabIndex = 1;
            // 
            // lblFraseSecreta
            // 
            this.lblFraseSecreta.AutoSize = true;
            this.lblFraseSecreta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFraseSecreta.ForeColor = System.Drawing.Color.Teal;
            this.lblFraseSecreta.Location = new System.Drawing.Point(187, 67);
            this.lblFraseSecreta.Name = "lblFraseSecreta";
            this.lblFraseSecreta.Size = new System.Drawing.Size(0, 21);
            this.lblFraseSecreta.TabIndex = 2;
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(164, 218);
            this.txtLetra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(23, 23);
            this.txtLetra.TabIndex = 3;
            // 
            // txtFrase
            // 
            this.txtFrase.Location = new System.Drawing.Point(353, 218);
            this.txtFrase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFrase.Name = "txtFrase";
            this.txtFrase.Size = new System.Drawing.Size(232, 23);
            this.txtFrase.TabIndex = 4;
            // 
            // btnLetra
            // 
            this.btnLetra.BackColor = System.Drawing.Color.Green;
            this.btnLetra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLetra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLetra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLetra.Location = new System.Drawing.Point(137, 272);
            this.btnLetra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLetra.Name = "btnLetra";
            this.btnLetra.Size = new System.Drawing.Size(82, 22);
            this.btnLetra.TabIndex = 5;
            this.btnLetra.Text = "Enviar";
            this.btnLetra.UseVisualStyleBackColor = false;
            this.btnLetra.Click += new System.EventHandler(this.btnLetra_Click);
            // 
            // btnFrase
            // 
            this.btnFrase.BackColor = System.Drawing.Color.Green;
            this.btnFrase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFrase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrase.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFrase.Location = new System.Drawing.Point(435, 272);
            this.btnFrase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFrase.Name = "btnFrase";
            this.btnFrase.Size = new System.Drawing.Size(82, 22);
            this.btnFrase.TabIndex = 6;
            this.btnFrase.Text = "Enviar";
            this.btnFrase.UseVisualStyleBackColor = false;
            this.btnFrase.Click += new System.EventHandler(this.btnFrase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(187, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 7;
            // 
            // FrmJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFrase);
            this.Controls.Add(this.btnLetra);
            this.Controls.Add(this.txtFrase);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.lblFraseSecreta);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmJuego";
            this.Text = "Guess that Prhase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lblTurno;
        private Label lblFraseSecreta;
        private TextBox txtLetra;
        private TextBox txtFrase;
        private Button btnLetra;
        private Button btnFrase;
        private Label label2;
    }
}