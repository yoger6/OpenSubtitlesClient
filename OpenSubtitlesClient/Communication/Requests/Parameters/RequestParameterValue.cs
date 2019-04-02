using System.Xml;

namespace OpenSubtitlesClient.Communication.Requests.Parameters
{
    public class RequestParameterValue : RequestParameterValueBase
    {
        public static RequestParameterValueBase String(string value = null)
        {
            return new RequestParameterValue("string", value);
        }

        public static RequestParameterValueBase Double(double value)
        {
            return new DoubleRequestParameterValue(value);
        }

        public static RequestParameterValueBase Int(int value)
        {
            return new RequestParameterValue("int", value.ToString());
        }

        public static RequestParameterValueBase Int(bool value)
        {
            var bit = value ? 1 : 0;
            return new RequestParameterValue("int", bit.ToString());
        }

        public static RequestParameterValueBase Array(params RequestParameterValueBase[] data)
        {
            return new RequestArrayRequestParameterValue(data);
        }

        public static RequestParameterValueBase Struct(params RequestParameterValueBase[] members)
        {
            return new StructRequestParameterValue(members);
        }

        public static RequestParameterValueBase Member(string name, RequestParameterValueBase value)
        {
            return new MemberRequestParameterValue(name, value);
        }

        private readonly string _type;
        private readonly string _value;

        public RequestParameterValue()
        {
        }

        private RequestParameterValue(string type, string value)
        {
            _type = type;
            _value = value;
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString(_type, _value);
        }

        private class RequestArrayRequestParameterValue : RequestParameterValueBase
        {
            private const string Type = "array";
            private const string DataType = "data";

            private readonly RequestParameterValueBase[] _data;

            public RequestArrayRequestParameterValue(params RequestParameterValueBase[] data)
            {
                _data = data;
            }

            public override void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement(Type);
                writer.WriteStartElement(DataType);

                foreach (var value in _data)
                {
                    writer.WriteStartElement("value");
                    value.WriteXml(writer);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        private class DoubleRequestParameterValue : RequestParameterValueBase
        {
            private const string Type = "double";

            private readonly double _value;

            public DoubleRequestParameterValue(double value)
            {
                _value = value;
            }

            public override void WriteXml(XmlWriter writer)
            {
                writer.WriteElementString(Type, _value.ToString("##.###"));
            }
        }

        private class StructRequestParameterValue : RequestParameterValueBase
        {
            private readonly RequestParameterValueBase[] _membersRequest;

            public StructRequestParameterValue()
            {
            }

            public StructRequestParameterValue(params RequestParameterValueBase[] membersRequest)
            {
                _membersRequest = membersRequest;
            }

            public override void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("struct");
                foreach (var member in _membersRequest)
                {
                    member.WriteXml(writer);
                }
                writer.WriteEndElement();
            }
        }

        private class MemberRequestParameterValue : RequestParameterValueBase
        {
            private readonly string _name;
            private readonly RequestParameterValueBase _value;

            public MemberRequestParameterValue()
            {
            }

            public MemberRequestParameterValue(string name, RequestParameterValueBase value)
            {
                _name = name;
                _value = value;
            }

            public override void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("member");
                writer.WriteElementString("name", _name);
                writer.WriteStartElement("value");
                _value.WriteXml(writer);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}