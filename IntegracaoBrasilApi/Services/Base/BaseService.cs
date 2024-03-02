namespace Harmonit.Microservice.Base.Library.BaseService;

public class BaseService<TIRefit>(TIRefit? refit) : IBaseService
where TIRefit : class
{
    public Guid _guidApiDataRequest;
    public TIRefit? _refit = refit;

    public void SetGuid(Guid guidApiDataRequest)
    {
        _guidApiDataRequest = guidApiDataRequest;
        GenericModule.SetGuidApiDataRequest(this, guidApiDataRequest);
    }

    //public BaseResponseApiContent<TTypeResult, TTypeException> ReturnResponse<TTypeResult, TTypeException>(ApiResponse<string> response, bool isHarmonitIntegration = false)
    //{
        
    //}
}