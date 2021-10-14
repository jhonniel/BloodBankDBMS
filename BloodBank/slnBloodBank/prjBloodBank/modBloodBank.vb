Imports MySql.Data.MySqlClient
Module modBloodBank
    ' establishes connection to a MySQL Server Database
    Private dbConn As MySqlConnection

    ' represents an SQL statement to execute against a MySQL database
    Private sqlCommand As MySqlCommand

    ' represents a set of data commands and a database connection that are used to fill
    ' a dataset and update a MySQL database
    Private da As MySqlDataAdapter

    ' it is an in-memory representation of structured data (like data read from a database)
    Private dt As DataTable

    ' sets the string used to connect to a MySQL server database
    Dim strConn As String = "Server=localhost; User ID=root; Database=dbbloodbank;" +
                            "Convert Zero Datetime=True;"
    Private rd As MySqlDataReader
    Private checker As MySqlDataReader
    Public UserName As String = ""

    Public Sub dbConnection()
        Try
            dbConn = New MySqlConnection(strConn)
        Catch ex As Exception
            MessageBox.Show("Error: DBConnection() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'SQL query with message 
    Public Sub SQLManager(ByVal strSQL As String, ByVal strMsg As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(strSQL, dbConn)
            With sqlCommand
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            dbConn.Close()

            MessageBox.Show(strMsg, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: SQLManager() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub
    'Login method
    Public Sub FunctionLogin(ByVal user As String, ByVal pass As String)
        Dim userID As Integer = UserFinder(user)
        Try
            dbConn = New MySqlConnection(strConn)
            dbConn.Open()
            Dim sqlQuery As String = "SELECT Username, Password FROM tbluser WHERE Username = '" + user + "' AND Password = '" + pass + "'"

            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            checker = sqlCommand.ExecuteReader()

            If (checker.Read() = True) Then
                frmMain.Show()
                login.Hide()
                sqlQuery = "INSERT INTO auditlogs (logType, UserID, LogModule, logComment) VALUES
                    ('" & "1" & "', '" & userID & "', '" & "Log-in" & "', 
                    '" & "User has successfully Logged-In" & "')"
                Audit(sqlQuery)
            ElseIf (checker.Read() = False) Then
                MessageBox.Show("Incorrect username or password.")
                sqlQuery = "INSERT INTO auditlogs (logType, UserID, LogModule, logComment) VALUES
                    ('" & "0" & "', '" & userID & "', '" & "Log-in" & "', 
                    '" & "User has unsuccessfully Logged-In" & "')"
                Audit(sqlQuery)
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Displays records 
    Public Sub DisplayRecords(ByVal strSQL As String, ByVal dg As DataGridView)
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)
            dg.DataSource = dt
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: DisplayRecords() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Counter of rows of Donor
    Public Function RecordCountDonor() As Integer
        Dim count As Integer = 0
        Dim strSQL As String = "SELECT * FROM donor ORDER BY DonorID DESC LIMIT 1"
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count() > 0 Then
                count = dt.Rows(0).Item("DonorID")
            Else
                count = 0
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: RecordCountDonor() " & ex.Message, "Blood bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return count
    End Function

    'counter of rows of Patient
    Public Function RecordCountPatient() As Integer
        Dim count As Integer = 0
        Dim strSQL As String = "SELECT * FROM patient ORDER BY PatientID DESC LIMIT 1"
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count() > 0 Then
                count = dt.Rows(0).Item("PatientID")
            Else
                count = 0
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: RecordCountPatient() " & ex.Message, "Blood bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return count
    End Function

    'counter of rows for Donation
    Public Function RecordCountDonation() As Integer
        Dim count As Integer = 0
        Dim strSQL As String = "SELECT * FROM donations ORDER BY DonationID DESC LIMIT 1"
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count() > 0 Then
                count = dt.Rows(0).Item("DonationID")
            Else
                count = 0
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: RecordCount() " & ex.Message, "Blood bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return count
    End Function

    'Counter of rows for user
    Public Function RecordCountUser() As Integer
        Dim count As Integer = 0
        Dim strSQL As String = "SELECT * FROM tbluser ORDER BY UserID DESC LIMIT 1"
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count() > 0 Then
                count = dt.Rows(0).Item("UserID")
            Else
                count = 0
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: RecordCount() " & ex.Message, "Blood bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return count
    End Function

    'Loads items to combo box
    Public Function LoadToComboBox(ByVal strSQL As String) As DataTable
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: LoadToComboBox() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function
    'Finder of user (Audit)
    Public Function UserFinder(ByVal user As String)
        Dim ra As Object
        Try
            dbConn = New MySqlConnection(strConn)
            dbConn.Open()
            Dim sqlQuery As String = "SELECT UserID FROM tbluser WHERE Username = '" & user & "'"
            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            rd = sqlCommand.ExecuteReader
            While rd.Read()
                ra = rd.Item("UserID")
            End While
            dbConn.Close()
            'Return CInt(ra)
        Catch ex As Exception
            MessageBox.Show("Error: UserFinder() " & ex.Message, "Blood Bank DBMS",
               MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return CInt(ra)
    End Function
    'Finder for the oldest product (Transaction), oldest products are to be used/discrded first
    Public Function OldestProductFinder(ByVal Str As String)
        Dim ProdID As Integer
        Integer.TryParse(Str, ProdID)
        Dim ra As Object
        Try
            dbConn = New MySqlConnection(strConn)
            dbConn.Open()
            Dim sqlQuery As String = "SELECT NVBSPNumber FROM stock_in WHERE ProductID = '" & ProdID & "' 
            AND (SELECT MIN(DatetobeDisposed)  FROM stock_in ORDER BY DatetobeDisposed ASC LIMIT 1)"
            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            ra = sqlCommand.ExecuteScalar
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: OldestFinder() " & ex.Message, "Blood Bank DBMS",
               MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return CInt(ra)
    End Function

    'Performs SQL queries without message (Audit purposes)
    Public Sub Audit(ByVal strSQL As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(strSQL, dbConn)
            With sqlCommand
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: Audit() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Adds Dates based on the collection date of the donated blood product
    Public Function DateAdder(ByVal Str As String, ByVal DatetobeAdded As Date) As Date
        Dim num As Integer
        Integer.TryParse(Str, num)
        Dim Interval As Integer
        Dim Expiry As Date
        Select Case num
            Case 1 To 8
                Interval = 35
                Expiry = DateAdd(DateInterval.Day, Interval, DatetobeAdded)
            Case 9 To 16
                Interval = 42
                Expiry = DateAdd(DateInterval.Day, Interval, DatetobeAdded)
            Case 17 To 24
                Interval = 365
                Expiry = DateAdd(DateInterval.Day, Interval, DatetobeAdded)
            Case 25 To 32
                Interval = 5
                Expiry = DateAdd(DateInterval.Day, Interval, DatetobeAdded)
            Case 33 To 40
                Interval = 365
                Expiry = DateAdd(DateInterval.Day, Interval, DatetobeAdded)
            Case 41 To 48
                Interval = 5
                Expiry = DateAdd(DateInterval.Day, Interval, DatetobeAdded)
        End Select
        Return Expiry
    End Function

    'Password Encrypt
    Public Function base64Encode(ByVal sData As String) As String
        Try
            Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)
            Dim encodedData As String = Convert.ToBase64String(encData_byte)
            Return (encodedData)
        Catch ex As Exception
            Throw (New Exception("Error in base64Encode" & ex.Message))
        End Try
    End Function

    'Password Decrypt
    Public Function base64Decode(ByVal sData As String) As String
        Dim encoder As New System.Text.UTF8Encoding()
        Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(sData)
        Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        Dim result As String = New [String](decoded_char)
        Return result
    End Function
End Module
