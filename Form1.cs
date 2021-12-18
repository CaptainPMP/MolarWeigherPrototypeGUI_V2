using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MolarWeigherPrototypeGUI_V2
{
    public partial class Form1 : Form    {

        private SerialPort myport;
        private string in_data;
        private string testElement;
        private Boolean IsInt = true;
        private Double FinishOutput;
        private Boolean IsStart = false;
        private List<string> myErrors = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = ports[0];
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += Myport_DataReceived;
            timer1.Start();

            try
            {
                myport.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            foreach (string port_name in ports)
            {
                portBox.Items.Add(port_name);
            }
        }

        private void Myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsStart)
            {
                if(myErrors.Count == 0)
                {
                    OutputMol.Text = $"{Math.Round((Convert.ToDouble(in_data) / FinishOutput), 3)}";
                }
                else
                {
                    OutputMol.Text = "Error";
                }
            } 
            else
            {
                OutputMol.Text = "0";
            }
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            

            
        }

        private void IntBTN_Click(object sender, EventArgs e)
        {
            IsInt = true;
            Calc_Click(null,null);
        }

        private void FloatBTN_Click(object sender, EventArgs e)
        {
            IsInt = false;
            Calc_Click(null, null);
        }

        private void ClearBTN_Click(object sender, EventArgs e)
        {
            IsStart = false;
            FinishOutput = 0;
            RawEleBox.Text = "";
        }

        private void IntBTN_Click_1(object sender, EventArgs e)
        {
            IsInt = true;
            Calc_Click_1(null, null);
        }

        private void FloatBTN_Click_1(object sender, EventArgs e)
        {
            IsInt = false;
            Calc_Click_1(null, null);
        }

        private void Calc_Click_1(object sender, EventArgs e)
        {
            double all_value = 0;
            Boolean IsSuccess = false;
            var ListOfRawElement = new List<string>();
            var ListOfFinalElement = new List<string>();
            Regex SplitElement = new Regex(@"[A-Z][a-z]?[a-z]?\d*");
            Regex IsNumber = new Regex(@"\d+");
            Regex Text = new Regex(@"[a-zA-Z]+");
            //var MainDictionary = IntPeriodicTable; //User can choose

            testElement = RawEleBox.Text;//รับค่ายัดใส่ตัวแปร
            IsStart = true; //เริ่ม
            if (string.IsNullOrEmpty(testElement))
            {
                ErrorLabel.Text = "Please enter your element again.";
            }
            var matches = SplitElement.Matches(testElement);

            /*foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }*/

            for (int i = 0; i < matches.Count; i++)
            {
                ListOfRawElement.Add(matches[i].Value);
            }

            foreach (var EachElement in ListOfRawElement)
            {
                if (IsNumber.IsMatch(EachElement))
                {
                    var n_round = IsNumber.Match(EachElement);
                    var NumList = new List<string>();
                    NumList.Add(n_round.Value);
                    int num_round = Convert.ToInt32(NumList[0]);

                    var t_round = Text.Match(EachElement);
                    var TextList = new List<string>();

                    for (int i = 0; i < num_round; i++)
                    {
                        TextList.Add(t_round.Value);
                    }
                    string[] MultipleText = TextList.ToArray();
                    string FinalText = String.Join("", MultipleText);

                    ListOfFinalElement.Add(FinalText);
                }

                else
                {
                    ListOfFinalElement.Add(EachElement);
                }

            }

            //string[] FinalElementArr = ListOfFinalElement.ToArray();
            string FinalSummaryElement = String.Join("", ListOfFinalElement); //NaNaNaNaNaOOOOOOOHHHHHHHHClClClClCl
            var FinalSummaryElementMatches = SplitElement.Matches(FinalSummaryElement); //Split Element => Na Na Na O O Cl Cl
            var FinalSummaryList = new List<string>();

            // Add value to list
            for (var j = 0; j < FinalSummaryElementMatches.Count; j++)
            {
                FinalSummaryList.Add(FinalSummaryElementMatches[j].Value);
            }

            //List to array => [Na, Na, Cl, Cl]
            string[] FinalSummaryArr = FinalSummaryList.ToArray();

            for (int k = 0; k < FinalSummaryArr.Length; k++)
            {
                /*if (MainDictionary.ContainsKey(FinalSummaryArr[k]))
                {
                    all_value += MainDictionary[FinalSummaryArr[k]];
                }
                else
                {
                    myErrors.Add($"{FinalSummaryArr[k]} is not the element");
                }*/
                switch (IsInt)
                {
                    case true:
                        switch (FinalSummaryArr[k])
                        {
							case "H":
								all_value += 1;
								break;
							case "He":
								all_value += 4;
								break;
							case "Li":
								all_value += 7;
								break;
							case "Be":
								all_value += 9;
								break;
							case "B":
								all_value += 10;
								break;
							case "C":
								all_value += 12;
								break;
                            case "N":
								all_value += 14;
								break;
							case "O":
								all_value += 16;
								break;
							case "F":
								all_value += 19;
								break;
							case "Ne":
								all_value += 20;
								break;
							case "Na":
								all_value += 23;
								break;
							case "Mg":
								all_value += 24;
								break;
							case "Al":
								all_value += 27;
								break;
							case "Si":
								all_value += 28;
								break;
							case "P":
								all_value += 31;
								break;
							case "S":
								all_value += 32;
								break;
							case "Cl":
								all_value += 35.5;
								break;
							case "Ar":
								all_value += 40;
								break;
							case "K":
								all_value += 39;
								break;
							case "Ca":
								all_value += 40;
								break;
							case "Sc":
								all_value += 45;
								break;
							case "Ti":
								all_value += 48;
								break;
							case "V":
								all_value += 51;
								break;
							case "Cr":
								all_value += 52;
								break;
							case "Mn":
								all_value += 55;
								break;
							case "Fe":
								all_value += 56;
								break;
							case "Co":
								all_value += 59;
								break;
							case "Ni":
								all_value += 59;
								break;
							case "Cu":
								all_value += 64;
								break;
							case "Zn":
								all_value += 65;
								break;
							case "Ga":
								all_value += 70;
								break;
							case "Ge":
								all_value += 73;
								break;
							case "As":
								all_value += 75;
								break;
							case "Se":
								all_value += 79;
								break;
							case "Br":
								all_value += 80;
								break;
							case "Kr":
								all_value += 84;
								break;
							case "Rb":
								all_value += 85;
								break;
							case "Sr":
								all_value += 88;
								break;
							case "Y":
								all_value += 89;
								break;
							case "Zr":
								all_value += 91;
								break;
							case "Nb":
								all_value += 93;
								break;
							case "Mo":
								all_value += 96;
								break;
							case "Tc":
								all_value += 97;
								break;
							case "Ru":
								all_value += 101;
								break;
							case "Rh":
								all_value += 103;
								break;
							case "Pd":
								all_value += 106;
								break;
							case "Ag":
								all_value += 108;
								break;
							case "Cd":
								all_value += 112;
								break;
							case "In":
								all_value += 115;
								break;
							case "Sn":
								all_value += 119;
								break;
							case "Sb":
								all_value += 122;
								break;
							case "Te":
								all_value += 128;
								break;
							case "I":
								all_value += 127;
								break;
							case "Xe":
								all_value += 131;
								break;
							case "Cs":
								all_value += 133;
								break;
							case "Ba":
								all_value += 137;
								break;
							case "La":
								all_value += 139;
								break;
							case "Ce":
								all_value += 140;
								break;
							case "Pr":
								all_value += 141;
								break;
							case "Nd":
								all_value += 144;
								break;
							case "Pm":
								all_value += 145;
								break;
							case "Sm":
								all_value += 150;
								break;
							case "Eu":
								all_value += 152;
								break;
							case "Gd":
								all_value += 157;
								break;
							case "Tb":
								all_value += 159;
								break;
							case "Dy":
								all_value += 162.5;
								break;
							case "Ho":
								all_value += 165;
								break;
							case "Er":
								all_value += 167;
								break;
							case "Tm":
								all_value += 169;
								break;
							case "Yb":
								all_value += 173;
								break;
							case "Lu":
								all_value += 175;
								break;
							case "Hf":
								all_value += 178;
								break;
							case "Ta":
								all_value += 181;
								break;
							case "W":
								all_value += 184;
								break;
							case "Re":
								all_value += 186;
								break;
							case "Os":
								all_value += 190;
								break;
							case "Ir":
								all_value += 192;
								break;
							case "Pt":
								all_value += 195;
								break;
							case "Au":
								all_value += 197;
								break;
							case "Hg":
								all_value += 201;
								break;
							case "Tl":
								all_value += 204;
								break;
							case "Pb":
								all_value += 207;
								break;
							case "Bi":
								all_value += 209;
								break;
							case "Po":
								all_value += 209;
								break;
							case "At":
								all_value += 210;
								break;
							case "Rn":
								all_value += 222;
								break;
							case "Fr":
								all_value += 223;
								break;
							case "Ra":
								all_value += 226;
								break;
							case "Ac":
								all_value += 227;
								break;
							case "Th":
								all_value += 232;
								break;
							case "Pa":
								all_value += 231;
								break;
							case "U":
								all_value += 238;
								break;
							case "Np":
								all_value += 237;
								break;
							case "Pu":
								all_value += 244;
								break;
							case "Am":
								all_value += 243;
								break;
							case "Cm":
								all_value += 247;
								break;
							case "Bk":
								all_value += 247;
								break;
							case "Cf":
								all_value += 251;
								break;
							case "Es":
								all_value += 252;
								break;
							case "Fm":
								all_value += 257;
								break;
							case "Md":
								all_value += 258;
								break;
							case "No":
								all_value += 259;
								break;
							case "Lr":
								all_value += 262;
								break;
							case "Rf":
								all_value += 263;
								break;
							case "Db":
								all_value += 268;
								break;
							case "Sg":
								all_value += 271;
								break;
							case "Bh":
								all_value += 270;
								break;
							case "Hs":
								all_value += 270;
								break;
							case "Mt":
								all_value += 278;
								break;
							case "Ds":
								all_value += 281;
								break;
							case "Rg":
								all_value += 281;
								break;
							case "Cn":
								all_value += 285;
								break;
							case "Uut":
								all_value += 286;
								break;
							case "Fl":
								all_value += 289;
								break;
							case "Uup":
								all_value += 289;
								break;
							case "Lv":
								all_value += 293;
								break;
							case "Uus":
								all_value += 294;
								break;
							case "Uuo":
								all_value += 294;
								break;
							default:
                                myErrors.Add($"{FinalSummaryArr[k]} is not the element");
                                break;
                        }
                        break;
                    case false:
                        switch (FinalSummaryArr[k])
                        {
							case "H":
								all_value += 1.00801;
								break;
							case "He":
								all_value += 4.002602;
								break;
							case "Li":
								all_value += 6.94;
								break;
							case "Be":
								all_value += 9.0121831;
								break;
							case "B":
								all_value += 10.81;
								break;
							case "C":
								all_value += 12.011;
								break;
							case "N":
								all_value += 14.007;
								break;
							case "O":
								all_value += 15.999;
								break;
							case "F":
								all_value += 18.99840316;
								break;
							case "Ne":
								all_value += 20.1797;
								break;
							case "Na":
								all_value += 22.98976928;
								break;
							case "Mg":
								all_value += 24.305;
								break;
							case "Al":
								all_value += 26.9815384;
								break;
							case "Si":
								all_value += 28.085;
								break;
							case "P":
								all_value += 30.973762;
								break;
							case "S":
								all_value += 32.06;
								break;
							case "Cl":
								all_value += 35.45;
								break;
							case "Ar":
								all_value += 39.948;
								break;
							case "K":
								all_value += 39.0983;
								break;
							case "Ca":
								all_value += 40.078;
								break;
							case "Sc":
								all_value += 44.955908;
								break;
							case "Ti":
								all_value += 47.867;
								break;
							case "V":
								all_value += 50.9415;
								break;
							case "Cr":
								all_value += 51.9961;
								break;
							case "Mn":
								all_value += 54.938044;
								break;
							case "Fe":
								all_value += 55.845;
								break;
							case "Co":
								all_value += 58.933194;
								break;
							case "Ni":
								all_value += 58.6934;
								break;
							case "Cu":
								all_value += 63.546;
								break;
							case "Zn":
								all_value += 65.38;
								break;
							case "Ga":
								all_value += 69.723;
								break;
							case "Ge":
								all_value += 72.63;
								break;
							case "As":
								all_value += 74.921595;
								break;
							case "Se":
								all_value += 78.971;
								break;
							case "Br":
								all_value += 79.904;
								break;
							case "Kr":
								all_value += 83.798;
								break;
							case "Rb":
								all_value += 85.4678;
								break;
							case "Sr":
								all_value += 87.62;
								break;
							case "Y":
								all_value += 88.90584;
								break;
							case "Zr":
								all_value += 91.224;
								break;
							case "Nb":
								all_value += 92.90637;
								break;
							case "Mo":
								all_value += 95.95;
								break;
							case "Tc":
								all_value += 97;
								break;
							case "Ru":
								all_value += 101.07;
								break;
							case "Rh":
								all_value += 102.90549;
								break;
							case "Pd":
								all_value += 106.42;
								break;
							case "Ag":
								all_value += 107.8682;
								break;
							case "Cd":
								all_value += 112.414;
								break;
							case "In":
								all_value += 114.818;
								break;
							case "Sn":
								all_value += 118.71;
								break;
							case "Sb":
								all_value += 121.76;
								break;
							case "Te":
								all_value += 127.6;
								break;
							case "I":
								all_value += 126.90447;
								break;
							case "Xe":
								all_value += 131.293;
								break;
							case "Cs":
								all_value += 132.905452;
								break;
							case "Ba":
								all_value += 137.327;
								break;
							case "La":
								all_value += 138.90547;
								break;
							case "Ce":
								all_value += 140.116;
								break;
							case "Pr":
								all_value += 140.90766;
								break;
							case "Nd":
								all_value += 144.242;
								break;
							case "Pm":
								all_value += 145;
								break;
							case "Sm":
								all_value += 150.36;
								break;
							case "Eu":
								all_value += 151.964;
								break;
							case "Gd":
								all_value += 157.25;
								break;
							case "Tb":
								all_value += 158.925354;
								break;
							case "Dy":
								all_value += 162.5;
								break;
							case "Ho":
								all_value += 164.930328;
								break;
							case "Er":
								all_value += 167.259;
								break;
							case "Tm":
								all_value += 168.934218;
								break;
							case "Yb":
								all_value += 173.045;
								break;
							case "Lu":
								all_value += 174.9668;
								break;
							case "Hf":
								all_value += 178.49;
								break;
							case "Ta":
								all_value += 180.94788;
								break;
							case "W":
								all_value += 183.84;
								break;
							case "Re":
								all_value += 186.207;
								break;
							case "Os":
								all_value += 190.23;
								break;
							case "Ir":
								all_value += 192.217;
								break;
							case "Pt":
								all_value += 195.084;
								break;
							case "Au":
								all_value += 196.96657;
								break;
							case "Hg":
								all_value += 200.592;
								break;
							case "Tl":
								all_value += 204.38;
								break;
							case "Pb":
								all_value += 207.2;
								break;
							case "Bi":
								all_value += 208.9804;
								break;
							case "Po":
								all_value += 209;
								break;
							case "At":
								all_value += 210;
								break;
							case "Rn":
								all_value += 222;
								break;
							case "Fr":
								all_value += 223;
								break;
							case "Ra":
								all_value += 226;
								break;
							case "Ac":
								all_value += 227;
								break;
							case "Th":
								all_value += 232.0377;
								break;
							case "Pa":
								all_value += 231.03588;
								break;
							case "U":
								all_value += 238.02891;
								break;
							case "Np":
								all_value += 237;
								break;
							case "Pu":
								all_value += 244;
								break;
							case "Am":
								all_value += 243;
								break;
							case "Cm":
								all_value += 247;
								break;
							case "Bk":
								all_value += 247;
								break;
							case "Cf":
								all_value += 251;
								break;
							case "Es":
								all_value += 252;
								break;
							case "Fm":
								all_value += 257;
								break;
							case "Md":
								all_value += 258;
								break;
							case "No":
								all_value += 259;
								break;
							case "Lr":
								all_value += 262;
								break;
							case "Rf":
								all_value += 263;
								break;
							case "Db":
								all_value += 268;
								break;
							case "Sg":
								all_value += 271;
								break;
							case "Bh":
								all_value += 270;
								break;
							case "Hs":
								all_value += 270;
								break;
							case "Mt":
								all_value += 278;
								break;
							case "Ds":
								all_value += 281;
								break;
							case "Rg":
								all_value += 281;
								break;
							case "Cn":
								all_value += 285;
								break;
							case "Uut":
								all_value += 286;
								break;
							case "Fl":
								all_value += 289;
								break;
							case "Uup":
								all_value += 289;
								break;
							case "Lv":
								all_value += 293;
								break;
							case "Uus":
								all_value += 294;
								break;
							case "Uuo":
								all_value += 294;
								break;
							default:
                                myErrors.Add($"{FinalSummaryArr[k]} is not the element");
                                break;
                        }
                        break;
                }
            }

            if (FinalSummaryArr.Length == 0)
            {
                myErrors.Add($"You have to use Uppercase as Element");
            }

            if (myErrors.Count == 0)
            {
                IsSuccess = true;
            }

            //Console.WriteLine(FinalSummaryElement);
            if (IsSuccess)
            {
                //Console.WriteLine($"Total Molecular Weight : {all_value}");
                FinishOutput = all_value;
            }
            else
            {
                /*Console.WriteLine("You type wrong element");
                Console.WriteLine("Your error is\n");*/
                /*for (int l = 0; l < myErrors.Count; l++)
                {
                    Console.WriteLine(myErrors[l]);
                }*/
                ErrorLabel.Text = "Error, Please try again.";
            }
        }

        private void ClearBTN_Click_1(object sender, EventArgs e)
        {
            IsStart = false;
            FinishOutput = 0;
            RawEleBox.Text = "";
            myErrors.Clear();
            ErrorLabel.Text = "Error : None";
        }
    }
}
