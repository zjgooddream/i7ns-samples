/*
* This example was written by Bruno Lowagie
* in the context of the book: iText 7 building blocks
*/

using System;
using System.IO;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace iText.Highlevel.Chapter01 {
    /// <author>Bruno Lowagie (iText Software)</author>
    public class C01E03_Text_Paragraph_NoCardo {
        public const String DEST = "../../../results/chapter01/text_paragraph_no_cardo.pdf";

        public const String REGULAR = "../../../resources/fonts/Cardo-Regular.ttf";

        public const String BOLD = "../../../resources/fonts/Cardo-Bold.ttf";

        public const String ITALIC = "../../../resources/fonts/Cardo-Italic.ttf";

        public static void Main(String[] args) {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();
            new C01E03_Text_Paragraph_NoCardo().CreatePdf(DEST);
        }

        public virtual void CreatePdf(String dest) {
            // Initialize PDF document
            PdfDocument pdf = new PdfDocument(new PdfWriter(dest));
            // Initialize document
            Document document = new Document(pdf);
            // Add content: the fonts aren't embedded! Don't do this!
            PdfFont font = PdfFontFactory.CreateFont(REGULAR);
            PdfFont bold = PdfFontFactory.CreateFont(BOLD);
            PdfFont italic = PdfFontFactory.CreateFont(ITALIC);
            Text title = new Text("The Strange Case of Dr. Jekyll and Mr. Hyde").SetFont(bold);
            Text author = new Text("Robert Louis Stevenson").SetFont(font);
            Paragraph p = new Paragraph().SetFont(italic).Add(title).Add(" by ").Add(author);
            document.Add(p);
            //Close document
            document.Close();
        }
    }
}
