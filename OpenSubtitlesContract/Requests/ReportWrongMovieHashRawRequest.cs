//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.33440")]
[System.Serializable()]
[System.Diagnostics.DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(TypeName = "methodCall", Namespace = "", AnonymousType = false)]
[System.Xml.Serialization.XmlRoot(Namespace="", IsNullable=false)]
public class ReportWrongMovieHashRawRequest{
    
    private string methodNameField;
    
    private Param[] paramsField;
    
    /// <remarks/>
    public string methodName {
        get {
            return methodNameField;
        }
        set {
            methodNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItem("param", IsNullable=false)]
    public Param[] @params {
        get {
            return paramsField;
        }
        set {
            paramsField = value;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.33440")]
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(TypeName = "methodCall", Namespace = "", AnonymousType = false)]
    public class Param
    {

        private ParamValue valueField;

        /// <remarks/>
        public ParamValue value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.33440")]
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(TypeName = "methodCall", Namespace = "", AnonymousType = false)]
    public class ParamValue
    {

        private ushort intField;

        private bool intFieldSpecified;

        private string stringField;

        /// <remarks/>
        public ushort @int
        {
            get
            {
                return intField;
            }
            set
            {
                intField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intSpecified
        {
            get
            {
                return intFieldSpecified;
            }
            set
            {
                intFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string @string
        {
            get
            {
                return stringField;
            }
            set
            {
                stringField = value;
            }
        }
    }
}
