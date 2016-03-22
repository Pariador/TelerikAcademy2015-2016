namespace Teleimot.Web.WCF
{
	using System.ServiceModel;

	[ServiceContract]
	public interface ITop
	{
		[OperationContract]
		TopResponseModel Top();
	}
}