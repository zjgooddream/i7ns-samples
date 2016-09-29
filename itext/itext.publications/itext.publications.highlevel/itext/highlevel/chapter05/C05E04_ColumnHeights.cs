/*
* This example was written by Bruno Lowagie
* in the context of the book: iText 7 building blocks
*/
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Test.Attributes;

namespace itext.publications.highlevel.itext.highlevel.chapter05 {
    /// <author>Bruno Lowagie (iText Software)</author>
    [WrapToTest]
    public class C05E04_ColumnHeights {
        public const String DEST = "results/chapter05/column_heights.pdf";

        /// <exception cref="System.IO.IOException"/>
        public static void Main(String[] args) {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();
            new C05E04_ColumnHeights().CreatePdf(DEST);
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void CreatePdf(String dest) {
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(new PdfWriter(dest));
            Paragraph p = new Paragraph("The Strange Case of\nDr. Jekyll\nand\nMr. Hyde").SetBorder(new DashedBorder(0.3f
                ));
            // Initialize document
            Document document = new Document(pdf);
            Table table = new Table(1);
            table.AddCell(p);
            Cell cell = new Cell().SetHeight(16).Add(p);
            table.AddCell(cell);
            cell = new Cell().SetHeight(144).Add(p);
            table.AddCell(cell);
            cell = new Cell().Add(p).SetRotationAngle(Math.PI / 6);
            table.AddCell(cell);
            document.Add(table);
            document.Close();
        }
    }
}