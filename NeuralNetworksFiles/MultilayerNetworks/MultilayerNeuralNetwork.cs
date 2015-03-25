using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public abstract class MultilayerNeuralNetwork
	{
		/*
		 * FIELDS
		 */
		protected Layer[] layer;


		/*
		 * CONSTRUCTORS
		 */
		public MultilayerNeuralNetwork(Layer[] layers)
		{
			this.layer = layers;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train();
	}
}
