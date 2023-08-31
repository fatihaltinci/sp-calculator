using Python.Runtime;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace MachineLearning
{
    public class Predictor
    {
        public dynamic _model;

        public Predictor()
        {
            Runtime.PythonDLL = "python310.dll";
            PythonEngine.Initialize();
        }

        public void LoadModel(string modelPath)
        {
            using (Py.GIL())
            {
                dynamic joblib = Py.Import("joblib");
                _model = joblib.load(modelPath);
            }
        }

        public double Predict(List<List<string>> inputData)
        {
            using (Py.GIL())
            {
                dynamic numpy = Py.Import("numpy");
                dynamic sklearn_preprocessing = Py.Import("sklearn.preprocessing");
                dynamic pandas = Py.Import("pandas");
                dynamic encoder = sklearn_preprocessing.OneHotEncoder();

                dynamic train_data = pandas.read_csv("C:\\Users\\Fatih\\source\\repos\\SPCalculator\\MachineLearning\\veri_seti.csv");
                dynamic train_features = train_data.drop("ParameterPoint", axis: 1);

                encoder.fit(train_features);

                dynamic veriler = new PyList();

                foreach (var row in inputData)
                {
                    dynamic rowData = new PyList();

                    foreach (var item in row)
                    {
                        rowData.append(item);
                    }

                    veriler.append(rowData);
                }

                var verilerEncoded = encoder.transform(veriler);
                var sonuclar = _model.predict(verilerEncoded);

                double tahminSonuc = sonuclar[0].As<double>();

                return tahminSonuc;
            }
        }

        public void Dispose()
        {
            PythonEngine.Shutdown();
        }
    }
}
