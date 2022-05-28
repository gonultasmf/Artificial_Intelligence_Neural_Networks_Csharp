namespace Neural_Networks
{
    public partial class Form1 : Form
    {
        List<Data> dataList;
        int classCount = 0;
        public Form1()
        {
            InitializeComponent();
            dataList = new List<Data>();
            
            double[] d1 = { 1, 2 };
            double[] d2 = { 1, 3 };
            double[] d3 = { -3, 1 };
            double[] d4 = { -2, 2 };
            double[] d5 = { -2, -2 };
            double[] d6 = { -1, -1 };
            dataList.Add(new Data(d1, 0));
            dataList.Add(new Data(d2, 0));
            dataList.Add(new Data(d3, 1));
            dataList.Add(new Data(d4, 1));
            dataList.Add(new Data(d5, 2));
            dataList.Add(new Data(d6, 2));

            HashSet<int> classArray = new HashSet<int>();
            for (int i = 0; i < dataList.Count; i++)
            {
                classArray.Add(dataList[i].output);
            }
            classCount = classArray.Count;
        }
        public void SingleLayerSingleNeuron(double c, int dimension, double bias)
        {

            Neuron neuron = new Neuron(bias, dimension, new BinaryFunction());
            while (true)
            {
                double error = 0;
                for (int i = 0; i < dataList.Count; i++)
                {
                    double net = neuron.function.net(dataList[i].input, neuron.w, neuron.bias);
                    double fnet = neuron.function.calculate(net);
                    for (int j = 0; j < (dimension - 1); j++)
                    {
                        neuron.w[j] = neuron.w[j] + c * (dataList[i].output - fnet) * dataList[i].input[j];
                    }
                    neuron.w[dimension - 1] = neuron.w[dimension - 1] + c * (dataList[i].output - fnet) * neuron.bias;
                    error = error + Math.Pow(dataList[i].output - fnet, 2) / 2;
                }
                if (error > 0.1)
                    break;
            }
            MessageBox.Show(neuron.getW());
        }
        public void SingleLayerMultiNeuron(double c, int dimension, double bias)
        {
            List<Neuron> neuronList = new List<Neuron>();
            for (int i = 0; i < classCount; i++)
            {
                neuronList.Add(new Neuron(bias, dimension, new BinaryFunction()));
            }
            while (true)
            {
                double error = 0;

                for (int i = 0; i < dataList.Count; i++)
                {
                    for (int j = 0; j < classCount; j++)
                    {
                        Neuron neuron = neuronList[j];
                        double net = neuronList[j].function.net(dataList[i].input, neuron.w, neuron.bias);
                        double fnet = neuron.function.calculate(net);
                        for (int k = 0; k < (dimension - 1); k++)
                        {
                            neuron.w[k] = neuron.w[k] + c * (neuron.getClass(dataList[i].output, j) - fnet) * dataList[i].input[k];
                        }
                        neuron.w[dimension - 1] = neuron.w[dimension - 1] + c * (neuron.getClass(dataList[i].output, j) - fnet) * neuron.bias;
                        error = error + Math.Pow(neuron.getClass(dataList[i].output, j) - fnet, 2) / 2;
                    }
                }

                if(error < 0.1 * classCount)
                    break;
            }
            for (int i = 0; i < neuronList.Count; i++)
            {
                MessageBox.Show(neuronList[i].getW());
            }
            
        }

        private void btnSLSN_Click(object sender, EventArgs e)
        {
            SingleLayerSingleNeuron(0.1, dataList[0].input.Length + 1, 1);
        }

        private void btnSLMN_Click(object sender, EventArgs e)
        {
            SingleLayerMultiNeuron(0.1, dataList[0].input.Length + 1, 1);
        }
    }

    class Data
    {
        public double[] input { get; set; }
        public int output { get; set; }

        public Data(double[] input, int output)
        {
            this.input = input;
            this.output = output;
        }
    }

    class Neuron
    {
        public double bias { get; set; }
        public double[] w { get; set; }
        public Function function { get; set; }

        public Neuron(double bias, int dimension, Function function)
        {
            this.bias = bias;
            this.w = new double[dimension];
            for (int i = 0; i < dimension; i++)
                this.w[i] = new Random().NextDouble();
            this.function = function;
        }
        public string getW()
        {
            string data = "";
            for (int i = 0; i < w.Length; i++)
            {
                data += w[i].ToString() + "\n";
            }
            return data;
        }
        public double getClass(int classNumber, int classIndex)
        {
            if (classNumber == classIndex)
                return 1;
            else
                return -1;
        }
    }

    abstract class Function
    {
        public double net(double[] input, double[] w, double bias)
        {
            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * w[i];

            }
            return sum + w[w.Length - 1] * bias;
        }
        public abstract double calculate(double net);
    }

    class BinaryFunction : Function
    {
        public override double calculate(double net)
        {
            if (net > 0)
                return 1;
            else
                return -1;
        }
    }
    class ContinousFunction : Function
    {
        public override double calculate(double net)
        {
            return 1 / (1 + Math.Pow(Math.E, -net));
        }
    }
}