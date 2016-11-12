using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MSPress.CSharpCoreRef.XmlListener
{
    public class XmlStreamTraceListener: TraceListener
    {
        public XmlStreamTraceListener(){}

        public XmlStreamTraceListener(string name): base(name){}

        public XmlStreamTraceListener(Stream stream, string name)
            : base(name)
        {
            Open(stream);
        }

        public override void Close()
        {
            if(_writer != null)
            {
                _writer.Close();
                _writer = null;
            }
            else
                throw new InvalidOperationException();
        }

        public void Open(Stream stream)
        {
            _writer = new XmlTextWriter(stream, Encoding.UTF8);
            _writer.Formatting = Formatting.Indented;
            WriteDocumentHeader();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_writer != null)
                {
                    _writer.Close();
                }
            }
        }

        public override void Fail(string message)
        {
            WriteFailNode(message, null);
        }

        public override void Fail(string message, string detailMessage)
        {
            WriteFailNode(message, detailMessage);
        }

        public override void Flush()
        {
            _writer.Flush();
        }

        public override void Write(object o)
        {
            WriteTraceNode(o.ToString(), null);
        }

        public override void Write(string message)
        {
            WriteTraceNode(message, null);
        }

        public override void Write(object o, string category)
        {
            WriteTraceNode(o.ToString(), category);
        }

        public override void Write(string message, string category)
        {
            WriteTraceNode(message, category);
        }

        public override void WriteLine(object o)
        {
            WriteTraceNode(o.ToString(), null);
        }

        public override void WriteLine(string message)
        {
            WriteTraceNode(message, null);
        }

        public override void WriteLine(object o, string category)
        {
            WriteTraceNode(o.ToString(), category);
        }

        public override void WriteLine(string message, string category)
        {
            WriteTraceNode(message, category);
        }

        protected void WriteFailNode(string message, string detail)
        {
            _writer.WriteStartElement("AssertionViolation", traceNamespace);
            if(_stackTrace == true)
            {
                WriteStackTrace();
            }
            if(message != null && message.Length != 0)
            {
                _writer.WriteElementString("Message", 
                    traceNamespace,
                    message);
            }
            if(detail != null && detail.Length != 0)
            {
                _writer.WriteElementString("DetailedMessage", 
                    traceNamespace,
                    detail);
            }
            _writer.WriteEndElement(); // AssertionViolation
        }

        protected void WriteTraceNode(string message, string category)
        {
            _writer.WriteStartElement("Trace", traceNamespace);
            if(_stackTrace == true)
            {
                WriteStackTrace();
            }
            _writer.WriteStartElement("Message");
            if(category != null)
            {
                string prefix = _writer.LookupPrefix(traceNamespace);
                _writer.WriteStartAttribute(prefix,
                                            "Category",
                                            traceNamespace);
                _writer.WriteString(category);
                _writer.WriteEndAttribute();     
            }
            _writer.WriteString(message);
            _writer.WriteEndElement(); // Message
            _writer.WriteEndElement(); // Trace
        }

        protected void WriteStackTrace()
        {
            _writer.WriteStartElement("Stack", traceNamespace);
            _writer.WriteStartElement("StackFrames", traceNamespace);

            StackTrace trace = new StackTrace(true);
            int frameCount = trace.FrameCount;
            for(int n = 0; n < frameCount; ++n)
            {
                StackFrame frame = trace.GetFrame(n);
                MethodBase methodBase = frame.GetMethod();

                // Don't display ourselves or internal tracing
                // methods in the callstack.
                if(methodBase.ReflectedType == this.GetType() ||
                   methodBase.ReflectedType == typeof(Trace)  ||
                   methodBase.ReflectedType.Name == "TraceInternal")
                   continue;
                
                // If part of the call stack lacks debug symbols, we
                // won't have valid data for these values.
                string fileName = frame.GetFileName();
                if(fileName == null)
                    fileName = "Not available";
                string lineNo = frame.GetFileLineNumber().ToString();
                string methodName = methodBase.Name;
                if(methodName == null)
                    methodName = "Not available";

                _writer.WriteStartElement("StackFrame", traceNamespace);
                _writer.WriteElementString("FileName",
                    traceNamespace,
                    fileName);
                _writer.WriteElementString("LineNumber", 
                    traceNamespace,
                    lineNo);
                _writer.WriteElementString("MethodName",
                    traceNamespace,
                    methodName);
                _writer.WriteEndElement(); // StackFrame
            }
            _writer.WriteEndElement(); // StackFrames
            _writer.WriteEndElement(); // Stack
        }

        protected void WriteDocumentHeader()
        {
            _writer.WriteStartDocument(true);
            _writer.WriteStartElement(tracePrefix,
                                      "TraceInformation",
                                      traceNamespace);
            _writer.WriteStartElement("Traces",
                                      traceNamespace);
        }

        protected void CloseDocument()
        {
            _writer.WriteEndDocument();
            _writer.Close();
        }

        bool StackTrace
        {
            set { _stackTrace = value; }
            get { return _stackTrace; }
        }

        protected bool _stackTrace = true;
        protected XmlTextWriter _writer = null;

        private const string traceNamespace = "urn:csharpcoreref";
        private const string tracePrefix    = "cscr";
    }
}
