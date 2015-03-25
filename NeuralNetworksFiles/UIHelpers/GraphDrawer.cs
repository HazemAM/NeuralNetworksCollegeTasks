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
			factorX = this.pictureBox.Width / this.dataSet.globalMax;
			factorY = this.pictureBox.Height / this.dataSet.globalMax;

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
			System.Collections.Generic.List<double[]>[] set =
				dataSet.normalized ? dataSet.dataNorm : dataSet.data;
			double maxX = VectorTools.max(set[classOne], featureMask),
				   minX = VectorTools.min(set[classOne], featureMask);

			double xOne = (minX + weightX + bias),
				   xTwo = (maxX + weightY + bias),
				   yOne = ((-xOne * weightX) / weightY) - (bias / weightY), //Derived from: x*w1 + y*w2 = 0.
				   yTwo = ((-xTwo * weightX) / weightY) - (bias / weightY);

			if(dataSet.normalized){
				double[] newDataOne = dataSet.unNorm(new double[]{xOne, yOne}, featureMask);
				double[] newDataTwo = dataSet.unNorm(new double[]{xTwo, yTwo}, featureMask);
				xOne = newDataOne[0]; yOne = newDataOne[1];
				xTwo = newDataTwo[0]; yTwo = newDataTwo[1];
			}

			Bitmap bitmap = this.pictureBox.Image as Bitmap;
			Graphics g = Graphics.FromImage(bitmap);
			Pen pen = new Pen(Color.Black);

			g.DrawLine(pen, (float)xOne * factorX, (float)yOne * factorY, (float)xTwo * factorX, (float)yTwo * factorY);
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
