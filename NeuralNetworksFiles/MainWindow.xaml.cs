using System.Windows;

namespace NeuralNetworks
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			testingPerceptron();
		}

		private void testingPerceptron()
		{
			double[] target = new double[] {-1, 0, 1};
			double eta = 0.75;

			DataSetReader iris = new DataSetReader("../../../DataSets/iris.data", DataSetType.IRIS);

			Perceptron net = new Perceptron(iris, target, eta);
			net.train(30);
			double test = net.test(new double[] {7.7,3.0,6.1,2.3});
		}
	}
}
