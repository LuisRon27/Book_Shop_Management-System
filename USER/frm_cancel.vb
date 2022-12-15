Public Class frm_cancel
    Private Sub frm_cancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_transaction()

    End Sub


    Sub load_transaction()

        DataGridView1.Rows.Clear()

        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "Select transno, transdate, transmonth,bookid,bookname,author,price,tax,totalprice,grandtotal From bookinventory"
            lectordatos = acciones.ExecuteReader

            While lectordatos.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, lectordatos.Item("bookid"), lectordatos.Item("transdate"), lectordatos.Item("transno"), lectordatos.Item("grandtotal"))
            End While

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        lectordatos.Close()

    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim colname As String = DataGridView1.Columns(e.ColumnIndex).Name

        If colname = "Column5" Then

            If MsgBox("Are You Sure Cancel This Order", vbQuestion + vbYesNo) = vbYes Then

                acciones.Connection = conexionSql
                acciones.CommandType = CommandType.Text
                acciones.CommandText = "DELETE From bookinventory WHERE transno= @transno"
                acciones.Parameters.Clear()
                acciones.Parameters.AddWithValue("@transno", DataGridView1.CurrentRow.Cells(3).Value)
                acciones.ExecuteNonQuery()
                MsgBox("Order Cancel Success!", vbInformation)
            Else
                Return




            End If

        End If
        Update_bookstatus()
        load_transaction()
        Frm_User.load_books()

    End Sub






    Sub Update_bookstatus()


        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "UPDATE bookmaster set status = @status Where bookid = @bookid"


            acciones.Parameters.Clear()
            acciones.Parameters.AddWithValue("@status", "DISPONIBLE")
            acciones.Parameters.AddWithValue("@bookid", DataGridView1.CurrentRow.Cells(1).Value)
            acciones.ExecuteNonQuery()





        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

End Class