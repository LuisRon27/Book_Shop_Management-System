Public Class Frm_Admin
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        If MsgBox("Esta seguro que Desea Cerrar Sesion?", MsgBoxStyle.Question + vbYesNo) = vbYes Then

            Me.Close()
            frm_Login.txt_passwordlogin.Clear()
            frm_Login.Show()

        Else
            Return

        End If


    End Sub

    Private Sub btn_manageusers_Click(sender As Object, e As EventArgs) Handles btn_manageusers.Click
        Frm_ManageUser.ShowDialog()

    End Sub

    Private Sub Frm_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Get_DashBoard()

    End Sub

    Private Sub btn_managebook_Click(sender As Object, e As EventArgs) Handles btn_managebook.Click
        Frm_ManageBook.ShowDialog()
    End Sub

    Sub Get_DashBoard()

        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select sum(totalprice) from bookinventory where transdate = '" & Date.Now.ToString("yyyy-MM-dd") & "'"

        Dim suma As Double

        If acciones.ExecuteScalar Is DBNull.Value Then
            suma = 0
        Else
            suma = Convert.ToDouble(acciones.ExecuteScalar)
        End If

        If suma = 0 Then
            ' Aquí puedes ejecutar código si la suma es igual a cero
            lbl_todaysale.Text = "0.00"
        Else
            ' Aquí puedes ejecutar código si la suma no es igual a cero
            lbl_todaysale.Text = suma
        End If



        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select count(bookid) from bookinventory where transdate = '" & Date.Now.ToString("yyyy-MM-dd") & "'"
        lbl_NoofTodaySale.Text = acciones.ExecuteScalar

        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select sum(totalprice) from bookinventory where transmonth = '" & Date.Now.ToString("MM") & "'"

        Dim sumames As Double

        If acciones.ExecuteScalar Is DBNull.Value Then
            sumames = 0
        Else
            sumames = Convert.ToDouble(acciones.ExecuteScalar)
        End If

        If sumames = 0 Then
            ' Aquí puedes ejecutar código si la suma es igual a cero
            lbl_currentMonthSale.Text = "0.00"
        Else
            ' Aquí puedes ejecutar código si la suma no es igual a cero
            lbl_currentMonthSale.Text = sumames
        End If


        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select count(bookid) from bookinventory where transmonth = '" & Date.Now.ToString("MM") & "'"
        lbl_NoofMonthSale.Text = acciones.ExecuteScalar


        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select COUNT(bookid) from bookmaster"
        Lbl_totalbooks.Text = acciones.ExecuteScalar

        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select COUNT(Name) from Usuario"
        lbl_TotalUsers.Text = acciones.ExecuteScalar


    End Sub
    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        frm_report.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick



        lbltime.Text = Date.Now.ToString("hh:mm:ss")
        lbldate.Text = Date.Now.ToString("dddd MMMM-yyyy")

    End Sub
End Class