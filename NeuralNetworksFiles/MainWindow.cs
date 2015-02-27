using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworks
{
	public partial class MainWindow : Form
	{
		DataSetReader iris;
		Perceptron machine;
		GraphDrawer graphDrawer;
		SolidBrush[] irisBrushes = new SolidBrush[]{
			new SolidBrush(Color.Red),
			new SolidBrush(Color.Green),
			new SolidBrush(Color.Blue),
		};

		public MainWindow()
		{
			InitializeComponent();
			iris = new DataSetReader("../../../DataSets/iris.data", DataSetType.IRIS);
			graphDrawer = new GraphDrawer(iris, graphPicture, irisBrushes);
		}

		private void irisPerceptron()
		{
			double[] target = new double[] {-1, 0, 1};
			double eta = 0.75;

			machine = new Perceptron(iris, target, eta, 2);
			machine.train(30);
		}

		private void btnDrawGraph_Click(object sender, EventArgs e)
		{
			irisPerceptron();
			graphDrawer.drawGraph((int)numFeatureOne.Value, (int)numFeatureTwo.Value);
		}

		private void graphPicture_MouseClick(object sender, MouseEventArgs e)
		{
			float x = (float)e.X;
			float y = (float)e.Y;
			PictureBox pictureBox = sender as PictureBox;

			if(pictureBox.Image == null) pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

			double[] testData = new double[] {
				x/graphDrawer.getFactorX(),
				y/graphDrawer.getFactorY()
			};
			int test = (int)machine.test(testData);

			graphDrawer.drawPoint(x, y, irisBrushes[test+1]);
		}
	}
}
