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

		protected int maxEpochs;


		/*
		 * CONSTRUCTORS
		 */
		public MultilayerNeuralNetwork(Layer[] layers, DataSetReader dataSet, double eta, int maxEpochs)
		{
			if(layers[layers.Length - 1].nodes != dataSet.classes)
				throw new ArgumentOutOfRangeException("Output layer's neurons and dataset classes must have the same length ");

			this.layer = layers;
			this.dataSet = dataSet;
			this.eta = eta;
			this.maxEpochs = maxEpochs;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train(int trainCount);
		public abstract int[,] test(int testCount);
		public abstract int classify(double[] input);
	}
}
