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
	[Display("EnrMode", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class EnrMode : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private string _ENRmode = "SPOT";

        [DisplayAttribute("ENRmode", "(SPOT, TABL}", "Input Parameters", 2)]
        public string ENRmode
        {
            get
            {
                return this._ENRmode;
            }
            set
            {
                this._ENRmode = value;
            }
        }

        private string _SpotCoverage = "SD2";

        [DisplayAttribute("SpotCoverage", "{ SD1, SD2, SD3}", "Input Parameters", 2)]
        public string SpotCoverage
        {
            get
            {
                return this._SpotCoverage;
            }
            set
            {
                this._SpotCoverage = value;
            }
        }

        private string _SpotDistribution = "FIX";

        [DisplayAttribute("SpotDistribution", "{ RAYL, UNIF, FIX }", "Input Parameters", 2)]
        public string SpotDistribution
        {
            get
            {
                return this._SpotDistribution;
            }
            set
            {
                this._SpotDistribution = value;
            }
        }

        private double _SpotEnr = 15D;

        [DisplayAttribute("SpotEnr", "ENR Spot mode.\r\nChoose from:\r\nMinimum of -100 dB up to\r\nMaximum of 100 dB", "Input Parameters", 2)]
        public double SpotEnr
        {
            get
            {
                return this._SpotEnr;
            }
            set
            {
                this._SpotEnr = value;
            }
        }

        private double _OnGamma = 0D;

        [DisplayAttribute("OnGamma", "0-1", "Input Parameters", 2)]
        public double OnGamma
        {
            get
            {
                return this._OnGamma;
            }
            set
            {
                this._OnGamma = value;
            }
        }

        private double _OffGamma = 0D;

        [DisplayAttribute("OffGamma", "0-1", "Input Parameters", 2)]
        public double OffGamma
        {
            get
            {
                return this._OffGamma;
            }
            set
            {
                this._OffGamma = value;
            }
        }

        private string _EnrSpecific = "FIX";

        [DisplayAttribute("EnrSpecific", @"ENR Spot mode's fixed value. 
Choose from:
MAX - Use this if this value represents the largest possible reflection coefficient for the population of devices to which the DUT belongs. This is true for ""does not exceed"" specifications.
PCTL95 - Use this if 95% of the population has a lower reflection coefficient than the value entered. This is the case for ""2 standard deviation"" (2s) type specifications.
PCTL80 - Use this if 80% of the population has a lower reflection coefficient than the value entered.
MED or MEAN - Use this if this value represents the median / mean reflection coefficient for the population of devices to which the DUT belongs.
FIX - Use this if the value is a measured value for the DUT.", "Input Parameters", 2)]
        public string EnrSpecific
        {
            get
            {
                return this._EnrSpecific;
            }
            set
            {
                this._EnrSpecific = value;
            }
        }

        private double _SpotUncertainty = 0D;

        [DisplayAttribute("SpotUncertainty", "ENR Spot mode\'s uncertainty value.\r\nChoose from:\r\nMinimum of -100 dB up to\r\nMaxim" +
            "um of 100 dB", "Input Parameters", 2)]
        public double SpotUncertainty
        {
            get
            {
                return this._SpotUncertainty;
            }
            set
            {
                this._SpotUncertainty = value;
            }
        }

        #endregion

        public EnrMode()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:CORRection:ENR:MODe {0}", ENRmode);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:COVerage {0}", SpotCoverage);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:DISTribution {0}", SpotDistribution);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:ENR {0}", SpotEnr);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:ONGamma {0}", OnGamma);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:OFFGamma {0}", OffGamma);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:SPEC {0}", EnrSpecific);
            MyInst.ScpiCommand(":SENSe:CORRection:ENR:SPOT:UNCertainty {0}", SpotUncertainty);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
