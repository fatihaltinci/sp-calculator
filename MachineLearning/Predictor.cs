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
            // Python.Runtime'ı başlatın
            Runtime.PythonDLL = "python310.dll";
            PythonEngine.Initialize();
        }

        public void LoadModel(string modelPath)
        {
            // Eğitilmiş modeli yükleyin
            using (Py.GIL())
            {
                dynamic joblib = Py.Import("joblib");
                _model = joblib.load(modelPath);
            }
        }

        public double Predict(List<List<string>> inputData)
        {
            // Giriş verisini modele tahmin etmek için uygun hale getirin ve tahmin yapın
            using (Py.GIL())
            {
                dynamic numpy = Py.Import("numpy");
                dynamic sklearn_preprocessing = Py.Import("sklearn.preprocessing");
                dynamic pandas = Py.Import("pandas");
                dynamic encoder = sklearn_preprocessing.OneHotEncoder();

                dynamic train_data = pandas.read_csv("C:\\Users\\Fatih\\source\\repos\\SPCalculator\\MachineLearning\\veri_seti.csv");
                dynamic train_features = train_data.drop("ParameterPoint", axis: 1);

                // One-Hot Encoder'ı yükle ve eğitim verisine uygula
                encoder.fit(train_features);

                // Verileri Python için uygun hale getirin
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

                // Tahmin yapın
                var verilerEncoded = encoder.transform(veriler);
                var sonuclar = _model.predict(verilerEncoded);

                // İlk tahmin sonucunu al ve döndür
                double tahminSonuc = sonuclar[0].As<double>(); // veya double olarak dönüştürün

                return tahminSonuc;
            }
        }

        public void Dispose()
        {
            // Python.Runtime'ı kapatın
            PythonEngine.Shutdown();
        }
    }
}
