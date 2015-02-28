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
		private int samples;	//Number of samples per class.
		private double[] featureMask;
		private double[] classMask;

		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="eta">The learning rate.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double eta)
		{
			this.target = target;
			this.data = dataSet.data;
			this.featureMask = VectorTools.sequence(dataSet.features);
			this.classMask = VectorTools.sequence(dataSet.classes);
			this.weight = VectorTools.ones(this.featureMask.Length);
			this.samples = dataSet.samples;
			this.eta = eta;
		}

		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="eta">The learning rate.</param>
		/// <param name="featureMask">Set of features to use in the machine.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double eta, double[] featureMask, double[] classMask){
			if(featureMask.Length > dataSet.features || featureMask.Length < 1)
				throw new ArgumentOutOfRangeException("Number of features specified is not applicable");

			this.target = target;
			this.data = dataSet.data;
			this.featureMask = featureMask;
			this.classMask = classMask;
			this.weight = VectorTools.ones(this.featureMask.Length);
			this.samples = dataSet.samples;
			this.eta = eta;
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
			this.featureMask = VectorTools.sequence(dataSet.features);
			this.classMask = VectorTools.sequence(dataSet.classes);
			this.samples = dataSet.samples;
			this.weight = weight;
			this.eta = eta;
		}

		/// <summary>Train the machine using the perceptron algorithm.</summary>
		/// <param name="trainCount">Number of data set smaples to use in training.</param>
		public void train(int trainCount)
		{
			int epochs = 0;
			const int MAX_EPOCHS = 1000;	//Limiting the number of iterations in the process.
			bool weightChanged = true;
			int classIndex;
			double[] lineData;
			
			/*REAL WORK*/
			while(weightChanged && epochs < MAX_EPOCHS)
			{
				weightChanged = false;
				for(int i=0; i<this.classMask.Length; i++) //Class index.
				{
					classIndex = (int)classMask[i] - 1;
					for(int j=0; j<trainCount; j++) //Data index.
					{
						lineData = VectorTools.trim(this.data[classIndex][j], this.featureMask);

						double net = VectorTools.multiply(this.weight, lineData);
						int sgnOut = ActivationFunctions.signum(net);

						if(sgnOut != this.target[i])
						{
							weightChanged = true;
							lineData = VectorTools.trim(this.data[classIndex][j], this.featureMask);

							double error = this.target[i] - sgnOut;
							double[] mulOut = VectorTools.multiply(lineData, error * this.eta);
							this.weight = VectorTools.sum(this.weight, mulOut);
						}
					}
				} //End of inner for.

				epochs++;
			} //End of outer while.
		}

		public int[,] test(int testCount)
		{
			//The to-be-returned confusion matrix:
			int[,] confMatrix = new int[this.classMask.Length, this.classMask.Length];

			int startIndex = this.samples - testCount - 1,
				success = 0,
				classIndex,
				resultIndex;
			double classOut;
			double[] lineData;

			for(int i=0; i<this.classMask.Length; i++)
			{
				classIndex = (int)this.classMask[i] - 1;
				for(int j=0; j<testCount; j++)
				{
					lineData = VectorTools.trim(this.data[classIndex][startIndex + j], this.featureMask);
					classOut = classify(lineData);
					if(classOut == this.target[i])
						success++;

					resultIndex = Array.IndexOf(this.target, (int)classOut);
					confMatrix[i, resultIndex]++;
				}
			}

			return confMatrix;
		}

		public double classify(double[] input)
		{
			double net = VectorTools.multiply(this.weight, input);
			int sgnOut = ActivationFunctions.signum(net);

			return sgnOut;
		}
	}
}
