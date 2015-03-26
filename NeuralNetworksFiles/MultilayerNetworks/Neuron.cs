using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class Neuron
	{
		public delegate double ActivationFunction(double num);

		public readonly double[] weight;
		public readonly double bias;
		public readonly double biasWeight;
		public readonly ActivationFunction activationFunction;

		public Neuron(double[] weights, double bias, double biasWeight, ActivationFunction activationFunction)
		{
			this.weight = weights;
			this.bias = bias;
			this.biasWeight = biasWeight;
			this.activationFunction = activationFunction;
		}
	}
}
