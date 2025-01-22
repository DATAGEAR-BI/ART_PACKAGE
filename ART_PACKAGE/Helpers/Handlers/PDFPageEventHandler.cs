
using com.sun.jdi.@event;
using iText.Commons.Actions;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using IEventHandler = iText.Kernel.Events.IEventHandler;

namespace ART_PACKAGE.Helpers.Handlers
{
    public class PDFPageEventHandler : IEventHandler
    {
        public void HandleEvent(iText.Kernel.Events.Event pdfEvent)
        {
            var documentEvent = (PdfDocumentEvent)pdfEvent;
            var pdfDoc = documentEvent.GetDocument();
            var page = documentEvent.GetPage();
            var pageSize = page.GetPageSize();

            var canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            var document = new Document(pdfDoc);

            // Page number
            var canvasObject = new Canvas(canvas, pageSize);
            canvasObject.SetFontSize(12)
                .ShowTextAligned(new Paragraph($"Page {pdfDoc.GetPageNumber(page)}"), pageSize.GetWidth() - 50, 30, TextAlignment.RIGHT);
        }

        
    }
}