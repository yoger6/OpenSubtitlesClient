using System;
using System.Collections.Generic;
using System.Xml;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseArrayParameterValue : ResponseParameterValueBase
    {
        public override T GetValue<T>()
        {
            if(typeof(T) == typeof(IList<ResponseStructParameterValue>))
            {
                return (T) _structs;
            }
            else
            {
                return (T) _data;
            }
        }

        private readonly IList<ResponseStructParameterValue> _structs = new List<ResponseStructParameterValue>();
        
        private readonly IList<string> _data = new List<string>();

        public override void ReadXml(XmlReader reader)
        {
            reader.Read();
            if (reader.Name == "data")
            {
                reader.ReadToDescendant("value");

                var hasMore = false;

                do
                {
                    reader.Read();
                    
                    if(reader.Name == "string")
                    {
                        reader.Read();
                        _data.Add(reader.ReadContentAsString());
                        reader.Read();
                    }
                    else if (reader.Name == "struct")
                    {
                        var str = new ResponseStructParameterValue();
                        str.ReadXml(reader);
                        _structs.Add(str);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Currently only string arrays are supported. {reader.Name} {GetType()}");
                    }

                    hasMore = reader.ReadToNextSibling("value");

                } while (hasMore);


            }
            else {
                bool hasMore;
                do
                {
                    var structure = new ResponseStructParameterValue();
                    structure.ReadXml(reader);
                    _structs.Add(structure);
                    hasMore = reader.ReadToNextSibling("struct");

                } while (hasMore);
            }

            base.ReadXml(reader);
        }

        protected override string NodeName => "array";
    }
}