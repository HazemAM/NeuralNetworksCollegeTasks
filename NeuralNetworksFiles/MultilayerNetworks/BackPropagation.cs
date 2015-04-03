﻿using System;

namespace NeuralNetworks.MultilayerNetworks
{
	public class BackPropagation : MultilayerNeuralNetwork
	{
		public BackPropagation(Layer[] layers, DataSetReader dataSet, double eta)
			: base(layers, dataSet, eta)
		{
			//Nothing here.
		}

		public override void train(int trainCount)
		{
			int epochs = 0;
			double[][] outputValue,	//Holding output data for every iteration.
					   error;		//Holding error data for every iteration.
			double[] input;			//Holding input for every sample.

			while(epochs < MultilayerNeuralNetwork.MAX_EPOCHS)
			{
				for(int c=0; c < this.dataSet.classes; c++) //Class index.
				{
					for(int s=0; s < trainCount; s++) //Sample index.
					{
						input = this.dataSet.dataNorm[c][s];
						error = new double[this.layer.Length][];


						/*
						 * FORWARD STEP
						 * Target vs. output
						 */
						outputValue = forwardStep(input);

						/* ITERATION CONTINUE CHECK */
						//bool isTargetEqualsOutput = true;
						//Layer outputLayer = this.layer[this.layer.Length - 1];
						//double[] outputLayerNet = outputValue[outputValue.Length - 1];
						//for(int i=0; i < outputLayer.nodes; i++) //Check if all neurons in output layer equals the corresponding target.
						//	if((isTargetEqualsOutput = (this.target[i] == outputLayerNet[i])) == false) break; //Break on first (target != output).

						//if(isTargetEqualsOutput)
						//	break;


						/*
						 * BACKWARD STEP
						 * Error calculations
						 */
						bool isOutputLayer = true;
						double tempPlus;
						int desiredOutput;
						for(int i = this.layer.Length - 1; i >= 0; i--) //The layers loop, REVERSED.
						{
							error[i] = new double[this.layer[i].nodes]; //Define error inner array of layer's neuron count.
							isOutputLayer = (i == this.layer.Length - 1);

							for(int j=0; j < this.layer[i].nodes; j++) //The neurons loop (for each layer).
							{
								error[i][j] = this.layer[i].neuron[j].activationFunctionDerivative(outputValue[i][j]);

								if(isOutputLayer){ //Special treatment for output layer.
									desiredOutput = (c == j) ? 1 : 0;
									error[i][j] *= (desiredOutput - outputValue[i][j]);
								}
								else{
									tempPlus = 0;
									for(int k=0; k < this.layer[i + 1].nodes; k++)
										tempPlus += this.layer[i + 1].neuron[k].weight[j] * error[i + 1][k];
									error[i][j] *= tempPlus;
								}
							}
						}


						/*
						 * SECOND FORWARD STEP
						 * Weights update
						 */
						bool isFirstLayer = true;
						double tempMult = 0;
						for(int i=0; i < this.layer.Length; i++) //The layers loop.
						{
							isFirstLayer = (i == 0); //Indicates: This is the first layer after input layer.
							for(int j=0; j < this.layer[i].nodes; j++) //The neurons loop (for each layer).
							{
								this.layer[i].neuron[j].biasWeight += this.eta * error[i][j] * this.layer[i].neuron[j].bias; //Update bias weight.

								for(int k=0; k < this.layer[i].neuron[j].weight.Length; k++){ //Update other weights.
									tempMult = isFirstLayer ? input[k] : outputValue[i - 1][k];
									this.layer[i].neuron[j].weight[k] += this.eta * error[i][j] * tempMult;
								}
							}
						}
					} //End of sample loop.
				} //End of class loop.

				/* END OF CURRENT EPOCH */
				epochs++;
			} //End of mother loop.
		}

		private double[][] forwardStep(double[] input)
		{
			double[][] outputValue = new double[this.layer.Length][];

			double tempNet = 0, tempMult = 0;
			bool isFirstLayer = true;
			for(int i=0; i < this.layer.Length; i++) //The layers loop.
			{
				outputValue[i] = new double[this.layer[i].nodes]; //Define output inner array of layer's neuron count.
				for(int j=0; j < this.layer[i].nodes; j++) //The neurons loop (for each layer).
				{
					tempNet = this.layer[i].neuron[j].biasWeight * this.layer[i].neuron[j].bias; //Interaction with bias.					
					isFirstLayer = (i == 0); //Indicates: This is the first layer after input layer.

					for(int k=0; k < this.layer[i].neuron[j].weight.Length; k++){
						if(i > 0 && this.layer[i].neuron[j].weight.Length != this.layer[i - 1].nodes) //In case weights doesn't equal previous layer's neurons.
							throw new ArgumentException("Neuron must have weight length of the previous layer's neurons");
							//TODO: Check first layer's neurons too (when i==0).

						tempMult = isFirstLayer ? input[k] : outputValue[i - 1][k]; //If this is the first layer, multiply with input layer.
						tempNet += this.layer[i].neuron[j].weight[k] * tempMult;
					}

					outputValue[i][j] = this.layer[i].neuron[j].activationFunction(tempNet); //Calculating net for current neuron.
				}
			}

			return outputValue;
		}

		public override int classify(double[] input)
		{
			input = dataSet.norm(input);
			
			double[][] output = forwardStep(input);
			int max = VectorTools.maxIndex(output[output.Length - 1]);
			return max;
		}

		public override int[,] test(int testCount)
		{
			int[,] confMatrix = new int[this.dataSet.classes, this.dataSet.classes];

			int startIndex = this.dataSet.samples - testCount - 1;
			int classOut;
			double[] lineData;

			for(int c=0; c < this.dataSet.classes; c++)
			{
				for(int j=0; j < testCount; j++)
				{
					lineData = this.dataSet.data[c][startIndex + j]; //Data is already normalized in classify,
					classOut = classify(lineData);					 //so send the UN-NORMALIZED data.

					confMatrix[c, classOut]++;
				}
			}

			return confMatrix;
		}
	}
}
