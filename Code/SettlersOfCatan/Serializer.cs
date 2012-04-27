using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace SettlersOfCatan
{
    public class Serializer
    {
        /// <summary>
        /// Function to save object to external file
        /// </summary>
        /// <param name="_Object">object to save</param>
        /// <param name="fileName">File name to save object</param>
        /// <returns>Return true if object save successfully, if not return false</returns>
        public bool ObjectToFile(object _Object, string fileName)
        {
            try
            {
                // create new memory stream
                var _MemoryStream = new MemoryStream();

                // create new BinaryFormatter
                var _BinaryFormatter
                    = new BinaryFormatter();

                // Serializes an object, or graph of connected objects, to the given stream.
                _BinaryFormatter.Serialize(_MemoryStream, _Object);

                // convert stream to byte array
                byte[] _ByteArray = _MemoryStream.ToArray();

                // Open file for writing
                var _FileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                // Writes a block of bytes to this stream using data from a byte array.
                _FileStream.Write(_ByteArray.ToArray(), 0, _ByteArray.Length);

                // close file stream
                _FileStream.Close();

                // cleanup
                _MemoryStream.Close();
                _MemoryStream.Dispose();
                _MemoryStream = null;
                _ByteArray = null;

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception);
            }

            // Error occured, return null
            return false;
        }

        /// <summary>
        /// Function to get object from external file
        /// </summary>
        /// <param name="fileName">File name to get object</param>
        /// <returns>object</returns>
        public object FileToObject(string fileName)
        {
            try
            {
                // Open file for reading
                var _FileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                // attach filestream to binary reader
                var _BinaryReader = new BinaryReader(_FileStream);

                // get total byte length of the file
                long _TotalBytes = new FileInfo(fileName).Length;

                // read entire file into buffer
                byte[] _ByteArray = _BinaryReader.ReadBytes((Int32) _TotalBytes);

                // close file reader and do some cleanup
                _FileStream.Close();
                _FileStream.Dispose();
                _FileStream = null;
                _BinaryReader.Close();

                // convert byte array to memory stream
                var _MemoryStream = new MemoryStream(_ByteArray);

                // create new BinaryFormatter
                var _BinaryFormatter
                    = new BinaryFormatter();

                // set memory stream position to starting point
                _MemoryStream.Position = 0;

                // Deserializes a stream into an object graph and return as a object.
                return _BinaryFormatter.Deserialize(_MemoryStream);
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception);
            }

            // Error occured, return null
            return null;
        }

        public GameController Load(string fileName)
        {
            return (GameController) FileToObject(fileName);
        }

        public bool Save(object _Object, string fileName)
        {
            return ObjectToFile(_Object, fileName);
        }
    }
}