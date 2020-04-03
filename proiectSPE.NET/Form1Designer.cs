using com.google.protobuf;
using com.sun.org.glassfish.gmbal;
using java.beans;
using nu.xom;
using org.relaxng.datatype;
using QuickGraph.Serialization.DirectedGraphML;
using System;
using System.Reflection.Emit;
using static java.util.Locale;

namespace ruben1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AcquiredCheckBox = new System.Windows.Forms.CheckBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.localityLabel = new System.Windows.Forms.Label();
            this.authorisedCheckBox = new System.Windows.Forms.CheckBox();
            this.captureMethodeLabel = new System.Windows.Forms.Label();
            this.schemaLabel = new System.Windows.Forms.Label();
            this.TransactionTypeLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.panelTxnType = new System.Windows.Forms.Panel();
            this.quasyCashLabel = new System.Windows.Forms.Label();
            this.octLabel = new System.Windows.Forms.Label();
            this.cashAdvanceLabel = new System.Windows.Forms.Label();
            this.pwcbLabel = new System.Windows.Forms.Label();
            this.refundLabel = new System.Windows.Forms.Label();
            this.purchaseLabel = new System.Windows.Forms.Label();
            this.panelSchemeForAcquired = new System.Windows.Forms.Panel();
            this.visaBusinessLabel = new System.Windows.Forms.Label();
            this.masterCardBusinessLabel = new System.Windows.Forms.Label();
            this.labelDinersDiscoverAcquired = new System.Windows.Forms.Label();
            this.jcbLabel = new System.Windows.Forms.Label();
            this.debitMasterCardPerIntLabel = new System.Windows.Forms.Label();
            this.maestroComLabel = new System.Windows.Forms.Label();
            this.masterCardCrPerLabel = new System.Windows.Forms.Label();
            this.visaDrPerIntLabel = new System.Windows.Forms.Label();
            this.visaDrComIntlLabel = new System.Windows.Forms.Label();
            this.visaCorporateLabel = new System.Windows.Forms.Label();
            this.visaCommerceLabel = new System.Windows.Forms.Label();
            this.visaCreditPersonalLabel = new System.Windows.Forms.Label();
            this.panelSchemaForProcessed = new System.Windows.Forms.Panel();
            this.labelDinersDiscoverdProcessed = new System.Windows.Forms.Label();
            this.labelAmericanExpress = new System.Windows.Forms.Label();
            this.panelCaptureMethode = new System.Windows.Forms.Panel();
            this.offlinePinLabel = new System.Windows.Forms.Label();
            this.motoSecureLabel = new System.Windows.Forms.Label();
            this.panKeyEntryLabel = new System.Windows.Forms.Label();
            this.onlineChipLabel = new System.Windows.Forms.Label();
            this.eCommerceLabel = new System.Windows.Forms.Label();
            this.magneticStripeLabel = new System.Windows.Forms.Label();
            this.contactlessLabel = new System.Windows.Forms.Label();
            this.panelLocality = new System.Windows.Forms.Panel();
            this.interRegionalLabel = new System.Windows.Forms.Label();
            this.domesticLabel = new System.Windows.Forms.Label();
            this.intraRegionalLabel = new System.Windows.Forms.Label();
            this.timerTxnType = new System.Windows.Forms.Timer(this.components);
            this.timerSchema = new System.Windows.Forms.Timer(this.components);
            this.timerCaptureMethode = new System.Windows.Forms.Timer(this.components);
            this.timerLocality = new System.Windows.Forms.Timer(this.components);
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panelErrorMsgBox = new System.Windows.Forms.Panel();
            this.buttonErrMsgBoxOK = new System.Windows.Forms.Button();
            this.labelErrMsgBox = new System.Windows.Forms.Label();
            this.textBox1Nr = new System.Windows.Forms.TextBox();
            this.textBox1Acquired_Processed = new System.Windows.Forms.TextBox();
            this.textBox1TxnType = new System.Windows.Forms.TextBox();
            this.textBox1Schema = new System.Windows.Forms.TextBox();
            this.textBox1Auth_NotAuth = new System.Windows.Forms.TextBox();
            this.textBox1CaptureMethode = new System.Windows.Forms.TextBox();
            this.textBox1Locality = new System.Windows.Forms.TextBox();
            this.textBox1Amount = new System.Windows.Forms.TextBox();
            this.textBox2Amount = new System.Windows.Forms.TextBox();
            this.textBox2Locality = new System.Windows.Forms.TextBox();
            this.textBox2CaptureMethode = new System.Windows.Forms.TextBox();
            this.textBox2Auth_NotAuth = new System.Windows.Forms.TextBox();
            this.textBox2Schema = new System.Windows.Forms.TextBox();
            this.textBox2TxnType = new System.Windows.Forms.TextBox();
            this.textBox2Acquired = new System.Windows.Forms.TextBox();
            this.textBox2Nr = new System.Windows.Forms.TextBox();
            this.textBox3Amount = new System.Windows.Forms.TextBox();
            this.textBox3Locality = new System.Windows.Forms.TextBox();
            this.textBox3CaptureMethode = new System.Windows.Forms.TextBox();
            this.textBox3Auth_NotAuth = new System.Windows.Forms.TextBox();
            this.textBox3Schema = new System.Windows.Forms.TextBox();
            this.textBox3TxnType = new System.Windows.Forms.TextBox();
            this.textBox3Acquired = new System.Windows.Forms.TextBox();
            this.textBox3Nr = new System.Windows.Forms.TextBox();
            this.textBox4Amount = new System.Windows.Forms.TextBox();
            this.textBox4Locality = new System.Windows.Forms.TextBox();
            this.textBox4CaptureMethode = new System.Windows.Forms.TextBox();
            this.textBox4Auth_NotAuth = new System.Windows.Forms.TextBox();
            this.textBox4Schema = new System.Windows.Forms.TextBox();
            this.textBox4TxnType = new System.Windows.Forms.TextBox();
            this.textBox4Acquired = new System.Windows.Forms.TextBox();
            this.textBox4Nr = new System.Windows.Forms.TextBox();
            this.panelDashbordTxn = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelTxnType.SuspendLayout();
            this.panelSchemeForAcquired.SuspendLayout();
            this.panelSchemaForProcessed.SuspendLayout();
            this.panelCaptureMethode.SuspendLayout();
            this.panelLocality.SuspendLayout();
            this.panelErrorMsgBox.SuspendLayout();
            this.panelDashbordTxn.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcquiredCheckBox
            // 
            this.AcquiredCheckBox.AutoSize = true;
            this.AcquiredCheckBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AcquiredCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcquiredCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AcquiredCheckBox.Location = new System.Drawing.Point(12, 9);
            this.AcquiredCheckBox.Name = "AcquiredCheckBox";
            this.AcquiredCheckBox.Size = new System.Drawing.Size(105, 24);
            this.AcquiredCheckBox.TabIndex = 2;
            this.AcquiredCheckBox.Text = "Acquired";
            this.AcquiredCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AcquiredCheckBox.UseVisualStyleBackColor = false;
            this.AcquiredCheckBox.CheckedChanged += new System.EventHandler(this.checkBoxAcquired_CheckedChanged);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelMenu.Controls.Add(this.amountTextBox);
            this.panelMenu.Controls.Add(this.amountLabel);
            this.panelMenu.Controls.Add(this.localityLabel);
            this.panelMenu.Controls.Add(this.authorisedCheckBox);
            this.panelMenu.Controls.Add(this.captureMethodeLabel);
            this.panelMenu.Controls.Add(this.schemaLabel);
            this.panelMenu.Controls.Add(this.TransactionTypeLabel);
            this.panelMenu.Controls.Add(this.AcquiredCheckBox);
            this.panelMenu.Location = new System.Drawing.Point(12, 12);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1399, 45);
            this.panelMenu.TabIndex = 3;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(1252, 11);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(138, 22);
            this.amountTextBox.TabIndex = 9;
            this.amountTextBox.Text = "0";
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.amountLabel.Location = new System.Drawing.Point(1174, 10);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(72, 20);
            this.amountLabel.TabIndex = 8;
            this.amountLabel.Text = "Amount";
            this.amountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.amountLabel.Click += new System.EventHandler(this.amountLabel_Click);
            // 
            // localityLabel
            // 
            this.localityLabel.AutoSize = true;
            this.localityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localityLabel.ForeColor = System.Drawing.Color.Aqua;
            this.localityLabel.Location = new System.Drawing.Point(1006, 10);
            this.localityLabel.Name = "localityLabel";
            this.localityLabel.Size = new System.Drawing.Size(75, 20);
            this.localityLabel.TabIndex = 7;
            this.localityLabel.Text = "Locality";
            this.localityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.localityLabel.Click += new System.EventHandler(this.localityLabel_Click);
            // 
            // authorisedCheckBox
            // 
            this.authorisedCheckBox.AutoSize = true;
            this.authorisedCheckBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.authorisedCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorisedCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.authorisedCheckBox.Location = new System.Drawing.Point(657, 10);
            this.authorisedCheckBox.Name = "authorisedCheckBox";
            this.authorisedCheckBox.Size = new System.Drawing.Size(121, 24);
            this.authorisedCheckBox.TabIndex = 6;
            this.authorisedCheckBox.Text = "Authorised";
            this.authorisedCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.authorisedCheckBox.UseVisualStyleBackColor = false;
            this.authorisedCheckBox.CheckedChanged += new System.EventHandler(this.checkBoxAuthorised_CheckedChanged);
            // 
            // captureMethodeLabel
            // 
            this.captureMethodeLabel.AutoSize = true;
            this.captureMethodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureMethodeLabel.ForeColor = System.Drawing.Color.Aqua;
            this.captureMethodeLabel.Location = new System.Drawing.Point(808, 10);
            this.captureMethodeLabel.Name = "captureMethodeLabel";
            this.captureMethodeLabel.Size = new System.Drawing.Size(152, 20);
            this.captureMethodeLabel.TabIndex = 5;
            this.captureMethodeLabel.Text = "Capture Methode";
            this.captureMethodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.captureMethodeLabel.Click += new System.EventHandler(this.captureMethodeLabel_Click);
            // 
            // schemaLabel
            // 
            this.schemaLabel.AutoSize = true;
            this.schemaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schemaLabel.ForeColor = System.Drawing.Color.Aqua;
            this.schemaLabel.Location = new System.Drawing.Point(386, 10);
            this.schemaLabel.Name = "schemaLabel";
            this.schemaLabel.Size = new System.Drawing.Size(76, 20);
            this.schemaLabel.TabIndex = 4;
            this.schemaLabel.Text = "Schema";
            this.schemaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.schemaLabel.Click += new System.EventHandler(this.schemaLabel_Click);
            // 
            // TransactionTypeLabel
            // 
            this.TransactionTypeLabel.AutoSize = true;
            this.TransactionTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionTypeLabel.ForeColor = System.Drawing.Color.Aqua;
            this.TransactionTypeLabel.Location = new System.Drawing.Point(178, 10);
            this.TransactionTypeLabel.Name = "TransactionTypeLabel";
            this.TransactionTypeLabel.Size = new System.Drawing.Size(154, 20);
            this.TransactionTypeLabel.TabIndex = 3;
            this.TransactionTypeLabel.Text = "Transaction Type";
            this.TransactionTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TransactionTypeLabel.Click += new System.EventHandler(this.TransactionTypeLabel_Click);
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(1264, 69);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(138, 32);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // panelTxnType
            // 
            this.panelTxnType.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelTxnType.Controls.Add(this.quasyCashLabel);
            this.panelTxnType.Controls.Add(this.octLabel);
            this.panelTxnType.Controls.Add(this.cashAdvanceLabel);
            this.panelTxnType.Controls.Add(this.pwcbLabel);
            this.panelTxnType.Controls.Add(this.refundLabel);
            this.panelTxnType.Controls.Add(this.purchaseLabel);
            this.panelTxnType.Location = new System.Drawing.Point(192, 55);
            this.panelTxnType.Name = "panelTxnType";
            this.panelTxnType.Size = new System.Drawing.Size(132, 0);
            this.panelTxnType.TabIndex = 5;
            this.panelTxnType.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // quasyCashLabel
            // 
            this.quasyCashLabel.AutoSize = true;
            this.quasyCashLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.quasyCashLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quasyCashLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.quasyCashLabel.Location = new System.Drawing.Point(3, 100);
            this.quasyCashLabel.Name = "quasyCashLabel";
            this.quasyCashLabel.Size = new System.Drawing.Size(102, 20);
            this.quasyCashLabel.TabIndex = 9;
            this.quasyCashLabel.Text = "Quasy Cash";
            this.quasyCashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quasyCashLabel.Click += new System.EventHandler(this.quasyCashLabel_Click);
            // 
            // octLabel
            // 
            this.octLabel.AutoSize = true;
            this.octLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.octLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.octLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.octLabel.Location = new System.Drawing.Point(3, 80);
            this.octLabel.Name = "octLabel";
            this.octLabel.Size = new System.Drawing.Size(44, 20);
            this.octLabel.TabIndex = 8;
            this.octLabel.Text = "OCT";
            this.octLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.octLabel.Click += new System.EventHandler(this.octLabel_Click);
            // 
            // cashAdvanceLabel
            // 
            this.cashAdvanceLabel.AutoSize = true;
            this.cashAdvanceLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cashAdvanceLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAdvanceLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cashAdvanceLabel.Location = new System.Drawing.Point(3, 60);
            this.cashAdvanceLabel.Name = "cashAdvanceLabel";
            this.cashAdvanceLabel.Size = new System.Drawing.Size(118, 20);
            this.cashAdvanceLabel.TabIndex = 7;
            this.cashAdvanceLabel.Text = "Cash Advance";
            this.cashAdvanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cashAdvanceLabel.Click += new System.EventHandler(this.cashAdvanceLabel_Click);
            // 
            // pwcbLabel
            // 
            this.pwcbLabel.AutoSize = true;
            this.pwcbLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pwcbLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwcbLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pwcbLabel.Location = new System.Drawing.Point(3, 40);
            this.pwcbLabel.Name = "pwcbLabel";
            this.pwcbLabel.Size = new System.Drawing.Size(58, 20);
            this.pwcbLabel.TabIndex = 6;
            this.pwcbLabel.Text = "PWCB";
            this.pwcbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pwcbLabel.Click += new System.EventHandler(this.pwcbLabel_Click);
            // 
            // refundLabel
            // 
            this.refundLabel.AutoSize = true;
            this.refundLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.refundLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refundLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.refundLabel.Location = new System.Drawing.Point(3, 20);
            this.refundLabel.Name = "refundLabel";
            this.refundLabel.Size = new System.Drawing.Size(62, 20);
            this.refundLabel.TabIndex = 5;
            this.refundLabel.Text = "Refund";
            this.refundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refundLabel.Click += new System.EventHandler(this.refundLabel_Click);
            // 
            // purchaseLabel
            // 
            this.purchaseLabel.AutoSize = true;
            this.purchaseLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.purchaseLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.purchaseLabel.Location = new System.Drawing.Point(3, 0);
            this.purchaseLabel.Name = "purchaseLabel";
            this.purchaseLabel.Size = new System.Drawing.Size(80, 20);
            this.purchaseLabel.TabIndex = 4;
            this.purchaseLabel.Text = "Purchase";
            this.purchaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.purchaseLabel.Click += new System.EventHandler(this.purchaseLabel_Click);
            // 
            // panelSchemeForAcquired
            // 
            this.panelSchemeForAcquired.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelSchemeForAcquired.Controls.Add(this.visaBusinessLabel);
            this.panelSchemeForAcquired.Controls.Add(this.masterCardBusinessLabel);
            this.panelSchemeForAcquired.Controls.Add(this.labelDinersDiscoverAcquired);
            this.panelSchemeForAcquired.Controls.Add(this.jcbLabel);
            this.panelSchemeForAcquired.Controls.Add(this.debitMasterCardPerIntLabel);
            this.panelSchemeForAcquired.Controls.Add(this.maestroComLabel);
            this.panelSchemeForAcquired.Controls.Add(this.masterCardCrPerLabel);
            this.panelSchemeForAcquired.Controls.Add(this.visaDrPerIntLabel);
            this.panelSchemeForAcquired.Controls.Add(this.visaDrComIntlLabel);
            this.panelSchemeForAcquired.Controls.Add(this.visaCorporateLabel);
            this.panelSchemeForAcquired.Controls.Add(this.visaCommerceLabel);
            this.panelSchemeForAcquired.Controls.Add(this.visaCreditPersonalLabel);
            this.panelSchemeForAcquired.Location = new System.Drawing.Point(390, 55);
            this.panelSchemeForAcquired.Name = "panelSchemeForAcquired";
            this.panelSchemeForAcquired.Size = new System.Drawing.Size(225, 0);
            this.panelSchemeForAcquired.TabIndex = 6;
            this.panelSchemeForAcquired.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // visaBusinessLabel
            // 
            this.visaBusinessLabel.AutoSize = true;
            this.visaBusinessLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visaBusinessLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visaBusinessLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.visaBusinessLabel.Location = new System.Drawing.Point(3, 20);
            this.visaBusinessLabel.Name = "visaBusinessLabel";
            this.visaBusinessLabel.Size = new System.Drawing.Size(116, 20);
            this.visaBusinessLabel.TabIndex = 11;
            this.visaBusinessLabel.Text = "Visa Business";
            this.visaBusinessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visaBusinessLabel.Click += new System.EventHandler(this.visaBusinessLabel_Click);
            // 
            // masterCardBusinessLabel
            // 
            this.masterCardBusinessLabel.AutoSize = true;
            this.masterCardBusinessLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.masterCardBusinessLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterCardBusinessLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.masterCardBusinessLabel.Location = new System.Drawing.Point(3, 140);
            this.masterCardBusinessLabel.Name = "masterCardBusinessLabel";
            this.masterCardBusinessLabel.Size = new System.Drawing.Size(171, 20);
            this.masterCardBusinessLabel.TabIndex = 17;
            this.masterCardBusinessLabel.Text = "MasterCard Business";
            this.masterCardBusinessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.masterCardBusinessLabel.Click += new System.EventHandler(this.masterCardBusinessLabel_Click);
            // 
            // labelDinersDiscoverAcquired
            // 
            this.labelDinersDiscoverAcquired.AutoSize = true;
            this.labelDinersDiscoverAcquired.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDinersDiscoverAcquired.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDinersDiscoverAcquired.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelDinersDiscoverAcquired.Location = new System.Drawing.Point(3, 220);
            this.labelDinersDiscoverAcquired.Name = "labelDinersDiscoverAcquired";
            this.labelDinersDiscoverAcquired.Size = new System.Drawing.Size(130, 20);
            this.labelDinersDiscoverAcquired.TabIndex = 22;
            this.labelDinersDiscoverAcquired.Text = "Diners Discover";
            this.labelDinersDiscoverAcquired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDinersDiscoverAcquired.Click += new System.EventHandler(this.dinersDiscoverLabel_Click);
            // 
            // jcbLabel
            // 
            this.jcbLabel.AutoSize = true;
            this.jcbLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.jcbLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jcbLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.jcbLabel.Location = new System.Drawing.Point(4, 200);
            this.jcbLabel.Name = "jcbLabel";
            this.jcbLabel.Size = new System.Drawing.Size(41, 20);
            this.jcbLabel.TabIndex = 21;
            this.jcbLabel.Text = "JCB";
            this.jcbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.jcbLabel.Click += new System.EventHandler(this.jcbLabel_Click);
            // 
            // debitMasterCardPerIntLabel
            // 
            this.debitMasterCardPerIntLabel.AutoSize = true;
            this.debitMasterCardPerIntLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.debitMasterCardPerIntLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debitMasterCardPerIntLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.debitMasterCardPerIntLabel.Location = new System.Drawing.Point(3, 180);
            this.debitMasterCardPerIntLabel.Name = "debitMasterCardPerIntLabel";
            this.debitMasterCardPerIntLabel.Size = new System.Drawing.Size(195, 20);
            this.debitMasterCardPerIntLabel.TabIndex = 19;
            this.debitMasterCardPerIntLabel.Text = "Debit MasterCard Per Int";
            this.debitMasterCardPerIntLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.debitMasterCardPerIntLabel.Click += new System.EventHandler(this.debitMasterCardPerIntLabel_Click);
            // 
            // maestroComLabel
            // 
            this.maestroComLabel.AutoSize = true;
            this.maestroComLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.maestroComLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maestroComLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maestroComLabel.Location = new System.Drawing.Point(3, 160);
            this.maestroComLabel.Name = "maestroComLabel";
            this.maestroComLabel.Size = new System.Drawing.Size(110, 20);
            this.maestroComLabel.TabIndex = 18;
            this.maestroComLabel.Text = "Maestro Com";
            this.maestroComLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maestroComLabel.Click += new System.EventHandler(this.maestroComLabel_Click);
            // 
            // masterCardCrPerLabel
            // 
            this.masterCardCrPerLabel.AutoSize = true;
            this.masterCardCrPerLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.masterCardCrPerLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterCardCrPerLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.masterCardCrPerLabel.Location = new System.Drawing.Point(3, 120);
            this.masterCardCrPerLabel.Name = "masterCardCrPerLabel";
            this.masterCardCrPerLabel.Size = new System.Drawing.Size(151, 20);
            this.masterCardCrPerLabel.TabIndex = 16;
            this.masterCardCrPerLabel.Text = "MasterCard Cr Per";
            this.masterCardCrPerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.masterCardCrPerLabel.Click += new System.EventHandler(this.masterCardCrPerLabel_Click);
            // 
            // visaDrPerIntLabel
            // 
            this.visaDrPerIntLabel.AutoSize = true;
            this.visaDrPerIntLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visaDrPerIntLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visaDrPerIntLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.visaDrPerIntLabel.Location = new System.Drawing.Point(3, 100);
            this.visaDrPerIntLabel.Name = "visaDrPerIntLabel";
            this.visaDrPerIntLabel.Size = new System.Drawing.Size(119, 20);
            this.visaDrPerIntLabel.TabIndex = 15;
            this.visaDrPerIntLabel.Text = "Visa Dr Per Int";
            this.visaDrPerIntLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visaDrPerIntLabel.Click += new System.EventHandler(this.visaDrPerIntLabel_Click);
            // 
            // visaDrComIntlLabel
            // 
            this.visaDrComIntlLabel.AutoSize = true;
            this.visaDrComIntlLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visaDrComIntlLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visaDrComIntlLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.visaDrComIntlLabel.Location = new System.Drawing.Point(3, 80);
            this.visaDrComIntlLabel.Name = "visaDrComIntlLabel";
            this.visaDrComIntlLabel.Size = new System.Drawing.Size(132, 20);
            this.visaDrComIntlLabel.TabIndex = 14;
            this.visaDrComIntlLabel.Text = "Visa Dr Com Intl";
            this.visaDrComIntlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visaDrComIntlLabel.Click += new System.EventHandler(this.visaDrComIntlLabel_Click);
            // 
            // visaCorporateLabel
            // 
            this.visaCorporateLabel.AutoSize = true;
            this.visaCorporateLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visaCorporateLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visaCorporateLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.visaCorporateLabel.Location = new System.Drawing.Point(3, 60);
            this.visaCorporateLabel.Name = "visaCorporateLabel";
            this.visaCorporateLabel.Size = new System.Drawing.Size(121, 20);
            this.visaCorporateLabel.TabIndex = 13;
            this.visaCorporateLabel.Text = "Visa Corporate";
            this.visaCorporateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visaCorporateLabel.Click += new System.EventHandler(this.visaCorporateLabel_Click);
            // 
            // visaCommerceLabel
            // 
            this.visaCommerceLabel.AutoSize = true;
            this.visaCommerceLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visaCommerceLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visaCommerceLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.visaCommerceLabel.Location = new System.Drawing.Point(3, 40);
            this.visaCommerceLabel.Name = "visaCommerceLabel";
            this.visaCommerceLabel.Size = new System.Drawing.Size(129, 20);
            this.visaCommerceLabel.TabIndex = 12;
            this.visaCommerceLabel.Text = "Visa Commerce";
            this.visaCommerceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visaCommerceLabel.Click += new System.EventHandler(this.visaCommerceLabel_Click);
            // 
            // visaCreditPersonalLabel
            // 
            this.visaCreditPersonalLabel.AutoSize = true;
            this.visaCreditPersonalLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.visaCreditPersonalLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visaCreditPersonalLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.visaCreditPersonalLabel.Location = new System.Drawing.Point(3, 0);
            this.visaCreditPersonalLabel.Name = "visaCreditPersonalLabel";
            this.visaCreditPersonalLabel.Size = new System.Drawing.Size(163, 20);
            this.visaCreditPersonalLabel.TabIndex = 10;
            this.visaCreditPersonalLabel.Text = "Visa Credit Personal";
            this.visaCreditPersonalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visaCreditPersonalLabel.Click += new System.EventHandler(this.visaCreditPersonalLabel_Click);
            // 
            // panelSchemaForProcessed
            // 
            this.panelSchemaForProcessed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelSchemaForProcessed.Controls.Add(this.labelDinersDiscoverdProcessed);
            this.panelSchemaForProcessed.Controls.Add(this.labelAmericanExpress);
            this.panelSchemaForProcessed.Location = new System.Drawing.Point(390, 55);
            this.panelSchemaForProcessed.Name = "panelSchemaForProcessed";
            this.panelSchemaForProcessed.Size = new System.Drawing.Size(170, 0);
            this.panelSchemaForProcessed.TabIndex = 23;
            this.panelSchemaForProcessed.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSchemaForProcessed_Paint);
            // 
            // labelDinersDiscoverdProcessed
            // 
            this.labelDinersDiscoverdProcessed.AutoSize = true;
            this.labelDinersDiscoverdProcessed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDinersDiscoverdProcessed.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDinersDiscoverdProcessed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelDinersDiscoverdProcessed.Location = new System.Drawing.Point(3, 23);
            this.labelDinersDiscoverdProcessed.Name = "labelDinersDiscoverdProcessed";
            this.labelDinersDiscoverdProcessed.Size = new System.Drawing.Size(130, 20);
            this.labelDinersDiscoverdProcessed.TabIndex = 22;
            this.labelDinersDiscoverdProcessed.Text = "Diners Discover";
            this.labelDinersDiscoverdProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDinersDiscoverdProcessed.Click += new System.EventHandler(this.labelDinersDiscoverdProcessed_Click);
            // 
            // labelAmericanExpress
            // 
            this.labelAmericanExpress.AutoSize = true;
            this.labelAmericanExpress.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAmericanExpress.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmericanExpress.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelAmericanExpress.Location = new System.Drawing.Point(3, 3);
            this.labelAmericanExpress.Name = "labelAmericanExpress";
            this.labelAmericanExpress.Size = new System.Drawing.Size(147, 20);
            this.labelAmericanExpress.TabIndex = 20;
            this.labelAmericanExpress.Text = "American Express";
            this.labelAmericanExpress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelAmericanExpress.Click += new System.EventHandler(this.labelAmericanExpress_Click);
            // 
            // panelCaptureMethode
            // 
            this.panelCaptureMethode.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelCaptureMethode.Controls.Add(this.offlinePinLabel);
            this.panelCaptureMethode.Controls.Add(this.motoSecureLabel);
            this.panelCaptureMethode.Controls.Add(this.panKeyEntryLabel);
            this.panelCaptureMethode.Controls.Add(this.onlineChipLabel);
            this.panelCaptureMethode.Controls.Add(this.eCommerceLabel);
            this.panelCaptureMethode.Controls.Add(this.magneticStripeLabel);
            this.panelCaptureMethode.Controls.Add(this.contactlessLabel);
            this.panelCaptureMethode.Location = new System.Drawing.Point(820, 55);
            this.panelCaptureMethode.Name = "panelCaptureMethode";
            this.panelCaptureMethode.Size = new System.Drawing.Size(148, 0);
            this.panelCaptureMethode.TabIndex = 7;
            this.panelCaptureMethode.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // offlinePinLabel
            // 
            this.offlinePinLabel.AutoSize = true;
            this.offlinePinLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.offlinePinLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offlinePinLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.offlinePinLabel.Location = new System.Drawing.Point(3, 60);
            this.offlinePinLabel.Name = "offlinePinLabel";
            this.offlinePinLabel.Size = new System.Drawing.Size(87, 20);
            this.offlinePinLabel.TabIndex = 13;
            this.offlinePinLabel.Text = "Offline Pin";
            this.offlinePinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.offlinePinLabel.Click += new System.EventHandler(this.offlinePinLabel_Click);
            // 
            // motoSecureLabel
            // 
            this.motoSecureLabel.AutoSize = true;
            this.motoSecureLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.motoSecureLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motoSecureLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.motoSecureLabel.Location = new System.Drawing.Point(3, 120);
            this.motoSecureLabel.Name = "motoSecureLabel";
            this.motoSecureLabel.Size = new System.Drawing.Size(115, 20);
            this.motoSecureLabel.TabIndex = 16;
            this.motoSecureLabel.Text = "MOTO secure";
            this.motoSecureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.motoSecureLabel.Click += new System.EventHandler(this.motoSecureLabel_Click);
            // 
            // panKeyEntryLabel
            // 
            this.panKeyEntryLabel.AutoSize = true;
            this.panKeyEntryLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panKeyEntryLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panKeyEntryLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panKeyEntryLabel.Location = new System.Drawing.Point(3, 100);
            this.panKeyEntryLabel.Name = "panKeyEntryLabel";
            this.panKeyEntryLabel.Size = new System.Drawing.Size(118, 20);
            this.panKeyEntryLabel.TabIndex = 15;
            this.panKeyEntryLabel.Text = "PAN key entry";
            this.panKeyEntryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.panKeyEntryLabel.Click += new System.EventHandler(this.panKeyEntryLabel_Click);
            // 
            // onlineChipLabel
            // 
            this.onlineChipLabel.AutoSize = true;
            this.onlineChipLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.onlineChipLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineChipLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.onlineChipLabel.Location = new System.Drawing.Point(3, 80);
            this.onlineChipLabel.Name = "onlineChipLabel";
            this.onlineChipLabel.Size = new System.Drawing.Size(96, 20);
            this.onlineChipLabel.TabIndex = 14;
            this.onlineChipLabel.Text = "Online Chip";
            this.onlineChipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onlineChipLabel.Click += new System.EventHandler(this.onlineChipLabel_Click);
            // 
            // eCommerceLabel
            // 
            this.eCommerceLabel.AutoSize = true;
            this.eCommerceLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.eCommerceLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eCommerceLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.eCommerceLabel.Location = new System.Drawing.Point(3, 40);
            this.eCommerceLabel.Name = "eCommerceLabel";
            this.eCommerceLabel.Size = new System.Drawing.Size(100, 20);
            this.eCommerceLabel.TabIndex = 12;
            this.eCommerceLabel.Text = "eCommerce";
            this.eCommerceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eCommerceLabel.Click += new System.EventHandler(this.eCommerceLabel_Click);
            // 
            // magneticStripeLabel
            // 
            this.magneticStripeLabel.AutoSize = true;
            this.magneticStripeLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.magneticStripeLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magneticStripeLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.magneticStripeLabel.Location = new System.Drawing.Point(3, 20);
            this.magneticStripeLabel.Name = "magneticStripeLabel";
            this.magneticStripeLabel.Size = new System.Drawing.Size(126, 20);
            this.magneticStripeLabel.TabIndex = 11;
            this.magneticStripeLabel.Text = "Magnetic Stripe";
            this.magneticStripeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.magneticStripeLabel.Click += new System.EventHandler(this.magneticStripeLabel_Click);
            // 
            // contactlessLabel
            // 
            this.contactlessLabel.AutoSize = true;
            this.contactlessLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.contactlessLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactlessLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.contactlessLabel.Location = new System.Drawing.Point(3, 0);
            this.contactlessLabel.Name = "contactlessLabel";
            this.contactlessLabel.Size = new System.Drawing.Size(98, 20);
            this.contactlessLabel.TabIndex = 10;
            this.contactlessLabel.Text = "Contactless";
            this.contactlessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contactlessLabel.Click += new System.EventHandler(this.contactlessLabel_Click);
            // 
            // panelLocality
            // 
            this.panelLocality.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLocality.Controls.Add(this.interRegionalLabel);
            this.panelLocality.Controls.Add(this.domesticLabel);
            this.panelLocality.Controls.Add(this.intraRegionalLabel);
            this.panelLocality.Location = new System.Drawing.Point(1010, 55);
            this.panelLocality.Name = "panelLocality";
            this.panelLocality.Size = new System.Drawing.Size(130, 0);
            this.panelLocality.TabIndex = 8;
            this.panelLocality.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // interRegionalLabel
            // 
            this.interRegionalLabel.AutoSize = true;
            this.interRegionalLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.interRegionalLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interRegionalLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.interRegionalLabel.Location = new System.Drawing.Point(3, 40);
            this.interRegionalLabel.Name = "interRegionalLabel";
            this.interRegionalLabel.Size = new System.Drawing.Size(107, 20);
            this.interRegionalLabel.TabIndex = 19;
            this.interRegionalLabel.Text = "Inter-regional";
            this.interRegionalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.interRegionalLabel.Click += new System.EventHandler(this.interRegionalLabel_Click);
            // 
            // domesticLabel
            // 
            this.domesticLabel.AutoSize = true;
            this.domesticLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.domesticLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domesticLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.domesticLabel.Location = new System.Drawing.Point(3, 20);
            this.domesticLabel.Name = "domesticLabel";
            this.domesticLabel.Size = new System.Drawing.Size(80, 20);
            this.domesticLabel.TabIndex = 18;
            this.domesticLabel.Text = "Domestic";
            this.domesticLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.domesticLabel.Click += new System.EventHandler(this.domesticLabel_Click);
            // 
            // intraRegionalLabel
            // 
            this.intraRegionalLabel.AutoSize = true;
            this.intraRegionalLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.intraRegionalLabel.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intraRegionalLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.intraRegionalLabel.Location = new System.Drawing.Point(3, 0);
            this.intraRegionalLabel.Name = "intraRegionalLabel";
            this.intraRegionalLabel.Size = new System.Drawing.Size(107, 20);
            this.intraRegionalLabel.TabIndex = 17;
            this.intraRegionalLabel.Text = "Intra-regional";
            this.intraRegionalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.intraRegionalLabel.Click += new System.EventHandler(this.intraRegionalLabel_Click);
            // 
            // timerTxnType
            // 
            this.timerTxnType.Interval = 20;
            this.timerTxnType.Tick += new System.EventHandler(this.timerTxnType_Tick);
            // 
            // timerSchema
            // 
            this.timerSchema.Interval = 20;
            this.timerSchema.Tick += new System.EventHandler(this.timerSchema_Tick);
            // 
            // timerCaptureMethode
            // 
            this.timerCaptureMethode.Interval = 20;
            this.timerCaptureMethode.Tick += new System.EventHandler(this.timerCaptureMethode_Tick);
            // 
            // timerLocality
            // 
            this.timerLocality.Interval = 20;
            this.timerLocality.Tick += new System.EventHandler(this.timerLocality_Tick);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(1264, 109);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(138, 32);
            this.buttonRefresh.TabIndex = 24;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panelErrorMsgBox
            // 
            this.panelErrorMsgBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelErrorMsgBox.Controls.Add(this.buttonErrMsgBoxOK);
            this.panelErrorMsgBox.Controls.Add(this.labelErrMsgBox);
            this.panelErrorMsgBox.Location = new System.Drawing.Point(511, 30);
            this.panelErrorMsgBox.Name = "panelErrorMsgBox";
            this.panelErrorMsgBox.Size = new System.Drawing.Size(0, 0);
            this.panelErrorMsgBox.TabIndex = 25;
            this.panelErrorMsgBox.Paint += new System.Windows.Forms.PaintEventHandler(this.panelErrorMsgBox_Paint);
            // 
            // buttonErrMsgBoxOK
            // 
            this.buttonErrMsgBoxOK.Location = new System.Drawing.Point(100, 24);
            this.buttonErrMsgBoxOK.Name = "buttonErrMsgBoxOK";
            this.buttonErrMsgBoxOK.Size = new System.Drawing.Size(100, 23);
            this.buttonErrMsgBoxOK.TabIndex = 1;
            this.buttonErrMsgBoxOK.Text = "OK";
            this.buttonErrMsgBoxOK.UseVisualStyleBackColor = true;
            this.buttonErrMsgBoxOK.Click += new System.EventHandler(this.buttonErrMsgBoxOK_Click);
            // 
            // labelErrMsgBox
            // 
            this.labelErrMsgBox.AutoSize = true;
            this.labelErrMsgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrMsgBox.Location = new System.Drawing.Point(12, 3);
            this.labelErrMsgBox.Name = "labelErrMsgBox";
            this.labelErrMsgBox.Size = new System.Drawing.Size(252, 18);
            this.labelErrMsgBox.TabIndex = 0;
            this.labelErrMsgBox.Text = "The combination is not possible!";
            this.labelErrMsgBox.Click += new System.EventHandler(this.labelErrMsgBox_Click);
            // 
            // textBox1Nr
            // 
            this.textBox1Nr.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1Nr.Location = new System.Drawing.Point(3, 8);
            this.textBox1Nr.Name = "textBox1Nr";
            this.textBox1Nr.Size = new System.Drawing.Size(49, 22);
            this.textBox1Nr.TabIndex = 28;
            this.textBox1Nr.Text = "Nr.";
            this.textBox1Nr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1Acquired_Processed
            // 
            this.textBox1Acquired_Processed.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1Acquired_Processed.Location = new System.Drawing.Point(49, 8);
            this.textBox1Acquired_Processed.Name = "textBox1Acquired_Processed";
            this.textBox1Acquired_Processed.Size = new System.Drawing.Size(145, 22);
            this.textBox1Acquired_Processed.TabIndex = 29;
            this.textBox1Acquired_Processed.Text = "Acquired/Processed";
            this.textBox1Acquired_Processed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1TxnType
            // 
            this.textBox1TxnType.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1TxnType.Location = new System.Drawing.Point(191, 8);
            this.textBox1TxnType.Name = "textBox1TxnType";
            this.textBox1TxnType.Size = new System.Drawing.Size(145, 22);
            this.textBox1TxnType.TabIndex = 30;
            this.textBox1TxnType.Text = "Transaction Type";
            this.textBox1TxnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1Schema
            // 
            this.textBox1Schema.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1Schema.Location = new System.Drawing.Point(332, 8);
            this.textBox1Schema.Name = "textBox1Schema";
            this.textBox1Schema.Size = new System.Drawing.Size(163, 22);
            this.textBox1Schema.TabIndex = 31;
            this.textBox1Schema.Text = "Schema";
            this.textBox1Schema.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1Auth_NotAuth
            // 
            this.textBox1Auth_NotAuth.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1Auth_NotAuth.Location = new System.Drawing.Point(491, 8);
            this.textBox1Auth_NotAuth.Name = "textBox1Auth_NotAuth";
            this.textBox1Auth_NotAuth.ReadOnly = true;
            this.textBox1Auth_NotAuth.Size = new System.Drawing.Size(176, 22);
            this.textBox1Auth_NotAuth.TabIndex = 32;
            this.textBox1Auth_NotAuth.Text = "Authorised/NotAuthorised";
            this.textBox1Auth_NotAuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1CaptureMethode
            // 
            this.textBox1CaptureMethode.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1CaptureMethode.Location = new System.Drawing.Point(661, 8);
            this.textBox1CaptureMethode.Name = "textBox1CaptureMethode";
            this.textBox1CaptureMethode.Size = new System.Drawing.Size(163, 22);
            this.textBox1CaptureMethode.TabIndex = 33;
            this.textBox1CaptureMethode.Text = "Capture Methode";
            this.textBox1CaptureMethode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1Locality
            // 
            this.textBox1Locality.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1Locality.Location = new System.Drawing.Point(819, 8);
            this.textBox1Locality.Name = "textBox1Locality";
            this.textBox1Locality.Size = new System.Drawing.Size(163, 22);
            this.textBox1Locality.TabIndex = 34;
            this.textBox1Locality.Text = "Locality";
            this.textBox1Locality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1Amount
            // 
            this.textBox1Amount.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1Amount.Location = new System.Drawing.Point(979, 8);
            this.textBox1Amount.Name = "textBox1Amount";
            this.textBox1Amount.Size = new System.Drawing.Size(153, 22);
            this.textBox1Amount.TabIndex = 35;
            this.textBox1Amount.Text = "Amount";
            this.textBox1Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2Amount
            // 
            this.textBox2Amount.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2Amount.Location = new System.Drawing.Point(979, 28);
            this.textBox2Amount.Name = "textBox2Amount";
            this.textBox2Amount.Size = new System.Drawing.Size(153, 22);
            this.textBox2Amount.TabIndex = 44;
            this.textBox2Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2Locality
            // 
            this.textBox2Locality.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2Locality.Location = new System.Drawing.Point(819, 28);
            this.textBox2Locality.Name = "textBox2Locality";
            this.textBox2Locality.Size = new System.Drawing.Size(163, 22);
            this.textBox2Locality.TabIndex = 43;
            this.textBox2Locality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2CaptureMethode
            // 
            this.textBox2CaptureMethode.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2CaptureMethode.Location = new System.Drawing.Point(661, 28);
            this.textBox2CaptureMethode.Name = "textBox2CaptureMethode";
            this.textBox2CaptureMethode.Size = new System.Drawing.Size(163, 22);
            this.textBox2CaptureMethode.TabIndex = 42;
            this.textBox2CaptureMethode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2Auth_NotAuth
            // 
            this.textBox2Auth_NotAuth.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2Auth_NotAuth.Location = new System.Drawing.Point(491, 28);
            this.textBox2Auth_NotAuth.Name = "textBox2Auth_NotAuth";
            this.textBox2Auth_NotAuth.ReadOnly = true;
            this.textBox2Auth_NotAuth.Size = new System.Drawing.Size(176, 22);
            this.textBox2Auth_NotAuth.TabIndex = 41;
            this.textBox2Auth_NotAuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2Schema
            // 
            this.textBox2Schema.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2Schema.Location = new System.Drawing.Point(332, 28);
            this.textBox2Schema.Name = "textBox2Schema";
            this.textBox2Schema.Size = new System.Drawing.Size(163, 22);
            this.textBox2Schema.TabIndex = 40;
            this.textBox2Schema.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2TxnType
            // 
            this.textBox2TxnType.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2TxnType.Location = new System.Drawing.Point(191, 28);
            this.textBox2TxnType.Name = "textBox2TxnType";
            this.textBox2TxnType.Size = new System.Drawing.Size(145, 22);
            this.textBox2TxnType.TabIndex = 39;
            this.textBox2TxnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2Acquired
            // 
            this.textBox2Acquired.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2Acquired.Location = new System.Drawing.Point(49, 28);
            this.textBox2Acquired.Name = "textBox2Acquired";
            this.textBox2Acquired.Size = new System.Drawing.Size(145, 22);
            this.textBox2Acquired.TabIndex = 38;
            this.textBox2Acquired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2Nr
            // 
            this.textBox2Nr.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2Nr.Location = new System.Drawing.Point(3, 28);
            this.textBox2Nr.Name = "textBox2Nr";
            this.textBox2Nr.Size = new System.Drawing.Size(49, 22);
            this.textBox2Nr.TabIndex = 37;
            this.textBox2Nr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3Amount
            // 
            this.textBox3Amount.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3Amount.Location = new System.Drawing.Point(979, 48);
            this.textBox3Amount.Name = "textBox3Amount";
            this.textBox3Amount.Size = new System.Drawing.Size(153, 22);
            this.textBox3Amount.TabIndex = 52;
            this.textBox3Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3Locality
            // 
            this.textBox3Locality.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3Locality.Location = new System.Drawing.Point(819, 48);
            this.textBox3Locality.Name = "textBox3Locality";
            this.textBox3Locality.Size = new System.Drawing.Size(163, 22);
            this.textBox3Locality.TabIndex = 51;
            this.textBox3Locality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3CaptureMethode
            // 
            this.textBox3CaptureMethode.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3CaptureMethode.Location = new System.Drawing.Point(661, 48);
            this.textBox3CaptureMethode.Name = "textBox3CaptureMethode";
            this.textBox3CaptureMethode.Size = new System.Drawing.Size(163, 22);
            this.textBox3CaptureMethode.TabIndex = 50;
            this.textBox3CaptureMethode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3Auth_NotAuth
            // 
            this.textBox3Auth_NotAuth.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3Auth_NotAuth.Location = new System.Drawing.Point(491, 48);
            this.textBox3Auth_NotAuth.Name = "textBox3Auth_NotAuth";
            this.textBox3Auth_NotAuth.ReadOnly = true;
            this.textBox3Auth_NotAuth.Size = new System.Drawing.Size(176, 22);
            this.textBox3Auth_NotAuth.TabIndex = 49;
            this.textBox3Auth_NotAuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3Schema
            // 
            this.textBox3Schema.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3Schema.Location = new System.Drawing.Point(332, 48);
            this.textBox3Schema.Name = "textBox3Schema";
            this.textBox3Schema.Size = new System.Drawing.Size(163, 22);
            this.textBox3Schema.TabIndex = 48;
            this.textBox3Schema.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3Schema.TextChanged += new System.EventHandler(this.textBox3Schema_TextChanged);
            // 
            // textBox3TxnType
            // 
            this.textBox3TxnType.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3TxnType.Location = new System.Drawing.Point(191, 48);
            this.textBox3TxnType.Name = "textBox3TxnType";
            this.textBox3TxnType.Size = new System.Drawing.Size(145, 22);
            this.textBox3TxnType.TabIndex = 47;
            this.textBox3TxnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3Acquired
            // 
            this.textBox3Acquired.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3Acquired.Location = new System.Drawing.Point(49, 48);
            this.textBox3Acquired.Name = "textBox3Acquired";
            this.textBox3Acquired.Size = new System.Drawing.Size(145, 22);
            this.textBox3Acquired.TabIndex = 46;
            this.textBox3Acquired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3Nr
            // 
            this.textBox3Nr.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3Nr.Location = new System.Drawing.Point(3, 48);
            this.textBox3Nr.Name = "textBox3Nr";
            this.textBox3Nr.Size = new System.Drawing.Size(49, 22);
            this.textBox3Nr.TabIndex = 45;
            this.textBox3Nr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4Amount
            // 
            this.textBox4Amount.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4Amount.Location = new System.Drawing.Point(979, 68);
            this.textBox4Amount.Name = "textBox4Amount";
            this.textBox4Amount.Size = new System.Drawing.Size(153, 22);
            this.textBox4Amount.TabIndex = 60;
            this.textBox4Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4Locality
            // 
            this.textBox4Locality.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4Locality.Location = new System.Drawing.Point(819, 68);
            this.textBox4Locality.Name = "textBox4Locality";
            this.textBox4Locality.Size = new System.Drawing.Size(163, 22);
            this.textBox4Locality.TabIndex = 59;
            this.textBox4Locality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4CaptureMethode
            // 
            this.textBox4CaptureMethode.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4CaptureMethode.Location = new System.Drawing.Point(661, 68);
            this.textBox4CaptureMethode.Name = "textBox4CaptureMethode";
            this.textBox4CaptureMethode.Size = new System.Drawing.Size(163, 22);
            this.textBox4CaptureMethode.TabIndex = 58;
            this.textBox4CaptureMethode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4Auth_NotAuth
            // 
            this.textBox4Auth_NotAuth.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4Auth_NotAuth.Location = new System.Drawing.Point(491, 68);
            this.textBox4Auth_NotAuth.Name = "textBox4Auth_NotAuth";
            this.textBox4Auth_NotAuth.ReadOnly = true;
            this.textBox4Auth_NotAuth.Size = new System.Drawing.Size(176, 22);
            this.textBox4Auth_NotAuth.TabIndex = 57;
            this.textBox4Auth_NotAuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4Schema
            // 
            this.textBox4Schema.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4Schema.Location = new System.Drawing.Point(332, 68);
            this.textBox4Schema.Name = "textBox4Schema";
            this.textBox4Schema.Size = new System.Drawing.Size(163, 22);
            this.textBox4Schema.TabIndex = 56;
            this.textBox4Schema.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4TxnType
            // 
            this.textBox4TxnType.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4TxnType.Location = new System.Drawing.Point(191, 68);
            this.textBox4TxnType.Name = "textBox4TxnType";
            this.textBox4TxnType.Size = new System.Drawing.Size(145, 22);
            this.textBox4TxnType.TabIndex = 55;
            this.textBox4TxnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4Acquired
            // 
            this.textBox4Acquired.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4Acquired.Location = new System.Drawing.Point(49, 68);
            this.textBox4Acquired.Name = "textBox4Acquired";
            this.textBox4Acquired.Size = new System.Drawing.Size(145, 22);
            this.textBox4Acquired.TabIndex = 54;
            this.textBox4Acquired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4Nr
            // 
            this.textBox4Nr.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4Nr.Location = new System.Drawing.Point(3, 68);
            this.textBox4Nr.Name = "textBox4Nr";
            this.textBox4Nr.Size = new System.Drawing.Size(49, 22);
            this.textBox4Nr.TabIndex = 53;
            this.textBox4Nr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelDashbordTxn
            // 
            this.panelDashbordTxn.Controls.Add(this.textBox4Amount);
            this.panelDashbordTxn.Controls.Add(this.textBox4Locality);
            this.panelDashbordTxn.Controls.Add(this.textBox4CaptureMethode);
            this.panelDashbordTxn.Controls.Add(this.textBox4Auth_NotAuth);
            this.panelDashbordTxn.Controls.Add(this.textBox4Schema);
            this.panelDashbordTxn.Controls.Add(this.textBox4TxnType);
            this.panelDashbordTxn.Controls.Add(this.textBox4Acquired);
            this.panelDashbordTxn.Controls.Add(this.textBox4Nr);
            this.panelDashbordTxn.Controls.Add(this.textBox3Amount);
            this.panelDashbordTxn.Controls.Add(this.textBox3Locality);
            this.panelDashbordTxn.Controls.Add(this.textBox3CaptureMethode);
            this.panelDashbordTxn.Controls.Add(this.textBox3Auth_NotAuth);
            this.panelDashbordTxn.Controls.Add(this.textBox3Schema);
            this.panelDashbordTxn.Controls.Add(this.textBox3TxnType);
            this.panelDashbordTxn.Controls.Add(this.textBox3Acquired);
            this.panelDashbordTxn.Controls.Add(this.textBox3Nr);
            this.panelDashbordTxn.Controls.Add(this.textBox2Amount);
            this.panelDashbordTxn.Controls.Add(this.textBox2Locality);
            this.panelDashbordTxn.Controls.Add(this.textBox2CaptureMethode);
            this.panelDashbordTxn.Controls.Add(this.textBox2Auth_NotAuth);
            this.panelDashbordTxn.Controls.Add(this.textBox2Schema);
            this.panelDashbordTxn.Controls.Add(this.textBox2TxnType);
            this.panelDashbordTxn.Controls.Add(this.textBox2Acquired);
            this.panelDashbordTxn.Controls.Add(this.textBox2Nr);
            this.panelDashbordTxn.Controls.Add(this.textBox1Amount);
            this.panelDashbordTxn.Controls.Add(this.textBox1Locality);
            this.panelDashbordTxn.Controls.Add(this.textBox1CaptureMethode);
            this.panelDashbordTxn.Controls.Add(this.textBox1Auth_NotAuth);
            this.panelDashbordTxn.Controls.Add(this.textBox1Schema);
            this.panelDashbordTxn.Controls.Add(this.textBox1TxnType);
            this.panelDashbordTxn.Controls.Add(this.textBox1Acquired_Processed);
            this.panelDashbordTxn.Controls.Add(this.textBox1Nr);
            this.panelDashbordTxn.Controls.Add(this.panelErrorMsgBox);
            this.panelDashbordTxn.Location = new System.Drawing.Point(8, 165);
            this.panelDashbordTxn.Name = "panelDashbordTxn";
            this.panelDashbordTxn.Size = new System.Drawing.Size(0, 0);
            this.panelDashbordTxn.TabIndex = 61;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 653);
            this.Controls.Add(this.panelSchemeForAcquired);
            this.Controls.Add(this.panelCaptureMethode);
            this.Controls.Add(this.panelLocality);
            this.Controls.Add(this.panelSchemaForProcessed);
            this.Controls.Add(this.panelTxnType);
            this.Controls.Add(this.panelDashbordTxn);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelTxnType.ResumeLayout(false);
            this.panelTxnType.PerformLayout();
            this.panelSchemeForAcquired.ResumeLayout(false);
            this.panelSchemeForAcquired.PerformLayout();
            this.panelSchemaForProcessed.ResumeLayout(false);
            this.panelSchemaForProcessed.PerformLayout();
            this.panelCaptureMethode.ResumeLayout(false);
            this.panelCaptureMethode.PerformLayout();
            this.panelLocality.ResumeLayout(false);
            this.panelLocality.PerformLayout();
            this.panelErrorMsgBox.ResumeLayout(false);
            this.panelErrorMsgBox.PerformLayout();
            this.panelDashbordTxn.ResumeLayout(false);
            this.panelDashbordTxn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox AcquiredCheckBox;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label TransactionTypeLabel;
        private System.Windows.Forms.CheckBox authorisedCheckBox;
        private System.Windows.Forms.Label captureMethodeLabel;
        private System.Windows.Forms.Label schemaLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label localityLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Panel panelTxnType;
        private System.Windows.Forms.Panel panelSchemeForAcquired;
        private System.Windows.Forms.Panel panelCaptureMethode;
        private System.Windows.Forms.Panel panelLocality;
        private System.Windows.Forms.Label quasyCashLabel;
        private System.Windows.Forms.Label octLabel;
        private System.Windows.Forms.Label cashAdvanceLabel;
        private System.Windows.Forms.Label pwcbLabel;
        private System.Windows.Forms.Label refundLabel;
        private System.Windows.Forms.Label purchaseLabel;
        private System.Windows.Forms.Label visaDrPerIntLabel;
        private System.Windows.Forms.Label visaDrComIntlLabel;
        private System.Windows.Forms.Label visaCorporateLabel;
        private System.Windows.Forms.Label visaCommerceLabel;
        private System.Windows.Forms.Label visaBusinessLabel;
        private System.Windows.Forms.Label visaCreditPersonalLabel;
        private System.Windows.Forms.Label labelDinersDiscoverAcquired;
        private System.Windows.Forms.Label jcbLabel;
        private System.Windows.Forms.Label debitMasterCardPerIntLabel;
        private System.Windows.Forms.Label maestroComLabel;
        private System.Windows.Forms.Label masterCardBusinessLabel;
        private System.Windows.Forms.Label masterCardCrPerLabel;
        private System.Windows.Forms.Label motoSecureLabel;
        private System.Windows.Forms.Label panKeyEntryLabel;
        private System.Windows.Forms.Label onlineChipLabel;
        private System.Windows.Forms.Label offlinePinLabel;
        private System.Windows.Forms.Label eCommerceLabel;
        private System.Windows.Forms.Label magneticStripeLabel;
        private System.Windows.Forms.Label contactlessLabel;
        private System.Windows.Forms.Label interRegionalLabel;
        private System.Windows.Forms.Label domesticLabel;
        private System.Windows.Forms.Label intraRegionalLabel;
        private System.Windows.Forms.Timer timerTxnType;
        private System.Windows.Forms.Timer timerSchema;
        private System.Windows.Forms.Timer timerCaptureMethode;
        private System.Windows.Forms.Timer timerLocality;
        private System.Windows.Forms.Panel panelSchemaForProcessed;
        private System.Windows.Forms.Label labelDinersDiscoverdProcessed;
        private System.Windows.Forms.Label labelAmericanExpress;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Panel panelErrorMsgBox;
        private System.Windows.Forms.Label labelErrMsgBox;
        private System.Windows.Forms.Button buttonErrMsgBoxOK;
        private System.Windows.Forms.TextBox textBox1Nr;
        private System.Windows.Forms.TextBox textBox1Acquired_Processed;
        private System.Windows.Forms.TextBox textBox1TxnType;
        private System.Windows.Forms.TextBox textBox1Schema;
        private System.Windows.Forms.TextBox textBox1Auth_NotAuth;
        private System.Windows.Forms.TextBox textBox1CaptureMethode;
        private System.Windows.Forms.TextBox textBox1Locality;
        private System.Windows.Forms.TextBox textBox1Amount;
        private System.Windows.Forms.TextBox textBox2Amount;
        private System.Windows.Forms.TextBox textBox2Locality;
        private System.Windows.Forms.TextBox textBox2CaptureMethode;
        private System.Windows.Forms.TextBox textBox2Auth_NotAuth;
        private System.Windows.Forms.TextBox textBox2Schema;
        private System.Windows.Forms.TextBox textBox2TxnType;
        private System.Windows.Forms.TextBox textBox2Acquired;
        private System.Windows.Forms.TextBox textBox2Nr;
        private System.Windows.Forms.TextBox textBox3Amount;
        private System.Windows.Forms.TextBox textBox3Locality;
        private System.Windows.Forms.TextBox textBox3CaptureMethode;
        private System.Windows.Forms.TextBox textBox3Auth_NotAuth;
        private System.Windows.Forms.TextBox textBox3Schema;
        private System.Windows.Forms.TextBox textBox3TxnType;
        private System.Windows.Forms.TextBox textBox3Acquired;
        private System.Windows.Forms.TextBox textBox3Nr;
        private System.Windows.Forms.TextBox textBox4Amount;
        private System.Windows.Forms.TextBox textBox4Locality;
        private System.Windows.Forms.TextBox textBox4CaptureMethode;
        private System.Windows.Forms.TextBox textBox4Auth_NotAuth;
        private System.Windows.Forms.TextBox textBox4Schema;
        private System.Windows.Forms.TextBox textBox4TxnType;
        private System.Windows.Forms.TextBox textBox4Acquired;
        private System.Windows.Forms.TextBox textBox4Nr;
        private System.Windows.Forms.Panel panelDashbordTxn;
    }
}
