using System;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class ResultDataReader : XmlDataReader
    {
        private const string XmlTagRow = "ns1:rbd_Areas";

        private const int FieldCount = 4;
        private const int InvalidItemId = -1;

        public ResultDataReader(XmlReader xmlReader)
            : base(xmlReader, FieldCount, XmlTagRow) { }

        public override object GetValue(int i)
        {
            switch (i)
            {
                case 0:
                    return CurrentElement.GuidFromValue<Guid>();
                case 1:
                    return CurrentElement.Element("Region").IntFromValue<int>();
                case 2:
                    return CurrentElement.Element("AreaCode").Value;
                case 3:
                    return CurrentElement.Element("AreaName").Value;
                default:

                    throw new InvalidOperationException("Column count mismatch.");
            }
        }
    }
}
