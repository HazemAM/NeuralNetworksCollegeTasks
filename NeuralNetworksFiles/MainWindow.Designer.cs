namespace NeuralNetworks
{
	partial class MainWindow
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
			this.graphPictureBox = new System.Windows.Forms.PictureBox();
			this.numFeatureOne = new System.Windows.Forms.NumericUpDown();
			this.numFeatureTwo = new System.Windows.Forms.NumericUpDown();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.numClassTwo = new System.Windows.Forms.NumericUpDown();
			this.numClassOne = new System.Windows.Forms.NumericUpDown();
			this.numEta = new System.Windows.Forms.NumericUpDown();
			this.btnDrawGraph = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblAccuracy = new System.Windows.Forms.Label();
			this.cmbNetworkType = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureOne)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureTwo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numClassTwo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numClassOne)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numEta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// graphPictureBox
			// 
			this.graphPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.graphPictureBox.Location = new System.Drawing.Point(12, 12);
			this.graphPictureBox.Name = "graphPictureBox";
			this.graphPictureBox.Size = new System.Drawing.Size(256, 256);
			this.graphPictureBox.TabIndex = 0;
			this.graphPictureBox.TabStop = false;
			this.graphPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphPicture_MouseClick);
			// 
			// numFeatureOne
			// 
			this.numFeatureOne.BackColor = System.Drawing.SystemColors.Window;
			this.numFeatureOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numFeatureOne.Location = new System.Drawing.Point(65, 300);
			this.numFeatureOne.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numFeatureOne.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numFeatureOne.Name = "numFeatureOne";
			this.numFeatureOne.Size = new System.Drawing.Size(41, 20);
			this.numFeatureOne.TabIndex = 1;
			this.toolTip.SetToolTip(this.numFeatureOne, "First feature index");
			this.numFeatureOne.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numFeatureTwo
			// 
			this.numFeatureTwo.BackColor = System.Drawing.SystemColors.Window;
			this.numFeatureTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numFeatureTwo.Location = new System.Drawing.Point(112, 300);
			this.numFeatureTwo.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numFeatureTwo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numFeatureTwo.Name = "numFeatureTwo";
			this.numFeatureTwo.Size = new System.Drawing.Size(41, 20);
			this.numFeatureTwo.TabIndex = 2;
			this.toolTip.SetToolTip(this.numFeatureTwo, "Second feature index");
			this.numFeatureTwo.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// numClassTwo
			// 
			this.numClassTwo.BackColor = System.Drawing.SystemColors.Window;
			this.numClassTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numClassTwo.Location = new System.Drawing.Point(112, 274);
			this.numClassTwo.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numClassTwo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numClassTwo.Name = "numClassTwo";
			this.numClassTwo.Size = new System.Drawing.Size(41, 20);
			this.numClassTwo.TabIndex = 5;
			this.toolTip.SetToolTip(this.numClassTwo, "1: Red, 2: Gray, 3:Blue");
			this.numClassTwo.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// numClassOne
			// 
			this.numClassOne.BackColor = System.Drawing.SystemColors.Window;
			this.numClassOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numClassOne.Location = new System.Drawing.Point(65, 274);
			this.numClassOne.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numClassOne.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numClassOne.Name = "numClassOne";
			this.numClassOne.Size = new System.Drawing.Size(41, 20);
			this.numClassOne.TabIndex = 4;
			this.toolTip.SetToolTip(this.numClassOne, "1: Red, 2: Gray, 3:Blue");
			this.numClassOne.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numEta
			// 
			this.numEta.BackColor = System.Drawing.SystemColors.Window;
			this.numEta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numEta.DecimalPlaces = 2;
			this.numEta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numEta.Location = new System.Drawing.Point(419, 12);
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
			this.numEta.TabIndex = 12;
			this.toolTip.SetToolTip(this.numEta, "Learning rate (eta)");
			this.numEta.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
			// 
			// btnDrawGraph
			// 
			this.btnDrawGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDrawGraph.Location = new System.Drawing.Point(190, 274);
			this.btnDrawGraph.Name = "btnDrawGraph";
			this.btnDrawGraph.Size = new System.Drawing.Size(79, 46);
			this.btnDrawGraph.TabIndex = 3;
			this.btnDrawGraph.Text = "Start";
			this.btnDrawGraph.UseVisualStyleBackColor = true;
			this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label2.Location = new System.Drawing.Point(13, 302);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Features:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Location = new System.Drawing.Point(13, 276);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Classes:";
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeColumns = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.ColumnHeadersVisible = false;
			this.dataGridView.Location = new System.Drawing.Point(292, 223);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.Size = new System.Drawing.Size(210, 45);
			this.dataGridView.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(289, 207);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Overall accuracy:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(398, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 13);
			this.label3.TabIndex = 10;
			// 
			// lblAccuracy
			// 
			this.lblAccuracy.AutoSize = true;
			this.lblAccuracy.Location = new System.Drawing.Point(395, 207);
			this.lblAccuracy.Name = "lblAccuracy";
			this.lblAccuracy.Size = new System.Drawing.Size(13, 13);
			this.lblAccuracy.TabIndex = 11;
			this.lblAccuracy.Text = "--";
			// 
			// cmbNetworkType
			// 
			this.cmbNetworkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNetworkType.FormattingEnabled = true;
			this.cmbNetworkType.Items.AddRange(new object[] {
            "Perceptron",
            "Least Mean Square"});
			this.cmbNetworkType.Location = new System.Drawing.Point(292, 12);
			this.cmbNetworkType.Name = "cmbNetworkType";
			this.cmbNetworkType.Size = new System.Drawing.Size(121, 21);
			this.cmbNetworkType.TabIndex = 13;
			this.cmbNetworkType.SelectedIndexChanged += new System.EventHandler(this.cmbNetworkType_SelectedIndexChanged);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(514, 331);
			this.Controls.Add(this.cmbNetworkType);
			this.Controls.Add(this.numEta);
			this.Controls.Add(this.lblAccuracy);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numClassTwo);
			this.Controls.Add(this.numClassOne);
			this.Controls.Add(this.btnDrawGraph);
			this.Controls.Add(this.numFeatureTwo);
			this.Controls.Add(this.numFeatureOne);
			this.Controls.Add(this.graphPictureBox);
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Neural Networks: The Perceptron";
			((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureOne)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureTwo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numClassTwo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numClassOne)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numEta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox graphPictureBox;
		private System.Windows.Forms.NumericUpDown numFeatureOne;
		private System.Windows.Forms.NumericUpDown numFeatureTwo;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button btnDrawGraph;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numClassTwo;
		private System.Windows.Forms.NumericUpDown numClassOne;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblAccuracy;
		private System.Windows.Forms.NumericUpDown numEta;
		private System.Windows.Forms.ComboBox cmbNetworkType;
	}
}

