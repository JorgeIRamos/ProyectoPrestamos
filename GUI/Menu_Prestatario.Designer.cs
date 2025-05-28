namespace GUI
{
    partial class Menu_Prestatario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlmenu = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btninicio = new System.Windows.Forms.Button();
            this.btnrecordatorios = new System.Windows.Forms.Button();
            this.btnmisprestamos = new System.Windows.Forms.Button();
            this.btnofertaprestamo = new System.Windows.Forms.Button();
            this.pnlofertasprestamo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDatosPrestamos = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlprestamosactivos = new System.Windows.Forms.Panel();
            this.dgvPrestamosActivos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlinicio = new System.Windows.Forms.Panel();
            this.labeluser = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlmenu.SuspendLayout();
            this.pnlofertasprestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPrestamos)).BeginInit();
            this.pnlprestamosactivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).BeginInit();
            this.pnlinicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlmenu
            // 
            this.pnlmenu.BackColor = System.Drawing.Color.LightGray;
            this.pnlmenu.Controls.Add(this.pictureBox1);
            this.pnlmenu.Controls.Add(this.button5);
            this.pnlmenu.Controls.Add(this.btninicio);
            this.pnlmenu.Controls.Add(this.btnrecordatorios);
            this.pnlmenu.Controls.Add(this.btnmisprestamos);
            this.pnlmenu.Controls.Add(this.btnofertaprestamo);
            this.pnlmenu.Location = new System.Drawing.Point(0, 0);
            this.pnlmenu.Name = "pnlmenu";
            this.pnlmenu.Size = new System.Drawing.Size(1031, 63);
            this.pnlmenu.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(849, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 42);
            this.button5.TabIndex = 5;
            this.button5.Text = "Salir";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btninicio
            // 
            this.btninicio.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninicio.ForeColor = System.Drawing.Color.Black;
            this.btninicio.Location = new System.Drawing.Point(190, 12);
            this.btninicio.Name = "btninicio";
            this.btninicio.Size = new System.Drawing.Size(159, 42);
            this.btninicio.TabIndex = 3;
            this.btninicio.Text = "Inicio";
            this.btninicio.UseVisualStyleBackColor = true;
            // 
            // btnrecordatorios
            // 
            this.btnrecordatorios.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrecordatorios.ForeColor = System.Drawing.Color.Black;
            this.btnrecordatorios.Location = new System.Drawing.Point(684, 11);
            this.btnrecordatorios.Name = "btnrecordatorios";
            this.btnrecordatorios.Size = new System.Drawing.Size(159, 42);
            this.btnrecordatorios.TabIndex = 2;
            this.btnrecordatorios.Text = "Notificaciones";
            this.btnrecordatorios.UseVisualStyleBackColor = true;
            // 
            // btnmisprestamos
            // 
            this.btnmisprestamos.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmisprestamos.ForeColor = System.Drawing.Color.Black;
            this.btnmisprestamos.Location = new System.Drawing.Point(519, 12);
            this.btnmisprestamos.Name = "btnmisprestamos";
            this.btnmisprestamos.Size = new System.Drawing.Size(159, 42);
            this.btnmisprestamos.TabIndex = 1;
            this.btnmisprestamos.Text = "Mis prestamos";
            this.btnmisprestamos.UseVisualStyleBackColor = true;
            this.btnmisprestamos.Click += new System.EventHandler(this.btnprestamosactivos_Click);
            // 
            // btnofertaprestamo
            // 
            this.btnofertaprestamo.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnofertaprestamo.ForeColor = System.Drawing.Color.Black;
            this.btnofertaprestamo.Location = new System.Drawing.Point(354, 12);
            this.btnofertaprestamo.Name = "btnofertaprestamo";
            this.btnofertaprestamo.Size = new System.Drawing.Size(159, 42);
            this.btnofertaprestamo.TabIndex = 0;
            this.btnofertaprestamo.Text = "Ofertas de prestamo";
            this.btnofertaprestamo.UseVisualStyleBackColor = true;
            this.btnofertaprestamo.Click += new System.EventHandler(this.btnofertasprestamo_Click);
            // 
            // pnlofertasprestamo
            // 
            this.pnlofertasprestamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.pnlofertasprestamo.BackgroundImage = global::GUI.Properties.Resources.Background_color;
            this.pnlofertasprestamo.Controls.Add(this.button1);
            this.pnlofertasprestamo.Controls.Add(this.dgvDatosPrestamos);
            this.pnlofertasprestamo.Controls.Add(this.label13);
            this.pnlofertasprestamo.Location = new System.Drawing.Point(104, 81);
            this.pnlofertasprestamo.Name = "pnlofertasprestamo";
            this.pnlofertasprestamo.Size = new System.Drawing.Size(814, 574);
            this.pnlofertasprestamo.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(328, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "ACEPTAR PRESTAMO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnaceptaroferta_Click);
            // 
            // dgvDatosPrestamos
            // 
            this.dgvDatosPrestamos.AllowUserToAddRows = false;
            this.dgvDatosPrestamos.AllowUserToDeleteRows = false;
            this.dgvDatosPrestamos.AllowUserToResizeColumns = false;
            this.dgvDatosPrestamos.AllowUserToResizeRows = false;
            this.dgvDatosPrestamos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.dgvDatosPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatosPrestamos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatosPrestamos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.dgvDatosPrestamos.Location = new System.Drawing.Point(92, 74);
            this.dgvDatosPrestamos.MultiSelect = false;
            this.dgvDatosPrestamos.Name = "dgvDatosPrestamos";
            this.dgvDatosPrestamos.ReadOnly = true;
            this.dgvDatosPrestamos.Size = new System.Drawing.Size(645, 449);
            this.dgvDatosPrestamos.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label13.Location = new System.Drawing.Point(240, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(347, 43);
            this.label13.TabIndex = 0;
            this.label13.Text = "OFERTAS DE PRESTAMO";
            // 
            // pnlprestamosactivos
            // 
            this.pnlprestamosactivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.pnlprestamosactivos.BackgroundImage = global::GUI.Properties.Resources.Background_color;
            this.pnlprestamosactivos.Controls.Add(this.dgvPrestamosActivos);
            this.pnlprestamosactivos.Controls.Add(this.label1);
            this.pnlprestamosactivos.Location = new System.Drawing.Point(103, 81);
            this.pnlprestamosactivos.Name = "pnlprestamosactivos";
            this.pnlprestamosactivos.Size = new System.Drawing.Size(814, 574);
            this.pnlprestamosactivos.TabIndex = 6;
            // 
            // dgvPrestamosActivos
            // 
            this.dgvPrestamosActivos.AllowUserToAddRows = false;
            this.dgvPrestamosActivos.AllowUserToDeleteRows = false;
            this.dgvPrestamosActivos.AllowUserToResizeColumns = false;
            this.dgvPrestamosActivos.AllowUserToResizeRows = false;
            this.dgvPrestamosActivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.dgvPrestamosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrestamosActivos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrestamosActivos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(186)))), ((int)(((byte)(139)))));
            this.dgvPrestamosActivos.Location = new System.Drawing.Point(95, 91);
            this.dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            this.dgvPrestamosActivos.Size = new System.Drawing.Size(645, 449);
            this.dgvPrestamosActivos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(208, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "MIS PRESTAMOS ACTIVOS";
            // 
            // pnlinicio
            // 
            this.pnlinicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.pnlinicio.BackgroundImage = global::GUI.Properties.Resources.Background_color;
            this.pnlinicio.Controls.Add(this.labeluser);
            this.pnlinicio.Controls.Add(this.label9);
            this.pnlinicio.Location = new System.Drawing.Point(109, 84);
            this.pnlinicio.Name = "pnlinicio";
            this.pnlinicio.Size = new System.Drawing.Size(811, 569);
            this.pnlinicio.TabIndex = 4;
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
            this.label9.Size = new System.Drawing.Size(540, 28);
            this.label9.TabIndex = 1;
            this.label9.Text = "SE ENCUENTRA EN EL MENU PARA PRESTATARIO";
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
            // Menu_Prestatario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1029, 687);
            this.Controls.Add(this.pnlofertasprestamo);
            this.Controls.Add(this.pnlprestamosactivos);
            this.Controls.Add(this.pnlinicio);
            this.Controls.Add(this.pnlmenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu_Prestatario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Prestatario";
            this.pnlmenu.ResumeLayout(false);
            this.pnlofertasprestamo.ResumeLayout(false);
            this.pnlofertasprestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPrestamos)).EndInit();
            this.pnlprestamosactivos.ResumeLayout(false);
            this.pnlprestamosactivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).EndInit();
            this.pnlinicio.ResumeLayout(false);
            this.pnlinicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlmenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btninicio;
        private System.Windows.Forms.Button btnrecordatorios;
        private System.Windows.Forms.Button btnmisprestamos;
        private System.Windows.Forms.Button btnofertaprestamo;
        private System.Windows.Forms.Panel pnlinicio;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlofertasprestamo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvDatosPrestamos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlprestamosactivos;
        private System.Windows.Forms.DataGridView dgvPrestamosActivos;
        private System.Windows.Forms.Label label1;
    }
}