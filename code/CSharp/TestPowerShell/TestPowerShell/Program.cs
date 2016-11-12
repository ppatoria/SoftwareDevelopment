using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TestPowerShell
{
    class Program
    {
		public string test = "";
        public string pgrep(   SwitchParameter AllMatches ,
							   SwitchParameter CaseSensitive ,
							   Int32[] Context ,
							   string Encoding ,
							   string[] Exclude,
							   string[] Include ,
							   PSObject InputObject ,
							   SwitchParameter List ,
							   SwitchParameter NotMatch ,
							   string[] Path ,
							   string[] Pattern ,
							   SwitchParameter Quiet,
							   SwitchParameter SimpleMatch) 
		//string CommonParameters)
			{
				Runspace runSpace = RunspaceFactory.CreateRunspace();
				runSpace.Open();
				Pipeline pipeline = runSpace.CreatePipeline();
				StringBuilder param = new StringBuilder();
				if (AllMatches != null) {
					param.Append("-AllMatches ");
					param.Append(AllMatches);
				}
				if(CaseSensitive != null){
					param.Append("-CaseSensitive ");
					param.Append(CaseSensitive);
				}
				if (Context != null) {
					param.Append("-Context ");
					param.Append(Context);
				}
				if(Encoding != null){
					param.Append("-Encoding ");
					param.Append(Encoding);
				}
				if (Exclude != null) {
					param.Append("-Exclude ");
					param.Append(Exclude);
				}
				if (Include != null) {
					param.Append("-Include ");
					param.Append(Include);
				}
				if (InputObject != null) {
					param.Append("-InputObject ");
					param.Append(InputObject);
				}
				if (List != null) {
					param.Append("-List ");
					param.Append(List);
				}
				if (NotMatch != null) {
					param.Append("-NotMatch ");
					param.Append(NotMatch);
				}
				if (Path != null) {
					param.Append("-Path ");
					param.Append(Path);
				}
				if (Pattern != null) {
					param.Append("-Pattern ");
					param.Append(Pattern);
				}
				if (Quiet != null) {
					param.Append("-Quiet ");
					param.Append(Quiet);
				}
				if (SimpleMatch != null) {
					param.Append("-SimpleMatch ");
					param.Append(SimpleMatch);
				}
				//AllMatches,CaseSensitive ,Context ,Encoding ,Exclude,Include ,InputObject ,List ,NotMatch ,Path ,Pattern ,Quiet ,SimpleMatch 
				//string.Format(@"-AllMatches {0}, -CaseSensitive {1} ,-Context {2} ,Encoding {3},Exclude {4},Include {5},InputObject {6},List {7},NotMatch {8},Path {9},Pattern {10},Quiet {11},SimpleMatch {12}")
				//string CommonParameters)
				string pgrep = string.Format("{0} {1}", "Select-String", param);
				Console.WriteLine(pgrep);
				pipeline.Commands.AddScript(pgrep);
				pipeline.Commands.Add("Out-String");
				Collection<PSObject> results = pipeline.Invoke();
				runSpace.Close();            
				StringBuilder strBuilder = new StringBuilder();
				foreach (PSObject obj in results) {
					strBuilder.AppendLine(obj.ToString());
				}

				Console.WriteLine(strBuilder.ToString());
				Console.Read();
				return strBuilder.ToString();
			}
        public string test(string param)
			{
				Runspace runSpace = RunspaceFactory.CreateRunspace();
				runSpace.Open();
				Pipeline pipeline = runSpace.CreatePipeline();
				string pgrep = string.Format("{0} {1}", "Select-String", param);
				pipeline.Commands.AddScript(pgrep);
				pipeline.Commands.Add("Out-String");
				Collection<PSObject> results = pipeline.Invoke();
				runSpace.Close();            
				StringBuilder strBuilder = new StringBuilder();
				foreach (PSObject obj in results) {
					strBuilder.AppendLine(obj.ToString());
				}

				Console.WriteLine(strBuilder.ToString());
				Console.Read();
				return strBuilder.ToString();
			}
        static void Main(string[] args)
			{

				Program test = new Program();
				test.pgrep(null, null, null, null, null, null, null, null, null, @"c:\Users\Pralay\Documents\dd.txt", "address", null, null);
            
				//p.test(@"address c:\Users\Pralay\Documents\dd.txt");
            
				//pipeline.Commands.Add(sort);
				//Process process = (Process)(pipeline.Invoke()[0].BaseObject);
            
				//Console.WriteLine(process.ProcessName);
				//Console.Read();
				//Collection<PSObject> output = new Collection<PSObject>();
				//output = pipeline.Invoke();
				//foreach (PSObject psObject in output) {
				//    Process process = (Process)psObject.BaseObject;
				//    Console.WriteLine("Process name: " + process.ProcessName);
				//}
				//Console.Read();
			}
    }
}

