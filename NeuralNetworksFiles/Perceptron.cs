using System;

namespace NeuralNetworks
{
	class Perceptron
	{
		/// <summary>Train the machine using the perceptron algorithm.</summary>
		/// <param name="input">The input vector to classify.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="eta">The learning rate.</param>
		public static void train(double[][] input, double[] target, double eta)
		{
			//Initializing weight with 1's:
			double[] weight = new double[input[0].Length];
			for(int i=0; i<weight.Length; i++)
				weight[i] = 1;

			train(input, target, weight, eta);
		}

		/// <summary>Train the machine using the perceptron algorithm.</summary>
		/// <param name="input">The input vector to classify.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="weight">The initial weight vector to start with.</param>
		/// <param name="eta">The learning rate.</param>
		public static void train(double[][] input, double[] target, double[] weight, double eta)
		{
			bool weightChanged = true;

			//First check:
			if(input.Length != target.Length)
				throw new ArgumentException("Input and target data are not of the same length");
			
			//Real work:
			while(weightChanged)
			{
				weightChanged = false;
				for(int i=0; i<target.Length; i++)
				{
					double net = VectorTools.multiply(weight, input[i]);
					int sgnOut = ActivationFunctions.signum(net);

					if(sgnOut != target[i])
					{
						weightChanged = true;

						double error = target[i] - sgnOut;
						double[] mulOut = VectorTools.multiply(input[i], error * eta);
						weight = VectorTools.sum(weight, mulOut);
					}
				} //End of inner for.
			} //End of outer while.
		}
	}
}
