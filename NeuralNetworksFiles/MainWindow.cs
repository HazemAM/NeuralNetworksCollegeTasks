using NeuralNetworks.MultilayerNetworks;
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

		NeuralNetwork machine;

		GraphDrawer graphDrawer;
		SolidBrush[] irisBrushes = new SolidBrush[]{
			new SolidBrush(Color.Red),
			new SolidBrush(Color.Gray),
			new SolidBrush(Color.Blue),
		};

		Type selectedNetwork;
		Type[] networkType = new Type[]{
			typeof(Perceptron),
			typeof(LMS)
		};

		string originalTitle;

		public MainWindow()
		{
			InitializeComponent();
			originalTitle = this.Text;
			cmbNetworkType.SelectedIndex = 0;



			/* MLP TESTING START */
			Layer hidden = new Layer(
				new Neuron[] {
					new Neuron(new double[] {0.21, 0.15, 0.15, 0.15}, 1, -0.3, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.4, 0.1, 0.2, 0.1}, 1, -0.1, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.15, 0.05, 0.25, 0.1}, 1, -0.15, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.35, 0.15, 0.1, 0.25}, 1, 0.1, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff)
				}
			);
			Layer output = new Layer(
				new Neuron[] {
					new Neuron(new double[] {-0.2, 0.25, 0.25, 0.1}, 1, -0.4, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.15, 0.10, 0.15, 0.35}, 1, -0.35, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {0.1, 0.3, 0.1, 0.15}, 1, -0.2, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff)
				}
			);

			irisSet = new DataSetReader("../../../DataSets/iris.data", DataSetType.IRIS, true);
			double[] target = new double[] {0.5, 0.5, 0.5};

			MultilayerNeuralNetwork network = new BackPropagation(new Layer[] { hidden, output }, irisSet, target, 0.75);
			network.train(50);
			network.test(20);
			//network.classify(new double[] {5.1,3.5,1.4,0.2});
			/* MLP TESTING END */

		}

		private void runIrisNetwork()
		{
			//Getting data set ready:
			bool normalize = selectedNetwork == typeof(LMS);
			irisSet = new DataSetReader("../../../DataSets/iris.data", DataSetType.IRIS, normalize);
			graphDrawer = new GraphDrawer(irisSet, graphPictureBox, irisBrushes);

			//Network parameters:
			target = new double[] {-1, 1};
			features = new double[] {(int)numFeatureOne.Value, (int)numFeatureTwo.Value};
			classes = new double[] {(int)numClassOne.Value, (int)numClassTwo.Value};
			double eta = (double)numEta.Value;
			double bias = 1.0;

			//Selecting the right network:
			if(selectedNetwork == typeof(Perceptron))
				machine = new Perceptron(irisSet, target, eta, bias, features, classes);
			else if(selectedNetwork == typeof(LMS))
				machine = new LMS(irisSet, target, eta, bias, features, classes);
			
			//Train the network:
			machine.train(30);
			
			//Test the network:
			int[,] testMatrix = machine.test(20);
			UiTools.drawMatrix(dataGridView, testMatrix);
			lblAccuracy.Text = VectorTools.confusionAccuracy(testMatrix).ToString();
		}

		private void btnDrawGraph_Click(object sender, EventArgs e)
		{
			runIrisNetwork();
			changeWindowTitle();
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
			if(irisSet.normalized)	//Normalize testData if data set is.
				testData = irisSet.norm(testData, features);

			int newClass = (int)machine.classify(testData);

			int brushIndex = Array.IndexOf(target, newClass);
			SolidBrush[] brushes = new SolidBrush[]{
				irisBrushes[(int)numClassOne.Value - 1],
				irisBrushes[(int)numClassTwo.Value - 1],
			};

			graphDrawer.drawPoint(x, y, brushes[brushIndex]);
		}

		private void changeWindowTitle()
		{
			string newTitle = originalTitle + ": ";
			if(selectedNetwork == typeof(Perceptron))
				newTitle += "The Perceptron";
			else if (selectedNetwork == typeof(LMS))
				newTitle += "Least Mean Square";

			this.Text = newTitle;
		}

		private void cmbNetworkType_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = sender as ComboBox;
			selectedNetwork = networkType[cmb.SelectedIndex];
		}
	}
}
