using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class Layer
	{
		public readonly Neuron[] neuron;
		public readonly double[] value;
		public readonly LayerType type;
		public readonly int nodes;

		public Layer(Neuron[] neurons)
		{
			this.neuron = neurons;
			this.nodes = neuron.Length;
			type = LayerType.NEURON_LAYER;
		}

		public Layer(Neuron neuron)
		{
			this.neuron = new Neuron[]{neuron};
			this.nodes = 1;
			type = LayerType.NEURON_LAYER;
		}

		public Layer(double[] values)
		{
			this.value = values;
			this.nodes = value.Length;
			type = LayerType.VALUE_LAYER;
		}
	}
}
