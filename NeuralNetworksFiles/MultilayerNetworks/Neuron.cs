using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class Neuron
	{
		public delegate double ActivationFunction(double num);

		public readonly double[] weight;
		public readonly double bias;
		public readonly ActivationFunction activationFunction;

		public Neuron(double[] weights, double bias, ActivationFunction activationFunction)
		{
			this.weight = weights;
			this.bias = bias;
			this.activationFunction = activationFunction;
		}
	}
}
