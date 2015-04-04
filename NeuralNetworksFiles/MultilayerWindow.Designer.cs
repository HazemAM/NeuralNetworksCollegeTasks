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
			this.components = new System.ComponentModel.Container();
			this.numEta = new System.Windows.Forms.NumericUpDown();
			this.lblAccuracy = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gridConfMatrix = new System.Windows.Forms.DataGridView();
			this.btnStartMachine = new System.Windows.Forms.Button();
			this.numMaxEpochs = new System.Windows.Forms.NumericUpDown();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.txtClassifyData = new System.Windows.Forms.TextBox();
			this.btnClassify = new System.Windows.Forms.Button();
			this.txtClassifyOutput = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numEta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridConfMatrix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxEpochs)).BeginInit();
			this.SuspendLayout();
			// 
			// numEta
			// 
			this.numEta.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.numEta.BackColor = System.Drawing.SystemColors.Window;
			this.numEta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numEta.DecimalPlaces = 2;
			this.numEta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numEta.Location = new System.Drawing.Point(99, 160);
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
			this.toolTip.SetToolTip(this.numEta, "Learning rate (eta)");
			this.numEta.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
			// 
			// lblAccuracy
			// 
			this.lblAccuracy.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblAccuracy.AutoSize = true;
			this.lblAccuracy.Location = new System.Drawing.Point(135, 23);
			this.lblAccuracy.Name = "lblAccuracy";
			this.lblAccuracy.Size = new System.Drawing.Size(13, 13);
			this.lblAccuracy.TabIndex = 16;
			this.lblAccuracy.Text = "--";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
			this.gridConfMatrix.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gridConfMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridConfMatrix.BackgroundColor = System.Drawing.SystemColors.Window;
			this.gridConfMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.gridConfMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridConfMatrix.ColumnHeadersVisible = false;
			this.gridConfMatrix.Location = new System.Drawing.Point(33, 39);
			this.gridConfMatrix.Name = "gridConfMatrix";
			this.gridConfMatrix.ReadOnly = true;
			this.gridConfMatrix.RowHeadersVisible = false;
			this.gridConfMatrix.Size = new System.Drawing.Size(241, 101);
			this.gridConfMatrix.TabIndex = 14;
			// 
			// btnStartMachine
			// 
			this.btnStartMachine.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnStartMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStartMachine.Location = new System.Drawing.Point(114, 186);
			this.btnStartMachine.Name = "btnStartMachine";
			this.btnStartMachine.Size = new System.Drawing.Size(79, 46);
			this.btnStartMachine.TabIndex = 13;
			this.btnStartMachine.Text = "Start";
			this.btnStartMachine.UseVisualStyleBackColor = true;
			this.btnStartMachine.Click += new System.EventHandler(this.btnStartMachine_Click);
			// 
			// numMaxEpochs
			// 
			this.numMaxEpochs.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.numMaxEpochs.BackColor = System.Drawing.SystemColors.Window;
			this.numMaxEpochs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numMaxEpochs.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numMaxEpochs.Location = new System.Drawing.Point(159, 160);
			this.numMaxEpochs.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
			this.numMaxEpochs.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numMaxEpochs.Name = "numMaxEpochs";
			this.numMaxEpochs.Size = new System.Drawing.Size(54, 20);
			this.numMaxEpochs.TabIndex = 18;
			this.toolTip.SetToolTip(this.numMaxEpochs, "Maximum epochs");
			this.numMaxEpochs.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(29, 262);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(250, 2);
			this.label1.TabIndex = 19;
			// 
			// txtClassifyData
			// 
			this.txtClassifyData.Location = new System.Drawing.Point(70, 284);
			this.txtClassifyData.Name = "txtClassifyData";
			this.txtClassifyData.Size = new System.Drawing.Size(100, 20);
			this.txtClassifyData.TabIndex = 20;
			// 
			// btnClassify
			// 
			this.btnClassify.Location = new System.Drawing.Point(172, 283);
			this.btnClassify.Name = "btnClassify";
			this.btnClassify.Size = new System.Drawing.Size(61, 22);
			this.btnClassify.TabIndex = 21;
			this.btnClassify.Text = "Classify";
			this.btnClassify.UseVisualStyleBackColor = true;
			this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
			// 
			// txtClassifyOutput
			// 
			this.txtClassifyOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtClassifyOutput.Location = new System.Drawing.Point(76, 315);
			this.txtClassifyOutput.Name = "txtClassifyOutput";
			this.txtClassifyOutput.Size = new System.Drawing.Size(150, 15);
			this.txtClassifyOutput.TabIndex = 23;
			this.txtClassifyOutput.Text = "--";
			this.txtClassifyOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MultilayerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(309, 346);
			this.Controls.Add(this.txtClassifyOutput);
			this.Controls.Add(this.btnClassify);
			this.Controls.Add(this.txtClassifyData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numMaxEpochs);
			this.Controls.Add(this.numEta);
			this.Controls.Add(this.lblAccuracy);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gridConfMatrix);
			this.Controls.Add(this.btnStartMachine);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MultilayerWindow";
			this.Text = "Multilayer Perceptron";
			((System.ComponentModel.ISupportInitialize)(this.numEta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridConfMatrix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxEpochs)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numEta;
		private System.Windows.Forms.Label lblAccuracy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView gridConfMatrix;
		private System.Windows.Forms.Button btnStartMachine;
		private System.Windows.Forms.NumericUpDown numMaxEpochs;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtClassifyData;
		private System.Windows.Forms.Button btnClassify;
		private System.Windows.Forms.Label txtClassifyOutput;

	}
}