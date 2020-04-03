﻿using DataManager.Models;
using DataManager.Repositories;
using java.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using Rectangle = iTextSharp.text.Rectangle;


namespace ruben1
{



    public partial class Form1 : Form
    {
        bool isTxnTypePanelOpen = false;
        bool isSchemaPanelOpen = false;
        bool isCaptureMethodePanelOpen = false;
        bool isLocalityPanelOpen = false;
        bool isMerchantPanelOpen = false;
        TransactionProcessingRepository transactionProcessingRepository;
        private int clicksNumber = 1;
        private DateTime cretionDate = DateTime.Now;
        private string schemaAbrev;
        private string cardIssuer;
        private string transactionCurrency = " RON";
        private string settlementCurrency = " RON";
        private string acquiredCode;
        private string pCaptureMCode;
        private string pAuth;
        private string pLocality;
        private string cardsProccessAcqChCD;
        private double fxin = 0.756;
        private double fxout = 0.723;
        private string misscellaneousCD;
        private string electronic = "ELECTRONIC";
        private string fxCharge = "0.00";
        private double finalAmount;
        private double costTVAdouble = 0.2;
        private int noTVA = 0;

        PricingRepository pricingRepository;
        ContractRepository contractRepository;
        public SqlConnection conn = new SqlConnection(@"Data Source=EN1410365\SQLEXPRESS;Initial Catalog=CalculatingPBI;Integrated Security=True");
        private object panelErrorMsgBox;

        //EN1410365\SQLEXPRESS;Initial Catalog = master; Integrated Security = True

        //OleDbConnection con = new OleDbConnection(@"Provider=SQLOLEDB;Data Source=EN1410365;Initial Catalog=CalculatingPBI;Integrated Security=True");


        public DateTime? getSystemData { get; private set; }
       // private int costTVAint = Convert.ToInt32(costTVAdouble * 100);
       // private string costTVAstring = (costTVAint).ToString + "%";

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(TransactionProcessingRepository transactionProcessingRepository, PricingRepository pricingRepository, ContractRepository contractRepository) : this()
        {
            this.transactionProcessingRepository = transactionProcessingRepository;
            this.pricingRepository = pricingRepository;
            this.contractRepository = contractRepository;
        }

        private void checkBoxAcquired_CheckedChanged(object sender, EventArgs e)
        {
            if (panelSchemaForProcessed.Size.Height == 100 && this.AcquiredCheckBox.Checked)
            {
                this.panelSchemaForProcessed.Size = new System.Drawing.Size(170, 0);
                isSchemaPanelOpen = false;
                schemaLabel.Text = "Schema";
                schemaLabel.ForeColor = System.Drawing.Color.Aqua;
            }
            if (panelSchemeForAcquired.Size.Height == 220 && !this.AcquiredCheckBox.Checked)
            {
                this.panelSchemeForAcquired.Size = new System.Drawing.Size(225, 0);
                isSchemaPanelOpen = false;
                schemaLabel.Text = "Schema";
                schemaLabel.ForeColor = System.Drawing.Color.Aqua;
            }
            schemaLabel.Text = "Schema";
            schemaLabel.ForeColor = System.Drawing.Color.Aqua;
        }


        private void checkBoxAuthorised_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void purchaseLabel_Click(object sender, EventArgs e)
        {

            TransactionTypeLabel.Text = purchaseLabel.Text;
            textBox3TxnType.Text = ((int)enumTransactionType.Purchase).ToString();
            TransactionTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerTxnType.Start();
        }
        private void cashAdvanceLabel_Click(object sender, EventArgs e)
        {
            TransactionTypeLabel.Text = cashAdvanceLabel.Text;
            textBox3TxnType.Text = ((int)enumTransactionType.CashAdvance).ToString();
            TransactionTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerTxnType.Start();
        }
        private void octLabel_Click(object sender, EventArgs e)
        {
            TransactionTypeLabel.Text = octLabel.Text;
            textBox3TxnType.Text = ((int)enumTransactionType.OCT).ToString();
            TransactionTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerTxnType.Start();
        }


        private void quasyCashLabel_Click(object sender, EventArgs e)
        {
            TransactionTypeLabel.Text = quasyCashLabel.Text;
            textBox3TxnType.Text = ((int)enumTransactionType.QuasiCash).ToString();
            TransactionTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerTxnType.Start();
        }
        private void pwcbLabel_Click(object sender, EventArgs e)
        {
            TransactionTypeLabel.Text = pwcbLabel.Text;
            textBox3TxnType.Text = ((int)enumTransactionType.PWCB).ToString();
            TransactionTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerTxnType.Start();
        }
        private void refundLabel_Click(object sender, EventArgs e)
        {
            TransactionTypeLabel.Text = refundLabel.Text;
            textBox3TxnType.Text = ((int)enumTransactionType.Refund).ToString();
            TransactionTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerTxnType.Start();
        }


        private void submitButton_Click(object sender, EventArgs e)
        {

           
            if (TransactionTypeLabel.Text == "Transaction Type" || schemaLabel.Text == "Schema"
                || captureMethodeLabel.Text == "Capture Methode" || localityLabel.Text == "Locality" )//|| labelMerchant.Text == "Merchant")
            {
                // this.panelErrorMsgBox.Size = new System.Drawing.Size(291, 57);
                // this.panelDashbordTxn.Size = new System.Drawing.Size(900, 100);
                MessageBox.Show("Please complete all transaction details!", "Error: The combination is not possible!", MessageBoxButtons.OKCancel);

            }

            else
            {
                clicksNumber++;
                this.panelDashbordTxn.Size = new System.Drawing.Size(900, 100);
                // this.textBox1Nr.Location = new System.Drawing.Point(3, 8);
                this.textBox1Nr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1Acquired_Processed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1TxnType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1Schema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1Auth_NotAuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1CaptureMethode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1Locality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox1Amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2Nr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2Acquired.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2TxnType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2Schema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2Auth_NotAuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2CaptureMethode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2Locality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox2Amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3Nr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3Acquired.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3TxnType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3Schema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3Auth_NotAuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3CaptureMethode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3Locality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox3Amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4Nr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4Acquired.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4TxnType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4Schema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4Auth_NotAuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4CaptureMethode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4Locality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.textBox4Amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                if (this.AcquiredCheckBox.Checked)
                {
                    this.textBox2Acquired.Text = "Acquired";
                    this.textBox3Acquired.Text = "Y";
                }
                else
                {
                    this.textBox2Acquired.Text = "Processed";
                    this.textBox3Acquired.Text = "N";
                }
                this.textBox2Nr.Text = "1";
                this.textBox3Nr.Text = "2";
                this.textBox4Nr.Text = "3";
                this.textBox2TxnType.Text = TransactionTypeLabel.Text;
                this.textBox2Schema.Text = schemaLabel.Text;


                if (this.authorisedCheckBox.Checked)
                {
                    this.textBox2Auth_NotAuth.Text = "Authorised";
                    this.textBox3Auth_NotAuth.Text = "Y";
                }
                else
                {
                    this.textBox2Auth_NotAuth.Text = "Not Authorised";
                    this.textBox3Auth_NotAuth.Text = "N";
                }
                this.textBox2CaptureMethode.Text = captureMethodeLabel.Text;
                this.textBox2Locality.Text = localityLabel.Text;
                this.textBox2Amount.Text = amountTextBox.Text;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=EN1410365\SQLEXPRESS;Initial Catalog=CalculatingPBI;Integrated Security=True";
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Select isnull (max(cast(Id as int)),0)+1 from TransactionProcessings";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                label1.Text = 1000 + dt.Rows[0][0].ToString();

                var transaction = new TransactionProcessing()
                {
                    Transaction_Type = textBox3TxnType.Text,
                    CaptureMethod = textBox3CaptureMethode.Text,
                    Schema = textBox3Schema.Text,
                    Locality = textBox3Locality.Text,
                    Authorised = textBox3Auth_NotAuth.Text,
                    Acquired = textBox3Acquired.Text,
                    Amount = amountTextBox.Text,
                    Event_Id = label1.Text,
                    Merchant_Id = labelMerchant.Text,
                    Txn_Currency = transactionCurrency,
                    FX_In = fxin,
                    FX_Out = fxout,
                    Creation_Data = cretionDate,
                    Electronic = "",
                    SettlementCurrency = settlementCurrency,
                    SchemaAbrev = schemaAbrev
                };
                this.transactionProcessingRepository.Add(transaction);
                //var xxx = this.transactionProcessingRepository.FindById(35);


                // Creaza Charge Code Acquired 
                if (!this.AcquiredCheckBox.Checked)
                {
                    acquiredCode = "";
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Quasy Cash" || TransactionTypeLabel.Text == "Refund")
                {
                    acquiredCode = "ARF" + textBox3Schema.Text;
                }
                /*else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Refund")
                {
                    acquiredCode = "ARF" + textBox3Schema.Text;
                }*/
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "OCT")
                {
                    acquiredCode = "AOC" + textBox3Schema.Text;
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Purchase")
                {
                    acquiredCode = "APU" + textBox3Schema.Text;
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Cash Advance")
                {
                    acquiredCode = "ACA" + textBox3Schema.Text;
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "PWCB")
                {
                    acquiredCode = "APC" + textBox3Schema.Text;
                }
                else
                {
                    acquiredCode = "combination not posible";
                }
                // Creaza Charge Code for Premium CaptureMethode 
                if (!this.AcquiredCheckBox.Checked)
                {
                    pCaptureMCode = "";
                }
                else if (this.AcquiredCheckBox.Checked && schemaLabel.Text == "Diners Discover" || schemaLabel.Text == "JCB")
                {
                    {
                        pCaptureMCode = "";
                    }
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Quasy Cash" || TransactionTypeLabel.Text == "Refund" || TransactionTypeLabel.Text == "OCT")
                {
                    pCaptureMCode = "PR" + cardIssuer + "C0" + textBox3CaptureMethode.Text;
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Purchase" || TransactionTypeLabel.Text == "Cash Advance" || TransactionTypeLabel.Text == "PWCB")
                {
                    pCaptureMCode = "PP" + cardIssuer + "C0" + textBox3CaptureMethode.Text;
                }
                else
                {
                    pCaptureMCode = "combination not posible";
                }
                // Creaza Charge Code for Premium Authorisation 
                if (this.authorisedCheckBox.Checked || !this.AcquiredCheckBox.Checked)
                {
                    {
                        pAuth = "";
                    }
                }
                else if (this.AcquiredCheckBox.Checked && !this.authorisedCheckBox.Checked && (captureMethodeLabel.Text == "Contactless" || captureMethodeLabel.Text == "Offline Pin" || schemaLabel.Text == "Diners Discover" || schemaLabel.Text == "JCB"))
                {
                    pAuth = "";
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Quasy Cash" || TransactionTypeLabel.Text == "Refund" || TransactionTypeLabel.Text == "OCT")
                {
                    pAuth = "PR" + cardIssuer + "A01";
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Purchase" || TransactionTypeLabel.Text == "Cash Advance" || TransactionTypeLabel.Text == "PWCB")
                {
                    pAuth = "PP" + cardIssuer + "A01";
                }
                else
                {
                    pAuth = "combination not posible";
                }

                // Creaza Charge Code for Premium Locality 
                if (!this.AcquiredCheckBox.Checked)
                {
                    {
                        pLocality = "";
                    }
                }
                else if (this.AcquiredCheckBox.Checked && (TransactionTypeLabel.Text == "Cash Advance" || schemaLabel.Text == "Diners Discover" || schemaLabel.Text == "JCB"))
                {
                    pLocality = "";
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Quasy Cash" || TransactionTypeLabel.Text == "Refund" || TransactionTypeLabel.Text == "OCT")
                {
                    pLocality = "PR" + cardIssuer + "L" + textBox3Locality.Text;
                }
                else if (this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Purchase" || TransactionTypeLabel.Text == "PWCB")
                {
                    pLocality = "PP" + cardIssuer + "L" + textBox3Locality.Text;
                }
                else
                {
                    pLocality = "combination not posible";
                }

                // Creaza Charge Code for Cards for Other Acquirers
                if (this.AcquiredCheckBox.Checked)
                {
                    {
                        cardsProccessAcqChCD = "";
                    }
                }

                else if (!this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Quasy Cash" || TransactionTypeLabel.Text == "Refund" || TransactionTypeLabel.Text == "OCT")
                {
                    cardsProccessAcqChCD = "CPAR" + textBox3Schema.Text;
                }
                else if (!this.AcquiredCheckBox.Checked && TransactionTypeLabel.Text == "Purchase" || TransactionTypeLabel.Text == "PWCB" || TransactionTypeLabel.Text == "Cash Advance")
                {
                    cardsProccessAcqChCD = "CPAP" + textBox3Schema.Text;
                }
                else
                {
                    cardsProccessAcqChCD = "combination not posible";
                }

                if (TransactionTypeLabel.Text == "Quasy Cash" || TransactionTypeLabel.Text == "Refund" || TransactionTypeLabel.Text == "OCT")
                {
                    finalAmount = -1 * double.Parse(amountTextBox.Text);
                }
                else
                {
                    finalAmount = double.Parse(amountTextBox.Text);
                }
                var pricing = new Pricing()
                {
                    Transaction_Type = textBox2TxnType.Text,
                    CaptureMethod = textBox2CaptureMethode.Text,
                    Schema = textBox2Schema.Text,
                    Locality = textBox2Locality.Text,
                    Authorised = textBox2Auth_NotAuth.Text,
                    Acquired = textBox2Acquired.Text,
                    Amount = finalAmount.ToString(),
                    Event_Id = label1.Text,
                    Merchant_Id = labelMerchant.Text,
                    FXCharge = fxCharge,
                    AcquiredCode = acquiredCode,
                    PremiumCaptMeth_CD = pCaptureMCode,
                    PremiumAuth_CD = pAuth,
                    PremiumLocality_CD = pLocality,
                    CardProcessed_CD = cardsProccessAcqChCD,
                    MiscellTVA = costTVAdouble,
                    CardProcessTVA = costTVAdouble,
                    PremTVA = noTVA,
                    AcqTVA = noTVA

                };
                this.pricingRepository.Add(pricing);

                if (this.AcquiredCheckBox.Checked)
                {
                    //-- look for CARDS ACQUIRED Charge Code and populate A_PPI and A_PPC
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "Select AcquiredCode from Pricings where event_id = '" + label1.Text + "'";
                    DataTable dtAcqCD = new DataTable();
                    SqlDataAdapter adapterAcqCD = new SqlDataAdapter(command);
                    adapterAcqCD.Fill(dtAcqCD);
                    string slctAcqChCodes = dtAcqCD.Rows[0][0].ToString();
                    // MessageBox.Show(slctChCodes);
                    //-- select Acquired PPI value from Contract
                    command.CommandText = "Select PPI from Contracts where ChargeCodes in ('" + slctAcqChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                    DataTable dtPPI = new DataTable();
                    SqlDataAdapter adapterPPI = new SqlDataAdapter(command);
                    adapterPPI.Fill(dtPPI);
                    string slctPPI = dtPPI.Rows[0][0].ToString();
                    //-- Update PPI value in Pricing
                    string updtAPPI = "update Pricings set A_PPI ='" + slctPPI + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmdPPI = new SqlCommand(updtAPPI, conn);
                    cmdPPI.ExecuteNonQuery();
                    //-- select PPC value from Contract
                    command.CommandText = "Select PPC from Contracts where ChargeCodes in ('" + slctAcqChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                    DataTable dtPPC = new DataTable();
                    SqlDataAdapter adapterPPC = new SqlDataAdapter(command);
                    adapterPPI.Fill(dtPPC);
                    string slctPPC = dtPPC.Rows[0][0].ToString();
                    //-- Update PPC value in Pricing
                    string updtAPPC = "update Pricings set A_PPC ='" + slctPPC + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmdPPC = new SqlCommand(updtAPPC, conn);
                    cmdPPC.ExecuteNonQuery();
                    //MessageBox.Show(slctPPC);
                    //-- Update A_PPC*FUND value in Pricing
                    double a_PPCxFund = double.Parse(amountTextBox.Text) * double.Parse(slctPPC.ToString());
                    //MessageBox.Show(a_PPCxFund.ToString());
                    string updta_PPCxFund = "update Pricings set A_PPCxFUND ='" + a_PPCxFund.ToString() + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmda_PPCxFund = new SqlCommand(updta_PPCxFund, conn);
                    cmda_PPCxFund.ExecuteNonQuery();
                    //-- Update A_PPCxFUNDplusPPI value in Pricing
                    double a_PPCxFUNDplusPPI = double.Parse(amountTextBox.Text) * double.Parse(slctPPC.ToString()) + double.Parse(slctPPI);
                    //MessageBox.Show(a_PPCxFUNDplusPPI.ToString());
                    string updta_PPCxFUNDplusPPI = "update Pricings set A_PPCxFUNDplusPPI ='" + a_PPCxFUNDplusPPI.ToString() + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmda_PPCxFUNDplusPPI = new SqlCommand(updta_PPCxFUNDplusPPI, conn);
                    cmda_PPCxFUNDplusPPI.ExecuteNonQuery();

                    if (AcquiredCheckBox.Checked && schemaLabel.Text == "Diners Discover" || schemaLabel.Text == "JCB")
                    {
                        //MessageBox.Show("Acquired Diners sau JCB a fost selectat ");
                        conn.Close();
                    }
                    else
                    {
                        // -- PREMIUM CAPTURE METHODE
                        command.CommandText = "Select PremiumCaptMeth_CD from Pricings where event_id = '" + label1.Text + "'";
                        DataTable dtPcmCD = new DataTable();
                        SqlDataAdapter adapterPcmCD = new SqlDataAdapter(command);
                        adapterPcmCD.Fill(dtPcmCD);
                        string slctPcmChCodes = dtPcmCD.Rows[0][0].ToString();
                        // MessageBox.Show(slctChCodes);
                        //-- select Premium CaptureMethode PPI value from Contract
                        command.CommandText = "Select PPI from Contracts where ChargeCodes in ('" + slctPcmChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                        DataTable dtPcmPPI = new DataTable();
                        SqlDataAdapter adapterPcmPPI = new SqlDataAdapter(command);
                        adapterPcmPPI.Fill(dtPcmPPI);
                        string slctPcmPPI = dtPcmPPI.Rows[0][0].ToString();
                        //-- Update Premium CaptureMethode PPI value in Pricing
                        string updtPcmPPI = "update Pricings set P_CM_PPI ='" + slctPcmPPI + "' where event_id = '" + label1.Text + "'";
                        SqlCommand cmdPcmPPI = new SqlCommand(updtPcmPPI, conn);
                        cmdPcmPPI.ExecuteNonQuery();
                        //-- select Premium CaptureMethode PPC value from Contract
                        command.CommandText = "Select PPC from Contracts where ChargeCodes in ('" + slctPcmChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                        DataTable dtPcmPPC = new DataTable();
                        SqlDataAdapter adapterPcmPPC = new SqlDataAdapter(command);
                        adapterPPC.Fill(dtPcmPPC);
                        string slctPcmPPC = dtPcmPPC.Rows[0][0].ToString();
                        //-- Update Premium CaptureMethode PPC value in Pricing
                        string updtPcmPPC = "update Pricings set P_CM_PPC ='" + slctPcmPPC + "' where event_id = '" + label1.Text + "'";
                        SqlCommand cmdPcmPPC = new SqlCommand(updtPcmPPC, conn);
                        cmdPcmPPC.ExecuteNonQuery();
                        //MessageBox.Show(slctPcmPPC);
                        //-- Update Premium CaptureMethode P_CM_PPC*FUND value in Pricing
                        double P_CM_PPCxFund = double.Parse(amountTextBox.Text) * double.Parse(slctPcmPPC.ToString());
                        //MessageBox.Show(P_CM_PPCxFund.ToString());
                        string updtP_CM_PPCxFund = "update Pricings set P_CM_PPCxFUND ='" + P_CM_PPCxFund.ToString() + "' where event_id = '" + label1.Text + "'";
                        SqlCommand cmdP_CM_PPCxFund = new SqlCommand(updtP_CM_PPCxFund, conn);
                        cmdP_CM_PPCxFund.ExecuteNonQuery();
                        //-- Premium CaptureMethode Update P_CM_PPCxFUNDplusPPI value in Pricing
                        double P_CM_PPCxFUNDplusPPI = double.Parse(amountTextBox.Text) * double.Parse(slctPcmPPC.ToString()) + double.Parse(slctPcmPPI);
                        //MessageBox.Show(P_CM_PPCxFUNDplusPPI.ToString());
                        string updtP_CM_PPCxFUNDplusPPI = "update Pricings set P_CM_PPCxFUNDplusPPI ='" + P_CM_PPCxFUNDplusPPI.ToString() + "' where event_id = '" + label1.Text + "'";
                        SqlCommand cmdP_CM_PPCxFUNDplusPPI = new SqlCommand(updtP_CM_PPCxFUNDplusPPI, conn);
                        cmdP_CM_PPCxFUNDplusPPI.ExecuteNonQuery();

                        if (textBox2TxnType.Text == "Cash Advance")
                        {
                            //MessageBox.Show("Cash Advence a fost selectat ");
                        }
                        else
                        {
                            // -- PREMIUM LOCALITY
                            command.CommandText = "Select PremiumLocality_CD from Pricings where event_id = '" + label1.Text + "'";
                            DataTable dtPlCD = new DataTable();
                            SqlDataAdapter adapterPlCD = new SqlDataAdapter(command);
                            adapterPlCD.Fill(dtPlCD);
                            string slctPlChCodes = dtPlCD.Rows[0][0].ToString();
                            // MessageBox.Show(slctChCodes);
                            //-- select Premium CaptureMethode PPI value from Contract
                            command.CommandText = "Select PPI from Contracts where ChargeCodes in ('" + slctPlChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                            DataTable dtPlPPI = new DataTable();
                            SqlDataAdapter adapterPlPPI = new SqlDataAdapter(command);
                            adapterPlPPI.Fill(dtPlPPI);
                            string slctPlPPI = dtPlPPI.Rows[0][0].ToString();
                            //-- Update Premium CaptureMethode PPI value in Pricing
                            string updtPlPPI = "update Pricings set P_L_PPI ='" + slctPlPPI + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdPlPPI = new SqlCommand(updtPlPPI, conn);
                            cmdPlPPI.ExecuteNonQuery();
                            //-- select Premium CaptureMethode PPC value from Contract
                            command.CommandText = "Select PPC from Contracts where ChargeCodes in ('" + slctPlChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                            DataTable dtPlPPC = new DataTable();
                            SqlDataAdapter adapterPlPPC = new SqlDataAdapter(command);
                            adapterPPC.Fill(dtPlPPC);
                            string slctPlPPC = dtPlPPC.Rows[0][0].ToString();
                            //-- Update Premium CaptureMethode PPC value in Pricing
                            string updtPlPPC = "update Pricings set P_L_PPC ='" + slctPlPPC + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdPlPPC = new SqlCommand(updtPlPPC, conn);
                            cmdPlPPC.ExecuteNonQuery();
                            //MessageBox.Show(slctPlPPC);
                            //-- Update Premium CaptureMethode P_L_PPC*FUND value in Pricing
                            double P_L_PPCxFund = double.Parse(amountTextBox.Text) * double.Parse(slctPlPPC.ToString());
                            //MessageBox.Show(P_L_PPCxFund.ToString());
                            string updtP_L_PPCxFund = "update Pricings set P_L_PPCxFUND ='" + P_L_PPCxFund.ToString() + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdP_L_PPCxFund = new SqlCommand(updtP_L_PPCxFund, conn);
                            cmdP_L_PPCxFund.ExecuteNonQuery();
                            //-- Premium CaptureMethode Update P_L_PPCxFUNDplusPPI value in Pricing
                            double P_L_PPCxFUNDplusPPI = double.Parse(amountTextBox.Text) * double.Parse(slctPlPPC.ToString()) + double.Parse(slctPlPPI);
                            //MessageBox.Show(P_L_PPCxFUNDplusPPI.ToString());
                            string updtP_L_PPCxFUNDplusPPI = "update Pricings set P_L_PPCxFUNDplusPPI ='" + P_L_PPCxFUNDplusPPI.ToString() + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdP_L_PPCxFUNDplusPPI = new SqlCommand(updtP_L_PPCxFUNDplusPPI, conn);
                            cmdP_L_PPCxFUNDplusPPI.ExecuteNonQuery();
                        }

                        // -- PREMIUM AUTHORISED
                        command.CommandText = "Select PremiumAuth_CD from Pricings where event_id = '" + label1.Text + "'";
                        DataTable dtPaCD = new DataTable();
                        SqlDataAdapter adapterPaCD = new SqlDataAdapter(command);
                        adapterPaCD.Fill(dtPaCD);
                        string slctPaChCodes = dtPaCD.Rows[0][0].ToString();
                        //MessageBox.Show(slctPaChCodes);
                        if (slctPaChCodes == "")
                        {
                            //MessageBox.Show("there is no ChCD. for Prem Auth");
                        }
                        else
                        {

                            //-- select Premium Authoristion PPI value from Contract
                            command.CommandText = "Select PPI from Contracts where ChargeCodes in ('" + slctPaChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                            DataTable dtPaPPI = new DataTable();
                            SqlDataAdapter adapterPaPPI = new SqlDataAdapter(command);
                            adapterPaPPI.Fill(dtPPI);
                            string slctPaPPI = dtPPI.Rows[0][0].ToString();
                            //MessageBox.Show(slctPaPPI);

                            //-- Update Premium Authoristion PPI value in Pricing
                            string updtPaPPI = "update Pricings set P_A_PPI ='" + slctPaPPI + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdPaPPI = new SqlCommand(updtPaPPI, conn);
                            cmdPaPPI.ExecuteNonQuery();
                            //-- select Premium Authoristion PPC value from Contract
                            command.CommandText = "Select PPC from Contracts where ChargeCodes in ('" + slctPaChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                            DataTable dtPaPPC = new DataTable();
                            SqlDataAdapter adapterPaPPC = new SqlDataAdapter(command);
                            adapterPPC.Fill(dtPaPPC);
                            string slctPaPPC = dtPaPPC.Rows[0][0].ToString();
                            //-- Update Premium CaptureMethode PPC value in Pricing
                            string updtPaPPC = "update Pricings set P_A_PPC ='" + slctPaPPC + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdPaPPC = new SqlCommand(updtPaPPC, conn);
                            cmdPaPPC.ExecuteNonQuery();
                            //MessageBox.Show(slctPaPPC);
                            //-- Update Premium Authoristion P_A_PPC*FUND value in Pricing
                            double P_A_PPCxFund = double.Parse(amountTextBox.Text) * double.Parse(slctPaPPC.ToString());
                            //MessageBox.Show(P_A_PPCxFund.ToString());
                            string updtP_A_PPCxFund = "update Pricings set P_A_PPCxFUND ='" + P_A_PPCxFund.ToString() + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdP_A_PPCxFund = new SqlCommand(updtP_A_PPCxFund, conn);
                            cmdP_A_PPCxFund.ExecuteNonQuery();
                            //-- Premium Authoristion Update P_A_PPCxFUNDplusPPI value in Pricing
                            double P_A_PPCxFUNDplusPPI = double.Parse(amountTextBox.Text) * double.Parse(slctPaPPC.ToString()) + double.Parse(slctPaPPI);
                            //MessageBox.Show(P_A_PPCxFUNDplusPPI.ToString());
                            string updtP_A_PPCxFUNDplusPPI = "update Pricings set P_A_PPCxFUNDplusPPI ='" + P_A_PPCxFUNDplusPPI.ToString() + "' where event_id = '" + label1.Text + "'";
                            SqlCommand cmdP_A_PPCxFUNDplusPPI = new SqlCommand(updtP_A_PPCxFUNDplusPPI, conn);
                            cmdP_A_PPCxFUNDplusPPI.ExecuteNonQuery();
                        }
                        conn.Close();
                    }

                }
                else
                {
                    //-- look for CARDS PROCESSED FOR OTHER ACQUIRER Charge Code and populate A_PPI and A_PPC
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "Select CardProcessed_CD from Pricings where event_id = '" + label1.Text + "'";
                    DataTable dtCpaCD = new DataTable();
                    SqlDataAdapter adapterCpaCD = new SqlDataAdapter(command);
                    adapterCpaCD.Fill(dtCpaCD);
                    string slctCpaChCodes = dtCpaCD.Rows[0][0].ToString();
                    // MessageBox.Show(slctChCodes);
                    //-- select Cards Processed for other Aqcquirer PPI value from Contract
                    command.CommandText = "Select PPI from Contracts where ChargeCodes in ('" + slctCpaChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                    DataTable dtPPI = new DataTable();
                    SqlDataAdapter adapterPPI = new SqlDataAdapter(command);
                    adapterPPI.Fill(dtPPI);
                    string slctCpaPPI = dtPPI.Rows[0][0].ToString();
                    //-- Update PPI value in Pricing
                    string updtCpaPPI = "update Pricings set CP_PPI ='" + slctCpaPPI + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmdCpaPPI = new SqlCommand(updtCpaPPI, conn);
                    cmdCpaPPI.ExecuteNonQuery();
                    //-- select PPC value from Contract
                    command.CommandText = "Select PPC from Contracts where ChargeCodes in ('" + slctCpaChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                    DataTable dtPPC = new DataTable();
                    SqlDataAdapter adapterPPC = new SqlDataAdapter(command);
                    adapterPPI.Fill(dtPPC);
                    string slctCpaPPC = dtPPC.Rows[0][0].ToString();
                    //-- Update PPC value in Pricing
                    string updtCpaPPC = "update Pricings set CP_PPC ='" + slctCpaPPC + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmdCpaPPC = new SqlCommand(updtCpaPPC, conn);
                    cmdCpaPPC.ExecuteNonQuery();
                    //MessageBox.Show(slctCpaPPC);
                    //-- Update CP_PPC*FUND value in Pricing
                    double CP_PPCxFund = double.Parse(amountTextBox.Text) * double.Parse(slctCpaPPC.ToString());
                    //MessageBox.Show(CP_PPCxFund.ToString());
                    string updtCP_PPCxFund = "update Pricings set CP_PPCxFUND ='" + CP_PPCxFund.ToString() + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmdCP_PPCxFund = new SqlCommand(updtCP_PPCxFund, conn);
                    cmdCP_PPCxFund.ExecuteNonQuery();
                    //-- Update CP_PPCxFUNDplusPPI value in Pricing
                    double CP_PPCxFUNDplusPPI = double.Parse(amountTextBox.Text) * double.Parse(slctCpaPPC.ToString()) + double.Parse(slctCpaPPI);
                    //MessageBox.Show(CP_PPCxFUNDplusPPI.ToString());
                    string updtCP_PPCxFUNDplusPPI = "update Pricings set CP_PPCxFUNDplusPPI ='" + CP_PPCxFUNDplusPPI.ToString() + "' where event_id = '" + label1.Text + "'";
                    SqlCommand cmdCP_PPCxFUNDplusPPI = new SqlCommand(updtCP_PPCxFUNDplusPPI, conn);
                    cmdCP_PPCxFUNDplusPPI.ExecuteNonQuery();
                    conn.Close();
                }

                // Creaza Charge Code for Premium Authorisation 
                if (this.authorisedCheckBox.Checked)
                {
                    misscellaneousCD = "MIS" + schemaAbrev.ToString();
                    //MessageBox.Show(schemaAbrev.ToString());
                    var transaction2 = new TransactionProcessing()
                    {
                        Transaction_Type = textBox3TxnType.Text,
                        CaptureMethod = textBox3CaptureMethode.Text,
                        Schema = textBox3Schema.Text,
                        Amount = amountTextBox.Text,
                        Event_Id = 1 + label1.Text,
                        Merchant_Id = labelMerchant.Text,
                        Txn_Currency = transactionCurrency,
                        FX_In = fxin,
                        FX_Out = fxout,
                        Creation_Data = cretionDate,
                        Electronic = electronic,
                        SettlementCurrency = settlementCurrency,
                        SchemaAbrev = schemaAbrev
                       
                    };
                    this.transactionProcessingRepository.Add(transaction2);

                    var pricing2 = new Pricing()
                    {
                        Event_Id = 1 + label1.Text,
                        Merchant_Id = labelMerchant.Text,
                        Authorised = electronic,
                        CaptureMethod = textBox2CaptureMethode.Text,
                        Amount = amountTextBox.Text,
                        MiscellTVA = costTVAdouble,
                        Misscellaneous_CD = misscellaneousCD,
                    };
                    this.pricingRepository.Add(pricing2);

                    //-- look for MISSCELLANEOUS Charge Code and populate M_PPI
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "Select Misscellaneous_CD from Pricings where event_id = '" + 1 + label1.Text + "'";
                    DataTable dtMisCD = new DataTable();
                    SqlDataAdapter adapterMisCD = new SqlDataAdapter(command);
                    adapterMisCD.Fill(dtMisCD);
                    string slctMisChCodes = dtMisCD.Rows[0][0].ToString();
                    // MessageBox.Show(slctMisChCodes);
                    //-- select Miscellaneous PPI value from Contract
                    command.CommandText = "Select PPI from Contracts where ChargeCodes in ('" + slctMisChCodes + "') and MerchanId  = '"+labelMerchant.Text+"'";
                    DataTable dtMisPPI = new DataTable();
                    SqlDataAdapter adapterMisPPI = new SqlDataAdapter(command);
                    adapterMisPPI.Fill(dtMisPPI);
                    string slctMisPPI = dtMisPPI.Rows[0][0].ToString();
                    //-- Update Miscellaneous PPI value in Pricing
                    string updtMisPPI = "update Pricings set M_PPI ='" + slctMisPPI + "' where event_id = '" + 1 + label1.Text + "'";
                    SqlCommand cmdMisPPI = new SqlCommand(updtMisPPI, conn);
                    cmdMisPPI.ExecuteNonQuery();
                    //MessageBox.Show(slctMisChCodes);


                    conn.Close();
                }
                else { }
            }
        }

        private void visaDrPerIntLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.VisaDrPerInt.GetDescription();
            schemaAbrev = enumSchemaAbrev.VisaDrPerInt.GetDescription();
            cardIssuer = enumCardIssuer.VisaDrPerInt.GetDescription();
            schemaLabel.Text = visaDrPerIntLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void visaDrComIntlLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.VisaDrComIntl.GetDescription();
            schemaAbrev = enumSchemaAbrev.VisaDrComIntl.GetDescription();
            cardIssuer = enumCardIssuer.VisaDrComIntl.GetDescription();
            schemaLabel.Text = visaDrComIntlLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }
        private void visaCorporateLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.VisaCorporate.GetDescription();
            schemaAbrev = enumSchemaAbrev.VisaCorporate.GetDescription();
            cardIssuer = enumCardIssuer.VisaCorporate.GetDescription();
            schemaLabel.Text = visaCorporateLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }
        private void visaCreditPersonalLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.VisaCreditPersonal.GetDescription();
            schemaAbrev = enumSchemaAbrev.VisaCreditPersonal.GetDescription();
            cardIssuer = enumCardIssuer.VisaCreditPersonal.GetDescription();
            schemaLabel.Text = visaCreditPersonalLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }
        private void visaCommerceLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.VisaCommerce.GetDescription();
            schemaAbrev = enumSchemaAbrev.VisaCommerce.GetDescription();
            cardIssuer = enumCardIssuer.VisaCommerce.GetDescription();
            schemaLabel.Text = visaCommerceLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }
        private void visaBusinessLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.VisaBusiness.GetDescription();
            schemaAbrev = enumSchemaAbrev.VisaBusiness.GetDescription();
            cardIssuer = enumCardIssuer.VisaBusiness.GetDescription();
            schemaLabel.Text = visaBusinessLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void masterCardBusinessLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.MasterCardBusiness.GetDescription();
            schemaAbrev = enumSchemaAbrev.MasterCardBusiness.GetDescription();
            cardIssuer = enumCardIssuer.MasterCardBusiness.GetDescription();
            schemaLabel.Text = masterCardBusinessLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void maestroComLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.MaestroUKCom.GetDescription();
            schemaAbrev = enumSchemaAbrev.MaestroUKCom.GetDescription();
            cardIssuer = enumCardIssuer.MaestroUKCom.GetDescription();
            schemaLabel.Text = maestroComLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void debitMasterCardPerIntLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.DebitMasterCardPerInt.GetDescription();
            schemaAbrev = enumSchemaAbrev.DebitMasterCardPerInt.GetDescription();
            cardIssuer = enumCardIssuer.DebitMasterCardPerInt.GetDescription();
            schemaLabel.Text = debitMasterCardPerIntLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void jcbLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.JCB.GetDescription();
            schemaAbrev = enumSchemaAbrev.JCB.GetDescription();
            schemaLabel.Text = jcbLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void dinersDiscoverLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.DinersDiscover.GetDescription();
            schemaAbrev = enumSchemaAbrev.DinersDiscover.GetDescription();
            schemaLabel.Text = labelDinersDiscoverAcquired.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }
        private void masterCardCrPerLabel_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.MasterCardCrPer.GetDescription();
            schemaAbrev = enumSchemaAbrev.MasterCardCrPer.GetDescription();
            cardIssuer = enumCardIssuer.MasterCardCrPer.GetDescription();
            schemaLabel.Text = masterCardCrPerLabel.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }
        private void panelSchemaForProcessed_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelAmericanExpress_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.AmericanExpress.GetDescription();
            schemaAbrev = enumSchemaAbrev.AmericanExpress.GetDescription();
            schemaLabel.Text = labelAmericanExpress.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void labelDinersDiscoverdProcessed_Click(object sender, EventArgs e)
        {
            textBox3Schema.Text = enumSchema.DinersClubDiscover.GetDescription();
            schemaAbrev = enumSchemaAbrev.DinersClubDiscover.GetDescription();
            schemaLabel.Text = labelDinersDiscoverdProcessed.Text;
            schemaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerSchema.Start();
        }

        private void contactlessLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = contactlessLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.Contactless).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }
        private void magneticStripeLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = magneticStripeLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.magneticStripe).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }

        private void eCommerceLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = eCommerceLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.eCommerce).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }

        private void offlinePinLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = offlinePinLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.OfflinePin).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }

        private void onlineChipLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = onlineChipLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.OnlineChip).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }
        private void panKeyEntryLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = panKeyEntryLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.PANKeyEntry).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }

        private void motoSecureLabel_Click(object sender, EventArgs e)
        {
            captureMethodeLabel.Text = motoSecureLabel.Text;
            textBox3CaptureMethode.Text = ((int)enumCaptureMethode.MOTOsecure).ToString();
            captureMethodeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerCaptureMethode.Start();
        }
        private void intraRegionalLabel_Click(object sender, EventArgs e)
        {
            localityLabel.Text = intraRegionalLabel.Text;
            textBox3Locality.Text = ((int)enumLocality.Intra_regional).ToString();
            localityLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerLocality.Start();
        }
        private void domesticLabel_Click(object sender, EventArgs e)
        {
            localityLabel.Text = domesticLabel.Text;
            textBox3Locality.Text = ((int)enumLocality.Domestic).ToString();
            localityLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerLocality.Start();
        }
        private void interRegionalLabel_Click(object sender, EventArgs e)
        {
            localityLabel.Text = interRegionalLabel.Text;
            textBox3Locality.Text = ((int)enumLocality.Inter_regional).ToString();
            localityLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerLocality.Start();
        }
        private void localityLabel_Click(object sender, EventArgs e)
        {
            timerLocality.Start();
        }

        private void TransactionTypeLabel_Click(object sender, EventArgs e)
        {
            timerTxnType.Start();
        }

        private void captureMethodeLabel_Click(object sender, EventArgs e)
        {
            timerCaptureMethode.Start();
        }

        private void schemaLabel_Click(object sender, EventArgs e)
        {
            timerSchema.Start();
        }

        private void timerTxnType_Tick(object sender, EventArgs e)
        {
            if (isTxnTypePanelOpen)
            {
                panelTxnType.Height -= 20;
                if (panelTxnType.Height == 0)
                {
                    timerTxnType.Stop();
                    isTxnTypePanelOpen = false;
                }
            }
            else if (!isTxnTypePanelOpen)
            {
                panelTxnType.Height += 20;
                if (panelTxnType.Height == 140)
                {
                    timerTxnType.Stop();
                    isTxnTypePanelOpen = true;
                }
            }
        }
        private void timerSchema_Tick(object sender, EventArgs e)
        {
            if (isSchemaPanelOpen && this.AcquiredCheckBox.Checked)
            {
                panelSchemeForAcquired.Height -= 20;
                if (panelSchemeForAcquired.Height == 0)
                {
                    timerSchema.Stop();
                    isSchemaPanelOpen = false;
                }
            }
            else if (!isSchemaPanelOpen && this.AcquiredCheckBox.Checked)
            {
                panelSchemeForAcquired.Height += 20;
                if (panelSchemeForAcquired.Height == 220)
                {
                    timerSchema.Stop();
                    isSchemaPanelOpen = true;
                }
            }

            if (isSchemaPanelOpen && !this.AcquiredCheckBox.Checked)
            {
                panelSchemaForProcessed.Height -= 20;
                if (panelSchemaForProcessed.Height == 0)
                {
                    timerSchema.Stop();
                    isSchemaPanelOpen = false;
                }
            }
            else if (!isSchemaPanelOpen && !this.AcquiredCheckBox.Checked)
            {
                panelSchemaForProcessed.Height += 20;
                if (panelSchemaForProcessed.Height == 100)
                {
                    timerSchema.Stop();
                    isSchemaPanelOpen = true;
                }
            }
        }
        private void timerCaptureMethode_Tick(object sender, EventArgs e)
        {
            if (isCaptureMethodePanelOpen)
            {
                panelCaptureMethode.Height -= 20;
                if (panelCaptureMethode.Height == 0)
                {
                    timerCaptureMethode.Stop();
                    isCaptureMethodePanelOpen = false;
                }
            }
            else if (!isCaptureMethodePanelOpen)
            {
                panelCaptureMethode.Height += 20;
                if (panelCaptureMethode.Height == 140)
                {
                    timerCaptureMethode.Stop();
                    isCaptureMethodePanelOpen = true;
                }
            }
        }

        private void timerLocality_Tick(object sender, EventArgs e)
        {
            if (isLocalityPanelOpen)
            {
                panelLocality.Height -= 20;
                if (panelLocality.Height == 0)
                {
                    timerLocality.Stop();
                    isLocalityPanelOpen = false;
                }
            }
            else if (!isLocalityPanelOpen)
            {
                panelLocality.Height += 20;
                if (panelLocality.Height == 80)
                {
                    timerLocality.Stop();
                    isLocalityPanelOpen = true;
                }
            }
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            TransactionTypeLabel.Text = "Transaction Type";
            schemaLabel.Text = "Schema";
            captureMethodeLabel.Text = "Capture Methode";
            localityLabel.Text = "Locality";
            labelMerchant.Text = "Merchant";
            panelTxnType.Size = new System.Drawing.Size(132, 0);
            panelSchemeForAcquired.Size = new System.Drawing.Size(225, 0);
            panelSchemaForProcessed.Size = new System.Drawing.Size(170, 0);
            panelCaptureMethode.Size = new System.Drawing.Size(148, 0);
            panelLocality.Size = new System.Drawing.Size(130, 0);
            panelMerchant.Size = new System.Drawing.Size(83, 0);
            TransactionTypeLabel.ForeColor = System.Drawing.Color.Aqua;
            schemaLabel.ForeColor = System.Drawing.Color.Aqua;
            captureMethodeLabel.ForeColor = System.Drawing.Color.Aqua;
            localityLabel.ForeColor = System.Drawing.Color.Aqua;
            labelMerchant.ForeColor = System.Drawing.Color.Aqua;
            buttonRefresh.Text = "Refresh";
            this.panelDashbordTxn.Size = new System.Drawing.Size(0, 0);
            clicksNumber = 0;


            conn.Open();
            string deleteAllFromPricings = "Delete from Pricings where Event_id >= '1000'";
            string deleteAllFromTxnProcessings = "Delete from TransactionProcessings where Event_id >= '1000'";
            SqlCommand cmd = new SqlCommand(deleteAllFromPricings, conn);
            SqlCommand cmd2 = new SqlCommand(deleteAllFromTxnProcessings, conn);
            int NrPricingRowsDeleted = cmd.ExecuteNonQuery();
            int NrTxnPRowsDeleted = cmd2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(NrPricingRowsDeleted.ToString() + " Rows deleted from Pricing table!\n" + NrTxnPRowsDeleted.ToString() + " Rows deleted from TransactionP. table!");
        }
       /* private void buttonErrMsgBoxOK_Click(object sender, EventArgs e)
        {
            this.panelErrorMsgBox.Size = new System.Drawing.Size(0, 0);

        }*/


        private void transaction_ProcessingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.transaction_ProcessingBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.pBICalculationDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'calculatingPBIDataSet.TransactionProcessings' table. You can move, or remove it, as needed.
           // this.transactionProcessingsTableAdapter.Fill(this.calculatingPBIDataSet.TransactionProcessings);
            // TODO: This line of code loads data into the "pBICalculationDataSet.Transaction_Processing" table. You can move, or remove it, as needed.
            //this.transaction_ProcessingTableAdapter.Fill(this.pBICalculationDataSet.Transaction_Processing);

        }

        private void buttonGeneratePDF_Click(object sender, EventArgs e)
        {
            SqlCommand commandCount = new SqlCommand();
            commandCount.Connection = conn;
            commandCount.CommandText = "select count(Event_id) from TransactionProcessings";
            DataTable dtCountTxn = new DataTable();
            SqlDataAdapter adapterCountTxn = new SqlDataAdapter(commandCount);
            adapterCountTxn.Fill(dtCountTxn);

            int countTxn = int.Parse((dtCountTxn.Rows[0][0].ToString()));

            if ( countTxn == 0)
            {
                MessageBox.Show("There is not transaction submitted\nPlease submit transaction(s) and generate invoice!", "Error: No transaction!");
            }

            else
            {
                clicksNumber++;
                //amountTextBox.Text = "100";
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Select max(Creation_Data) from TransactionProcessings";
                DataTable datamaxima = new DataTable();
                SqlDataAdapter adapterDmax = new SqlDataAdapter(command);
                adapterDmax.Fill(datamaxima);
                command.CommandText = "Select min(Creation_Data) from TransactionProcessings";
                DataTable dataminima = new DataTable();
                SqlDataAdapter adapterDmin = new SqlDataAdapter(command);
                adapterDmin.Fill(dataminima);
                command.CommandText = "Select round(CHRGAmount,2) from InvoiceDataUNIONALL where ChrgCode = 'Total Acquired'";
                DataTable dtTotalAcquire = new DataTable();
                SqlDataAdapter adapterTotalAcquired = new SqlDataAdapter(command);
                adapterTotalAcquired.Fill(dtTotalAcquire);
                command.CommandText = "Select round(CHRGAmount,2) from InvoiceDataUNIONALL where ChrgCode = 'Total CardProcessed'";
                DataTable dtTotalCardPr = new DataTable();
                SqlDataAdapter adapterTotalCardPr = new SqlDataAdapter(command);
                adapterTotalCardPr.Fill(dtTotalCardPr);
                command.CommandText = "Select round(CHRGAmount,2) from InvoiceDataUNIONALL where ChrgCode = 'Total Premium'";
                DataTable dtTotalPremium = new DataTable();
                SqlDataAdapter adapterTotalPremium = new SqlDataAdapter(command);
                adapterTotalPremium.Fill(dtTotalPremium);
                command.CommandText = "Select round(CHRGAmount,2) from InvoiceDataUNIONALL where ChrgCode = 'Total Miscellaneous'";
                DataTable dtTotalMis = new DataTable();
                SqlDataAdapter adapterTotalMis = new SqlDataAdapter(command);
                adapterTotalMis.Fill(dtTotalMis);
                command.CommandText = "Select round(sum(CHRGAmount),2) from InvoiceDataUNIONALL where ChrgCode like 'Total%'";
                DataTable dtTotalComis = new DataTable();
                SqlDataAdapter adapterTotalComis = new SqlDataAdapter(command);
                adapterTotalComis.Fill(dtTotalComis);
                command.CommandText = "Select round(sum(Tva*CHRGAmount/100),2)  from InvoiceDataTAX_ALL";
                DataTable dtVAT = new DataTable();
                SqlDataAdapter adapterVAT = new SqlDataAdapter(command);
                adapterVAT.Fill(dtVAT);
                command.CommandText = "Select count(ChrgCode) from InvoiceDataUNIONALL where ChrgCode like'A%'";
                DataTable dtCountCardAcqRows = new DataTable();
                SqlDataAdapter adapterCountCardAcqRows = new SqlDataAdapter(command);
                adapterCountCardAcqRows.Fill(dtCountCardAcqRows);
                command.CommandText = "Select count(ChrgCode) from InvoiceDataUNIONALL where ChrgCode like'C%'";
                DataTable dtCountCardProcessRows = new DataTable();
                SqlDataAdapter adapterCardProcessRows = new SqlDataAdapter(command);
                adapterCardProcessRows.Fill(dtCountCardProcessRows);
                command.CommandText = "Select count(ChrgCode) from InvoiceDataUNIONALL where ChrgCode like'P%'";
                DataTable dtCountPremiumRows = new DataTable();
                SqlDataAdapter adapterCountPremiumRows = new SqlDataAdapter(command);
                adapterCountPremiumRows.Fill(dtCountPremiumRows);
                command.CommandText = "Select count(ChrgCode) from InvoiceDataUNIONALL where ChrgCode like'M%'";
                DataTable dtCountMisRows = new DataTable();
                SqlDataAdapter adapterCountMisRows = new SqlDataAdapter(command);
                adapterCountMisRows.Fill(dtCountMisRows);
                command.CommandText = "select txnAmount from InvoiceDataUNIONALL where ChrgCode = 'Total Acquired'";
                DataTable dtBatchTotals = new DataTable();
                SqlDataAdapter adapterBatchTotals = new SqlDataAdapter(command);
                adapterBatchTotals.Fill(dtBatchTotals);
                SqlCommand commandMerchantName = new SqlCommand();
                commandMerchantName.Connection = conn;
                commandMerchantName.CommandText = "select distinct Merchant_id from TransactionProcessings";
                DataTable dtMerchantName = new DataTable();
                SqlDataAdapter adapterMerchantName = new SqlDataAdapter(commandMerchantName);
                adapterMerchantName.Fill(dtMerchantName);
                






                conn.Close();

                string datamax = datamaxima.Rows[0][0].ToString();
                string datamin = dataminima.Rows[0][0].ToString();
                string totalAcquire = dtTotalAcquire.Rows[0][0].ToString();
                string totalCardProcessed = dtTotalCardPr.Rows[0][0].ToString();
                string totalPremium = dtTotalPremium.Rows[0][0].ToString();
                string totalMiscellaneous = dtTotalMis.Rows[0][0].ToString();
                string totalComisioane = dtTotalComis.Rows[0][0].ToString();
                string totalTVA = dtVAT.Rows[0][0].ToString();
                double grandTotal = double.Parse(totalTVA) + double.Parse(totalComisioane);
                int RowsNrForCardAcq = int.Parse(dtCountCardAcqRows.Rows[0][0].ToString()) * 7;
                int RowsNrForCardProcessed = int.Parse(dtCountCardProcessRows.Rows[0][0].ToString()) * 7;
                int RowsNrForPremium = int.Parse(dtCountPremiumRows.Rows[0][0].ToString()) * 7;
                int RowsNrForMis = int.Parse(dtCountMisRows.Rows[0][0].ToString()) * 5;
                string batchTotals = (dtBatchTotals.Rows[0][0].ToString());
                string merchantName = dtMerchantName.Rows[0][0].ToString();
                int jCA = 0;
                int kCA = -1;
                int jCP = 0;
                int kCP = -1;
                int jPrem = 0;
                int kPrem = -1;
                int jMis = 0;
                int kMis = -1;




                /*  Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                 PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("TestRubChrgCalc.pdf", FileMode.Create));
                 doc.Open();
                 Paragraph paragraph = new Paragraph("Factura Nr: "+clicksNumber+"\nNume Comerciant: "+merchantID+
                     "\nPerioada facturarii: "+datamin.Substring(0,10)+"  -  "+datamax.Substring(0, 10)+"\n\nData facturarii: "
                     + cretionDate);
                 // add other lines 
                 doc.Add(paragraph);

                 doc.Close();
             */

                //Document doc = new Document(PageSize.A4);

                Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("TestRubChrgCalc1.pdf", FileMode.Create));
                doc.Open();
                Paragraph paragraph = new Paragraph("Factura Nr: " + (clicksNumber-1) + "\nNume Comerciant: " + merchantName +
                    "\nPerioada facturarii: " + datamin.Substring(0, 10) + "  -  " + datamax.Substring(0, 10) + "\n\nData emiterii facturarii: "
                    + cretionDate + "\n\n",FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD));
                // add other lines 
                doc.Add(paragraph);

                PdfPTable table1Sumar = new PdfPTable(2);
                table1Sumar.WidthPercentage = 90;


                PdfPCell cellSumar = new PdfPCell();
                cellSumar.AddElement(new Paragraph("Sumar factura", FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD)));
                cellSumar.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cellSumarSume = new PdfPCell();
                cellSumarSume.AddElement(new Paragraph("Sume", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                cellSumarSume.Border = Rectangle.BOTTOM_BORDER;
                table1Sumar.AddCell(cellSumar);
                table1Sumar.AddCell(cellSumarSume);

                PdfPTable table2SumarCosturi = new PdfPTable(2);
                table2SumarCosturi.WidthPercentage = 90;
                

                PdfPCell cell21CostCardAcq = new PdfPCell();
                 cell21CostCardAcq.AddElement(new Phrase("Cost tranzactii: Cards Acquired "));
                 //("Tva 0%"));
                 cell21CostCardAcq.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell22SumaCardAcq = new PdfPCell();
                if (string.IsNullOrEmpty(totalAcquire))
                {
                    cell22SumaCardAcq.AddElement(new Paragraph("0" + settlementCurrency));
                }
                else
                {
                    cell22SumaCardAcq.AddElement(new Paragraph(totalAcquire + settlementCurrency));
                }
                cell22SumaCardAcq.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell211CostCardProcess = new PdfPCell();
                cell211CostCardProcess.AddElement(new Paragraph("Cost tranzactii: Cards Processed (tva%)"));
                cell211CostCardProcess.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell221SumaCardProcess = new PdfPCell();
                if (string.IsNullOrEmpty(totalCardProcessed))
                {
                    cell221SumaCardProcess.AddElement(new Paragraph("0" + settlementCurrency));
                }
                else
                {
                    cell221SumaCardProcess.AddElement(new Paragraph(totalCardProcessed + settlementCurrency /*+ " (tva%)" + costTVAdouble*100+"%)"*/));
                }
                cell221SumaCardProcess.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell212CostPremium = new PdfPCell();
                cell212CostPremium.AddElement(new Paragraph("Cost tranzactii: Premium "));
                cell212CostPremium.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell222SumaPremium = new PdfPCell();
                if (string.IsNullOrEmpty(totalPremium))
                {
                    cell222SumaPremium.AddElement(new Paragraph("0" + settlementCurrency));
                }
                else
                {
                    cell222SumaPremium.AddElement(new Paragraph(totalPremium + settlementCurrency));
                }
                
                cell222SumaPremium.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell213CostMis = new PdfPCell();
                cell213CostMis.AddElement(new Paragraph("Cost tranzactii: Miscellaneous (tva%)"));
                cell213CostMis.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell223SumaMis = new PdfPCell();
                if (string.IsNullOrEmpty(totalMiscellaneous))
                {
                    cell223SumaMis.AddElement(new Paragraph("0" + settlementCurrency));
                }
                else
                {
                    cell223SumaMis.AddElement(new Paragraph(totalMiscellaneous + settlementCurrency ));
                }
                
                cell223SumaMis.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell214FaraTVA = new PdfPCell();
                cell214FaraTVA.AddElement(new Paragraph("Total factura curenta fara TVA: ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                cell214FaraTVA.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell224SumaFaraTVA = new PdfPCell();
                cell224SumaFaraTVA.AddElement(new Paragraph(totalComisioane + settlementCurrency, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                cell224SumaFaraTVA.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell215TVA = new PdfPCell();
                cell215TVA.AddElement(new Paragraph("TVA " + costTVAdouble * 100 + "%"));
                cell215TVA.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell225TVASuma = new PdfPCell();
                cell225TVASuma.AddElement(new Paragraph(totalTVA + settlementCurrency));
                cell225TVASuma.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell216GrandTotal = new PdfPCell();
                cell216GrandTotal.AddElement(new Paragraph("Grand Total:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)));
                cell216GrandTotal.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell226GrandTSuma = new PdfPCell();
                if (string.IsNullOrEmpty(grandTotal.ToString()))
                {
                    cell226GrandTSuma.AddElement(new Paragraph("0" + settlementCurrency, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)));
                }
                else
                {
                    cell226GrandTSuma.AddElement(new Paragraph(grandTotal.ToString() + settlementCurrency, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)));
                }
                cell226GrandTSuma.Border = Rectangle.BOTTOM_BORDER;
                table2SumarCosturi.AddCell(cell21CostCardAcq);
                table2SumarCosturi.AddCell(cell22SumaCardAcq);
                table2SumarCosturi.AddCell(cell211CostCardProcess);
                table2SumarCosturi.AddCell(cell221SumaCardProcess);
                table2SumarCosturi.AddCell(cell212CostPremium);
                table2SumarCosturi.AddCell(cell222SumaPremium);
                table2SumarCosturi.AddCell(cell213CostMis);
                table2SumarCosturi.AddCell(cell223SumaMis);
                table2SumarCosturi.AddCell(cell214FaraTVA);
                table2SumarCosturi.AddCell(cell224SumaFaraTVA);
                table2SumarCosturi.AddCell(cell215TVA);
                table2SumarCosturi.AddCell(cell225TVASuma);
                table2SumarCosturi.AddCell(cell216GrandTotal);
                table2SumarCosturi.AddCell(cell226GrandTSuma);

                PdfPTable table3HeadDetaliiCost = new PdfPTable(1);
                table3HeadDetaliiCost.WidthPercentage = 90;
                PdfPCell cell3 = new PdfPCell();
                cell3.AddElement(new Paragraph("\n\n Detaliere costuri", FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD)));
                cell3.Border = Rectangle.BOTTOM_BORDER;
                table3HeadDetaliiCost.AddCell(cell3);
                // CARD ACQUIRED
                PdfPTable table4DetaliereCardAcq = new PdfPTable(7);
                table4DetaliereCardAcq.HorizontalAlignment = 1;
                table4DetaliereCardAcq.TotalWidth = 500f;
                table4DetaliereCardAcq.LockedWidth = true;
                float[] widthsCA = new float[] { 165f, 60f, 60f, 65f, 60f, 60f, 30f };
                table4DetaliereCardAcq.SetWidths(widthsCA);
                PdfPCell cell40HeadCA = new PdfPCell();
                cell40HeadCA.AddElement(new Paragraph("Cards Acquires", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                cell40HeadCA.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell41HeadNrOfTxn = new PdfPCell();
                cell41HeadNrOfTxn.AddElement(new Paragraph("Nr.\nTranzactii", FontFactory.GetFont("Arial", 8)));
                cell41HeadNrOfTxn.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell42PPI = new PdfPCell();
                cell42PPI.AddElement(new Paragraph("Cost Per\nTranzactie", FontFactory.GetFont("Arial", 8)));
                cell42PPI.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell43TxnVal = new PdfPCell();
                cell43TxnVal.AddElement(new Paragraph("Valoare\nTranzactie", FontFactory.GetFont("Arial", 8)));
                cell43TxnVal.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell44PPC = new PdfPCell();
                cell44PPC.AddElement(new Paragraph("Procentaj\n% ", FontFactory.GetFont("Arial", 8)));
                cell44PPC.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell45TxnCost = new PdfPCell();
                cell45TxnCost.AddElement(new Paragraph("Cost\nTranzactie", FontFactory.GetFont("Arial", 8)));
                cell45TxnCost.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell46TVA = new PdfPCell();
                cell46TVA.AddElement(new Paragraph("TVA\n%", FontFactory.GetFont("Arial", 8)));
                cell46TVA.Border = Rectangle.BOTTOM_BORDER;

                table4DetaliereCardAcq.AddCell(cell40HeadCA);
                table4DetaliereCardAcq.AddCell(cell41HeadNrOfTxn);
                table4DetaliereCardAcq.AddCell(cell42PPI);
                table4DetaliereCardAcq.AddCell(cell43TxnVal);
                table4DetaliereCardAcq.AddCell(cell44PPC);
                table4DetaliereCardAcq.AddCell(cell45TxnCost);
                table4DetaliereCardAcq.AddCell(cell46TVA);


                for (int i = 0; i < RowsNrForCardAcq; i++)
                {
                    if (kCA >= 6 && kCA <= RowsNrForCardAcq)
                    {
                        jCA++;
                        kCA = -1;
                    }
                    kCA++;

                    ///MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select Descriptions, NrOfTxn, Chrg_Per_Item, TxnAmount,Chrg_Percentage, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode like 'A%' order by Descriptions asc";
                    DataTable dtDescriptionCardAcq = new DataTable();
                    SqlDataAdapter adapterDescriptionCardAcq = new SqlDataAdapter(command);
                    adapterCountCardAcqRows.Fill(dtDescriptionCardAcq);
                    string descriptionCAmNegativ = dtDescriptionCardAcq.Rows[jCA][3].ToString();
                    if (int.Parse(descriptionCAmNegativ) < 0 && kCA == 4)
                    {
                        string description = "-" + dtDescriptionCardAcq.Rows[jCA][kCA].ToString() + "%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(description, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table4DetaliereCardAcq.AddCell(cell);
                    }
                    else if(kCA == 4 || kCA == 6)
                    {
                        string description = dtDescriptionCardAcq.Rows[jCA][kCA].ToString() + "%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(description, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table4DetaliereCardAcq.AddCell(cell);
                    }
                    else
                    {
                        string description = dtDescriptionCardAcq.Rows[jCA][kCA].ToString();
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(description, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table4DetaliereCardAcq.AddCell(cell);
                    }
                    
                }
                for (int i = 0; i < 7; i++)
                {                ///MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select ChrgCode, NrOfTxn, Chrg_Per_Item, TxnAmount,Chrg_Percentage, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode ='Total Acquired'";
                    DataTable dtDescriptionTotalCardAcq = new DataTable();
                    SqlDataAdapter adapterDescriptionTotalCardAcq = new SqlDataAdapter(command);
                    adapterDescriptionTotalCardAcq.Fill(dtDescriptionTotalCardAcq);
                    string descriptionTotCAcq = dtDescriptionTotalCardAcq.Rows[0][i].ToString();
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Paragraph(descriptionTotCAcq, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    cell.Border = Rectangle.BOTTOM_BORDER;
                    table4DetaliereCardAcq.AddCell(cell);
                }

                PdfPTable tablegol = new PdfPTable(1);
                tablegol.WidthPercentage = 90;
                PdfPCell cellgoala = new PdfPCell();
                cellgoala.AddElement(new Paragraph("\n\n"));
                cellgoala.Border = Rectangle.NO_BORDER;
                tablegol.AddCell(cellgoala);

                // CARD PROCESSED
                PdfPTable table5DetaliereCardProcessed = new PdfPTable(7);
                table5DetaliereCardProcessed.HorizontalAlignment = 1;
                table5DetaliereCardProcessed.TotalWidth = 500f;
                table5DetaliereCardProcessed.LockedWidth = true;
                float[] widthsCP = new float[] { 165f, 60f, 60f, 65f, 60f, 60f, 30f };
                table5DetaliereCardProcessed.SetWidths(widthsCP);
                PdfPCell cell50HeadCP = new PdfPCell();
                cell50HeadCP.AddElement(new Paragraph("CardsProcessed", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                cell50HeadCP.Border = Rectangle.BOTTOM_BORDER;


                table5DetaliereCardProcessed.AddCell(cell50HeadCP);
                table5DetaliereCardProcessed.AddCell(cell41HeadNrOfTxn);
                table5DetaliereCardProcessed.AddCell(cell42PPI);
                table5DetaliereCardProcessed.AddCell(cell43TxnVal);
                table5DetaliereCardProcessed.AddCell(cell44PPC);
                table5DetaliereCardProcessed.AddCell(cell45TxnCost);
                table5DetaliereCardProcessed.AddCell(cell46TVA);
                for (int i = 0; i < RowsNrForCardProcessed; i++)
                {
                    if (kCP >= 6 && kCP <= RowsNrForCardProcessed)
                    {

                        jCP++;
                        kCP = -1;
                    }
                    kCP++;
                    //MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select Descriptions, NrOfTxn, Chrg_Per_Item, TxnAmount,Chrg_Percentage, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode like 'C%' order by Descriptions asc";
                    DataTable dtDescriptionCardProcess = new DataTable();
                    SqlDataAdapter adapterDescriptionCardProcess = new SqlDataAdapter(command);
                    adapterDescriptionCardProcess.Fill(dtDescriptionCardProcess);
                    string descriptionCPmNegativ = dtDescriptionCardProcess.Rows[jCP][3].ToString();
                    if (int.Parse(descriptionCPmNegativ) < 0 && kCP == 4)
                    {
                        string descriptionCP = "-"+dtDescriptionCardProcess.Rows[jCP][kCP].ToString() + "%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionCP, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table5DetaliereCardProcessed.AddCell(cell);
                    }
                    else if(kCP == 4 || kCP == 6)
                    {
                        string descriptionCP = dtDescriptionCardProcess.Rows[jCP][kCP].ToString()+"%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionCP, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table5DetaliereCardProcessed.AddCell(cell);
                    }
                    else
                    {
                        string descriptionCP = dtDescriptionCardProcess.Rows[jCP][kCP].ToString();
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionCP, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table5DetaliereCardProcessed.AddCell(cell);
                    }
                }
                for (int i = 0; i < 7; i++)
                {                ///MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select ChrgCode, NrOfTxn, Chrg_Per_Item, TxnAmount,Chrg_Percentage, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode ='Total CardProcessed'";
                    DataTable dtDescriptionTotalCardAcq = new DataTable();
                    SqlDataAdapter adapterDescriptionTotalCardAcq = new SqlDataAdapter(command);
                    adapterDescriptionTotalCardAcq.Fill(dtDescriptionTotalCardAcq);
                    string descriptionTotCAcq = dtDescriptionTotalCardAcq.Rows[0][i].ToString();
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Paragraph(descriptionTotCAcq, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    cell.Border = Rectangle.BOTTOM_BORDER;
                    table5DetaliereCardProcessed.AddCell(cell);
                }
                // PREMIUM
                PdfPTable table6DetalierePremium = new PdfPTable(7);
                table6DetalierePremium.HorizontalAlignment = 1;
                table6DetalierePremium.TotalWidth = 500f;
                table6DetalierePremium.LockedWidth = true;
                float[] widthsP = new float[] { 195f, 45f, 60f, 60f, 60f, 60f, 30f };
                table6DetalierePremium.SetWidths(widthsP);
                PdfPCell cell60HeadPrem = new PdfPCell();
                cell60HeadPrem.AddElement(new Paragraph("Costuri Premium        ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                cell60HeadPrem.Border = Rectangle.BOTTOM_BORDER;


                table6DetalierePremium.AddCell(cell60HeadPrem);
                table6DetalierePremium.AddCell(cell41HeadNrOfTxn);
                table6DetalierePremium.AddCell(cell42PPI);
                table6DetalierePremium.AddCell(cell43TxnVal);
                table6DetalierePremium.AddCell(cell44PPC);
                table6DetalierePremium.AddCell(cell45TxnCost);
                table6DetalierePremium.AddCell(cell46TVA);
                for (int i = 0; i < RowsNrForPremium; i++)
                {
                    if (kPrem >= 6 && kPrem <= RowsNrForPremium)
                    {

                        jPrem++;
                        kPrem = -1;
                    }
                    kPrem++;
                    //MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select Descriptions, NrOfTxn, Chrg_Per_Item, TxnAmount, Chrg_Percentage, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode like 'P%' order by Descriptions asc";
                    DataTable dtDescriptionPremium = new DataTable();
                    SqlDataAdapter adapterDescriptionPremium = new SqlDataAdapter(command);
                    adapterDescriptionPremium.Fill(dtDescriptionPremium);
                    string descriptionPremNegativ = dtDescriptionPremium.Rows[jPrem][3].ToString();
                        if (int.Parse(descriptionPremNegativ) < 0 && kPrem ==4)
                    {
                        string descriptionPrem = "-"+dtDescriptionPremium.Rows[jPrem][kPrem].ToString() + "%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionPrem, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table6DetalierePremium.AddCell(cell);
                    }
                    else if ( kPrem == 4 || kPrem == 6)
                    {
                        string descriptionPrem = dtDescriptionPremium.Rows[jPrem][kPrem].ToString()+"%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionPrem, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table6DetalierePremium.AddCell(cell);
                    }
                    else
                    {
                        string descriptionPrem = dtDescriptionPremium.Rows[jPrem][kPrem].ToString();
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionPrem, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table6DetalierePremium.AddCell(cell);
                    }
                }
                for (int i = 0; i < 7; i++)
                {                ///MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select ChrgCode, NrOfTxn, Chrg_Per_Item, TxnAmount,Chrg_Percentage, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode ='Total Premium'";
                    DataTable dtDescriptionTotalCardAcq = new DataTable();
                    SqlDataAdapter adapterDescriptionTotalCardAcq = new SqlDataAdapter(command);
                    adapterDescriptionTotalCardAcq.Fill(dtDescriptionTotalCardAcq);
                    string descriptionTotCAcq = dtDescriptionTotalCardAcq.Rows[0][i].ToString();
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Paragraph(descriptionTotCAcq, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    cell.Border = Rectangle.BOTTOM_BORDER;
                    table6DetalierePremium.AddCell(cell);
                }

                // MISCELLANEOUS
                PdfPTable table7DetaliereMiscellaneous = new PdfPTable(5);
                table7DetaliereMiscellaneous.HorizontalAlignment = 1;
                table7DetaliereMiscellaneous.TotalWidth = 500f;
                table7DetaliereMiscellaneous.LockedWidth = true;
                float[] widthsM = new float[] { 285f, 65f, 60f, 60f, 30f };
                table7DetaliereMiscellaneous.SetWidths(widthsM);
                PdfPCell cell70HeadMis = new PdfPCell();
                cell70HeadMis.AddElement(new Paragraph("Costuri Miscellaneous        ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                cell70HeadMis.Border = Rectangle.BOTTOM_BORDER;


                table7DetaliereMiscellaneous.AddCell(cell70HeadMis);
                table7DetaliereMiscellaneous.AddCell(cell41HeadNrOfTxn);
                table7DetaliereMiscellaneous.AddCell(cell43TxnVal);
                table7DetaliereMiscellaneous.AddCell(cell45TxnCost);
                table7DetaliereMiscellaneous.AddCell(cell46TVA);
                for (int i = 0; i < RowsNrForMis; i++)
                {
                    if (kMis >= 4 && kMis <= RowsNrForMis)
                    {

                        jMis++;
                        kMis = -1;
                    }
                    kMis++;
                    //MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select Descriptions, NrOfTxn, Chrg_Per_Item, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode like 'M%' order by Descriptions asc";
                    DataTable dtDescriptionMis = new DataTable();
                    SqlDataAdapter adapterDescriptionMis = new SqlDataAdapter(command);
                    adapterDescriptionMis.Fill(dtDescriptionMis);
                    if (kMis == 4)
                    {
                        string descriptionMis = dtDescriptionMis.Rows[jMis][kMis].ToString() + "%";
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionMis, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table7DetaliereMiscellaneous.AddCell(cell);
                    }
                    else
                    {
                        string descriptionMis = dtDescriptionMis.Rows[jMis][kMis].ToString();
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Paragraph(descriptionMis, FontFactory.GetFont("Arial", 8)));
                        cell.Border = Rectangle.BOTTOM_BORDER;
                        table7DetaliereMiscellaneous.AddCell(cell);
                    }

                }
                for (int i = 0; i < 5; i++)
                {                ///MessageBox.Show("i=" + i + ", j=" + j + ", k=" + k);
                    command.CommandText = "select ChrgCode, NrOfTxn, TxnAmount, CHRGAmount, TVA from InvoiceDataUNIONALL where ChrgCode ='Total Miscellaneous'";
                    DataTable dtDescriptionTotalMis = new DataTable();
                    SqlDataAdapter adapterDescriptionTotalMis = new SqlDataAdapter(command);
                    adapterDescriptionTotalMis.Fill(dtDescriptionTotalMis);
                    string descriptionTotMis = dtDescriptionTotalMis.Rows[0][i].ToString();
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Paragraph(descriptionTotMis, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    cell.Border = Rectangle.BOTTOM_BORDER;
                    table7DetaliereMiscellaneous.AddCell(cell);
                }
                PdfPTable table8HeadTotalTranzactionat = new PdfPTable(1);
                table8HeadTotalTranzactionat.WidthPercentage = 90;
                PdfPCell cell7 = new PdfPCell();
                cell7.AddElement(new Paragraph("\n\n Total Tranzactionat", FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.BOLD)));
                cell7.Border = Rectangle.BOTTOM_BORDER;
                table8HeadTotalTranzactionat.AddCell(cell7);

                PdfPTable table9TotalTranzactionat = new PdfPTable(2);
                table9TotalTranzactionat.WidthPercentage = 90;
                PdfPCell cell7TotTxnData = new PdfPCell();
                cell7TotTxnData.AddElement(new Paragraph("Perioada tranzactionare", FontFactory.GetFont("Arial", 9)));
                cell7TotTxnData.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cellBatchTotalAmount = new PdfPCell();
                cellBatchTotalAmount.AddElement(new Paragraph("Total suma tranzactionata", FontFactory.GetFont("Arial", 9)));
                cellBatchTotalAmount.Border = Rectangle.BOTTOM_BORDER;

                table9TotalTranzactionat.AddCell(cell7TotTxnData);
                table9TotalTranzactionat.AddCell(cellBatchTotalAmount);

                PdfPTable table10TotalSumTranzactionat = new PdfPTable(2);
                table10TotalSumTranzactionat.WidthPercentage = 90;
                PdfPCell cell10TotTxnDataFromTo = new PdfPCell();
                cell10TotTxnDataFromTo.AddElement(new Paragraph((datamin + " - " + datamax), FontFactory.GetFont("Arial", 9)));
                cell10TotTxnDataFromTo.Border = Rectangle.BOTTOM_BORDER;
                PdfPCell cell10BatchTotalAmount = new PdfPCell();
                if (String.IsNullOrEmpty(batchTotals))
                {
                    cell10BatchTotalAmount.AddElement(new Paragraph("0" + settlementCurrency, FontFactory.GetFont("Arial", 9)));
                }
                else
                {
                    cell10BatchTotalAmount.AddElement(new Paragraph(batchTotals + settlementCurrency, FontFactory.GetFont("Arial", 9,iTextSharp.text.Font.BOLD)));
                }
                cell10BatchTotalAmount.Border = Rectangle.BOTTOM_BORDER;

                table10TotalSumTranzactionat.AddCell(cell10TotTxnDataFromTo);
                table10TotalSumTranzactionat.AddCell(cell10BatchTotalAmount);

                doc.Add(table1Sumar);
                doc.Add(table2SumarCosturi);
                doc.Add(table3HeadDetaliiCost);
                doc.Add(table4DetaliereCardAcq);
                doc.Add(tablegol);
                doc.Add(table5DetaliereCardProcessed);
                doc.Add(tablegol);
                doc.Add(table6DetalierePremium);
                doc.Add(tablegol);
                doc.Add(table7DetaliereMiscellaneous);
                doc.Add(tablegol);
                doc.Add(table8HeadTotalTranzactionat);
                doc.Add(table9TotalTranzactionat);
                doc.Add(table10TotalSumTranzactionat);
                doc.Close();
            }
        }

        private void timerMerchant_Tick(object sender, EventArgs e)
        {
            SqlCommand commandCount = new SqlCommand();
            commandCount.Connection = conn;
            commandCount.CommandText = "select count(Event_id) from TransactionProcessings";
            DataTable dtCountTxn = new DataTable();
            SqlDataAdapter adapterCountTxn = new SqlDataAdapter(commandCount);
            adapterCountTxn.Fill(dtCountTxn);
            int countTxn = int.Parse((dtCountTxn.Rows[0][0].ToString()));

            if (countTxn == 0)
            {
                if (isMerchantPanelOpen)
                {
                    panelMerchant.Height -= 20;
                    if (panelMerchant.Height == 0)
                    {
                        timerMerchant.Stop();
                        isMerchantPanelOpen = true;
                    }
                }
                else if (!isMerchantPanelOpen)
                {
                    panelMerchant.Height += 20;
                    if (panelMerchant.Height == 80)
                    {
                        timerMerchant.Stop();
                        isMerchantPanelOpen = true;
                    }
                }
            }
            else
                isMerchantPanelOpen = false;
        }


/*
       private void labelMerchant_Click(object sender, EventArgs e)
        {
            SqlCommand commandCount = new SqlCommand();
            commandCount.Connection = conn;
            commandCount.CommandText = "select count(Event_id) from TransactionProcessings";
            DataTable dtCountTxn = new DataTable();
            SqlDataAdapter adapterCountTxn = new SqlDataAdapter(commandCount);
            adapterCountTxn.Fill(dtCountTxn);
            int countTxn = int.Parse((dtCountTxn.Rows[0][0].ToString()));

            

            if (countTxn == 0)
            {
                labelMerchant.Text = labelMerchant.Text;
                isMerchantPanelOpen = false;
            }
            else
            {
                SqlCommand commandMerchantName = new SqlCommand();
                commandMerchantName.Connection = conn;
                commandMerchantName.CommandText = "select distinct Merchant_id from TransactionProcessings";
                DataTable dtMerchantName = new DataTable();
                SqlDataAdapter adapterMerchantName = new SqlDataAdapter(commandMerchantName);
                adapterMerchantName.Fill(dtMerchantName);
                string merchantName = dtMerchantName.Rows[0][0].ToString();
                labelMerchant.Text = merchantName.ToString();
                isMerchantPanelOpen = true;
                MessageBox.Show(merchantName.ToString() + " merchant is already started a trade.\nIn this case it will be automatically set and it will remain the same until the data will be Refreshed an Cleared");
                 
            }
            timerMerchant.Start();
        }

   */    
        private void labelTarom_Click(object sender, EventArgs e)
        {
            labelMerchant.Text = labelTarom.Text;
            //textBox3Locality.Text = ((int)enumLocality.Intra_regional).ToString();
            labelMerchant.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerMerchant.Start();
        }

        private void labelTessco_Click(object sender, EventArgs e)
        {
            labelMerchant.Text = labelTessco.Text;
            //textBox3Locality.Text = ((int)enumLocality.Intra_regional).ToString();
            labelMerchant.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerMerchant.Start();
        }

        private void labelAuchan_Click(object sender, EventArgs e)
        {
            labelMerchant.Text = labelAuchan.Text;
            //textBox3Locality.Text = ((int)enumLocality.Intra_regional).ToString();
            labelMerchant.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            timerMerchant.Start();
        }
    }
}
