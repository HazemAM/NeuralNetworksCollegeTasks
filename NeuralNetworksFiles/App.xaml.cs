using System.Windows;

namespace NeuralNetworks
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			testingPerceptron();
		}

		private void testingPerceptron() //Using the "AND" problem.
		{
			double[][] input = new double[][]{
				new double[] {1,1,1},
				new double[] {1,1,-1},
				new double[] {1,-1,1},
				new double[] {1,-1,-1},
			};
			double[] target = new double[] {1,-1,-1,-1};
			double[] initWeight = new double[] {0.5,0.3,0.7};
			double eta = 0.1;

			Perceptron.train(input, target, initWeight, eta);
		}
	}
}
