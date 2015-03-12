using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworks
{
	class GraphDrawer
	{
		private DataSetReader dataSet;
		private PictureBox pictureBox;
		private SolidBrush[] brush;

		private const float POINT_SIZE = 3;
		private float factorX;
		private float factorY;

		public GraphDrawer(DataSetReader dataSet, PictureBox pictureBox, SolidBrush[] brush)
		{
			this.dataSet = dataSet;
			this.pictureBox = pictureBox;
			this.brush = brush;
		}

		public void drawGraph(int featureOne, int featureTwo)
		{
			factorX = this.pictureBox.Width / this.dataSet.maxValue;
			factorY = this.pictureBox.Height / this.dataSet.maxValue;

			//First checks:
			if(featureOne > this.dataSet.features || featureTwo > this.dataSet.features ||
				featureOne < 1 || featureTwo < 1)
				throw new ArgumentException("Bad feature index");
			if(this.brush.Length != this.dataSet.classes)
				throw new ArgumentException("Brushes and number of classes do not match");

			//Real work:
			featureOne--; featureTwo--;	//Getting features ready for useing as indices.

			Bitmap bitmap = new Bitmap(this.pictureBox.Width, this.pictureBox.Height);
			Graphics g = Graphics.FromImage(bitmap);

			float x, y;
			Brush b = new SolidBrush(Color.Black);
			for(int i=0; i<this.dataSet.classes; i++)
				for(int j=0; j<this.dataSet.samples; j++){
					x = (float)this.dataSet.data[i][j][featureOne] * factorX;
					y = (float)this.dataSet.data[i][j][featureTwo] * factorY;
					g.FillRectangle(this.brush[i], x, y, POINT_SIZE, POINT_SIZE);
				}

			this.pictureBox.Image = bitmap;
		}

		public void drawLine(NeuralNetwork network)
		{
			//Checks and getting ready:
			double[] classMask = network.getClassMask(),
					 featureMask = network.getFeatureMask(),
					 weight = network.getWeight();
			double bias = network.getBias(),
				   weightX = weight[0],
				   weightY = weight[1];

			if(classMask.Length != 2)
				throw new ArgumentOutOfRangeException("Mask must contain exactly two classes");

			classMask[0]--; classMask[1]--; //For using as indices.
			int classOne = (int)classMask[0],
				classTwo = (int)classMask[1];
			
			//Real work:
			double maxX = VectorTools.max(this.dataSet.data[classOne], featureMask),
				   minX = VectorTools.min(this.dataSet.data[classOne], featureMask);

			double xOne = (minX + weightX + bias) * factorX,
				   xTwo = (maxX + weightY + bias) * factorX,
				   yOne = ((-xOne * weightX) / weightY) - (bias / weightY) * factorY, //Derived from: x*w1 + y*w2 = 0.
				   yTwo = ((-xTwo * weightX) / weightY) - (bias / weightY) * factorY;

			Bitmap bitmap = this.pictureBox.Image as Bitmap;
			Graphics g = Graphics.FromImage(bitmap);
			Pen pen = new Pen(Color.Black);

			g.DrawLine(pen, (float)xOne, (float)yOne, (float)xTwo, (float)yTwo);
		}

		public void drawPoint(float x, float y, SolidBrush brush){
			Bitmap bitmap = this.pictureBox.Image as Bitmap;
			Graphics g = Graphics.FromImage(bitmap);

			g.FillRectangle(brush, x, y, POINT_SIZE, POINT_SIZE);
			pictureBox.Refresh();
		}

		public float getFactorX(){
			return factorX;
		}

		public float getFactorY(){
			return factorY;
		}
	}
}
