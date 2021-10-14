Public Class frmMain

    Dim index As Integer
    Private Total, totalamount As Double
    Public User As String = login.UserName
    Dim UserID As Integer = UserFinder(User)
    Private Sub tryConn_Click(sender As Object, e As EventArgs)
        dbConnection()
    End Sub


    Private Sub DonorsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DonorsToolStripMenuItem.Click
        pnlDonors.Visible = True
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = False
    End Sub

    Private Sub DonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonationsToolStripMenuItem.Click
        Dim strQuery As String
        pnlDonors.Visible = False
        pnlDonations.Visible = True
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = False
        strQuery = "SELECT * FROM donor ORDER BY DonorID"
        cboDonorID.DataSource = LoadToComboBox(strQuery)
        cboDonorID.ValueMember = LoadToComboBox(strQuery).Columns("DonorID").ToString
        cboDonorID.DisplayMember = LoadToComboBox(strQuery).Columns("DonorID").ToString
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = True
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = False
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = True
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = False
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = True
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = False
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = True
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = False
    End Sub
    Private Sub StockInToolStripMenu_Click(sender As Object, e As EventArgs) Handles StockInToolStripMenu.Click
        Dim strQuery As String
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = True
        pnlAuditLog.Visible = False
        strQuery = "DELETE FROM stock_in WHERE InStore = 0"
        Audit(strQuery)
        strQuery = "SELECT NVBSPNumber, stock_in.ProductID , bloodproduct.ProductName, InStore, DateCollected, 
                DatetobeDisposed, AddedByID
                FROM stock_in INNER JOIN bloodproduct WHERE stock_in.ProductID = bloodproduct.ProductID
                ORDER BY NVBSPNumber"
        DisplayRecords(strQuery, dgStockIn)
    End Sub

    Private Sub AuditLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditLogToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        pnlAuditLog.Visible = True
    End Sub
    'Main form
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strQuery As String
        dbConnection()
        strQuery = "SELECT * FROM donor ORDER BY DonorID"
        DisplayRecords(strQuery, dgDonors)
        lblDonorID.Text = RecordCountDonor() + 1
        btnAddDonor.Visible = True
        btnUpdateDonor.Visible = False
        btnDeleteDonor.Visible = False

        strQuery = "SELECT * FROM donations ORDER BY DonationID"
        DisplayRecords(strQuery, dgDonations)
        lblDonationID.Text = RecordCountDonation() + 1
        btnAddDonation.Visible = True
        btnUpdateDonation.Visible = False
        btnDeleteDonation.Visible = False

        strQuery = "SELECT * FROM donor ORDER BY DonorID"
        cboDonorID.DataSource = LoadToComboBox(strQuery)
        cboDonorID.ValueMember = LoadToComboBox(strQuery).Columns("DonorID").ToString
        cboDonorID.DisplayMember = LoadToComboBox(strQuery).Columns("DonorID").ToString

        strQuery = "SELECT * FROM transactionrecords ORDER BY TransactionID"
        DisplayRecords(strQuery, dgTransaction)

        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
        lblPatientID.Text = RecordCountPatient() + 1
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False
        cboPatientID.DataSource = LoadToComboBox(strQuery)
        cboPatientID.ValueMember = LoadToComboBox(strQuery).Columns("PatientID").ToString
        cboPatientID.DisplayMember = LoadToComboBox(strQuery).Columns("PatientID").ToString

        strQuery = "SELECT * FROM bloodproduct ORDER BY ProductID"
        DisplayRecords(strQuery, dgProducts)
        cboProductID.DataSource = LoadToComboBox(strQuery)
        cboProductID.ValueMember = LoadToComboBox(strQuery).Columns("ProductID").ToString
        cboProductID.DisplayMember = LoadToComboBox(strQuery).Columns("ProductID").ToString

        strQuery = "SELECT * FROM auditlogs ORDER BY logID"
        DisplayRecords(strQuery, dgAuditLog)

        strQuery = "SELECT * FROM tbluser ORDER BY UserID"
        DisplayRecords(strQuery, dgUsers)
        lblUserID.Text = RecordCountUser() + 1
        btnAddUser.Visible = True
        btnUpdateUser.Visible = False
        btnDeleteUser.Visible = False

        strQuery = "SELECT NVBSPNumber, stock_in.ProductID , bloodproduct.ProductName, InStore, DateCollected, 
                DatetobeDisposed, AddedByID
                FROM stock_in INNER JOIN bloodproduct WHERE stock_in.ProductID = bloodproduct.ProductID
                ORDER BY NVBSPNumber"
        DisplayRecords(strQuery, dgStockIn)

    End Sub
    'Add feature of user
    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim strQuery As String
        Dim str As String = base64Encode(txtPassword.Text)
        Try
            strQuery = "INSERT INTO tbluser (Username, Password, FirstName, LastName, CreatedBy,CreatedDate)" +
            "VALUES ('" & txtUsername.Text & "', '" & str & "', '" & txtFirstnameUser.Text & "',
                     '" & txtLastnameUser.Text & "', '" & UserID & "', '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "')"
            SQLManager(strQuery, "User saved.")

            strQuery = "SELECT UserID, Username, Password, FirstName, LastName, CreatedBy " +
                       "FROM tbluser"
            DisplayRecords(strQuery, dgUsers)

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "2" & "', '" & UserID & "', '" & "User" & "', '" & "User Added" & "')"
            Audit(strQuery)

            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)

        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT * FROM tbluser ORDER BY UserID"
        DisplayRecords(strQuery, dgUsers)
        btnAddUser.Visible = True
        btnUpdateUser.Visible = False
        btnDeleteUser.Visible = False
    End Sub
    'Update feature of user table
    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click
        Dim strQuery As String
        Dim str As String = base64Encode(txtPassword.Text)
        Try
            strQuery = "UPDATE tbluser SET Username = '" & txtUsername.Text & "',
                                        Password = '" & str & "',
                                        FirstName = '" & txtFirstnameUser.Text & "',
                                        LastName = '" & txtLastnameUser.Text & "',
                                        ModifiedBy = " & UserID & ",
                                        ModifiedDate = '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "'
                                        WHERE UserID = " & lblUserID.Text & ""
            SQLManager(strQuery, "User Updated")

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment)
                            VALUES ('" & "3" & "', '" & UserID & "', '" & "User" & "', '" & "User Updated" & "')"
            Audit(strQuery)
            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)

        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT * FROM tbluser ORDER BY UserID"
        DisplayRecords(strQuery, dgUsers)
        btnAddUser.Visible = True
        btnUpdateUser.Visible = False
        btnDeleteUser.Visible = False
    End Sub

    'Delete feature of user table
    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM tbluser WHERE UserID = '" & lblUserID.Text & "'"
            del = MessageBox.Show("Delete this record?", "Delete Record", MessageBoxButtons.YesNo)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "Record Deleted")
                strQuery = "SELECT * FROM tbluser ORDER BY UserID"
                DisplayRecords(strQuery, dgUsers)

                strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "4" & "', '" & UserID & "', '" & "User" & "', '" & "User Deleted" & "')"
                Audit(strQuery)

                strQuery = "SELECT * FROM auditlogs ORDER BY logID"
                DisplayRecords(strQuery, dgAuditLog)
            Else
                strQuery = "SELECT * FROM tbluser ORDER BY UserID"
                DisplayRecords(strQuery, dgUsers)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddUser.Visible = True
        btnUpdateUser.Visible = False
        btnDeleteUser.Visible = False
    End Sub

    'Datagrid click of User
    Private Sub dgUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgUsers.CellContentClick
        Dim i As Integer = e.RowIndex
        Try
            With dgUsers
                lblUserID.Text = .Item("UserID", i).Value
                txtUsername.Text = .Item("Username", i).Value
                txtPassword.Text = base64Decode(.Item("Password", i).Value)
                txtFirstnameUser.Text = .Item("FirstName", i).Value
                txtLastnameUser.Text = .Item("LastName", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddUser.Visible = False
        btnUpdateUser.Visible = True
        btnDeleteUser.Visible = True
    End Sub

    'Add feature of Donor 
    Private Sub btnAddDonor_Click(sender As Object, e As EventArgs) Handles btnAddDonor.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO donor (DonorBloodType, DonorFname, DonorMname, DonorLname,
            DonorBirthDate,DonorAge,DonorHeight,DonorWeight,DonorAddress,DonorCity,DonorZip,
            DonorContactNo,IsActive,AddedByID,AddedDate) 
            VALUES ('" & cboBloodTypeDonor.Text & "',
                            '" & txtFirstnameDonor.Text & "',
                            '" & txtMiddlenameDonor.Text & "',
                            '" & txtLastnameDonor.Text & "',
                            '" & CDate(txtBirthdateDonor.Text).ToString("yyyy-MM-dd") & "',
                            '" & txtAgeDonor.Text & "',
                            '" & txtHeightDonor.Text & "',
                            '" & txtWeightDonor.Text & "',
                            '" & txtAddressDonor.Text & "',
                            '" & txtCityDonor.Text & "',
                            '" & txtZipDonor.Text & "',
                            '" & txtContactNumberDonor.Text & "',
                            '" & cboStatusDonor.Text & "',
                            '" & UserID & "',
                            '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "') "
            SQLManager(strQuery, "Record Saved.")
            lblDonorID.Text = RecordCountDonor() + 1
        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "2" & "', '" & UserID & "', '" & "Donor" & "', '" & "Donor Added" & "')"
            Audit(strQuery)
            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Audit() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodTypeDonor.Text = ""
        txtFirstnameDonor.Clear()
        txtMiddlenameDonor.Clear()
        txtLastnameDonor.Clear()
        txtBirthdateDonor.Clear()
        txtAgeDonor.Clear()
        txtHeightDonor.Clear()
        txtWeightDonor.Clear()
        txtAddressDonor.Clear()
        txtCityDonor.Clear()
        txtZipDonor.Clear()
        txtContactNumberDonor.Clear()
        cboStatusDonor.Text = ""
        strQuery = "SELECT * FROM donor ORDER BY DonorID"
        DisplayRecords(strQuery, dgDonors)
        btnAddDonor.Visible = True
        btnUpdateDonor.Visible = False
        btnDeleteDonor.Visible = False
    End Sub

    'Update feature of Donor
    Private Sub btnUpdateDonor_Click(sender As Object, e As EventArgs) Handles btnUpdateDonor.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE donor SET DonorBloodType = '" & cboBloodTypeDonor.Text & "',
                                         DonorFname = '" & txtFirstnameDonor.Text & "',
                                         DonorMname = '" & txtMiddlenameDonor.Text & "',
                                         DonorLname = '" & txtLastnameDonor.Text & "',
                                         DonorBirthDate = '" & CDate(txtBirthdateDonor.Text).ToString("yyyy-MM-dd") & "',
                                         DonorAge = '" & txtAgeDonor.Text & "',
                                         DonorHeight = '" & txtHeightDonor.Text & "',
                                         DonorWeight = '" & txtWeightDonor.Text & "',
                                         DonorAddress = '" & txtAddressDonor.Text & "',
                                         DonorCity = '" & txtCityDonor.Text & "',
                                         DonorZip = '" & txtZipDonor.Text & "',
                                         DonorContactNo = '" & txtContactNumberDonor.Text & "',
                                         IsActive = '" & cboStatusDonor.Text & "',
                                         LastModifiedByID = '" & UserID & "',
                                         LastModifiedDate = '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "'
                                         WHERE DonorID = " & lblDonorID.Text & ""
            SQLManager(strQuery, "Record Updated")

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "3" & "', '" & UserID & "', '" & "Donor" & "', '" & "Donor Updated" & "')"
            Audit(strQuery)

            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)

        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodTypeDonor.Text = ""
        txtFirstnameDonor.Clear()
        txtMiddlenameDonor.Clear()
        txtLastnameDonor.Clear()
        txtBirthdateDonor.Clear()
        txtAgeDonor.Clear()
        txtHeightDonor.Clear()
        txtWeightDonor.Clear()
        txtAddressDonor.Clear()
        txtCityDonor.Clear()
        txtZipDonor.Clear()
        txtContactNumberDonor.Clear()
        cboStatusDonor.Text = ""
        strQuery = "SELECT * FROM Donor ORDER BY DonorID"
        DisplayRecords(strQuery, dgDonors)
        btnAddDonor.Visible = True
        btnUpdateDonor.Visible = False
        btnDeleteDonor.Visible = False
    End Sub

    'Delete feature of Donors
    Private Sub btnDeleteDonor_Click(sender As Object, e As EventArgs) Handles btnDeleteDonor.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM donor WHERE DonorID = '" & lblDonorID.Text & "'"
            del = MessageBox.Show("Delete this record?", "Delete Record", MessageBoxButtons.YesNo)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "Record Deleted")
                strQuery = "SELECT * FROM donor ORDER BY DonorID"
                DisplayRecords(strQuery, dgDonors)

                strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "4" & "', '" & UserID & "', '" & "Donor" & "', '" & "Donor Deleted" & "')"
                Audit(strQuery)

                strQuery = "SELECT * FROM auditlogs ORDER BY logID"
                DisplayRecords(strQuery, dgAuditLog)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Delete() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodTypeDonor.Text = ""
        txtFirstnameDonor.Clear()
        txtMiddlenameDonor.Clear()
        txtLastnameDonor.Clear()
        txtBirthdateDonor.Clear()
        txtAgeDonor.Clear()
        txtHeightDonor.Clear()
        txtWeightDonor.Clear()
        txtAddressDonor.Clear()
        txtCityDonor.Clear()
        txtZipDonor.Clear()
        txtContactNumberDonor.Clear()
        cboStatusDonor.Text = ""
        btnAddDonor.Visible = True
        btnUpdateDonor.Visible = False
        btnDeleteDonor.Visible = False
    End Sub

    'Datagrid of Donors table
    Private Sub dgDonors_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDonors.CellClick
        Dim i As Integer = e.RowIndex
        Try
            With dgDonors
                lblDonorID.Text = .Item("DonorID", i).Value
                cboBloodTypeDonor.Text = .Item("DonorBloodType", i).Value
                txtFirstnameDonor.Text = .Item("DonorFname", i).Value
                txtMiddlenameDonor.Text = .Item("DonorMname", i).Value
                txtLastnameDonor.Text = .Item("DonorLname", i).Value
                txtBirthdateDonor.Text = .Item("DonorBirthdate", i).Value
                txtAgeDonor.Text = .Item("DonorAge", i).Value
                txtHeightDonor.Text = .Item("DonorHeight", i).Value
                txtWeightDonor.Text = .Item("DonorWeight", i).Value
                txtAddressDonor.Text = .Item("DonorAddress", i).Value
                txtCityDonor.Text = .Item("DonorCity", i).Value
                txtZipDonor.Text = .Item("DonorZip", i).Value
                txtContactNumberDonor.Text = .Item("DonorContactNo", i).Value
                cboStatusDonor.Text = .Item("IsActive", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddDonor.Visible = False
        btnUpdateDonor.Visible = True
        btnDeleteDonor.Visible = True
    End Sub

    'Add of Patient
    Private Sub btnAddPatient_Click(sender As Object, e As EventArgs) Handles btnAddPatient.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO patient (PatientBloodType, PatientFname, PatientMname, 
            PatientLname, PatientBirthDate, PatientAge, PatientHeight, PatientWeight,
            PatientDisease, Address, City, Zip,  PatientContactPerson, PatientContactNo, IsActive, AddedByID, AddedDate )" +
            "VALUES ('" & cboBloodTypePatient.Text & "',
            '" & txtFirstnamePatient.Text & "',
            '" & txtMiddlenamePatient.Text & "',
            '" & txtLastnamePatient.Text & "',
            '" & CDate(txtBirthdatePatient.Text).ToString("yyyy-MM-dd") & "',
            '" & txtAgePatient.Text & "',
            '" & txtHeightPatient.Text & "',
            '" & txtWeightPatient.Text & "',
            '" & txtDiseasePatient.Text & "',
            '" & txtAddressPatient.Text & "',
            '" & txtCityPatient.Text & "',
            '" & txtZipPatient.Text & "',
            '" & txtContactPersonPatient.Text & "',
            '" & txtContactPersonNumber.Text & "',
            '" & cboStatusPatient.Text & "',
            '" & UserID & "',
            '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "')"
            SQLManager(strQuery, "Record saved.")
            lblPatientID.Text = RecordCountPatient() + 1

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "2" & "', '" & UserID & "', '" & "Patient" & "', '" & "Patient Added" & "')"
            Audit(strQuery)
            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodTypePatient.Text = ""
        txtFirstnamePatient.Clear()
        txtMiddlenamePatient.Clear()
        txtLastnamePatient.Clear()
        txtBirthdatePatient.Clear()
        txtAgePatient.Clear()
        txtHeightPatient.Clear()
        txtWeightPatient.Clear()
        txtDiseasePatient.Clear()
        txtAddressPatient.Clear()
        txtCityPatient.Clear()
        txtZipPatient.Clear()
        txtContactPersonPatient.Clear()
        txtContactPersonNumber.Clear()
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
        cboPatientID.DataSource = LoadToComboBox(strQuery)
        cboPatientID.ValueMember = LoadToComboBox(strQuery).Columns("PatientID").ToString
        cboPatientID.DisplayMember = LoadToComboBox(strQuery).Columns("PatientID").ToString
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False
    End Sub

    'Update of Patient 
    Private Sub btnUpdatePatient_Click(sender As Object, e As EventArgs) Handles btnUpdatePatient.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE patient SET PatientFname = '" & txtFirstnamePatient.Text & "', 
                PatientMname = '" & txtMiddlenamePatient.Text & "',
                PatientLname = '" & txtLastnamePatient.Text & "',
                PatientBloodType = '" & cboBloodTypePatient.SelectedItem & "',
                PatientDisease = '" & txtDiseasePatient.Text & "',
                PatientBirthDate = '" & CDate(txtBirthdatePatient.Text).ToString("yyyy-MM-dd") & "',
                PatientAge = " & txtAgePatient.Text & ",
                PatientHeight ='" & txtHeightPatient.Text & "',
                PatientWeight = '" & txtWeightPatient.Text & "',
                Address = '" & txtAddressPatient.Text & "', City = '" & txtCityPatient.Text & "',
                Zip = '" & txtZipPatient.Text & "',
                PatientContactPerson = '" & txtContactPersonPatient.Text & "',
                PatientContactNo = '" & txtContactPersonNumber.Text & "',
                IsActive = '" & cboStatusPatient.Text & "',
                LastModifiedByID = '" & UserID & "',
                LastModifiedDate = '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "'
                WHERE PatientID = " & lblPatientID.Text & ""
            SQLManager(strQuery, "Record updated.")

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "3" & "', '" & UserID & "', '" & "Patient" & "', '" & "Patient Updated" & "')"
            Audit(strQuery)

            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)

        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
        cboBloodTypePatient.Text = ""
        txtFirstnamePatient.Clear()
        txtMiddlenamePatient.Clear()
        txtLastnamePatient.Clear()
        txtBirthdatePatient.Clear()
        txtAgePatient.Clear()
        txtHeightPatient.Clear()
        txtWeightPatient.Clear()
        txtDiseasePatient.Clear()
        txtAddressPatient.Clear()
        txtCityPatient.Clear()
        txtZipPatient.Clear()
        txtContactPersonPatient.Clear()
        txtContactPersonNumber.Clear()
        cboStatusPatient.Text = ""
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False
    End Sub

    'Delete of Patient table
    Private Sub btnDeletePatient_Click(sender As Object, e As EventArgs) Handles btnDeletePatient.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM patient WHERE PatientID = '" & lblPatientID.Text & "'"
            del = MessageBox.Show("Delete this record?", "Delete Record", MessageBoxButtons.YesNo)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "Record Deleted")
                strQuery = "SELECT * FROM patient ORDER BY PatientID"
                DisplayRecords(strQuery, dgPatients)

                strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "4" & "', '" & UserID & "', '" & "Patient" & "', '" & "Patient Deleted" & "')"
                Audit(strQuery)

                strQuery = "SELECT * FROM auditlogs ORDER BY logID"
                DisplayRecords(strQuery, dgAuditLog)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Delete() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodTypePatient.Text = ""
        txtFirstnamePatient.Clear()
        txtMiddlenamePatient.Clear()
        txtLastnamePatient.Clear()
        txtBirthdatePatient.Clear()
        txtAgePatient.Clear()
        txtHeightPatient.Clear()
        txtWeightPatient.Clear()
        txtDiseasePatient.Clear()
        txtAddressPatient.Clear()
        txtCityPatient.Clear()
        txtZipPatient.Clear()
        txtContactPersonPatient.Clear()
        txtContactPersonNumber.Clear()
        cboStatusPatient.Text = ""
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        cboPatientID.DataSource = LoadToComboBox(strQuery)
        cboPatientID.ValueMember = LoadToComboBox(strQuery).Columns("PatientID").ToString
        cboPatientID.DisplayMember = LoadToComboBox(strQuery).Columns("PatientID").ToString
    End Sub

    'Datagrid of Patient
    Private Sub dgPatients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPatients.CellClick
        Dim i As Integer = e.RowIndex
        Try
            With dgPatients
                lblPatientID.Text = .Item("PatientID", i).Value
                txtFirstnamePatient.Text = .Item("PatientFname", i).Value
                txtMiddlenamePatient.Text = .Item("PatientMname", i).Value
                txtLastnamePatient.Text = .Item("PatientLname", i).Value
                cboBloodTypePatient.Text = .Item("PatientBloodType", i).Value
                txtDiseasePatient.Text = .Item("PatientDisease", i).Value
                txtBirthdatePatient.Text = .Item("PatientBirthdate", i).Value
                txtAgePatient.Text = .Item("PatientAge", i).Value
                txtHeightPatient.Text = .Item("PatientHeight", i).Value
                txtWeightPatient.Text = .Item("PatientWeight", i).Value
                txtAddressPatient.Text = .Item("Address", i).Value
                txtCityPatient.Text = .Item("City", i).Value
                txtZipPatient.Text = .Item("Zip", i).Value
                txtContactPersonPatient.Text = .Item("PatientContactPerson", i).Value
                txtContactPersonNumber.Text = .Item("PatientContactNo", i).Value
                cboStatusPatient.Text = .Item("IsActive", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick()" & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddPatient.Visible = False
        btnUpdatePatient.Visible = True
        btnDeletePatient.Visible = True
    End Sub

    'Addition of Donation
    Private Sub btnAddDonation_Click(sender As Object, e As EventArgs) Handles btnAddDonation.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO donations (DonorID, DateDonated, DonationType, BProduct_Donated, Units, Status)" +
            "VALUES ('" & cboDonorID.SelectedValue & "',
            '" & dtpDonation.Value.ToString("yyyy-M-d") & "',
            '" & cboDonationType.Text & "',
            '" & cboProductDonated.Text & "',
            '" & txtUnits.Text & "',
            '" & cboStatusDonation.Text & " ')"
            SQLManager(strQuery, "Record saved.")
            lblDonationID.Text = RecordCountDonation() + 1

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "2" & "', '" & UserID & "', '" & "Donation" & "', '" & "Donation Added" & "')"
            Audit(strQuery)
            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboDonorID.Text = ""
        dtpDonation.ResetText()
        cboDonationType.Text = ""
        cboProductDonated.Text = ""
        txtUnits.Clear()
        cboStatusDonation.Text = ""
        strQuery = "SELECT * FROM donations ORDER BY DonationID"
        DisplayRecords(strQuery, dgDonations)
        btnAddDonation.Visible = True
        btnUpdateDonation.Visible = False
        btnDeleteDonation.Visible = False

    End Sub

    'Update of Donation
    Private Sub btnUpdateDonation_Click(sender As Object, e As EventArgs) Handles btnUpdateDonation.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE donations SET DateDonated = '" & dtpDonation.Value.ToString("yyyy-M-d") & "',
                                             DonorID = '" & cboDonorID.Text & "',
                                             DonationType ='" & cboDonationType.Text & "',
                                             BProduct_Donated = '" & cboProductDonated.Text & "',
                                             Units = '" & txtUnits.Text & "',
                                             Status = '" & cboStatusDonation.Text & "'
                                             Where DonationID = " & lblDonationID.Text & ""
            SQLManager(strQuery, "Donation Updated")

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "3" & "', '" & UserID & "', '" & "Donation" & "', '" & "Donation Updated" & "')"
            Audit(strQuery)
            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboDonorID.Text = ""
        dtpDonation.ResetText()
        cboDonationType.Text = ""
        cboProductDonated.Text = ""
        txtUnits.Clear()
        cboStatusDonation.Text = ""
        strQuery = "SELECT * FROM donations ORDER BY DonationID"
        DisplayRecords(strQuery, dgDonations)
        btnAddDonation.Visible = True
        btnUpdateDonation.Visible = False
        btnDeleteDonation.Visible = False
    End Sub

    'Delete of Donation
    Private Sub btnDeleteDonation_Click(sender As Object, e As EventArgs) Handles btnDeleteDonation.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM donations WHERE DonationID = '" & lblDonationID.Text & "'"
            del = MessageBox.Show("Delete this record?", "Delete Record", MessageBoxButtons.YesNo)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "Record Deleted")
                strQuery = "SELECT * FROM donations ORDER BY DonationID"
                DisplayRecords(strQuery, dgDonations)

                strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "4" & "', '" & UserID & "', '" & "Donation" & "', '" & "Donation Deleted" & "')"
                Audit(strQuery)
                strQuery = "SELECT * FROM auditlogs ORDER BY logID"
                DisplayRecords(strQuery, dgAuditLog)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Delete() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboDonorID.Text = ""
        dtpDonation.ResetText()
        cboDonationType.Text = ""
        cboProductDonated.Text = ""
        txtUnits.Clear()
        cboStatusDonation.Text = ""
        btnAddDonation.Visible = True
        btnUpdateDonation.Visible = False
        btnDeleteDonation.Visible = False
    End Sub

    'Search feature of Donation
    Private Sub txtSearchDonation_TextChanged(sender As Object, e As EventArgs) Handles txtSearchDonation.TextChanged
        Dim strQuery As String
        Try
            If txtSearchDonation.Text = "" Then
                strQuery = "SELECT * FROM donations ORDER BY DonationID"
                DisplayRecords(strQuery, dgDonations)
            Else
                strQuery = "SELECT * FROM donations WHERE DonationID= '" & txtSearchDonation.Text & "' OR 
            DonationType= '" & txtSearchDonation.Text & "' OR Status='" & txtSearchDonation.Text & "' 
            ORDER BY DonationID"
                DisplayRecords(strQuery, dgDonations)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Datagrid click of Donation
    Private Sub dgDonations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDonations.CellClick
        Dim i As Integer = e.RowIndex
        Try
            With dgDonations
                lblDonationID.Text = .Item("DonationID", i).Value
                cboDonationType.Text = .Item("DonationType", i).Value
                dtpDonation.Text = CDate(.Item("DateDonated", i).Value)
                cboDonorID.Text = .Item("DonorID", i).Value
                cboProductDonated.Text = .Item("BProduct_Donated", i).Value
                txtUnits.Text = .Item("Units", i).Value
                cboStatusDonation.Text = .Item("Status", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick()" & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddDonation.Visible = False
        btnUpdateDonation.Visible = True
        btnDeleteDonation.Visible = True
    End Sub

    'Search feature of bloodproducts table
    Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProduct.TextChanged
        Dim strQuery As String
        Try
            If txtSearchProduct.Text = "" Then
                strQuery = "SELECT * FROM bloodproduct ORDER BY ProductID"
                DisplayRecords(strQuery, dgProducts)
            Else
                strQuery = "SELECT * FROM bloodproduct WHERE ProductID = '" & txtSearchProduct.Text & "' OR 
                    ProductName = '" & txtSearchProduct.Text & "' OR BloodType = '" & txtSearchProduct.Text & "' 
                    ORDER BY ProductID"
                DisplayRecords(strQuery, dgProducts)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Donation feature: When whole blood is selected the only product available is whole blood
    'When apheresis is selected: Only available blood product are: RBC, Platelets, Plasma
    Private Sub cboDonationType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDonationType.SelectedValueChanged
        cboProductDonated.Items.Clear()
        If cboDonationType.SelectedItem.ToString = "Whole blood" Then
            cboProductDonated.Items.Add("Whole blood")
        ElseIf cboDonationType.SelectedItem.ToString = "Apheresis" Then
            cboProductDonated.Items.Add("RBC(Red Blood Cells)")
            cboProductDonated.Items.Add("Plasma")
            cboProductDonated.Items.Add("Platelet")
        End If
    End Sub

    'TRANSACTION ADD
    Private Sub btnAddTrans_Click(sender As Object, e As EventArgs) Handles btnAddTrans.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO transactionrecords (`PatientID`, `TransactionDate`, `ProductID`,`NVBSPNumber`, 
            `Quantity`, `PaymentMethod`, `Total_Amount`, `CardNumber`, `CardOwner`,
            `PaymentNetwork`, `CreatedByID`,`CreatedDate`)" +
            "VALUES ('" & cboPatientID.Text & "',
            '" & dtpTrans.Value.ToString("yyyy-M-d hh:mm:ss") & "',
            '" & cboProductID.Text & "',
            '" & lblNVBSP.Text & "',
            '" & txtQuantityTrans.Text & "', 
            '" & cboPaymentMethod.SelectedItem & "',
            '" & lblTotalPrice.Text & "',
            '" & txtCardNumber.Text & "',
            '" & txtCardOwner.Text & "',
            '" & cboPaymentNetwork.SelectedItem & "',
            '" & UserID & "',
            '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "')"
            SQLManager(strQuery, "Record saved.")

            strQuery = "UPDATE stock_in SET InStore = Instore - '" & txtQuantityTrans.Text & "' 
                WHERE NVBSPNumber = '" & lblNVBSP.Text & "'"
            Audit(strQuery)
        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "2" & "', '" & UserID & "', '" & "Transaction" & "', '" & "Transaction Added" & "')"
        Audit(strQuery)
        strQuery = "SELECT * FROM auditlogs ORDER BY logID"
        DisplayRecords(strQuery, dgAuditLog)
        cboPatientID.Text = ""
        dtpTrans.ResetText()
        cboProductID.Text = ""
        lblNVBSP.Text = ""
        txtQuantityTrans.Clear()
        cboPaymentMethod.Text = ""
        lblTotalPrice.Text = ""
        txtCardNumber.Clear()
        txtCardOwner.Clear()
        cboPaymentNetwork.Text = ""
        strQuery = "SELECT * FROM transactionrecords ORDER BY TransactionID"
        DisplayRecords(strQuery, dgTransaction)
    End Sub

    'TRANSACTION UPDATE
    Private Sub btnUpdateTrans_Click(sender As Object, e As EventArgs) Handles btnUpdateTrans.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE transactionrecords SET PatientID = '" & cboPatientID.Text & "',
                                             TransactionDate = '" & dtpTrans.Value.ToString("yyyy-MM-dd hh:mm:ss") & "',
                                             ProductID = '" & cboProductID.Text & "',
                                             NVBSPNumber= '" & lblNVBSP.Text & "',
                                             Quantity = '" & txtQuantityTrans.Text & "',
                                             PaymentMethod = '" & cboPaymentMethod.SelectedItem & "',
                                             Total_Amount = '" & lblTotalPrice.Text & "',
                                             PaymentNetwork = '" & cboPaymentNetwork.SelectedItem & "',
                                             CardNumber = '" & txtCardNumber.Text & "',
                                             CardOwner = '" & txtCardOwner.Text & "',
                                             LastModifiedByID = '" & UserID & "',
                                             LastModifiedDate = '" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "'
                                             Where TransactionID = '" & index & "'"
            SQLManager(strQuery, "Transaction Updated")

            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "3" & "', '" & UserID & "', '" & "Transaction" & "', '" & "Transaction Updated" & "')"
            Audit(strQuery)
            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboPatientID.Text = ""
        dtpTrans.ResetText()
        cboProductID.Text = ""
        lblNVBSP.Text = ""
        txtQuantityTrans.Clear()
        cboPaymentMethod.Text = ""
        lblTotalPrice.Text = ""
        txtCardNumber.Clear()
        txtCardOwner.Clear()
        cboPaymentNetwork.Text = ""
        strQuery = "SELECT * FROM transactionrecords ORDER BY TransactionID"
        DisplayRecords(strQuery, dgTransaction)
    End Sub

    'Search feature of transaction
    Private Sub dgTransaction_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransaction.CellContentClick
        Dim i As Integer = e.RowIndex
        Try
            With dgTransaction
                index = .Item("TransactionID", i).Value
                cboPatientID.Text = .Item("PatientID", i).Value
                dtpTrans.Text = CDate(.Item("TransactionDate", i).Value)
                cboProductID.Text = .Item("ProductID", i).Value
                lblNVBSP.Text = .Item("NVBSPNumber", i).Value
                txtQuantityTrans.Text = .Item("Quantity", i).Value
                cboPaymentMethod.Text = .Item("PaymentMethod", i).Value
                lblTotalPrice.Text = .Item("Total_Amount", i).Value
                txtCardNumber.Text = .Item("CardNumber", i).Value
                txtCardOwner.Text = .Item("CardOwner", i).Value
                cboPaymentNetwork.Text = .Item("PaymentNetwork", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick()" & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddTrans.Visible = False
        btnUpdateTrans.Visible = True
    End Sub

    'Search feature of transaction
    Private Sub txtSearchTrans_TextChanged(sender As Object, e As EventArgs) Handles txtSearchTrans.TextChanged
        Dim strQuery As String
        Try
            If txtSearchTrans.Text = "" Then
                strQuery = "SELECT * FROM transactionrecords ORDER BY TransactionID"
                DisplayRecords(strQuery, dgTransaction)
            Else
                strQuery = "SELECT * FROM transactionrecords WHERE TransactionID = '" & txtSearchTrans.Text & "' OR 
                    PatientID = '" & txtSearchProduct.Text & "' OR ProductID = '" & txtSearchProduct.Text & "' 
                    ORDER BY TransactionID"
                DisplayRecords(strQuery, dgTransaction)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtQuantityTrans_TextChanged(sender As Object, e As EventArgs)
        txtQuantityTrans.SelectAll()
    End Sub

    'Calculate feature in Transaction
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim intcode As Integer

        Integer.TryParse(txtQuantityTrans.Text, intcode)
        Call CalculateBlood(cboProductID.Text)
        lblNVBSP.Text = OldestProductFinder(cboProductID.Text).ToString
        totalamount = Total * intcode
        lblTotalPrice.Text = totalamount.ToString("c2")
    End Sub

    'Logout
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim strQuery As String
        strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "6" & "', '" & UserID & "', '" & "Logout" & "', '" & "Log out" & "')"
        Audit(strQuery)
        Me.Close()
        login.Show()
    End Sub

    'Create feature of stock_in
    Private Sub btnAddStock_Click(sender As Object, e As EventArgs) Handles btnAddStock.Click
        Dim i As Integer = cboProductIDStockIn.SelectedItem
        Dim d As Date = CDate(txtDateCollected.Text).ToString("yyyy-M-d")
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO stock_in (ProductID, InStore, DateCollected,
                DatetobeDisposed,AddedByID)
                VALUES(
                '" & cboProductIDStockIn.SelectedItem & "',
                '" & txtAddStock.Text & "',
                '" & CDate(txtDateCollected.Text).ToString("yyyy-MM-dd") & "',
                '" & CDate(DateAdder(i, d)).ToString("yyyy-MM-dd") & "',
                '" & UserID & "')"
            SQLManager(strQuery, "Stock Added")
            cboProductID.Text = ""
            txtAddStock.Clear()
            txtDateCollected.Clear()
            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "2" & "', '" & UserID & "', '" & "Stock In" & "', '" & "Stock Added" & "')"
            Audit(strQuery)

            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Add() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT NVBSPNumber, stock_in.ProductID ,bloodproduct.ProductName, InStore, DateCollected, 
                DatetobeDisposed,AddedById
                FROM stock_in INNER JOIN bloodproduct WHERE stock_in.ProductID = bloodproduct.ProductID
                ORDER BY NVBSPNumber"
        DisplayRecords(strQuery, dgStockIn)
    End Sub

    'Delete feature of stock_in
    Private Sub btnRemoveStock_Click(sender As Object, e As EventArgs) Handles btnRemoveStock.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM stock_in WHERE NVBSPNumber = '" & lblNVBSPNumber.Text & "'"
            del = MessageBox.Show("Delete this record?", "Delete Record", MessageBoxButtons.YesNo)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "Record Deleted")
            End If
            strQuery = "INSERT INTO auditlogs (logtype, UserID, LogModule, logComment) 
                        VALUES ('" & "4" & "', '" & UserID & "', '" & "Stock In" & "', '" & "Stock Deleted" & "')"
            Audit(strQuery)

            strQuery = "SELECT * FROM auditlogs ORDER BY logID"
            DisplayRecords(strQuery, dgAuditLog)
        Catch ex As Exception
            MessageBox.Show("Error: Delete() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT NVBSPNumber, stock_in.ProductID , bloodproduct.ProductName, InStore, DateCollected, 
                DatetobeDisposed, AddedById
                FROM stock_in INNER JOIN bloodproduct WHERE stock_in.ProductID = bloodproduct.ProductID
                ORDER BY NVBSPNumber"
        DisplayRecords(strQuery, dgStockIn)
    End Sub

    'Search of stock_in
    Private Sub txtSearchStockIn_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStockIn.TextChanged
        Dim strQuery As String
        Try
            If txtSearchStockIn.Text = "" Then
                strQuery = "SELECT NVBSPNumber, stock_in.ProductID , bloodproduct.ProductName, InStore, DateCollected, 
                DatetobeDisposed, AddedById,LastModifiedById, LastModifiedDate
                FROM stock_in INNER JOIN bloodproduct WHERE stock_in.ProductID = bloodproduct.ProductID ORDER BY NVBSPNumber"
                DisplayRecords(strQuery, dgStockIn)
            Else
                strQuery = "SELECT NVBSPNumber, stock_in.ProductID ,bloodproduct.ProductName, InStore, DateCollected, 
                DatetobeDisposed, AddedById,LastModifiedById, LastModifiedDate
                FROM stock_in INNER JOIN bloodproduct WHERE stock_in.ProductID = bloodproduct.ProductID 
                AND NVBSPNumber= '" & txtSearchStockIn.Text & "'"
                DisplayRecords(strQuery, dgStockIn)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Retrieves values from the stock_in datagrid
    Private Sub dgStockIn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockIn.CellContentClick
        Dim i As Integer
        i = e.RowIndex
        Try
            With dgStockIn
                lblNVBSPNumber.Text = .Item("NVBSPNumber", i).Value
                cboProductIDStockIn.Text = .Item("ProductID", i).Value
                txtAddStock.Text = .Item("InStore", i).Value
                txtDateCollected.Text = .Item("DateCollected", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick()" & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Feature in transaction that when cash is selected, card option disappears
    Private Sub cboPaymentMethod_SelectedTextChange(sender As Object, e As EventArgs) Handles cboPaymentMethod.TextChanged
        If cboPaymentMethod.Text = "Cash" Then
            txtCardOwner.Visible = False
            txtCardNumber.Visible = False
            cboPaymentNetwork.Visible = False
            Label31.Visible = False
            Label51.Visible = False
            Label30.Visible = False
            Label29.Visible = False
        Else
            txtCardOwner.Visible = True
            txtCardNumber.Visible = True
            cboPaymentNetwork.Visible = True
            Label31.Visible = True
            Label51.Visible = True
            Label30.Visible = True
            Label29.Visible = True
        End If
    End Sub

    'Calculates the price of blood
    Private Sub CalculateBlood(ByVal Str As String)
        Dim dblBlood As Double
        Dim ProdID As Integer
        Integer.TryParse(Str, ProdID)

        Select Case ProdID
            Case 1 To 8
                dblBlood = 1500.0
            Case 9 To 16
                dblBlood = 1000.0
            Case 17 To 24
                dblBlood = 1000.0
            Case 25 To 32
                dblBlood = 1000.0
            Case 33 To 40
                dblBlood = 700.0
            Case 41 To 48
                dblBlood = 700.0
        End Select
        Total = dblBlood
    End Sub

End Class
