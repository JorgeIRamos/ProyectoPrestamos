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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AceptarPrestamo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtproposito = new System.Windows.Forms.TextBox();
            this.btnfinalizar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.boxtipopago = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
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
            this.txtproposito.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtproposito.ForeColor = System.Drawing.Color.Black;
            this.txtproposito.Location = new System.Drawing.Point(214, 115);
            this.txtproposito.Name = "txtproposito";
            this.txtproposito.Size = new System.Drawing.Size(203, 23);
            this.txtproposito.TabIndex = 2;
            // 
            // btnfinalizar
            // 
            this.btnfinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(209)))));
            this.btnfinalizar.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfinalizar.ForeColor = System.Drawing.Color.Transparent;
            this.btnfinalizar.Image = global::GUI.Properties.Resources.accept;
            this.btnfinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfinalizar.Location = new System.Drawing.Point(177, 236);
            this.btnfinalizar.Name = "btnfinalizar";
            this.btnfinalizar.Size = new System.Drawing.Size(127, 37);
            this.btnfinalizar.TabIndex = 5;
            this.btnfinalizar.Text = "FINALIZAR";
            this.btnfinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfinalizar.UseVisualStyleBackColor = false;
            this.btnfinalizar.Click += new System.EventHandler(this.btnfinalizar_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(47)))), ((int)(((byte)(74)))));
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(-303, -4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1099, 74);
            this.panel3.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Impact", 26.25F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(401, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(291, 43);
            this.label11.TabIndex = 0;
            this.label11.Text = "ACEPTAR PRESTAMO";
            // 
            // boxtipopago
            // 
            this.boxtipopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxtipopago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxtipopago.FormattingEnabled = true;
            this.boxtipopago.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia"});
            this.boxtipopago.Location = new System.Drawing.Point(215, 179);
            this.boxtipopago.Name = "boxtipopago";
            this.boxtipopago.Size = new System.Drawing.Size(202, 23);
            this.boxtipopago.TabIndex = 26;
            // 
            // AceptarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(492, 386);
            this.Controls.Add(this.boxtipopago);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnfinalizar);
            this.Controls.Add(this.txtproposito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AceptarPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aceptar Prestamo";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtproposito;
        private System.Windows.Forms.Button btnfinalizar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox boxtipopago;
    }
}