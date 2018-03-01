using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace qslib {
    /*
     * A class for the simplification of serializing/deserializing custom
     * objects.
     * Alex M. 2018.
     */
    [Serializable()]
    public abstract class SerializableObject {
        public SerializableObject() {

        }

        public SerializableObject(
            SerializationInfo info, StreamingContext context) {

            foreach (PropertyInfo property in this.GetType().GetProperties()) {
                property.SetValue(this, info.GetValue(property.Name,
                    property.GetType()));
            }
        }
        public void GetSerializationData(
            SerializationInfo info, StreamingContext context) {
            foreach (PropertyInfo property in this.GetType().GetProperties()) {
                info.AddValue(property.Name, property.GetValue(this));
            }
        }

        public void Save(string fileName) {
            BinaryFile.Save(fileName, this);
        }
        public static SerializableObject Load(string fileName) {
            return BinaryFile.Load<SerializableObject>(fileName);
        }
    }
}
