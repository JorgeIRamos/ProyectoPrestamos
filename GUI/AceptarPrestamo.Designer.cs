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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROPOSITO DEL PRESTAMO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(102, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "TIPO DE PAGO";
            // 
            // txtproposito
            // 
            this.txtproposito.BackColor = System.Drawing.Color.Gainsboro;
            this.txtproposito.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproposito.ForeColor = System.Drawing.Color.Black;
            this.txtproposito.Location = new System.Drawing.Point(214, 115);
            this.txtproposito.Name = "txtproposito";
            this.txtproposito.Size = new System.Drawing.Size(203, 22);
            this.txtproposito.TabIndex = 2;
            // 
            // txtpago
            // 
            this.txtpago.BackColor = System.Drawing.Color.Gainsboro;
            this.txtpago.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpago.ForeColor = System.Drawing.Color.Black;
            this.txtpago.Location = new System.Drawing.Point(214, 180);
            this.txtpago.Name = "txtpago";
            this.txtpago.Size = new System.Drawing.Size(203, 22);
            this.txtpago.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(116, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "CONFIRMAR PRESTAMO";
            // 
            // btnfinalizar
            // 
            this.btnfinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(209)))));
            this.btnfinalizar.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfinalizar.ForeColor = System.Drawing.Color.Transparent;
            this.btnfinalizar.Location = new System.Drawing.Point(177, 239);
            this.btnfinalizar.Name = "btnfinalizar";
            this.btnfinalizar.Size = new System.Drawing.Size(112, 34);
            this.btnfinalizar.TabIndex = 5;
            this.btnfinalizar.Text = "FINALIZAR";
            this.btnfinalizar.UseVisualStyleBackColor = false;
            this.btnfinalizar.Click += new System.EventHandler(this.btnfinalizar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(47)))), ((int)(((byte)(74)))));
            this.panel1.Location = new System.Drawing.Point(-19, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 12);
            this.panel1.TabIndex = 6;
            // 
            // AceptarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(492, 386);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.Panel panel1;
    }
}