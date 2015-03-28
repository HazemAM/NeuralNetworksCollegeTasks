﻿using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class BackPropagation : MultilayerNeuralNetwork
	{
		public BackPropagation(Layer[] layers, double eta)
			: base(layers, eta)
		{
			//Nothing here.
		}

		public override void train(){
			double[] input = new double[] {0, 0};
			double[] target = new double[] {0};

			Layer outputLayer = layer[layer.Length - 1];
			double[][] outputValue = new double[layer.Length][]; //Holding output data for every iteration.
			double[][] error = new double[layer.Length][]; //Holding error data for every iteration.


			/*
			 * FORWARD STEP
			 * Target vs. output
			 */
			double tempNet = 0, tempMult = 0;
			bool isFirstLayer = true;
			int previousLayerNeurons = 0;
			for(int i=0; i < layer.Length; i++) //The layers loop.
			{
				outputValue[i] = new double[layer[i].neuron.Length]; //Define output inner array of layer's neuron count.
				for(int j=0; j < layer[i].neuron.Length; j++) //The neurons loop (for each layer).
				{
					tempNet = layer[i].neuron[j].biasWeight * layer[i].neuron[j].bias; //Interaction with bias.
					
					isFirstLayer = (i == 0); //Indicates: This is the first layer after input layer.
					previousLayerNeurons = isFirstLayer ? input.Length : layer[i - 1].neuron.Length; //If this is first layer after input,
					for(int k=0; k < previousLayerNeurons; k++){									 //interact with input layer. Else, interact with previous layer.
						if(layer[i].neuron[j].weight.Length != previousLayerNeurons)
							throw new ArgumentException("Neuron must have weight length of the previous layer's neurons");

						tempMult = isFirstLayer ? input[k] : outputValue[i - 1][k]; //If this is the first layer, multiply with input layer.
						tempNet += layer[i].neuron[j].weight[k] * tempMult; //+1 for bias.
					}

					outputValue[i][j] = layer[i].neuron[j].activationFunction(tempNet); //Calculating net for current neuron.
				}
			}

			/* ITERATION CONTINUE CHECK */
			bool isTargetEqualsOutput = true;
			double[] outputLayerNet = outputValue[outputValue.Length - 1];
			for(int i=0; i < outputLayer.neuron.Length; i++) //Check if all neurons in output layer equals the corresponding target.
				if((isTargetEqualsOutput = (target[i] == outputLayerNet[i])) == false) break; //Break on first (target != output).

			//if(isTargetEqualsOutput)
			//	break;


			/*
			 * BACKWARD STEP
			 * Error calculations
			 */
			bool isOutputLayer = true;
			double tempPlus;
			for(int i = layer.Length - 1; i >= 0; i--) //The layers loop, REVERSED.
			{
				error[i] = new double[layer[i].neuron.Length]; //Define error inner array of layer's neuron count.
					
				isOutputLayer = (i == layer.Length - 1);
				for(int j=0; j < layer[i].neuron.Length; j++) //The neurons loop (for each layer).
				{
					error[i][j] = layer[i].neuron[j].activationFunctionDerivative(outputValue[i][j]);

					if(isOutputLayer) //Special treatment for output layer.
						error[i][j] *= (target[j] - outputValue[i][j]);
					else{
						tempPlus = 0;
						for(int k=0; k < layer[i + 1].nodes; k++)
							tempPlus += layer[i + 1].neuron[k].weight[j] * error[i + 1][k];
						error[i][j] *= tempPlus;
					}
				}
			}
		}
	}
}