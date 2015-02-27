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
			this.graphPicture = new System.Windows.Forms.PictureBox();
			this.numFeatureOne = new System.Windows.Forms.NumericUpDown();
			this.numFeatureTwo = new System.Windows.Forms.NumericUpDown();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnDrawGraph = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.graphPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureOne)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureTwo)).BeginInit();
			this.SuspendLayout();
			// 
			// graphPicture
			// 
			this.graphPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.graphPicture.Location = new System.Drawing.Point(12, 12);
			this.graphPicture.Name = "graphPicture";
			this.graphPicture.Size = new System.Drawing.Size(256, 256);
			this.graphPicture.TabIndex = 0;
			this.graphPicture.TabStop = false;
			this.graphPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphPicture_MouseClick);
			// 
			// numFeatureOne
			// 
			this.numFeatureOne.BackColor = System.Drawing.SystemColors.Window;
			this.numFeatureOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numFeatureOne.Location = new System.Drawing.Point(12, 275);
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
			this.numFeatureTwo.Location = new System.Drawing.Point(59, 275);
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
            1,
            0,
            0,
            0});
			// 
			// btnDrawGraph
			// 
			this.btnDrawGraph.Location = new System.Drawing.Point(194, 274);
			this.btnDrawGraph.Name = "btnDrawGraph";
			this.btnDrawGraph.Size = new System.Drawing.Size(75, 22);
			this.btnDrawGraph.TabIndex = 3;
			this.btnDrawGraph.Text = "Draw Graph";
			this.btnDrawGraph.UseVisualStyleBackColor = true;
			this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(555, 470);
			this.Controls.Add(this.btnDrawGraph);
			this.Controls.Add(this.numFeatureTwo);
			this.Controls.Add(this.numFeatureOne);
			this.Controls.Add(this.graphPicture);
			this.Name = "MainWindow";
			this.Text = "Neural Networks";
			((System.ComponentModel.ISupportInitialize)(this.graphPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureOne)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFeatureTwo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox graphPicture;
		private System.Windows.Forms.NumericUpDown numFeatureOne;
		private System.Windows.Forms.NumericUpDown numFeatureTwo;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button btnDrawGraph;
	}
}

