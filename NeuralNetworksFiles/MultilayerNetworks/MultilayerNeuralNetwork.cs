using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public abstract class MultilayerNeuralNetwork
	{
		/*
		 * FIELDS
		 */
		protected Layer[] layer;
		protected DataSetReader dataSet;
		protected double eta;

		protected const int MAX_EPOCHS = 500;


		/*
		 * CONSTRUCTORS
		 */
		public MultilayerNeuralNetwork(Layer[] layers, DataSetReader dataSet, double eta)
		{
			if(layers[layers.Length - 1].nodes != dataSet.classes)
				throw new ArgumentOutOfRangeException("Output layer's neurons and dataset classes must have the same length ");

			this.layer = layers;
			this.dataSet = dataSet;
			this.eta = eta;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train(int trainCount);
		public abstract int[,] test(int testCount);
		public abstract int classify(double[] input);
	}
}
