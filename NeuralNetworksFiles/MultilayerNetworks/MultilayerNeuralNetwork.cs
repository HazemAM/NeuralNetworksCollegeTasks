using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public abstract class MultilayerNeuralNetwork
	{
		/*
		 * FIELDS
		 */
		protected Layer[] layer;
		protected double eta;

		protected const int MAX_EPOCHS = 500;


		/*
		 * CONSTRUCTORS
		 */
		public MultilayerNeuralNetwork(Layer[] layers, double eta)
		{
			this.layer = layers;
			this.eta = eta;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train();
	}
}
