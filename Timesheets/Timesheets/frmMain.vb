Imports System.IO
Imports itextsharp.text.pdf
Imports itextsharp.text
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmMain

    ' *****************************************
    ' Timesheets
    ' Author: Edward Lay
    ' Date: 26/7/17
    ' Written in Visual Basic 2015
    ' For SAT
    ' *****************************************

    ' Declare variables for each field in file to store each record
    Dim dates As New List(Of DateTime)
    Dim times As New List(Of DateTime)
    Dim descriptions As New List(Of String)
    Dim users As New List(Of String)
    Dim doors As New List(Of String)

    ' Declare temporary variables to store each record for a user per day
    Dim userTimes As New List(Of DateTime)
    Dim userDescriptions As New List(Of String)
    Dim userDoors As New List(Of String)

    ' Declare variables to store the individual dates and users
    Dim uniqueDates As New List(Of DateTime)
    Dim uniqueUsers As New List(Of String)

    ' Declare variable to store the total hours of each user
    Dim usersHours As New Dictionary(Of String, TimeSpan)

    Dim counter As Integer

    Dim init As Boolean = False

    Dim userRecords As New List(Of String)
    Dim hoursRecords As New List(Of TimeSpan)

    Dim valid As Boolean = True

    Dim totalHoursString As String

    ' Code for reading the file and storing its contents in variables
    Private Sub read()

        Dim sr As New StreamReader(dlgOpen.FileName)

        Dim contents As String
        Dim file() As String
        Dim fields() As String

        sr.ReadLine() ' Skip first line to ignore field names
        contents = sr.ReadToEnd ' Read rest of file

        file = contents.Split(vbNewLine) ' Split file contents by newline character

        ' Read data and store in lists
        For Each line In file

            If line <> "" Then

                fields = line.Split(",") ' Split line by commas

                If IsDate(fields(0)) = False Then

                    MsgBox("Invalid date:" & fields(0))
                    valid = False

                End If

                If IsDate(fields(1)) = False Then

                    MsgBox("Invalid time:" & fields(1))
                    valid = False

                End If

                If valid = False Then

                    sr.Close()
                    reset()
                    Exit Sub

                End If

                dates.Add(fields(0))
                times.Add(fields(1))
                descriptions.Add(fields(2))
                users.Add(fields(3))
                doors.Add(fields(4))

                ' Check to add only different dates
                If uniqueDates.Contains(fields(0)) = False Then

                    uniqueDates.Add(fields(0))

                End If

                ' Check to add only different users and not empty users
                If uniqueUsers.Contains(fields(3)) = False And fields(3) <> "" Then

                    uniqueUsers.Add(fields(3))

                    ' Populate usersHours and lstSelectUser with uniqueUsers
                    usersHours(fields(3)) = TimeSpan.Zero
                    lstSelectUser.Items.Add(fields(3))

                End If

            End If

        Next

        sr.Close()

    End Sub

    ' Code to clear and repopulate userHours
    Private Sub clearUsersHours()

        usersHours.Clear()

        For Each user In uniqueUsers

            usersHours(user) = TimeSpan.Zero

        Next

    End Sub

    ' Code for getting the total hours worked for each day within the selected range per user
    Private Sub process(startDate As Date, endDate As Date)

        Dim hours As TimeSpan = TimeSpan.Zero

        For Each _date In uniqueDates

            ' Check if the date is within the range. Note: if range is negative, then all users will have zero hours
            If _date >= startDate And _date <= endDate Then

                For Each user In uniqueUsers

                    hours = getHours(user, _date)

                    ' Add to the user' s hours
                    usersHours(user) += hours

                Next

            End If

        Next

    End Sub

    ' Code for filtering by user and by day
    Private Sub byUser(targetUser, targetDate)

        ' Clear the temporary daily per user data
        userTimes.Clear()
        userDescriptions.Clear()
        userDoors.Clear()

        Dim pos As Integer

        ' Filter users and populate the temporary per user data
        For Each user In users

            If users(pos) = targetUser And dates(pos) = targetDate Then

                ' Check if the user opened the door
                If doorOpenCheck(pos) = True Then

                    userTimes.Add(times(pos))
                    userDescriptions.Add(descriptions(pos))
                    userDoors.Add(doors(pos))

                End If

                ' End If

            End If

            ' Store the current index in users
            pos += 1

        Next

    End Sub

    ' Code for checking if the door has been opened
    Private Function doorOpenCheck(pos)

        Dim doorOpened As Boolean = False

        Dim index As Integer = pos + 1

        ' Check if the user scanned again
        While users(index) = ""

            ' If not, check if the door is opened
            For Each description In descriptions.Skip(pos + 1)

                If description.StartsWith("Door") And description.EndsWith("Opened ") Then

                    doorOpened = True

                    Exit While

                End If

                ' Store the current index in descriptions
                index += 1

            Next

        End While

        Return doorOpened

    End Function

    ' Code to add any users who have not scanned out to the list view
    Private Sub generatelstFlag(targetUser, targetDate)

        If init = False Then

            lstFlag.Items.Add(targetUser)
            lstFlag.Items(counter).SubItems.Add(targetDate)

        End If

    End Sub

    ' Code for calculating the total hours worked each day per user
    Private Function getHours(targetUser, targetDate)

        ' Filter by the target user and date
        byUser(targetUser, targetDate)

        ' Default hours = 0
        Dim hours As TimeSpan = TimeSpan.Zero

        ' Check if the user went to work at all on that day
        If userTimes.Count <> 0 Then

            ' Check if the number of times is odd
            If userTimes.Count Mod 2 <> 0 Then

                ' Find the time difference between consecutive pairs of times in userTimes
                For loops = 0 To userTimes.Count - 1 Step 2

                    Try

                        hours += userTimes(loops + 1) - userTimes(loops)

                    Catch ex As ArgumentOutOfRangeException ' This will subtract the last time of the user from the endOfDay or endWorkingHours time

                        generatelstFlag(targetUser, targetDate)

                        counter += 1

                        hours = TimeSpan.Parse("07:36:00")

                    End Try

                Next

            Else

                ' Find the time difference between consecutive pairs of times in userTimes
                For loops = 0 To userTimes.Count - 1 Step 2

                    hours += userTimes(loops + 1) - userTimes(loops)

                Next

            End If

        End If

        Return hours

    End Function

    ' Code to format the timespan values in hours and minutes
    Private Function formatHours(duration As TimeSpan)

        Dim hours = duration.TotalHours
        Dim minutes = duration.TotalMinutes - (Int(hours) * 60)

        Return Int(hours) & " hrs " & Math.Ceiling(minutes) & " mins"

    End Function

    ' Code to format the timespan values in hours and minutes for display on the graph
    Private Function formatHoursGraph(duration As TimeSpan)

        Dim hours = duration.TotalHours
        Dim minutes = duration.TotalMinutes - (Int(hours) * 60)

        Return Int(hours) & " hrs " & vbNewLine & Math.Ceiling(minutes) & " mins"

    End Function

    ' Get the total hours of all users within the selected range of days
    Private Sub getTotalHours()

        Dim totalHours As TimeSpan = TimeSpan.Zero

        For Each user As KeyValuePair(Of String, TimeSpan) In usersHours

            totalHours += user.Value

        Next

        totalHoursString = formatHours(totalHours)

    End Sub

    ' Code for displaying the results
    Private Sub displayHours(targetUser)

        userRecords = usersHours.Keys.ToList
        hoursRecords = usersHours.Values.ToList

        '  Create new Stopwatch instance.
        Dim watch As Stopwatch = Stopwatch.StartNew()

        quickSort(userRecords, hoursRecords, 0, hoursRecords.Count - 1)

        watch.Stop()
        Console.WriteLine(watch.Elapsed.TotalMilliseconds & " milliseconds was taken")

        graph()

        getTotalHours()

        ' Check if the selected user in lstSelectUser is All Users
        If targetUser = "All Users" Then

            lblHoursWorked.Text = totalHoursString

        Else

            ' Get and display the hours of the select user in lstSelectUser
            lblHoursWorked.Text = formatHours(usersHours(targetUser))

        End If

    End Sub

    ' Code to get the hours for the selected user in lstSelectUser
    Private Sub lstSelectUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSelectUser.SelectedIndexChanged

        displayHours(lstSelectUser.SelectedItem)
        lblSelectedUser.Text = lstSelectUser.SelectedItem

    End Sub

    ' Code to enable calculations for a range of dates and will pre-calculate the hours for the last selected range of dates
    Private Sub chkDateSpecific_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateSpecific.CheckedChanged

        If chkDateSpecific.Checked = True Then

            dtpStartDate.Enabled = True
            dtpEndDate.Enabled = True

            ' Update the hours of the selected user for a specified range of dates
            dtpStartDate_ValueChanged(sender, e)

        Else

            dtpStartDate.Enabled = False
            dtpEndDate.Enabled = False

            ' Update the hours of the selected user for all dates
            clearUsersHours()
            process(#1/1/0001#, #12/31/9999#)
            displayHours(lstSelectUser.SelectedItem)

        End If

    End Sub

    ' Code to run calculations when the start date is changed for the range
    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged

        If dtpEndDate.Enabled = True Then

            clearUsersHours()
            process(dtpStartDate.Value.Date, dtpEndDate.Value.Date)
            displayHours(lstSelectUser.SelectedItem)

        End If

    End Sub

    ' Code to run calculations when the end date is changed for the range
    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged

        If dtpStartDate.Enabled = True Then

            clearUsersHours()
            process(dtpStartDate.Value.Date, dtpEndDate.Value.Date)
            displayHours(lstSelectUser.SelectedItem)

        End If

    End Sub

    ' Code to exit the program when the close(x) button is clicked
    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Application.Exit()

    End Sub

    ' Code for sorting two lists using the quick sort algorithm
    Private Sub quickSort(keys, values, min, max)

        Dim random_number As New Random
        Dim pointer
        Dim pointer2
        Dim high As Integer
        Dim low As Integer
        Dim pivot As Integer

        ' If min >= max, the list contains 0 or 1 items so it is sorted.
        If min >= max Then Exit Sub

        ' Pick the dividing value.
        pivot = random_number.Next(min, max + 1)
        pointer = values(pivot)
        pointer2 = keys(pivot)

        ' Swap it to the front.
        values(pivot) = values(min)
        keys(pivot) = keys(min)

        low = min
        high = max

        Do

            ' Look down from high for a value < pointer
            Do While values(high) >= pointer

                high = high - 1
                If high <= low Then Exit Do

            Loop

            If high <= low Then

                values(low) = pointer
                keys(low) = pointer2
                Exit Do

            End If

            ' Swap the low and high values.
            values(low) = values(high)
            keys(low) = keys(high)

            ' Look up from low for a value >= pointer
            low = low + 1

            Do While values(low) < pointer

                low = low + 1
                If low >= high Then Exit Do

            Loop

            If low >= high Then

                low = high
                values(high) = pointer
                keys(high) = pointer2
                Exit Do

            End If

            ' Swap the high and low values.
            values(high) = values(low)
            keys(high) = keys(low)

        Loop

        ' Sort the two sublists.
        quickSort(keys, values, min, low - 1)
        quickSort(keys, values, low + 1, max)

    End Sub

    ' When the Export CSV button is clicked, prompt the user for a save location, then write out all user hours to a CSV file
    Private Sub muiSaveCSV_Click(sender As Object, e As EventArgs) Handles muiSaveCSV.Click

        If dlgSaveCSV.ShowDialog() = System.Windows.Forms.DialogResult.OK Then ' Only executes if file is selected

            Dim file As New StreamWriter(dlgSaveCSV.FileName)

            For loops = 0 To usersHours.Count - 1

                file.WriteLine(userRecords(loops) & "," & formatHours(hoursRecords(loops)))

            Next

            file.Close()

            Diagnostics.Process.Start(dlgSaveCSV.FileName)

        End If

    End Sub

    ' When the Export PDF Report button is clicked, prompt the user for a save location, then write out all user hours to a PDF file
    Private Sub muiSaveSummaryPDF_Click(sender As Object, e As EventArgs) Handles muiSaveSummaryPDF.Click

        If dlgSavePDF.ShowDialog() = System.Windows.Forms.DialogResult.OK Then ' Only executes if file is selected

            Dim line As String = ""
            Dim pdfDoc As New Document()
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(dlgSavePDF.FileName, FileMode.Create))

            pdfDoc.Open()

            Dim logo As Image = Image.GetInstance("logo.png")
            logo.ScalePercent(20)
            pdfDoc.Add(logo)

            Dim cb = pdfWrite.DirectContent
            Dim ct As New ColumnText(cb)

            Dim addressSection As New Phrase()
            Dim address As New Chunk("Address: ")
            address.Font.SetStyle(FontStyle.Bold)
            addressSection.Add(address)
            addressSection.Add("12/347 Bay Rd, Cheltenham VIC 3192" & vbNewLine)

            Dim phoneSection As New Phrase()
            Dim phone As New Chunk("Phone: ")
            phone.Font.SetStyle(FontStyle.Bold)
            phoneSection.Add(phone)
            phoneSection.Add("(03) 8676 5300" & vbNewLine)

            Dim websiteSection As New Phrase()
            Dim website As New Chunk("Website: ")
            website.Font.SetStyle(FontStyle.Bold)
            websiteSection.Add(website)
            websiteSection.Add("https://www.combitel.com.au/")

            ct.SetSimpleColumn(addressSection, 400, 800, 580, 350, 15, Element.ALIGN_LEFT)
            ct.SetSimpleColumn(phoneSection, 400, 800, 580, 350, 15, Element.ALIGN_LEFT)
            ct.SetSimpleColumn(websiteSection, 400, 800, 580, 350, 15, Element.ALIGN_LEFT)
            ct.Go()

            'adds a break
            pdfDoc.Add(New Paragraph(vbNewLine))
            pdfDoc.Add(New Paragraph(vbNewLine))

            Dim dateRange As String

            If chkDateSpecific.Checked = False Then

                dateRange = "All time"

            Else

                dateRange = dtpStartDate.Value.Date & " to " & dtpEndDate.Value.Date

            End If

            Dim headingSection0 As New Phrase()
            Dim heading0 As New Chunk("Date range: ")
            heading0.Font.SetStyle(FontStyle.Bold)
            headingSection0.Add(heading0)
            headingSection0.Add(dateRange)

            pdfDoc.Add(headingSection0)

            pdfDoc.Add(New Paragraph(vbNewLine))

            Dim headingSection1 As New Phrase()
            Dim heading1 As New Chunk("Employee Hours: ")
            heading1.Font.SetStyle(FontStyle.Bold)
            headingSection1.Add(heading1)

            pdfDoc.Add(headingSection1)

            'User hours summary table
            Dim userHoursTable As New PdfPTable(2)

            'makes the table 100% width of the pdf
            userHoursTable.WidthPercentage = 100

            'formatting for the table heading
            Dim usersCell As New PdfPCell(New Phrase("Name"))
            Dim hoursCell As New PdfPCell(New Phrase("Hours worked"))

            usersCell.Colspan = 1
            hoursCell.Colspan = 1

            usersCell.HorizontalAlignment = 1
            hoursCell.HorizontalAlignment = 1

            ' 0 = left ' 1 = centre ' 2 = right
            usersCell.BackgroundColor = BaseColor.LIGHT_GRAY
            hoursCell.BackgroundColor = BaseColor.LIGHT_GRAY

            usersCell.PaddingTop = 5
            usersCell.PaddingBottom = 8
            hoursCell.PaddingTop = 5
            hoursCell.PaddingBottom = 8

            userHoursTable.AddCell(usersCell)     '("Col 1 Row 1")
            userHoursTable.AddCell(hoursCell)      '("Col 2 Row 1")

            'adds the users to each row
            For loops = 0 To userRecords.Count - 1

                userHoursTable.AddCell(userRecords(loops))
                userHoursTable.AddCell(formatHours(hoursRecords(loops)))

            Next

            pdfDoc.Add(userHoursTable)

            pdfDoc.Add(New Paragraph(vbNewLine))

            'Total hours worked
            Dim totalHoursWorkedSection As New Phrase()
            Dim totalHoursWorked As New Chunk("Total hours worked: " & totalHoursString)
            totalHoursWorked.Font.SetStyle(FontStyle.Italic)
            totalHoursWorkedSection.Add(totalHoursWorked)

            pdfDoc.Add(totalHoursWorkedSection)

            'adds a break
            pdfDoc.Add(New Paragraph(vbNewLine))

            pdfDoc.Add(New Paragraph(New Chunk(New draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1))))

            pdfDoc.Add(New Paragraph(vbNewLine))

            Dim headingSection2 As New Phrase()
            Dim heading2 As New Chunk("Who did not scan out:")
            heading2.Font.SetStyle(FontStyle.Bold)
            headingSection2.Add(heading2)

            pdfDoc.Add(headingSection2)

            'User hours summary table
            Dim userNoScanTable As New PdfPTable(2)

            'makes the table 100% width of the pdf
            userNoScanTable.WidthPercentage = 100

            'formatting for the product table heading
            Dim usersNoScanCell As New PdfPCell(New Phrase("Name"))
            Dim dateNoScanCell As New PdfPCell(New Phrase("Date"))

            usersNoScanCell.Colspan = 1
            dateNoScanCell.Colspan = 1

            usersNoScanCell.HorizontalAlignment = 1
            dateNoScanCell.HorizontalAlignment = 1

            ' 0 = left ' 1 = centre ' 2 = right
            usersNoScanCell.BackgroundColor = BaseColor.LIGHT_GRAY
            dateNoScanCell.BackgroundColor = BaseColor.LIGHT_GRAY

            usersNoScanCell.PaddingTop = 5
            usersNoScanCell.PaddingBottom = 8
            dateNoScanCell.PaddingTop = 5
            dateNoScanCell.PaddingBottom = 8

            userNoScanTable.AddCell(usersNoScanCell)     '("Col 1 Row 1")
            userNoScanTable.AddCell(dateNoScanCell)      '("Col 2 Row 1")

            'adds the users to each row
            For loops = 0 To lstFlag.Items.Count - 1

                userNoScanTable.AddCell(lstFlag.Items(loops).Text)
                userNoScanTable.AddCell(lstFlag.Items(loops).SubItems(1).Text)

            Next

            pdfDoc.Add(userNoScanTable)

            pdfDoc.Add(New Paragraph(vbNewLine))

            'Total hours worked
            Dim totalDaysNoScanSection As New Phrase()
            Dim totalDaysNoScan As New Chunk("Total days not scanned out: " & lstFlag.Items.Count & " days")
            totalDaysNoScan.Font.SetStyle(FontStyle.Italic)
            totalDaysNoScanSection.Add(totalDaysNoScan)

            pdfDoc.Add(totalDaysNoScanSection)

            pdfDoc.Add(New Paragraph(vbNewLine))

            pdfDoc.Add(New Paragraph(New Chunk(New draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1))))

            pdfDoc.Add(New Paragraph(vbNewLine))

            Dim headingSection3 As New Phrase()
            Dim heading3 As New Chunk("Generated on: ")
            heading3.Font.SetStyle(FontStyle.Bold)
            headingSection3.Add(heading3)
            headingSection3.Add(Date.Now)

            pdfDoc.Add(headingSection3)

            pdfDoc.Close()

            Diagnostics.Process.Start(dlgSavePDF.FileName)

        End If

    End Sub

    'Code for displaying the user hours on the graph
    Private Sub graph()

        chtHours.Series(0).Points.Clear()

        For loops = 0 To hoursRecords.Count - 1

            chtHours.Series(0).Points.AddXY(userRecords(loops), hoursRecords(loops).TotalHours)
            chtHours.Series(0).Points(loops).Label = formatHoursGraph(hoursRecords(loops))
            chtHours.Series(0).Points(loops).AxisLabel = userRecords(loops)

        Next

        chtHours.ChartAreas(0).AxisX.Interval = 1
        chtHours.ChartAreas(0).AxisX.IsLabelAutoFit = True
        chtHours.ChartAreas(0).AxisX.LabelStyle.IsStaggered = True
        chtHours.ChartAreas(0).AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont

    End Sub

    'When an item is selected in the list view, search for that item and display it
    Private Sub lstFlag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFlag.SelectedIndexChanged

        lstSelectUser.SelectedItem = lstFlag.Items(lstFlag.FocusedItem.Index).Text
        If chkDateSpecific.Checked = False Then

            chkDateSpecific.Checked = True

        End If
        dtpStartDate.Value = lstFlag.Items(lstFlag.FocusedItem.Index).SubItems(1).Text
        dtpEndDate.Value = lstFlag.Items(lstFlag.FocusedItem.Index).SubItems(1).Text

    End Sub

    'When the about button is clicked, show the about form
    Private Sub muiAbout_Click(sender As Object, e As EventArgs) Handles muiAbout.Click

        frmAbout.ShowDialog()

    End Sub

    'Code for clearing all lists and the text of elements on the form
    Private Sub reset()

        chkDateSpecific.Checked = False
        tabControl.SelectedTab = tabHours
        dates.Clear()
        times.Clear()
        descriptions.Clear()
        users.Clear()
        doors.Clear()
        uniqueDates.Clear()
        uniqueUsers.Clear()
        usersHours.Clear()
        counter = 0
        init = False
        userRecords.Clear()
        hoursRecords.Clear()
        lstFlag.Items.Clear()
        lblHoursWorked.Text = 0
        lblSelectedUser.Text = ""
        chtHours.Series(0).Points.Clear()
        lstSelectUser.Items.Clear()
        lstSelectUser.Items.Add("All Users")
        totalHoursString = ""
        muiSaveCSV.Enabled = False
        muiSaveSummaryPDF.Enabled = False
        lstSelectUser.Enabled = False
        chkDateSpecific.Enabled = False
        tabControl.Enabled = False
        lstFlag.Enabled = False
        dtpStartDate.Value = Date.Now
        dtpEndDate.Value = Date.Now
        Me.Text = "Timesheets"

    End Sub

    ' Code to pre-calculate the hours for all users without a specified range of dates when a file is selected
    Private Sub muiOpen_Click(sender As Object, e As EventArgs) Handles muiOpen.Click

        If dlgOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then ' Only executes if file is selected

            reset()

            read()

            If valid = False Then

                valid = True
                Exit Sub

            End If

            Me.Text = "Timesheets - " & dlgOpen.SafeFileName

            muiSaveCSV.Enabled = True
            muiSaveSummaryPDF.Enabled = True
            lstSelectUser.Enabled = True
            chkDateSpecific.Enabled = True
            tabControl.Enabled = True
            lstFlag.Enabled = True

            process(#1/1/0001#, #12/31/9999#)

            ' Set the selected user in lstSelectUser to show All Users
            lstSelectUser.SelectedItem = lstSelectUser.Items(0)

            init = True

        End If

    End Sub

    'When the logout button is clicked, reset and hide the main form, then show the login form
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        reset()

        frmLogin.Show()
        Me.Hide()

    End Sub

    ' Show the change password form and hide the login form
    Private Sub muiChangePassword_Click(sender As Object, e As EventArgs) Handles muiChangePassword.Click

        frmChangePass.ShowDialog()

    End Sub

End Class
