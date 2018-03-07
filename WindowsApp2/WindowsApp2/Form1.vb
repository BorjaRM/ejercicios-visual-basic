Public Class Form1
    Public Class GlobalVariables
        Public Shared equipos = New String() {"Baskonia", "Gipuzkoa", "Joventut", "Gran Canaria", "Fuenlabrada",
            "Real Betis", "Tecnyconta Zaragoza", "MoraBanc Andorra", "Unicaja", "Valencia Basket", "Iberostar Tenerife",
            "Real Madrid", "Bilbao Basket", "UCAM Murcia", "Barcelona", "Estudiantes", "San Pablo Burgos", "Obradoiro"}
    End Class
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        calendario.Hide()
        hora.Format = DateTimePickerFormat.Time
        hora.ShowUpDown = True
        local.Maximum = 200
        visitante.Maximum = 200
        fecha.Text = " "
    End Sub
    Private Sub cb2_GotFocus() Handles cb2.GotFocus
        Dim equipo As String
        Dim i As Integer

        If (cb1.SelectedItem Is Nothing) Then
            cb2.Items.Clear()
            For i = 0 To (GlobalVariables.equipos.Length - 1)
                equipo = GlobalVariables.equipos(i)
                cb2.Items.Add(equipo)
            Next i
        Else
            cb2.Items.Clear()
            For i = 0 To (GlobalVariables.equipos.Length - 1)
                equipo = GlobalVariables.equipos(i)
                If Not (equipo.Equals(cb1.SelectedItem)) Then
                    cb2.Items.Add(equipo)
                End If
            Next i
        End If
    End Sub
    Private Sub cb1_GotFocus() Handles cb1.GotFocus
        Dim equipo As String
        Dim i As Integer

        If (cb2.SelectedItem Is Nothing) Then
            cb1.Items.Clear()
            For i = 0 To (GlobalVariables.equipos.Length - 1)
                equipo = GlobalVariables.equipos(i)
                cb1.Items.Add(equipo)
            Next i
        Else
            cb1.Items.Clear()
            For i = 0 To (GlobalVariables.equipos.Length - 1)
                equipo = GlobalVariables.equipos(i)
                If Not (equipo.Equals(cb2.SelectedItem)) Then
                    cb1.Items.Add(equipo)
                End If
            Next i
        End If
    End Sub
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calendario.DateChanged
        fecha.Text = e.Start.ToShortDateString()
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cb1.Items.Clear()
        cb2.Items.Clear()
        fecha.Clear()
        hora.ResetText()
        local.ResetText()
        local.Value = 0
        visitante.ResetText()
        visitante.Value = 0
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If (cb1.SelectedItem Is Nothing Or cb2.SelectedItem Is Nothing) Then
            MessageBox.Show("Debe seleccionar, al menos, equipo local y visitante", "Error",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Partido: " & cb1.SelectedItem.ToString & " " & local.Value & " - " &
            cb2.SelectedItem.ToString & " " & visitante.Value & vbNewLine & " Jornada: " & fecha.Text &
            " " & hora.Value.ToShortTimeString, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub fecha_GotFocus() Handles fecha.GotFocus
        calendario.Show()
    End Sub
    Private Sub fecha_LostFocus() Handles fecha.LostFocus
        calendario.Hide()
    End Sub
End Class
