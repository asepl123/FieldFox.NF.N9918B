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
	[Display("Frequency", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class Frequency : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private double _CenterFrequency = 1000000D;

        [DisplayAttribute("CenterFrequency", "", "Input Parameters", 2)]
        public double CenterFrequency
        {
            get
            {
                return this._CenterFrequency;
            }
            set
            {
                this._CenterFrequency = value;
            }
        }

        private double _FreqSpan = 100000000D;

        [DisplayAttribute("FreqSpan", "", "Input Parameters", 2)]
        public double FreqSpan
        {
            get
            {
                return this._FreqSpan;
            }
            set
            {
                this._FreqSpan = value;
            }
        }

        #endregion

        public Frequency()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:FREQuency:CENTer {0}", CenterFrequency);
            MyInst.ScpiCommand(":SENSe:FREQuency:SPAN {0}", FreqSpan);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
