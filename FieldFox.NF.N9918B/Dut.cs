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
	[Display("Dut", Group: "FieldFox.NF.N9918B", Description: "Insert a description here")]
	public class Dut : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

		[DisplayAttribute("DutType", "Choose from:\r\n\r\nAMPL - Amplifier\r\nDCON - Downconverter\r\nUCON. - Upconverter\r\nMCON" +
			" - Multi-Stage Converter", "Input Parameters", 2)]
		public string DutType { get; set; } = "AMPL";

		[DisplayAttribute("sideband", "Choose from:\r\nLSB - lower sideband\r\nUSB - upper sideband\r\nDSB - double sideband", "Input Parameters", 2)]
		public string sideband { get; set; } = "DSB";

		[DisplayAttribute("AfterLossEnable", "", "Input Parameters", 2)]
		public bool AfterLossEnable { get; set; } = false;

		[DisplayAttribute("AfterLossValue", "Set the amount of noise figure loss correction after the DUT input. Choose from:\r" +
			"\n-100 to 100 dB ", "Input Parameters", 2)]
		public double AfterLossValue { get; set; } = 0D;

		[DisplayAttribute("AfterLossTemperature", "", "Input Parameters", 2)]
		public double AfterLossTemperature { get; set; } = 296.5D;

		[DisplayAttribute("BeforeLossEnable", "", "Input Parameters", 2)]
		public bool BeforeLossEnable { get; set; } = false;

		[DisplayAttribute("BeforeLossValue", "", "Input Parameters", 2)]
		public double BeforeLossValue { get; set; } = 0D;

		[DisplayAttribute("BeforeLossTemperature", "", "Input Parameters", 2)]
		public double BeforeLossTemperature { get; set; } = 296.5D;

		#endregion

		public Dut()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:DUT:TYPe {0}", DutType);
            MyInst.ScpiCommand(":SENSe:DUT:SIDeband {0}", sideband);

            MyInst.ScpiCommand(":SENSe:CORRection:LOSS:AFTer:ENABled {0}", AfterLossEnable);
            if(AfterLossEnable)
			{
                MyInst.ScpiCommand(":SENSe:CORRection:LOSS:AFTer:VALue {0}", AfterLossValue);
                MyInst.ScpiCommand(":SENSe:CORRection:LOSS:AFTer:TEMPerature {0}", AfterLossTemperature);
            }
            MyInst.ScpiCommand(":SENSe:CORRection:LOSS:BEFore:ENABled {0}", BeforeLossEnable);
			if (BeforeLossEnable)
			{
                MyInst.ScpiCommand(":SENSe:CORRection:LOSS:BEFore:VALue {0}", BeforeLossValue);
                MyInst.ScpiCommand(":SENSe:CORRection:LOSS:BEFore:TEMPerature {0}", BeforeLossTemperature);
            }
            
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
