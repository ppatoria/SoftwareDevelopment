using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ComponentModel;

namespace AmazonPS
{
	[RunInstaller(true)]
	public class AmazonPSSnapIn : CustomPSSnapIn
	{
		private Collection<CmdletConfigurationEntry> _cmdlets;
		/// <summary>
		/// Gets description of powershell snap-in.
		/// </summary>
		public override string Description
		{
			get { return "Amazon.com Powershell Snap-in by BytesBlock.com"; }
		}

		/// <summary>
		/// Gets name of power shell snap-in
		/// </summary>
		public override string Name
		{
			get { return "AmazonPSSnapIn"; }
		}

		/// <summary>
		/// Gets name of the vendor
		/// </summary>
		public override string Vendor
		{
			get { return "ByteBlocks.com"; }
		}

		/// <summary>
		/// This method gets called during install time to get list of
		/// Cmdlets that need to be registered.
		/// </summary>
		public override Collection<CmdletConfigurationEntry> Cmdlets
		{
			get
			{
				if (null == _cmdlets)
				{
					_cmdlets = new Collection<CmdletConfigurationEntry>();
					_cmdlets.Add(new CmdletConfigurationEntry("Get-Book", typeof(GetBookCommand), "AmazonPS.dll-Help.xml"));
                    _cmdlets.Add(new CmdletConfigurationEntry("Get-DVD", typeof(GetDVDCommand), "AmazonPS.dll-Help.xml"));
                    _cmdlets.Add(new CmdletConfigurationEntry("Get-DigitalMusic", typeof(GetDigitalMusicCommand), "AmazonPS.dll-Help.xml"));
				}
				return _cmdlets;
			}
		}
	}
}
