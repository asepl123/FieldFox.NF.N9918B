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
	[Display("Integration", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class Integration : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private double _Jitter = 0.5D;

        [DisplayAttribute("Jitter", "Jitter goal\r\nChoose from:\r\nMinimum  -100 dB up to\r\nMaximum 100 dB", "Input Parameters", 2)]
        public double Jitter
        {
            get
            {
                return this._Jitter;
            }
            set
            {
                this._Jitter = value;
            }
        }

        private double _Maxtime = 2D;

        [DisplayAttribute("Maxtime", "Maximum time per point", "Input Parameters", 2)]
        public double Maxtime
        {
            get
            {
                return this._Maxtime;
            }
            set
            {
                this._Maxtime = value;
            }
        }

        private string _Mode = "AUTO";

        [DisplayAttribute("Mode", "{ AUTO, FIX }\r\nIntegration mode. Choose from:\r\nAUTO, FIX", "Input Parameters", 2)]
        public string Mode
        {
            get
            {
                return this._Mode;
            }
            set
            {
                this._Mode = value;
            }
        }

        private double _Time = 0.5D;

        [DisplayAttribute("Time", "", "Input Parameters", 2)]
        public double Time
        {
            get
            {
                return this._Time;
            }
            set
            {
                this._Time = value;
            }
        }

        #endregion

        public Integration()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:INTegration:JITTer {0}", Jitter);
            MyInst.ScpiCommand(":SENSe:INTegration:MAXTime {0}", Maxtime);
            MyInst.ScpiCommand(":SENSe:INTegration:MODe {0}", Mode);
            // Only if mode is FIX
            MyInst.ScpiCommand(":SENSe:INTegration:TIMe {0}", Time);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
