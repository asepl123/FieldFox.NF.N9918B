// Author: MyName
// Copyright:   Copyright 2020 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

namespace FieldFox.NF.N9918B
{
	[Display("Sweep", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class Sweep : TestStep
	{
		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

		private int _SweepPoints = 201;

		[DisplayAttribute("SweepPoints", "", "Input Parameters", 2)]
		public int SweepPoints
		{
			get
			{
				return this._SweepPoints;
			}
			set
			{
				this._SweepPoints = value;
			}
		}

		#endregion

		public Sweep()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

			MyInst.ScpiCommand(":SENSe:SWEep:POINts {0}", SweepPoints);

			// If no verdict is used, the verdict will default to NotSet.
			// You can change the verdict using UpgradeVerdict() as shown below.
			// UpgradeVerdict(Verdict.Pass);
		}
	}
}
