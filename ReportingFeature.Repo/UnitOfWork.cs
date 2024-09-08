using ReportingFeature.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ReportingFeature.REPO
{
    public class UnitOfWork : IDisposable
    {

        private readonly RFContext _context;
        private GenericRepository<Booking>? _booking;
        private GenericRepository<BookingService>? _bookingService;
        private GenericRepository<Transaction>? _transaction;
        private GenericRepository<Client>? _client;
        private GenericRepository<Branch>? _branch;
        private GenericRepository<Service>? _service;

        public UnitOfWork(RFContext context)
        {
            _context = context;
        }
        public GenericRepository<Booking> Booking
        {

            get
            {
                if (_booking == null)
                {
                    _booking = new GenericRepository<Booking>(_context);
                }
                return _booking;
            }
        }
        public GenericRepository<BookingService> BookingService
        {

            get
            {
                if (_bookingService == null)
                {
                    _bookingService = new GenericRepository<BookingService>(_context);
                }
                return _bookingService;
            }
        }
        public GenericRepository<Transaction> Transaction
        {

            get
            {
                if (_transaction == null)
                {
                    _transaction = new GenericRepository<Transaction>(_context);
                }
                return _transaction;
            }
        }

        public GenericRepository<Client> Client
        {

            get
            {
                if (_client == null)
                {
                    _client = new GenericRepository<Client>(_context);
                }
                return _client;
            }
        }
        public GenericRepository<Branch> Branch
        {

            get
            {
                if (_branch == null)
                {
                    _branch = new GenericRepository<Branch>(_context);
                }
                return _branch;
            }
        }
        public GenericRepository<Service> Service
        {

            get
            {
                if (_service == null)
                {
                    _service = new GenericRepository<Service>(_context);
                }
                return _service;
            }
        }


        public async Task<int> Complete()
        {
                var x= await _context.SaveChangesAsync();
                return x;

        }



       



        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
    }
}
