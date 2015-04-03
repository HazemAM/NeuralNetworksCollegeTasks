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
		protected double[] target;
		protected double eta;

		protected const int MAX_EPOCHS = 50;


		/*
		 * CONSTRUCTORS
		 */
		public MultilayerNeuralNetwork(Layer[] layers, DataSetReader dataSet, double[] target, double eta)
		{
			if(target.Length != dataSet.classes)
				throw new ArgumentOutOfRangeException("Target must have length equal to dataset classes");

			this.layer = layers;
			this.dataSet = dataSet;
			this.target = target;
			this.eta = eta;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train(int trainCount);
		public abstract double classify(double[] input);
	}
}
