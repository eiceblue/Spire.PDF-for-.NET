Imports System.IO
Imports System.Text
Imports Spire.Pdf

Namespace DocumentAndPagePieceDictionaries
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Specify the path of the input PDF file
            Dim input As String = "..\..\..\..\..\..\Data\DocumentAndPagePieceDictionaries.pdf"

            ' Load the PDF document from the specified path
            pdf.LoadFromFile(input)

            ' * Add piece dictionaries into a document  * 

            ' Check if the document's piece information is null
            If pdf.DocumentPieceInfo Is Nothing Then
                ' If it is null, create a new PdfPieceInfo object and assign it to the document's PieceInfo property
                pdf.DocumentPieceInfo = New PdfPieceInfo()
            End If

            ' Add application data to the document's piece information
            pdf.DocumentPieceInfo.AddApplicationData("ice", "E-iceblue-ice")
            pdf.DocumentPieceInfo.AddApplicationData("blue", "E-iceblue-blue")
            pdf.DocumentPieceInfo.AddApplicationData("Blue", "E-iceblue-Blue")
            pdf.DocumentPieceInfo.AddApplicationData("Ice", "E-iceblue-Ice")

            ' Remove the application data with key "blue" from the document's piece information
            pdf.DocumentPieceInfo.RemoveApplicationData("blue")


            ' * Add piece dictionaries into a page * 

            ' Check if the page's piece information is null
            If pdf.Pages(0).PagePieceInfo Is Nothing Then
                ' If it is null, create a new PdfPieceInfo object and assign it to the page's PieceInfo property
                pdf.Pages(0).PagePieceInfo = New PdfPieceInfo()
            End If

            ' Add application data to the page's piece information
            pdf.Pages(0).PagePieceInfo.AddApplicationData("ice", "E-iceblue-ice")
            pdf.Pages(0).PagePieceInfo.AddApplicationData("blue", "E-iceblue-blue")
            pdf.Pages(0).PagePieceInfo.AddApplicationData("Blue", "E-iceblue-Blue")
            pdf.Pages(0).PagePieceInfo.AddApplicationData("Ice", "E-iceblue-Ice")

            ' Remove the application data with key "Ice" from the page's piece information
            pdf.Pages(0).PagePieceInfo.RemoveApplicationData("Ice")

            ' Get the dictionary of application datas from the document's piece information and save it to a file named "documentPieceDictionary.txt"
            getDictionary(pdf.DocumentPieceInfo.ApplicationDatas, "documentPieceDictionary.txt")

            ' Get the dictionary of application datas from the page's piece information and save it to a file named "pagePieceDictionary.txt"
            getDictionary(pdf.Pages(0).PagePieceInfo.ApplicationDatas, "pagePieceDictionary.txt")

            ' Save the modified PDF document to a file named "DocumentAndPagePieceDictionaries-result.pdf"
            pdf.SaveToFile("DocumentAndPagePieceDictionaries-result.pdf")

            ' Close the PDF document
            pdf.Close()

            'Launch the Pdf file
            FileViewer("DocumentAndPagePieceDictionaries-result.pdf")

            'Launch the .txt files
            FileViewer("documentPieceDictionary.txt")
            FileViewer("pagePieceDictionary.txt")
        End Sub

        Private Sub getDictionary(ByVal dic As IDictionary(Of String, PdfApplicationData), ByVal fileName As String)
            Dim sb As New StringBuilder()
            'Traverse all keys in the dictionary
            For Each item As String In dic.Keys
                Dim data As PdfApplicationData = dic(item)
                If TypeOf data.Private Is String Then
                    'Get the value and append it to StringBuilder
                    Dim ss As String = TryCast(data.Private, String)
                    sb.AppendLine(ss)
                End If
            Next item
            'Wirte the text of StringBuilder to file
            File.WriteAllText(fileName, sb.ToString())
        End Sub

        Private Sub FileViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
