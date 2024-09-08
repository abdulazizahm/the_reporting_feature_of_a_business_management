using AutoMapper;
using ReportingFeature.DTO;
using ReportingFeature.Helpers;
using ReportingFeature.REPO;

namespace ReportingFeature.Business
{
    public class BaseMananger : IDisposable
    {
        protected readonly UnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public BaseMananger(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        

        protected readonly ValidationMessagesParser _VMP = new();
       
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                    // TODO: dispose managed state (managed objects).

                }

                disposedValue = true;
            }
        }
        public async Task<Response> SaveChanges(int lang)
        {
            var check = await _unitOfWork.Complete();
            return new Response
            {
                ResponseCode = Enum.ResponseTypeEnum.Success,
                ResultMessege = lang == 0 ? _VMP.Get("Common.SuccesSave") : _VMP.Get("Common.SuccesSaveAr")
            };
        }


        public void DeleteFile(string Path)
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}