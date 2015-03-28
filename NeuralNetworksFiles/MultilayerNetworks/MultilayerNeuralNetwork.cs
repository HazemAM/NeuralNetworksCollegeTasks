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
