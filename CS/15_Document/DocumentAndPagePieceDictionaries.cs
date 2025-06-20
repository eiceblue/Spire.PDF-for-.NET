using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;


namespace DocumentAndPagePieceDictionaries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of PdfDocument
            PdfDocument pdf = new PdfDocument();

            // Specify the input file path
            String input = @"..\..\..\..\..\..\Data\DocumentAndPagePieceDictionaries.pdf";

            // Load the PDF document from disk
            pdf.LoadFromFile(input);

            /**
             * Add piece dictionaries into a document 
             */

            // If the document piece info is null, create it
            if (pdf.DocumentPieceInfo == null)
            {
                pdf.DocumentPieceInfo = new PdfPieceInfo();
            }

            // Add key-value pairs to the document piece info
            pdf.DocumentPieceInfo.AddApplicationData("ice", "E-iceblue-ice");
            pdf.DocumentPieceInfo.AddApplicationData("blue", "E-iceblue-blue");
            pdf.DocumentPieceInfo.AddApplicationData("Blue", "E-iceblue-Blue");
            pdf.DocumentPieceInfo.AddApplicationData("Ice", "E-iceblue-Ice");

            // Remove a value based on its key from the document piece info
            pdf.DocumentPieceInfo.RemoveApplicationData("blue");

            /**
             * Add piece dictionaries into a page
             */

            // If the piece info in the first page is null, create it
            if (pdf.Pages[0].PagePieceInfo == null)
            {
                pdf.Pages[0].PagePieceInfo = new PdfPieceInfo();
            }

            // Add key-value pairs to the piece info of the first page
            pdf.Pages[0].PagePieceInfo.AddApplicationData("ice", "E-iceblue-ice");
            pdf.Pages[0].PagePieceInfo.AddApplicationData("blue", "E-iceblue-blue");
            pdf.Pages[0].PagePieceInfo.AddApplicationData("Blue", "E-iceblue-Blue");
            pdf.Pages[0].PagePieceInfo.AddApplicationData("Ice", "E-iceblue-Ice");

            // Remove a value based on its key from the piece info of the first page
            pdf.Pages[0].PagePieceInfo.RemoveApplicationData("Ice");

            // Get the piece dictionaries from the document and save them to a file named "documentPieceDictionary.txt"
            getDictionary(pdf.DocumentPieceInfo.ApplicationDatas, "documentPieceDictionary.txt");

            // Get the piece dictionaries from the first page and save them to a file named "pagePieceDictionary.txt"
            getDictionary(pdf.Pages[0].PagePieceInfo.ApplicationDatas, "pagePieceDictionary.txt");

            // Save the modified PDF document to a new file named "DocumentAndPagePieceDictionaries-result.pdf"
            pdf.SaveToFile("DocumentAndPagePieceDictionaries-result.pdf");

            // Close the document
            pdf.Close();

            //Launch the Pdf file
            FileViewer("DocumentAndPagePieceDictionaries-result.pdf");
            //Launch the .txt files
            FileViewer("documentPieceDictionary.txt");
            FileViewer("pagePieceDictionary.txt");
        }

        private void getDictionary(IDictionary<string, PdfApplicationData> dic, string fileName)
        {
            StringBuilder sb = new StringBuilder();

            // Iterate over all the keys in the dictionary
            foreach (string item in dic.Keys)
            {
                PdfApplicationData data = dic[item];
                if (data.Private is String)
                {
                    // Get the value and append it to the StringBuilder
                    string ss = data.Private as string;
                    sb.AppendLine(ss);
                }
            }

            // Write the text content of the StringBuilder to the specified file
            File.WriteAllText(fileName, sb.ToString());
        }

        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
