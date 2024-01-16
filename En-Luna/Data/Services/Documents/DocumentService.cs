using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class DocumentService : BaseService<Document>, IDocumentService
    {
        public DocumentService(ApplicationContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public Document Approve(Document document)
        {
            document.IsVerified = true;
            _context.Documents.Update(document);
            _context.SaveChanges();
            return document;
        }

        /// <inheritdoc />
        public Document Deny(Document document)
        {
            document.IsVerified = true;
            _context.Documents.Update(document);
            _context.SaveChanges();
            return document;
        }
    }
}
