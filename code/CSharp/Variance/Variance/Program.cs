/*
 * Created by SharpDevelop.
 * User: Pralay
 * Date: 24-12-2013
 * Time: 8:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Variance
{
	class Base {}
	class Derived_1 : Base {}
	class Derived_2 : Base {}
	
	class Program
	{
		public static void Main1(string[] args)
		{
			TestCovariance covariance = new TestCovariance();
			
			Base b = new Derived_1 ();
			Base [] barray = new Derived_1 [10];
			barray [0] = new Derived_1 ();
			barray [1] = new Derived_2 ();
			barray [2] = new Base ();
			//List<Base> blist = new List<Derived>();
		}
	}
}