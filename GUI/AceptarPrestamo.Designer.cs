namespace GUI
{
    partial class AceptarPrestamo
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtproposito = new System.Windows.Forms.TextBox();
            this.txtpago = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnfinalizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROPOSITO DEL PRESTAMO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(86, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TIPO DE PAGO";
            // 
            // txtproposito
            // 
            this.txtproposito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(54)))), ((int)(((byte)(132)))));
            this.txtproposito.ForeColor = System.Drawing.Color.Transparent;
            this.txtproposito.Location = new System.Drawing.Point(193, 98);
            this.txtproposito.Name = "txtproposito";
            this.txtproposito.Size = new System.Drawing.Size(203, 20);
            this.txtproposito.TabIndex = 2;
            // 
            // txtpago
            // 
            this.txtpago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(54)))), ((int)(((byte)(132)))));
            this.txtpago.ForeColor = System.Drawing.Color.Transparent;
            this.txtpago.Location = new System.Drawing.Point(193, 163);
            this.txtpago.Name = "txtpago";
            this.txtpago.Size = new System.Drawing.Size(203, 20);
            this.txtpago.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(181, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CONFIRMAR PRESTAMO";
            // 
            // btnfinalizar
            // 
            this.btnfinalizar.Location = new System.Drawing.Point(202, 240);
            this.btnfinalizar.Name = "btnfinalizar";
            this.btnfinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnfinalizar.TabIndex = 5;
            this.btnfinalizar.Text = "FINALIZAR";
            this.btnfinalizar.UseVisualStyleBackColor = true;
            this.btnfinalizar.Click += new System.EventHandler(this.btnfinalizar_Click);
            // 
            // AceptarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(54)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(492, 386);
            this.Controls.Add(this.btnfinalizar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpago);
            this.Controls.Add(this.txtproposito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AceptarPrestamo";
            this.Text = "AceptarPrestamo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtproposito;
        private System.Windows.Forms.TextBox txtpago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnfinalizar;
    }
}