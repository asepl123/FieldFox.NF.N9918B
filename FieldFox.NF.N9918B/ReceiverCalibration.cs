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
	[Display("ReceiverCalibration", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class ReceiverCalibration : TestStep
	{
		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

		private Boolean state;

		#endregion

		public ReceiverCalibration()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

			MyInst.ScpiCommand(":SENSe:CORRection:RCALibration:RUN");
			MyInst.ScpiCommand("*WAI");
			MyInst.ScpiCommand("*OPC");
			state = MyInst.ScpiQuery<System.Boolean>(Scpi.Format(":SENSe:CORRection:RCALibration:STATe?"), true);

			// If no verdict is used, the verdict will default to NotSet.
			// You can change the verdict using UpgradeVerdict() as shown below.
			// UpgradeVerdict(Verdict.Pass);
		}
	}
}
