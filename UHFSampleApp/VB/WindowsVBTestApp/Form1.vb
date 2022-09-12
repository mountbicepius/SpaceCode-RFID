Imports UHFAPI_SPC
Imports System.Text
Imports System.IO

Public Class Form1

    Private _SPC_RFID As UHFAPI_SPC.SPC_RFID = Nothing
    Public Sub New()
        _SPC_RFID = SPC_RFID.getInstance()

        InitializeComponent()
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs)
        'SPC_RFID.setDeviceStatusDelegate(devStAdd);


    End Sub
    Public Sub tagAdd(a As String, r As String)
        Me.Invoke(DirectCast(Sub()
                                 a = If((Not String.IsNullOrWhiteSpace(txtTagsList.Text)), Convert.ToString(vbCr & vbLf) & a, a)
                                 txtTagsList.AppendText(a)
                                 lblCount.Text = "Count : " + _SPC_RFID.Tags_id.Count.ToString()

                                 txtTagsList.ScrollToCaret()

                             End Sub, MethodInvoker))
    End Sub


    Public Sub scanComplted(tag As ArrayList)

        Me.Invoke(DirectCast(Sub() lblmsg.Text = "ScanCompleted:" + tag.Count.ToString() + " :tags ", MethodInvoker))
    End Sub


    Public Sub errorAdd(a As String)
        'lblError.Text = a;
        Me.Invoke(DirectCast(Sub()

                             End Sub, MethodInvoker))

    End Sub

    Public Sub devStAdd(a As String)
        Me.Invoke(DirectCast(Sub() lblConnection.Text = a, MethodInvoker))
    End Sub


    Private printers As New List(Of String)()


    Private Sub printEncodeTRags(dt As DataTable)
        Dim sbprn As New StringBuilder()


        For Each dr As DataRow In dt.Rows
            sbprn.Append(" CT~~CD,~CC^~CT~" + System.Environment.NewLine)
            sbprn.Append("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR6,6~SD26^JUS^LRN^CI0^RR6^RS8,,,3^XZ" + System.Environment.NewLine)
            sbprn.Append("^XA" + System.Environment.NewLine)
            sbprn.Append("^MMF" + System.Environment.NewLine)
            sbprn.Append("^PW1000" + System.Environment.NewLine)
            sbprn.Append("^LL0450" + System.Environment.NewLine)
            sbprn.Append("^LS0" + System.Environment.NewLine)

            'Barcode
            sbprn.Append("^FT610,145^BY2^BCN,50,Y\^FD" + dr(0).ToString() + "^FS" + System.Environment.NewLine)
            'fro barcode EAN128 Format.
            'first Line first value

            sbprn.Append("^FT600,190^A0N,20,22^FH\^FD" + dr.Table.Columns(1).ColumnName.ToString() + ":" + dr(1) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,190^A0N,20,22^FH\^FD" + dr.Table.Columns(2).ColumnName.ToString().ToString() + ":" + dr(2) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT600,215^A0N,20,22^FH\^FD" + dr.Table.Columns(3).ColumnName.ToString().ToString() + ":" + dr(3) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,215^A0N,20,22^FH\^FD" + dr.Table.Columns(4).ColumnName.ToString().ToString() + ":" + dr(4) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT600,270^A0N,20,22^FH\^FD" + dr.Table.Columns(5).ColumnName.ToString().ToString() + ":" + dr(5) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,270^A0N,20,22^FH\^FD" + dr.Table.Columns(6).ColumnName.ToString().ToString() + ":" + dr(6) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT600,295^^A0N,20,22^FH\^FD" + dr.Table.Columns(7).ColumnName.ToString().ToString() + ":" + dr(7) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,295^^A0N,20,22^FH\^FD" + dr.Table.Columns(8).ColumnName.ToString().ToString() + ":" + dr(8) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT600,320^^A0N,20,22^FH\^FD" + dr.Table.Columns(9).ColumnName.ToString().ToString() + ":" + dr(9) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,320^^A0N,20,22^FH\^FD" + dr.Table.Columns(10).ColumnName.ToString().ToString() + ":" + dr(10) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT600,345^^A0N,20,22^FH\^FD" + dr.Table.Columns(11).ColumnName.ToString().ToString() + ":" + dr(11) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,345^^A0N,20,22^FH\^FD" + dr.Table.Columns(12).ColumnName.ToString().ToString() + ":" + dr(12) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT600,370^^A0N,20,22^FH\^FD" + dr.Table.Columns(13).ColumnName.ToString().ToString() + ":" + dr(13) + "^FS" + System.Environment.NewLine)
            sbprn.Append("^FT745,370^^A0N,20,22^FH\^FD" + dr.Table.Columns(14).ColumnName.ToString().ToString() + ":" + dr(14) + "^FS" + System.Environment.NewLine)

            sbprn.Append("^WVN")
            sbprn.Append("^RFW,H,1,16,1^FD3000" + dr(0).ToString().ToHex() + "^FS")
            sbprn.Append("^PQ1,0,1,Y^XZ")
        Next



        Dim printerN As String = cmbPrinters.Text

        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\t2.prn", sbprn.ToString())
        Dim res As Boolean = _SPC_RFID.SendStringToPrinter(printerN, sbprn.ToString())

        Dim msg As String = If((res), "Success", "Failed")
        MessageBox.Show(msg)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function openExcel() As DataTable
        Dim excs As DataTable = Nothing
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "csv,excel files |*.csv;*.xlsx;*.xls"
        If dlg.ShowDialog() = DialogResult.OK Then
            Dim fileName As String
            fileName = dlg.FileName
            '''txtFilePath.Text = fileName;

            Dim ext As String = Path.GetExtension(dlg.FileName)

            Select Case ext.ToLower()
                Case ".csv"
                    excs = DirectCast(CommanFunctions.ReadCsvFile(fileName), DataTable)
                    Exit Select
                Case ".xls", ".xlsx"
                    excs = CommanFunctions.ImportExcelXLS(fileName, True).Tables(0)
                    Exit Select

            End Select
        End If
        Return excs
    End Function



    Private Sub btnConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        _SPC_RFID.tagsDelegate = AddressOf tagAdd
        _SPC_RFID.deviceStatusDelegate = AddressOf devStAdd
        _SPC_RFID.errorDelegate = AddressOf errorAdd
        _SPC_RFID.scanCompleteDelegate = AddressOf scanComplted

        _SPC_RFID.connectReader(ReaderMake.Dtr)
    End Sub

    Private Sub btnScan_Click_1(sender As System.Object, e As System.EventArgs) Handles btnScan.Click
        If btnScan.Text.Equals("Start Scan") Then
            trackBarPower.Value = 31

            _SPC_RFID.AllowDuplicateTagScan = False
            _SPC_RFID.SetPower(trackBarPower.Value)
            _SPC_RFID.SetDuty(trackBarDuty.Value)
            _SPC_RFID.startScan(True)
            btnScan.Text = "Stop Scan"
        Else
            _SPC_RFID.stopScan()
            btnScan.Text = "Start Scan"
        End If

    End Sub

    Private Sub btnNewForm_Click_1(sender As System.Object, e As System.EventArgs) Handles btnNewForm.Click
        Dim form2 As New Form2()
        form2.Show()
    End Sub

    Private Sub btnPrint_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim dt As DataTable = openExcel()

        If dt IsNot Nothing Then
            printEncodeTRags(dt)
        End If
    End Sub

    Private Sub btnRead_Click(sender As System.Object, e As System.EventArgs) Handles btnRead.Click
        txttag.Text = _SPC_RFID.readSingleTag()
    End Sub

    Private Sub Form1_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnConnect.PerformClick()
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            printers.Add(printer)
        Next

        cmbPrinters.Items.Clear()
        cmbPrinters.DataSource = printers

        If printers.Count > 0 Then
            cmbPrinters.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnEncode_Click_1(sender As System.Object, e As System.EventArgs) Handles btnEncode.Click
        trackBarPower.Value = 6
        If Not txttag.Text.Equals(String.Empty) Then
            Dim res As Boolean = _SPC_RFID.encodeTag(txttag.Text)
            txttag.ForeColor = If((res), Color.Green, Color.Red)
        End If
    End Sub

    Private Sub txttag_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txttag.TextChanged
        txttag.ForeColor = Color.Black
    End Sub
End Class
