using System;
using System.Windows.Forms;
using NeuralNetworks.MultilayerNetworks;

namespace NeuralNetworks
{
	public partial class MultilayerWindow : Form
	{
		DataSetReader irisSet = new DataSetReader("../../../DataSets/iris.data", DataSetType.IRIS, true);
		MultilayerNeuralNetwork network;
		string[] irisClasses = new string[]
		{
			"Setosa",
			"Versicolor",
			"Virginica"
		};

		public MultilayerWindow()
		{
			InitializeComponent();
		}

		private void startIrisMachine()
		{
			Layer hidden = new Layer(
				new Neuron[] {
					new Neuron(new double[] {0.21, 0.15, 0.15, 0.15}, 1, -0.3, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.4, 0.1, 0.2, 0.1}, 1, -0.1, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.15, 0.05, 0.25, 0.1}, 1, -0.15, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff)
				}
			);
			Layer output = new Layer(
				new Neuron[] {
					new Neuron(new double[] {-0.2, 0.25, 0.25}, 1, -0.4, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {-0.15, 0.10, 0.15}, 1, -0.35, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff),
					new Neuron(new double[] {0.1, 0.3, 0.1}, 1, -0.2, ActivationFunctions.sigmoid, ActivationFunctions.sigmoidDiff)
				}
			);
			
			double eta = (double)numEta.Value;
			int epochs = (int)numMaxEpochs.Value;
			network = new BackPropagation(new Layer[] { hidden, output }, irisSet, eta, epochs);

			network.train(50);
			int[,] testMatrix = network.test(20);

			UiTools.drawMatrix(gridConfMatrix, testMatrix);
			double accuracy = VectorTools.confusionAccuracy(testMatrix);
			lblAccuracy.Text = Math.Round(accuracy, 4).ToString();
		}

		private void btnStartMachine_Click(object sender, EventArgs e)
		{
			startIrisMachine();
		}

		private void btnClassify_Click(object sender, EventArgs e)
		{
			string[] dataString = txtClassifyData.Text.Split(new string[] {",", ", "}, StringSplitOptions.RemoveEmptyEntries);
			double[] data = Array.ConvertAll(dataString, double.Parse);
			if(data.Length < irisSet.features || network == null)
				return;

			int classOut = network.classify(data);
			txtClassifyOutput.Text = irisClasses[classOut] + " (" + (classOut + 1).ToString() + ")";
		}
	}
}
