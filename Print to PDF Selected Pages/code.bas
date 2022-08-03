Attribute VB_Name = "Module1"
Sub acrobat_read_pdf()
    

    
    Dim file As String
    Dim printarg As String
    Dim page As String
    
    ' Dim result As Boolean
    
    file = "C:\Users\Jonny\Desktop\Documents\DOH.pdf"
    
    page = Cells(2, 2).Value
    
    
    Shell "C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe /A ""page=" & page & "=OpenActions"" """ & file & """", vbNormalFocus
    
    

End Sub

Sub iPrint()
    Dim lRow As Long
    Dim searchVal As Integer
    Dim counter As Integer
    Dim lPage As Integer
    Dim originSearchVal As Integer
    Dim first As String
    Dim second As String
    
    lRow = Cells(Rows.Count, 3).End(xlUp).Row
    searchVal = 4
    originSearchVal = 4
    couter = 0
    
   Dim found As Boolean
   found = False
   
   For k = 1 To 30
     For i = 1 To lRow
        If searchVal = Cells(i, 3) Then
            found = True
            Exit For
        End If
        
      Next i
        If found = False Then
            counter = counter + 1
            searchVal = searchVal + 1
        Else
            Exit For
        End If

    Next k
      
      second = CStr(originSearchVal + counter)
       first = CStr(originSearchVal)
        test = "2"
        
   Call Shell("cmd.exe /S /C" & "cd " + ActiveWorkbook.Path + " & PDFtoPrinter file.pdf pages=" + first + "-" + second, vbNormalFocus)
    

End Sub

