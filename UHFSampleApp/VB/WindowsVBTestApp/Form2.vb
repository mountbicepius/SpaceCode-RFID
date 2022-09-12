Imports UHFAPI_SPC

Public Class Form2
    Private _SPC_RFID As SPC_RFID = Nothing

    Private Sub btnScan_Click(sender As System.Object, e As System.EventArgs) Handles btnScan.Click
        _SPC_RFID.tagsDelegate = AddressOf tagAdd
        _SPC_RFID.deviceStatusDelegate = AddressOf devStAdd
        _SPC_RFID.errorDelegate = AddressOf errorAdd
        _SPC_RFID.scanCompleteDelegate = AddressOf scanComplted

        If btnScan.Text.Equals("Start Scan") Then
            _SPC_RFID.startScan(False)
            btnScan.Text = "Stop Scan"
        Else
            _SPC_RFID.stopScan()
            btnScan.Text = "Start Scan"
        End If
    End Sub



    Public Sub New()
        InitializeComponent()
        _SPC_RFID = SPC_RFID.getInstance()
    End Sub



    Public Sub tagAdd(a As String, r As String)
        Me.Invoke(DirectCast(Sub()
                                 a = If((Not String.IsNullOrWhiteSpace(txtTagsList.Text)), Convert.ToString(vbCr & vbLf) & a, a)
                                 txtTagsList.AppendText(a)
                                 lblCount.Text = "Count : " + _SPC_RFID.Tags_id.Count

                                 txtTagsList.ScrollToCaret()

                             End Sub, MethodInvoker))
    End Sub


    Public Sub scanComplted(tag As ArrayList)
        'lblMessage.Text = tag.ToArray()[0]+" : " + weight+ " : " + user;
        'lstControls.Items.Clear();
        'lstControls.Items.AddRange(tag.ToArray());                
        Me.Invoke(DirectCast(Sub()

                             End Sub, MethodInvoker))
    End Sub


    Public Sub errorAdd(a As String)
        'lblError.Text = a;
        Me.Invoke(DirectCast(Sub()

                             End Sub, MethodInvoker))

    End Sub

    Public Sub devStAdd(a As String)

    End Sub
End Class