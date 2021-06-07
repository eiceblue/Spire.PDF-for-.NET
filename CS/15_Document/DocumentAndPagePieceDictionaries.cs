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
            //Create a pdf document
            PdfDocument pdf = new PdfDocument();
            //Input file path
            String input = @"..\..\..\..\..\..\Data\DocumentAndPagePieceDictionaries.pdf";
            //Load file from disk
            pdf.LoadFromFile(input);
            /**
             * Add piece dictionaries into a document 
             * */
            //If the document piece info is null, create it
            if (pdf.DocumentPieceInfo == null)
            {
                pdf.DocumentPieceInfo = new PdfPieceInfo();
            }
            //Add pairs of key-value
            pdf.DocumentPieceInfo.AddApplicationData("ice", "E-iceblue-ice");
            pdf.DocumentPieceInfo.AddApplicationData("blue", "E-iceblue-blue");
            pdf.DocumentPieceInfo.AddApplicationData("Blue", "E-iceblue-Blue");
            pdf.DocumentPieceInfo.AddApplicationData("Ice", "E-iceblue-Ice");
            //Remove the value by key
            pdf.DocumentPieceInfo.RemoveApplicationData("blue");
            /**
             * Add piece dictionaries into a page
             * */
            //If the piece info in the first page is null, create it
            if (pdf.Pages[0].PagePieceInfo == null)
            {
                pdf.Pages[0].PagePieceInfo = new PdfPieceInfo();
            }
            //Add pairs of key-value
            pdf.Pages[0].PagePieceInfo.AddApplicationData("ice", "E-iceblue-ice");
            pdf.Pages[0].PagePieceInfo.AddApplicationData("blue", "E-iceblue-blue");
            pdf.Pages[0].PagePieceInfo.AddApplicationData("Blue", "E-iceblue-Blue");
            pdf.Pages[0].PagePieceInfo.AddApplicationData("Ice", "E-iceblue-Ice");
            //Remove the value by key
            pdf.Pages[0].PagePieceInfo.RemoveApplicationData("Ice");

            //Get piece dictionaries from document
            getDictionary(pdf.DocumentPieceInfo.ApplicationDatas, "documentPieceDictionary.txt");
            //Get piece dictionaries from the first page
            getDictionary(pdf.Pages[0].PagePieceInfo.ApplicationDatas, "pagePieceDictionary.txt");

            //Save pdf file
            pdf.SaveToFile("DocumentAndPagePieceDictionaries-result.pdf");
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
            //Traverse all keys in the dictionary
            foreach (string item in dic.Keys)
            {
                PdfApplicationData data = dic[item];
                if (data.Private is String)
                {
                    //Get the value and append it to StringBuilder
                    string ss = data.Private as string;
                    sb.AppendLine(ss);
                }
            }
            //Wirte the text of StringBuilder to file
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
