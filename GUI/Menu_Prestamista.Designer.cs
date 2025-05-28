namespace GUI
{
    partial class Menu_Prestamista
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
            this.pnlmenu = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btninicio = new System.Windows.Forms.Button();
            this.btnrecordatorios = new System.Windows.Forms.Button();
            this.btnconsultarprestamos = new System.Windows.Forms.Button();
            this.btncrearprestamo = new System.Windows.Forms.Button();
            this.pnlinicio = new System.Windows.Forms.Panel();
            this.labeluser = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlconsultarprestamo = new System.Windows.Forms.Panel();
            this.dgvDatosPrestamos = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlcrearprestamo = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btncrear = new System.Windows.Forms.Button();
            this.txtplazo = new System.Windows.Forms.TextBox();
            this.txtintereses = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlmenu.SuspendLayout();
            this.pnlinicio.SuspendLayout();
            this.pnlconsultarprestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPrestamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlcrearprestamo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlmenu
            // 
            this.pnlmenu.BackColor = System.Drawing.Color.LightGray;
            this.pnlmenu.Controls.Add(this.pictureBox1);
            this.pnlmenu.Controls.Add(this.button5);
            this.pnlmenu.Controls.Add(this.btninicio);
            this.pnlmenu.Controls.Add(this.btnrecordatorios);
            this.pnlmenu.Controls.Add(this.btnconsultarprestamos);
            this.pnlmenu.Controls.Add(this.btncrearprestamo);
            this.pnlmenu.Location = new System.Drawing.Point(-1, -5);
            this.pnlmenu.Name = "pnlmenu";
            this.pnlmenu.Size = new System.Drawing.Size(1031, 63);
            this.pnlmenu.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(849, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 42);
            this.button5.TabIndex = 5;
            this.button5.Text = "Salir";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btninicio
            // 
            this.btninicio.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninicio.Location = new System.Drawing.Point(190, 12);
            this.btninicio.Name = "btninicio";
            this.btninicio.Size = new System.Drawing.Size(159, 42);
            this.btninicio.TabIndex = 3;
            this.btninicio.Text = "Inicio";
            this.btninicio.UseVisualStyleBackColor = true;
            this.btninicio.Click += new System.EventHandler(this.btninicio_Click);
            // 
            // btnrecordatorios
            // 
            this.btnrecordatorios.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrecordatorios.Location = new System.Drawing.Point(684, 11);
            this.btnrecordatorios.Name = "btnrecordatorios";
            this.btnrecordatorios.Size = new System.Drawing.Size(159, 42);
            this.btnrecordatorios.TabIndex = 2;
            this.btnrecordatorios.Text = "Recordatorios";
            this.btnrecordatorios.UseVisualStyleBackColor = true;
            // 
            // btnconsultarprestamos
            // 
            this.btnconsultarprestamos.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconsultarprestamos.Location = new System.Drawing.Point(519, 12);
            this.btnconsultarprestamos.Name = "btnconsultarprestamos";
            this.btnconsultarprestamos.Size = new System.Drawing.Size(159, 42);
            this.btnconsultarprestamos.TabIndex = 1;
            this.btnconsultarprestamos.Text = "Consultar Prestamos";
            this.btnconsultarprestamos.UseVisualStyleBackColor = true;
            this.btnconsultarprestamos.Click += new System.EventHandler(this.btnconsultarprestamos_Click);
            // 
            // btncrearprestamo
            // 
            this.btncrearprestamo.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncrearprestamo.Location = new System.Drawing.Point(354, 12);
            this.btncrearprestamo.Name = "btncrearprestamo";
            this.btncrearprestamo.Size = new System.Drawing.Size(159, 42);
            this.btncrearprestamo.TabIndex = 0;
            this.btncrearprestamo.Text = "Crear Prestamo";
            this.btncrearprestamo.UseVisualStyleBackColor = true;
            this.btncrearprestamo.Click += new System.EventHandler(this.btncrearprestamo_Click);
            // 
            // pnlinicio
            // 
            this.pnlinicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.pnlinicio.BackgroundImage = global::GUI.Properties.Resources.Background_color;
            this.pnlinicio.Controls.Add(this.labeluser);
            this.pnlinicio.Controls.Add(this.label9);
            this.pnlinicio.Location = new System.Drawing.Point(131, 74);
            this.pnlinicio.Name = "pnlinicio";
            this.pnlinicio.Size = new System.Drawing.Size(811, 569);
            this.pnlinicio.TabIndex = 3;
            // 
            // labeluser
            // 
            this.labeluser.AutoSize = true;
            this.labeluser.BackColor = System.Drawing.Color.Transparent;
            this.labeluser.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeluser.ForeColor = System.Drawing.Color.White;
            this.labeluser.Location = new System.Drawing.Point(132, 207);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(163, 80);
            this.labeluser.TabIndex = 5;
            this.labeluser.Text = "USER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(130, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(543, 28);
            this.label9.TabIndex = 1;
            this.label9.Text = "SE ENCUENTRA EN EL MENU PARA PRESTAMISTA";
            // 
            // pnlconsultarprestamo
            // 
            this.pnlconsultarprestamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.pnlconsultarprestamo.BackgroundImage = global::GUI.Properties.Resources.Background_color;
            this.pnlconsultarprestamo.Controls.Add(this.dgvDatosPrestamos);
            this.pnlconsultarprestamo.Controls.Add(this.label13);
            this.pnlconsultarprestamo.Location = new System.Drawing.Point(128, 69);
            this.pnlconsultarprestamo.Name = "pnlconsultarprestamo";
            this.pnlconsultarprestamo.Size = new System.Drawing.Size(814, 574);
            this.pnlconsultarprestamo.TabIndex = 2;
            // 
            // dgvDatosPrestamos
            // 
            this.dgvDatosPrestamos.AllowUserToAddRows = false;
            this.dgvDatosPrestamos.AllowUserToDeleteRows = false;
            this.dgvDatosPrestamos.AllowUserToResizeColumns = false;
            this.dgvDatosPrestamos.AllowUserToResizeRows = false;
            this.dgvDatosPrestamos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.dgvDatosPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosPrestamos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.dgvDatosPrestamos.Location = new System.Drawing.Point(99, 111);
            this.dgvDatosPrestamos.Name = "dgvDatosPrestamos";
            this.dgvDatosPrestamos.Size = new System.Drawing.Size(645, 449);
            this.dgvDatosPrestamos.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label13.Location = new System.Drawing.Point(187, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(465, 60);
            this.label13.TabIndex = 0;
            this.label13.Text = "CONSULTAR PRESTAMO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.Logo_PresTech;
            this.pictureBox1.Location = new System.Drawing.Point(13, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pnlcrearprestamo
            // 
            this.pnlcrearprestamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.pnlcrearprestamo.BackgroundImage = global::GUI.Properties.Resources.Background_color;
            this.pnlcrearprestamo.Controls.Add(this.panel7);
            this.pnlcrearprestamo.Controls.Add(this.panel4);
            this.pnlcrearprestamo.Controls.Add(this.panel3);
            this.pnlcrearprestamo.Controls.Add(this.panel2);
            this.pnlcrearprestamo.Controls.Add(this.btncrear);
            this.pnlcrearprestamo.Controls.Add(this.txtplazo);
            this.pnlcrearprestamo.Controls.Add(this.txtintereses);
            this.pnlcrearprestamo.Controls.Add(this.txtcantidad);
            this.pnlcrearprestamo.Controls.Add(this.label5);
            this.pnlcrearprestamo.Controls.Add(this.label4);
            this.pnlcrearprestamo.Controls.Add(this.label3);
            this.pnlcrearprestamo.Controls.Add(this.label2);
            this.pnlcrearprestamo.Location = new System.Drawing.Point(128, 69);
            this.pnlcrearprestamo.Name = "pnlcrearprestamo";
            this.pnlcrearprestamo.Size = new System.Drawing.Size(814, 574);
            this.pnlcrearprestamo.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(189)))), ((int)(((byte)(229)))));
            this.panel7.Location = new System.Drawing.Point(118, 148);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(607, 1);
            this.panel7.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel4.Location = new System.Drawing.Point(289, 303);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(316, 1);
            this.panel4.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel3.Location = new System.Drawing.Point(289, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 1);
            this.panel3.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.Location = new System.Drawing.Point(289, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 1);
            this.panel2.TabIndex = 18;
            // 
            // btncrear
            // 
            this.btncrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.btncrear.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncrear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btncrear.Location = new System.Drawing.Point(316, 359);
            this.btncrear.Name = "btncrear";
            this.btncrear.Size = new System.Drawing.Size(186, 39);
            this.btncrear.TabIndex = 13;
            this.btncrear.Text = "CREAR PRESTAMO";
            this.btncrear.UseVisualStyleBackColor = false;
            this.btncrear.Click += new System.EventHandler(this.btncrear_Click);
            // 
            // txtplazo
            // 
            this.txtplazo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.txtplazo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtplazo.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtplazo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtplazo.Location = new System.Drawing.Point(289, 282);
            this.txtplazo.Name = "txtplazo";
            this.txtplazo.Size = new System.Drawing.Size(316, 15);
            this.txtplazo.TabIndex = 8;
            // 
            // txtintereses
            // 
            this.txtintereses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.txtintereses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtintereses.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtintereses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtintereses.Location = new System.Drawing.Point(289, 240);
            this.txtintereses.Name = "txtintereses";
            this.txtintereses.Size = new System.Drawing.Size(316, 15);
            this.txtintereses.TabIndex = 7;
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.txtcantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcantidad.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtcantidad.Location = new System.Drawing.Point(289, 199);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(316, 15);
            this.txtcantidad.TabIndex = 6;
            this.txtcantidad.TextChanged += new System.EventHandler(this.txtcantidad_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(215, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "PLAZO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(191, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "INTERESES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(191, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "CANTIDAD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(238, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 60);
            this.label2.TabIndex = 0;
            this.label2.Text = "CREAR PRESTAMO";
            // 
            // Menu_Prestamista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1029, 687);
            this.Controls.Add(this.pnlinicio);
            this.Controls.Add(this.pnlcrearprestamo);
            this.Controls.Add(this.pnlconsultarprestamo);
            this.Controls.Add(this.pnlmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu_Prestamista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Prestamista";
            this.pnlmenu.ResumeLayout(false);
            this.pnlinicio.ResumeLayout(false);
            this.pnlinicio.PerformLayout();
            this.pnlconsultarprestamo.ResumeLayout(false);
            this.pnlconsultarprestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPrestamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlcrearprestamo.ResumeLayout(false);
            this.pnlcrearprestamo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlmenu;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btninicio;
        private System.Windows.Forms.Button btnrecordatorios;
        private System.Windows.Forms.Button btnconsultarprestamos;
        private System.Windows.Forms.Button btncrearprestamo;
        private System.Windows.Forms.Panel pnlcrearprestamo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtplazo;
        private System.Windows.Forms.TextBox txtintereses;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Button btncrear;
        private System.Windows.Forms.Panel pnlconsultarprestamo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlinicio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvDatosPrestamos;
    }
}