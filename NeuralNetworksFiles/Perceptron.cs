using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
	public class Perceptron : NeuralNetwork
	{
		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="eta">The learning rate.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double eta, double bias)
			: base(dataSet, target, eta, bias)
		{
			//Nothing here.
		}

		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="eta">The learning rate.</param>
		/// <param name="featureMask">Set of features to use in the machine.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double eta, double bias, double[] featureMask, double[] classMask)
			: base(dataSet, target, eta, bias, featureMask, classMask)
		{
			//Nothing here.
		}

		/// <summary>Create a new perceptron machine.</summary>
		/// <param name="dataSet">Object holding the dataset to work on.</param>
		/// <param name="target">The target/goal vector for the training.</param>
		/// <param name="weight">The initial weight vector to start with.</param>
		/// <param name="eta">The learning rate.</param>
		public Perceptron(DataSetReader dataSet, double[] target, double[] weight, double eta, double bias)
			: base(dataSet, target, weight, eta, bias)
		{
			//Nothing here.
		}

		/// <summary>Train the machine using the perceptron algorithm.</summary>
		/// <param name="trainCount">Number of data set smaples to use in training.</param>
		public override void train(int trainCount)
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
						lineData = VectorTools.prepend(lineData, this.bias); //Prepend the bias.

						double net = VectorTools.multiply(this.weight, lineData);
						int sgnOut = ActivationFunctions.signum(net);

						if(sgnOut != this.target[i])
						{
							weightChanged = true;
							lineData = VectorTools.trim(this.data[classIndex][j], this.featureMask);
							lineData = VectorTools.prepend(lineData, this.bias);

							double error = this.target[i] - sgnOut;
							double[] mulOut = VectorTools.multiply(lineData, error * this.eta);
							this.weight = VectorTools.sum(this.weight, mulOut);
						}
					}
				} //End of inner for.

				epochs++;
			} //End of outer while.
		}

		/// <summary>Test the machine using the perceptron algorithm.</summary>
		/// <param name="testCount">Number of data set smaples to use in testing (starting from the end).</param>
		public override int[,] test(int testCount)
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

		/// <summary>Classify one sample in the machine using the perceptron algorithm (used after training).</summary>
		/// <param name="input">The sample to classify</param>
		public override double classify(double[] input)
		{
			if(input.Length > this.featureMask.Length)
				throw new ArgumentOutOfRangeException("Input features is bigger than features in feature mask");

			input = VectorTools.prepend(input, this.bias); //Add the bias.
			double net = VectorTools.multiply(this.weight, input);
			int sgnOut = ActivationFunctions.signum(net);

			return sgnOut;
		}
	}
}
