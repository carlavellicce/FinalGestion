namespace GD_Final_Baternoa.Liquidacion
{
    partial class PantallaLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaLiquidacion));
            this.label2 = new System.Windows.Forms.Label();
            this.comboCategoria = new System.Windows.Forms.ComboBox();
            this.comboEmpleado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAyP = new System.Windows.Forms.TextBox();
            this.txtCUIL = new System.Windows.Forms.TextBox();
            this.txtAnt = new System.Windows.Forms.TextBox();
            this.comboConceptos = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIDCon = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtfechaing = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBasico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHijos = new System.Windows.Forms.TextBox();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.comboAño = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CATEGORIA DE EMPLEADO";
            // 
            // comboCategoria
            // 
            this.comboCategoria.FormattingEnabled = true;
            this.comboCategoria.Location = new System.Drawing.Point(463, 22);
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(134, 21);
            this.comboCategoria.TabIndex = 3;
            this.comboCategoria.SelectedIndexChanged += new System.EventHandler(this.comboCategoria_SelectedIndexChanged);
            // 
            // comboEmpleado
            // 
            this.comboEmpleado.FormattingEnabled = true;
            this.comboEmpleado.Location = new System.Drawing.Point(463, 49);
            this.comboEmpleado.Name = "comboEmpleado";
            this.comboEmpleado.Size = new System.Drawing.Size(134, 21);
            this.comboEmpleado.TabIndex = 5;
            this.comboEmpleado.SelectedIndexChanged += new System.EventHandler(this.comboEmpleado_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "PERIODO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(270, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "EMPLEADO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "CONCEPTOS";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Location = new System.Drawing.Point(717, 690);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Apellido y Nombre";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(251, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "CUIL";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(251, 292);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Antiguedad";
            // 
            // txtAyP
            // 
            this.txtAyP.Location = new System.Drawing.Point(372, 211);
            this.txtAyP.Name = "txtAyP";
            this.txtAyP.ReadOnly = true;
            this.txtAyP.Size = new System.Drawing.Size(100, 20);
            this.txtAyP.TabIndex = 24;
            // 
            // txtCUIL
            // 
            this.txtCUIL.Location = new System.Drawing.Point(372, 237);
            this.txtCUIL.Name = "txtCUIL";
            this.txtCUIL.ReadOnly = true;
            this.txtCUIL.Size = new System.Drawing.Size(100, 20);
            this.txtCUIL.TabIndex = 25;
            // 
            // txtAnt
            // 
            this.txtAnt.Location = new System.Drawing.Point(372, 289);
            this.txtAnt.Name = "txtAnt";
            this.txtAnt.ReadOnly = true;
            this.txtAnt.Size = new System.Drawing.Size(100, 20);
            this.txtAnt.TabIndex = 27;
            // 
            // comboConceptos
            // 
            this.comboConceptos.FormattingEnabled = true;
            this.comboConceptos.Location = new System.Drawing.Point(115, 456);
            this.comboConceptos.Name = "comboConceptos";
            this.comboConceptos.Size = new System.Drawing.Size(121, 21);
            this.comboConceptos.TabIndex = 28;
            this.comboConceptos.SelectedIndexChanged += new System.EventHandler(this.comboConceptos_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 498);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "lD";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 550);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Valor";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 606);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Unidades";
            // 
            // txtIDCon
            // 
            this.txtIDCon.Location = new System.Drawing.Point(104, 495);
            this.txtIDCon.Name = "txtIDCon";
            this.txtIDCon.ReadOnly = true;
            this.txtIDCon.Size = new System.Drawing.Size(100, 20);
            this.txtIDCon.TabIndex = 32;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(104, 547);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 33;
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(104, 599);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(100, 20);
            this.txtUnidades.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(175, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(657, 625);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 23);
            this.button4.TabIndex = 36;
            this.button4.Text = "Eliminar Concepto";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Coral;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(511, 683);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 37);
            this.button5.TabIndex = 37;
            this.button5.Text = "Iniciar Liquidacion";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dgv
            // 
            this.dgv.AllowDrop = true;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion,
            this.Valor,
            this.Tipo});
            this.dgv.Location = new System.Drawing.Point(336, 456);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(444, 163);
            this.dgv.TabIndex = 38;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // txtfechaing
            // 
            this.txtfechaing.AutoSize = true;
            this.txtfechaing.Location = new System.Drawing.Point(251, 269);
            this.txtfechaing.Name = "txtfechaing";
            this.txtfechaing.Size = new System.Drawing.Size(75, 13);
            this.txtfechaing.TabIndex = 41;
            this.txtfechaing.Text = "Fecha Ingreso";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(372, 263);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker2.TabIndex = 42;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(459, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 24);
            this.button2.TabIndex = 43;
            this.button2.Text = "Aceptar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(547, 121);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 24);
            this.button6.TabIndex = 44;
            this.button6.Text = "Cancelar";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Sueldo Basico";
            // 
            // txtBasico
            // 
            this.txtBasico.Location = new System.Drawing.Point(372, 315);
            this.txtBasico.Name = "txtBasico";
            this.txtBasico.ReadOnly = true;
            this.txtBasico.Size = new System.Drawing.Size(100, 20);
            this.txtBasico.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Descripcion";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(104, 521);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(100, 20);
            this.txtDesc.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 576);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Tipo";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(104, 573);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(100, 20);
            this.txtTipo.TabIndex = 50;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(490, 345);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(171, 36);
            this.button7.TabIndex = 51;
            this.button7.Text = "Calcular Hijos Menores";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Hijos menores";
            // 
            // txtHijos
            // 
            this.txtHijos.Location = new System.Drawing.Point(372, 354);
            this.txtHijos.Name = "txtHijos";
            this.txtHijos.ReadOnly = true;
            this.txtHijos.Size = new System.Drawing.Size(100, 20);
            this.txtHijos.TabIndex = 53;
            // 
            // comboMes
            // 
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Location = new System.Drawing.Point(463, 82);
            this.comboMes.Name = "comboMes";
            this.comboMes.Size = new System.Drawing.Size(67, 21);
            this.comboMes.TabIndex = 63;
            this.comboMes.SelectedIndexChanged += new System.EventHandler(this.comboMes_SelectedIndexChanged);
            // 
            // comboAño
            // 
            this.comboAño.FormattingEnabled = true;
            this.comboAño.Location = new System.Drawing.Point(536, 82);
            this.comboAño.Name = "comboAño";
            this.comboAño.Size = new System.Drawing.Size(61, 21);
            this.comboAño.TabIndex = 64;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(253, 401);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 65;
            this.label18.Text = "Comisiones";
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(372, 398);
            this.txtComision.Name = "txtComision";
            this.txtComision.ReadOnly = true;
            this.txtComision.Size = new System.Drawing.Size(100, 20);
            this.txtComision.TabIndex = 66;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(490, 387);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(148, 40);
            this.button9.TabIndex = 67;
            this.button9.Text = "Ver Comisiones";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID Concepto";
            this.ID.Name = "ID";
            // 
            // PantallaLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 732);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.txtComision);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboAño);
            this.Controls.Add(this.comboMes);
            this.Controls.Add(this.txtHijos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBasico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.txtfechaing);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtIDCon);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboConceptos);
            this.Controls.Add(this.txtAnt);
            this.Controls.Add(this.txtCUIL);
            this.Controls.Add(this.txtAyP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboEmpleado);
            this.Controls.Add(this.comboCategoria);
            this.Controls.Add(this.label2);
            this.Name = "PantallaLiquidacion";
            this.Text = "PantallaLiquidacion";
            this.Load += new System.EventHandler(this.PantallaLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCategoria;
        private System.Windows.Forms.ComboBox comboEmpleado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAyP;
        private System.Windows.Forms.TextBox txtCUIL;
        private System.Windows.Forms.TextBox txtAnt;
        private System.Windows.Forms.ComboBox comboConceptos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtIDCon;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label txtfechaing;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBasico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtHijos;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.ComboBox comboAño;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
    }
}