using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTap;   // Use OpenTAP infrastructure/core components (log,TestStep definition, etc)

namespace FieldFox.NF.N9918B
{
	[Display("SetupNoiseSource", Group: "FieldFox.NF.N9918B", Description: "Set up the noise source and ENR table")]
	public class Uncertainty : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private bool _CalibrationUncertainty = false;

        [DisplayAttribute("CalibrationUncertainty", "", "Input Parameters", 2)]
        public bool CalibrationUncertainty
        {
            get
            {
                return this._CalibrationUncertainty;
            }
            set
            {
                this._CalibrationUncertainty = value;
            }
        }

        private string _CoverageUncertainty = "SD2";

        [DisplayAttribute("CoverageUncertainty", @"Current settings uncertainty coverage value. Choose from:

SD1 - 1σ (About 68% of the values fall within 1 standard deviation of the mean.)

SD2 - 2σ (About 95% of the values fall within 2 standard deviations of the mean.)

SD3 - 3σ (About 99.7% of the values fall within 3 standard deviations of the mean.)", "Input Parameters", 2)]
        public string CoverageUncertainty
        {
            get
            {
                return this._CoverageUncertainty;
            }
            set
            {
                this._CoverageUncertainty = value;
            }
        }

        private bool _EnrUncertainty = true;

        [DisplayAttribute("EnrUncertainty", "", "Input Parameters", 2)]
        public bool EnrUncertainty
        {
            get
            {
                return this._EnrUncertainty;
            }
            set
            {
                this._EnrUncertainty = value;
            }
        }

        private bool _JitterUncertainty = true;

        [DisplayAttribute("JitterUncertainty", "", "Input Parameters", 2)]
        public bool JitterUncertainty
        {
            get
            {
                return this._JitterUncertainty;
            }
            set
            {
                this._JitterUncertainty = value;
            }
        }

        private bool _MismatchUncertainty = true;

        [DisplayAttribute("MismatchUncertainty", "", "Input Parameters", 2)]
        public bool MismatchUncertainty
        {
            get
            {
                return this._MismatchUncertainty;
            }
            set
            {
                this._MismatchUncertainty = value;
            }
        }

        #endregion

        public Uncertainty()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:CORRection:UNCertainty:CALibration {0}", CalibrationUncertainty);
            MyInst.ScpiCommand(":SENSe:CORRection:UNCertainty:COVerage {0}", CoverageUncertainty);
            MyInst.ScpiCommand(":SENSe:CORRection:UNCertainty:ENR {0}", EnrUncertainty);
            MyInst.ScpiCommand(":SENSe:CORRection:UNCertainty:JITTer {0}", JitterUncertainty);
            MyInst.ScpiCommand(":SENSe:CORRection:UNCertainty:MISMatch {0}", MismatchUncertainty);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
