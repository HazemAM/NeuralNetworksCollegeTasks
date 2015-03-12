using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworks
{
	public partial class MainWindow : Form
	{
		double[] target;
		double[] features;
		double[] classes;

		DataSetReader irisSet;
		//Perceptron machine;
        LMS machine;
		GraphDrawer graphDrawer;
		SolidBrush[] irisBrushes = new SolidBrush[]{
			new SolidBrush(Color.Red),
			new SolidBrush(Color.Gray),
			new SolidBrush(Color.Blue),
		};

		public MainWindow()
		{
			InitializeComponent();

			irisSet = new DataSetReader("../../../DataSets/iris.data", DataSetType.IRIS);
			graphDrawer = new GraphDrawer(irisSet, graphPictureBox, irisBrushes);
		}

		private void runIrisPerceptron()
		{
			target = new double[] {-1, 1};
			features = new double[] {(int)numFeatureOne.Value, (int)numFeatureTwo.Value};
			classes = new double[] {(int)numClassOne.Value, (int)numClassTwo.Value};
			double eta = 0.75;
			double bias = 1.0;

			machine = new LMS(irisSet, target, eta, bias, features, classes);
			machine.train(30);
			
			int[,] testMatrix = machine.test(20);
			UiTools.drawMatrix(dataGridView, testMatrix);
			lblAccuracy.Text = VectorTools.confusionAccuracy(testMatrix).ToString();
		}

		private void btnDrawGraph_Click(object sender, EventArgs e)
		{
			runIrisPerceptron();
			graphDrawer.drawGraph((int)numFeatureOne.Value, (int)numFeatureTwo.Value);
			graphDrawer.drawLine(machine);
		}

		private void graphPicture_MouseClick(object sender, MouseEventArgs e)
		{
			float x = (float)e.X;
			float y = (float)e.Y;
			PictureBox pictureBox = sender as PictureBox;

			if(pictureBox.Image == null) return;

			double[] testData = new double[] {
				x/graphDrawer.getFactorX(),
				y/graphDrawer.getFactorY()
			};
			int newClass = (int)machine.classify(testData);

			int brushIndex = Array.IndexOf(target, newClass);
			SolidBrush[] brushes = new SolidBrush[]{
				irisBrushes[(int)numClassOne.Value - 1],
				irisBrushes[(int)numClassTwo.Value - 1],
			};

			graphDrawer.drawPoint(x, y, brushes[brushIndex]);
		}
	}
}
