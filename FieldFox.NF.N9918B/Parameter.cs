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
	[Display("Parameter", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class Parameter : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private uint _PARameterNo = 1u;

        [DisplayAttribute("PARameterNo", "", "Input Parameters", 2)]
        public uint PARameterNo
        {
            get
            {
                return this._PARameterNo;
            }
            set
            {
                this._PARameterNo = value;
            }
        }

        private string _ParameterName = "NFIG";

        [DisplayAttribute("ParameterName", "NFIG - Noise Figure\r\nNFAC - Noise Factor\r\nGAIN - Gain\r\nNTEM - Noise temperature\r\n" +
            "YFAC - Y-Factor", "Input Parameters", 2)]
        public string ParameterName
        {
            get
            {
                return this._ParameterName;
            }
            set
            {
                this._ParameterName = value;
            }
        }

        #endregion

        public Parameter()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":CALCulate:PARameter{0}:DEFine {1}", PARameterNo, ParameterName);
            MyInst.ScpiCommand(":CALCulate:PARameter{0}:SELect", PARameterNo);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
