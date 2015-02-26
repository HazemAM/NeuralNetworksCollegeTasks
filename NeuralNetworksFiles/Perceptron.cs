using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
	class Perceptron
	{
		private double[] target;
		private double[] weight;
		private double eta;
		private List<double[]>[] data;
		private int classes;	//Number of classes.
		private int samples;	//Number of samples per class.
		private int features;	//Number of features per sample.

		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="eta">The learning rate.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double eta)
		{
			this.target = target;
			this.data = dataSet.data;
			this.classes = dataSet.classes;
			this.features = dataSet.features;
			this.samples = dataSet.samples;
			this.eta = eta;

			//Initializing weight with 1's:
			initializeWeight(this.features);
		}

		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="weight">The initial weight vector to start with.</param>
		/// <param name="eta">The learning rate.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double[] weight, double eta)
		{
			this.target = target;
			this.data = dataSet.data;
			this.classes = dataSet.classes;
			this.features = dataSet.features;
			this.samples = dataSet.samples;
			this.weight = weight;
			this.eta = eta;
		}

		/// <summary>Train the machine using the perceptron algorithm.</summary>
		/// <param name="trainCount">Number of smaples from data set to use in training.</param>
		public void train(int trainCount)
		{
			int epochs = 0;
			const int MAX_EPOCHS = 1000;	//Limiting the number of iterations in the process.
			bool weightChanged = true;

			/*INIT CHECKS*/
			if(this.data.Length != this.classes)
				throw new ArgumentException("Input and target data are not of the same length");
			
			/*REAL WORK*/
			while(weightChanged && epochs < MAX_EPOCHS)
			{
				weightChanged = false;
				for(int i=0; i<this.classes; i++) //Class index.
				{
					for(int j=0; j<trainCount; j++) //Data index.
					{
						double net = VectorTools.multiply(this.weight, this.data[i][j]);
						int sgnOut = ActivationFunctions.signum(net);

						if(sgnOut != this.target[i])
						{
							weightChanged = true;

							double error = this.target[i] - sgnOut;
							double[] mulOut = VectorTools.multiply(this.data[i][j], error * this.eta);
							this.weight = VectorTools.sum(this.weight, mulOut);
						}
					}
				} //End of inner for.

				epochs++;
			} //End of outer while.
		}

		public double test(double[] input)
		{
			double net = VectorTools.multiply(this.weight, input);
			int sgnOut = ActivationFunctions.signum(net);

			return sgnOut;
		}

		private void initializeWeight(int length)
		{
			this.weight = new double[length];
			for(int i=0; i < this.weight.Length; i++)
				this.weight[i] = 1;
		}
	}
}
