Public Class frm_report
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()

    End Sub

    Private Sub frm_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.RowTemplate.Height = 25

        load_report()
    End Sub




    Sub load_report()
        DataGridView1.Rows.Clear()


        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "Select transno, transdate,bookid,bookname,author,price,tax,totalprice,grandtotal From bookinventory WHERE transno like '%" & txt_search.Text & "%' or bookid like '%" & txt_search.Text & "%' or bookname like '%" & txt_search.Text & "%' or author like '%" & txt_search.Text & "%'"
            lectordatos = acciones.ExecuteReader

            While lectordatos.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, lectordatos.Item("transdate"), lectordatos.Item("transno"), lectordatos.Item("bookid"), lectordatos.Item("bookname"), lectordatos.Item("author"), lectordatos.Item("price"), lectordatos.Item("tax"), lectordatos.Item("totalprice"), lectordatos.Item("grandtotal"))

            End While


        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        lectordatos.Close()

    End Sub

    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click

        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim date2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")

        DataGridView1.Rows.Clear()


        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "Select transno, transdate,bookid,bookname,author,price,tax,totalprice,grandtotal From bookinventory WHERE transdate between '" & date1 & "' and '" & date2 & "' "
            lectordatos = acciones.ExecuteReader

            While lectordatos.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, lectordatos.Item("transdate"), lectordatos.Item("transno"), lectordatos.Item("bookid"), lectordatos.Item("bookname"), lectordatos.Item("author"), lectordatos.Item("price"), lectordatos.Item("tax"), lectordatos.Item("totalprice"), lectordatos.Item("grandtotal"))

            End While


        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        lectordatos.Close()

    End Sub


    Sub total()
        Try
            Dim sum As Double = 0
            For j As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                sum = sum + DataGridView1.Rows(j).Cells(8).Value

            Next
            lbl_total.Text = sum
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' Obtener el índice de la columna que deseas sumar (en este caso, la columna 8)
        Dim columnIndex As Integer = 8

        ' Obtener la suma de los valores en la columna especificada
        Dim sum As Double = 0

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim cellValue As String = CStr(row.Cells(columnIndex).Value)
            Dim value As Double
            If Double.TryParse(cellValue, value) Then
                ' Si la conversión es exitosa, agregar el valor convertido a la suma
                sum += value
            End If
        Next

        ' Mostrar la suma en el label en formato decimal con dos dígitos decimales
        lbl_total.Text = String.Format("Total: {0:N2}", sum)





    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        load_report()

    End Sub
End Class