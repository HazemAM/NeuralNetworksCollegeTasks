using System;
using System.Collections.Generic;

namespace NeuralNetworks.MultilayerNetworks
{
	public abstract class MultilayerNeuralNetwork
	{
		/*
		 * FIELDS
		 */
		protected Layer[] layer;
		protected List<double[]>[] data;
		protected double[] target;
		protected double eta;
		protected int samples;

		protected const int MAX_EPOCHS = 500;


		/*
		 * CONSTRUCTORS
		 */
		public MultilayerNeuralNetwork(Layer[] layers, DataSetReader dataSet, double[] target, double eta)
		{
			if(target.Length != dataSet.classes)
				throw new ArgumentOutOfRangeException("Target must have length equal to dataset classes");

			this.layer = layers;
			this.data = dataSet.data;
			this.samples = dataSet.samples;
			this.target = target;
			this.eta = eta;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train(int trainCount);
	}
}
