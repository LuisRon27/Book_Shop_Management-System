Public Class Frm_ManageUser

    Public Sub clear()
        txt_name.Clear()
        txt_password.Clear()
        txt_username.Clear()
        cbo_role.SelectedIndex = -1

    End Sub
    Private Sub btn_registrar_Click(sender As Object, e As EventArgs) Handles btn_registrar.Click

        'Para  Registrar




        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "INSERT INTO Usuario(Name, UserName, Password, role)VALUES('" & txt_name.Text & "','" & txt_username.Text & "','" & txt_password.Text & "','" & cbo_role.Text & "')"
            acciones.ExecuteNonQuery()

            'conexion.close

            'MsgBox("¡Nuevo Registro De Usuario Exitoso!", vbOKOnly + vbInformation)
            MessageBox.Show("¡Nuevo Registro De Usuario Exitoso!", "BOOK SHOP", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try


        Close()



    End Sub

    Private Sub Frm_ManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        'conexionSql.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BookShopManagement;Data Source=LAPTOP-68VR45A9\SQLEXPRESS"

        'conexionSql.Open()

        'Catch ex As Exception

        ' MsgBox(ex.ToString)

        ' End Try

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        clear()
        Me.Close()
    End Sub

    Private Sub pbvisible_Click(sender As Object, e As EventArgs) Handles pbvisible.Click
        txt_password.PasswordChar = ""
        pbvisible.Visible = False
        pbocultar.Visible = True
    End Sub

    Private Sub pbocultar_Click(sender As Object, e As EventArgs) Handles pbocultar.Click
        txt_password.PasswordChar = "*"
        pbvisible.Visible = True
        pbocultar.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Close()
    End Sub
End Class
