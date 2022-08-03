VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ThisDocument"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
Sub RunMacro()

    Dim Hui ' Create some variables ~!~
    Dim tablenum As Integer
    tablenum = ActiveDocument.Tables.Count ' Count tables in doc.. ~
    
    Dim Fso As Object, objFolder As Object, objSubFolder As Object ' more variables.. ~
    Dim FromPath As String
    Dim FileInFolder As Object
    
    FromPath = ActiveDocument.Path + "\pictures\" ' path to picture dir ..~
    Set Fso = CreateObject("Scripting.filesystemobject")
    Set objFolder = Fso.GetFolder(FromPath)
    
    For Each objSubFolder In objFolder.subfolders ' loop through all your folders ~
        AddTable ' create table for each folder

        For Each FileInFolder In objSubFolder.Files ' loop through all files in folder
            tablenum = ActiveDocument.Tables.Count
            currentfolder = Mid(objSubFolder, InStrRev(objSubFolder, "\") + 1) ' current folder name
            ActiveDocument.Tables(tablenum).Cell(1, 1).Range.Text = currentfolder ' table name to folder name
            Set Hui = ActiveDocument.Tables(tablenum).Cell(2, 1).Range.InlineShapes.AddPicture(FileName:=FileInFolder, _
                            LinkToFile:=False, _
                            SaveWithDocument:=True) ' add image
            With Hui ' some changes to image size
                'this will keep ratio
                .LockAspectRatio = msoTrue
                'this will adjust width to 3 inch ~
                .Width = InchesToPoints(3)
        End With
        
        Next FileInFolder
    Next objSubFolder
    
    BorderMacro

End Sub  ' end! :)

Function AddTable() ' create a table (copies from temp)

    Dim doc As Word.Document
    Dim rngTableTarget As Word.Range
    Set doc = ActiveDocument
    Set rngTableTarget = doc.Content
    
    
    Dim tempPath As String
    tempPath = ActiveDocument.Path & "\template\temp.docx"
    
    Set x = Application.Documents.Open(tempPath, ReadOnly:=True, Visible:=False)
    
    Dim tbl As Table
    Set tbl = x.Tables(1)
    
    rngTableTarget.Start = doc.Content.End
    rngTableTarget.FormattedText = tbl.Range.FormattedText

    x.Close
    Set x = Nothing
    
    Selection.EndKey Unit:=wdStory
    rngTableTarget.Start = doc.Content.End
    Selection.TypeParagraph
    
    
End Function

Function BorderMacro() ' border to all images in doc
Dim oInlineShp As InlineShape
For Each oInlineShp In ActiveDocument.InlineShapes
    With oInlineShp
        With .Borders(wdBorderLeft)
            .LineStyle = wdLineStyleSingle
            .LineWidth = wdLineWidth100pt
            .Color = wdColorAutomatic
        End With
        With .Borders(wdBorderRight)
            .LineStyle = wdLineStyleSingle
            .LineWidth = wdLineWidth100pt
            .Color = wdColorAutomatic
        End With
        With .Borders(wdBorderTop)
            .LineStyle = wdLineStyleSingle
            .LineWidth = wdLineWidth100pt
            .Color = wdColorAutomatic
        End With
        With .Borders(wdBorderBottom)
            .LineStyle = wdLineStyleSingle
            .LineWidth = wdLineWidth100pt
            .Color = wdColorAutomatic
        End With
'        .Borders.Shadow = True
    End With
    With Options
        .DefaultBorderLineStyle = wdLineStyleSingle
        .DefaultBorderLineWidth = wdLineWidth100pt
        .DefaultBorderColor = wdColorAutomatic
    End With
Next
End Function
