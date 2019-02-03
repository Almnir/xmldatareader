using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{

    public abstract class XmlDataReader : IDataReader
    {
        private readonly string m_rowElementName;

        private readonly XmlReader m_xmlReader;
        private readonly int m_fieldCount = -1;

        private bool m_disposed;

        protected IEnumerator<XElement> m_enumerator;

        public abstract object GetValue(int i);

        /// <summary>
        /// Initialize the XmlDataStreamer. After initialization call Read() to move the reader forward.
        /// </summary>
        /// <param name="xmlReader">XmlReader used to iterate the data. Will be disposed by when done.</param>
        /// <param name="fieldCount">IDataReader FiledCount.</param>
        /// <param name="rowElementName">Name of the XML element that contains row data</param>
        public XmlDataReader(XmlReader xmlReader, int fieldCount, string rowElementName)
        {
            m_rowElementName = rowElementName;
            m_fieldCount = fieldCount;
            m_xmlReader = xmlReader;
            m_enumerator = GetXmlStream().GetEnumerator();
        }

        public bool Read()
        {
            return m_enumerator.MoveNext();
        }

        public int FieldCount
        {
            get { return m_fieldCount; }
        }

        public XElement CurrentElement
        {
            get { return m_enumerator.Current; }
        }

        public int Depth => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public int RecordsAffected => throw new NotImplementedException();

        public object this[string name] => throw new NotImplementedException();

        public object this[int i] => throw new NotImplementedException();

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/system.xml.linq.xstreamingelement.aspx
        /// </summary>
        /// <param name="m_xmlReader"></param>
        /// <returns></returns>
        private IEnumerable<XElement> GetXmlStream()
        {
            XElement rowElement;
            using (m_xmlReader)
            {
                m_xmlReader.MoveToContent();

                while (m_xmlReader.Read())
                {
                    if (IsRowElement())
                    {
                        rowElement = XElement.ReadFrom(m_xmlReader) as XElement;
                        if (rowElement != null)
                        {
                            yield return rowElement;
                        }
                    }
                }
            }
        }

        private bool IsRowElement()
        {
            if (m_xmlReader.NodeType != XmlNodeType.Element)
                return false;

            //return m_xmlReader.Name == m_rowElementName;
            if (m_xmlReader.Name == m_rowElementName)
            {
                return false;
            }
            return true;
        }

        protected virtual void Dispose()
        {
            if (m_disposed)
                return;

            m_enumerator.Dispose();
            m_disposed = true;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }
    }

}
