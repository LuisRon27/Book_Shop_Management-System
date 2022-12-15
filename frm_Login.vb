
Imports System.Runtime.InteropServices

Public Class frm_Login
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click

        If MsgBox("esta seguro que desea salir?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
            Application.Exit()

        Else
            Return

        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        End
    End Sub

    Private Sub pbvisible_Click(sender As Object, e As EventArgs) Handles pbvisible.Click
        txt_passwordlogin.PasswordChar = ""
        pbvisible.Visible = False
        pbocultar.Visible = True
    End Sub

    Private Sub pbocultar_Click(sender As Object, e As EventArgs) Handles pbocultar.Click
        txt_passwordlogin.PasswordChar = "*"
        pbvisible.Visible = True
        pbocultar.Visible = False
    End Sub

    Dim Cont As Integer
    Private Sub Iniciar()


        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select * from Usuario where UserName='" & txt_usernamelogin.Text & "'"
        acciones.Parameters.Clear()
        acciones.Parameters.AddWithValue("UserName", txt_usernamelogin.Text)
        adaptadorSql.SelectCommand = acciones
        adaptadorSql.Fill(tabladedatos)

        If (tabladedatos.Rows.Count > 0) Then

            acciones.CommandText = "Select * from Usuario where UserName='" & txt_usernamelogin.Text & "' and Password='" & txt_passwordlogin.Text & "'"
            acciones.Parameters.Clear()
            acciones.Parameters.AddWithValue("UserName", txt_usernamelogin.Text)
            acciones.Parameters.AddWithValue("Password", txt_passwordlogin.Text)
            lectordatos = acciones.ExecuteReader



            If lectordatos.Read = True Then



                Dim Name As String = lectordatos.Item("Name").ToString
                Dim UserName As String = lectordatos.Item("UserName").ToString
                Dim Password As String = lectordatos.Item("Password").ToString
                Dim role As String = lectordatos.Item("role").ToString



                If UCase(role) = "ADMIN" Then

                    'MessageBox.Show("Bienvenido al Sistema:" & Name, "BOOK SHOP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lectordatos.Close()
                    Me.Hide()
                    Frm_Admin.Show()
                    Frm_Admin.lbl_userinfo.Text = "Login User : " & Name & " Login Time: " & Date.Now.ToString("hh:mm:ss tt") & ""

                ElseIf UCase(role) = "USER" Then

                    'MessageBox.Show("Bienvenido al Sistema:" & Name, "BOOK SHOP", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    lectordatos.Close()
                    Me.Hide()
                    Frm_User.Show()
                    Frm_User.lbl_userinfo.Text = "Login User : " & Name & " Login Time: " & Date.Now.ToString("hh:mm:ss tt") & ""


                End If





            Else
                Cont = Cont + 1
                MsgBox("El Usuario Y contraseña no coinciden ", 32, "Advertencia")
                txt_usernamelogin.Text = ""
                txt_passwordlogin.Text = ""
                txt_usernamelogin.Focus()

                If Cont > 2 Then

                    MsgBox("Cumplio sus tres intentos ", 16, "Advertencia")
                    Me.Close()
                End If



            End If


            lectordatos.Close()


        End If




    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Iniciar()




    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub


    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conexionSql.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BookShopManagement;Data Source=LAPTOP-68VR45A9\SQLEXPRESS"

            conexionSql.Open()

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class