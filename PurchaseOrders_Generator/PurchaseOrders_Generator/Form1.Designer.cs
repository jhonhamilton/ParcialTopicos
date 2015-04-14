namespace PurchaseOrders_Generator
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCantidadOrdenes = new System.Windows.Forms.Label();
            this.nudCantidadOrdenes = new System.Windows.Forms.NumericUpDown();
            this.openFileParties = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenParties = new System.Windows.Forms.Button();
            this.openFileProducts = new System.Windows.Forms.OpenFileDialog();
            this.txtParties = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.btnExaminarProductos = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidadOrdenes
            // 
            this.lblCantidadOrdenes.AutoSize = true;
            this.lblCantidadOrdenes.Location = new System.Drawing.Point(24, 9);
            this.lblCantidadOrdenes.Name = "lblCantidadOrdenes";
            this.lblCantidadOrdenes.Size = new System.Drawing.Size(206, 13);
            this.lblCantidadOrdenes.TabIndex = 0;
            this.lblCantidadOrdenes.Text = "Cantidad de orgenes de compra a generar";
            // 
            // nudCantidadOrdenes
            // 
            this.nudCantidadOrdenes.Location = new System.Drawing.Point(237, 9);
            this.nudCantidadOrdenes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCantidadOrdenes.Name = "nudCantidadOrdenes";
            this.nudCantidadOrdenes.Size = new System.Drawing.Size(41, 20);
            this.nudCantidadOrdenes.TabIndex = 1;
            this.nudCantidadOrdenes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // openFileParties
            // 
            this.openFileParties.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cargue el archivo de EMPRESAS bien formado";
            // 
            // btnOpenParties
            // 
            this.btnOpenParties.Location = new System.Drawing.Point(27, 88);
            this.btnOpenParties.Name = "btnOpenParties";
            this.btnOpenParties.Size = new System.Drawing.Size(264, 30);
            this.btnOpenParties.TabIndex = 3;
            this.btnOpenParties.Text = "Examinar...";
            this.btnOpenParties.UseVisualStyleBackColor = true;
            this.btnOpenParties.Click += new System.EventHandler(this.btnOpenParties_Click);
            // 
            // openFileProducts
            // 
            this.openFileProducts.FileName = "openFileDialog2";
            // 
            // txtParties
            // 
            this.txtParties.Location = new System.Drawing.Point(27, 62);
            this.txtParties.Name = "txtParties";
            this.txtParties.Size = new System.Drawing.Size(264, 20);
            this.txtParties.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cargue el archivo de PRODUCTOS bien formado";
            // 
            // txtProducts
            // 
            this.txtProducts.Location = new System.Drawing.Point(27, 157);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(264, 20);
            this.txtProducts.TabIndex = 7;
            // 
            // btnExaminarProductos
            // 
            this.btnExaminarProductos.Location = new System.Drawing.Point(27, 183);
            this.btnExaminarProductos.Name = "btnExaminarProductos";
            this.btnExaminarProductos.Size = new System.Drawing.Size(264, 30);
            this.btnExaminarProductos.TabIndex = 8;
            this.btnExaminarProductos.Text = "Examinar...";
            this.btnExaminarProductos.UseVisualStyleBackColor = true;
            this.btnExaminarProductos.Click += new System.EventHandler(this.btnExaminarProductos_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(84, 233);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(146, 30);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 286);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnExaminarProductos);
            this.Controls.Add(this.txtProducts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtParties);
            this.Controls.Add(this.btnOpenParties);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCantidadOrdenes);
            this.Controls.Add(this.lblCantidadOrdenes);
            this.Name = "Form1";
            this.Text = "Generador de ordenes de compra";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidadOrdenes;
        private System.Windows.Forms.NumericUpDown nudCantidadOrdenes;
        private System.Windows.Forms.OpenFileDialog openFileParties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenParties;
        private System.Windows.Forms.OpenFileDialog openFileProducts;
        private System.Windows.Forms.TextBox txtParties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProducts;
        private System.Windows.Forms.Button btnExaminarProductos;
        private System.Windows.Forms.Button btnGenerar;
    }
}

