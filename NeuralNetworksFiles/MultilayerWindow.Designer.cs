namespace NeuralNetworks
{
	partial class MultilayerWindow
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
			this.numEta = new System.Windows.Forms.NumericUpDown();
			this.lblAccuracy = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gridConfMatrix = new System.Windows.Forms.DataGridView();
			this.btnStartMachine = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numEta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridConfMatrix)).BeginInit();
			this.SuspendLayout();
			// 
			// numEta
			// 
			this.numEta.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numEta.BackColor = System.Drawing.SystemColors.Window;
			this.numEta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numEta.DecimalPlaces = 2;
			this.numEta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numEta.Location = new System.Drawing.Point(127, 191);
			this.numEta.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numEta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numEta.Name = "numEta";
			this.numEta.Size = new System.Drawing.Size(54, 20);
			this.numEta.TabIndex = 17;
			this.numEta.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
			// 
			// lblAccuracy
			// 
			this.lblAccuracy.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAccuracy.AutoSize = true;
			this.lblAccuracy.Location = new System.Drawing.Point(135, 23);
			this.lblAccuracy.Name = "lblAccuracy";
			this.lblAccuracy.Size = new System.Drawing.Size(13, 13);
			this.lblAccuracy.TabIndex = 16;
			this.lblAccuracy.Text = "--";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(29, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Overall accuracy:";
			// 
			// gridConfMatrix
			// 
			this.gridConfMatrix.AllowUserToAddRows = false;
			this.gridConfMatrix.AllowUserToDeleteRows = false;
			this.gridConfMatrix.AllowUserToResizeColumns = false;
			this.gridConfMatrix.AllowUserToResizeRows = false;
			this.gridConfMatrix.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.gridConfMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridConfMatrix.BackgroundColor = System.Drawing.SystemColors.Window;
			this.gridConfMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.gridConfMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridConfMatrix.ColumnHeadersVisible = false;
			this.gridConfMatrix.Location = new System.Drawing.Point(33, 39);
			this.gridConfMatrix.Name = "gridConfMatrix";
			this.gridConfMatrix.ReadOnly = true;
			this.gridConfMatrix.RowHeadersVisible = false;
			this.gridConfMatrix.Size = new System.Drawing.Size(241, 122);
			this.gridConfMatrix.TabIndex = 14;
			// 
			// btnStartMachine
			// 
			this.btnStartMachine.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnStartMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStartMachine.Location = new System.Drawing.Point(114, 217);
			this.btnStartMachine.Name = "btnStartMachine";
			this.btnStartMachine.Size = new System.Drawing.Size(79, 46);
			this.btnStartMachine.TabIndex = 13;
			this.btnStartMachine.Text = "Start";
			this.btnStartMachine.UseVisualStyleBackColor = true;
			this.btnStartMachine.Click += new System.EventHandler(this.btnStartMachine_Click);
			// 
			// MultilayerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(309, 275);
			this.Controls.Add(this.numEta);
			this.Controls.Add(this.lblAccuracy);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gridConfMatrix);
			this.Controls.Add(this.btnStartMachine);
			this.Name = "MultilayerWindow";
			this.Text = "Multilayer Perceptron";
			((System.ComponentModel.ISupportInitialize)(this.numEta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridConfMatrix)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numEta;
		private System.Windows.Forms.Label lblAccuracy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView gridConfMatrix;
		private System.Windows.Forms.Button btnStartMachine;

	}
}