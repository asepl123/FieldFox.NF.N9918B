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
	[Display("UserCalibration", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class UserCalibration : TestStep
	{
		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

		private bool _UserCalibrationState = true;

		[DisplayAttribute("UserCalibrationState", "", "Input Parameters", 2)]
		public bool UserCalibrationState
		{
			get
			{
				return this._UserCalibrationState;
			}
			set
			{
				this._UserCalibrationState = value;
			}
		}

		#endregion

		public UserCalibration()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

			MyInst.ScpiCommand(":SENSe:CORRection:UCALibration:STATe {0}", UserCalibrationState);
			MyInst.ScpiCommand(":SENSe:CORRection:UCALibration:RUN");
			MyInst.ScpiCommand("*WAI");
			MyInst.ScpiCommand("*OPC");

			// If no verdict is used, the verdict will default to NotSet.
			// You can change the verdict using UpgradeVerdict() as shown below.
			// UpgradeVerdict(Verdict.Pass);
		}
	}
}
