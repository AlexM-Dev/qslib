using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace qslib {
    public class BinaryFile {
        public static void Save<T>(string fileName, T obj) {
            using (Stream stream = System.IO.File.Open(fileName, FileMode.Create)) {
                var binary = new BinaryFormatter();

                binary.Serialize(stream, obj);
            }
        }
        public static T Load<T>(string fileName) {
            using (Stream stream = System.IO.File.Open(fileName, FileMode.Open)) {
                var binary = new BinaryFormatter();

                return (T)binary.Deserialize(stream);
            }
        }
    }
}
