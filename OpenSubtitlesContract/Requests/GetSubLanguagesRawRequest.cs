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
public class GetSubLanguagesRawRequest{
    
    private string methodNameField;
    
    private Params paramsField;
    
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
    public Params @params {
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
    public class Params
    {

        private ParamsParam paramField;

        /// <remarks/>
        public ParamsParam param
        {
            get
            {
                return paramField;
            }
            set
            {
                paramField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.33440")]
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(TypeName = "methodCall", Namespace = "", AnonymousType = false)]
    public class ParamsParam
    {

        private ParamsParamValue valueField;

        /// <remarks/>
        public ParamsParamValue value
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
    public class ParamsParamValue
    {

        private string stringField;

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
