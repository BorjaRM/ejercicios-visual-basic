Public Class Form1
    Dim numeroAleatorio As Integer
    Dim contador As Integer = 0


    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Randomize()
        numeroAleatorio = (Rnd() * 100 + 1)

        btnGenerar.Text = "Ya he generado un número, adivinalo!"
        btnGenerar.Enabled = False
        numero.Enabled = True
        contador = 0
        intentos.Text = ""
        consola.Items.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        contador = 0
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        btnGenerar.Enabled = True
        consola.Items.Clear()
        numero.Clear()
        numero.Enabled = False
        intentos.Text = ""
        btnGenerar.Text = "JUGAR"
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub numero_TextChanged(sender As Object, e As EventArgs) Handles numero.TextChanged

    End Sub

    Private Sub numero_KeyDown(sender As Object, e As KeyEventArgs) Handles numero.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (IsNumeric(numero.Text)) Then
                If (numero.Text Mod 1) = 0 Then
                    contador = contador + 1
                    If (numero.Text < numeroAleatorio) Then
                        consola.Items.Add(numero.Text & " es demasiado pequeño!")
                    End If
                    If (numero.Text > numeroAleatorio) Then
                        consola.Items.Add(numero.Text & " es demasiado grande!")
                    End If
                    If (numero.Text = numeroAleatorio) Then
                        consola.Items.Add("Felicidades!! Has adivinado el numero!")
                        consola.Items.Add(contador & " intentos")
                        btnGenerar.Enabled = True
                        numero.Enabled = False
                        err.Text = ""
                        btnGenerar.Text = "JUGAR"
                    End If
                    numero.Clear()
                    intentos.Text = contador
                Else
                    err.Text = "Debe introducir un número entero"
                    numero.Clear()
                End If
            Else
                err.Text = "Debe introducir un número entero"
                numero.Clear()
            End If
        End If
    End Sub
End Class

