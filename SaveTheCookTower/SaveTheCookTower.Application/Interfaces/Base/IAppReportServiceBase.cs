namespace SaveTheCookTower.Application.Interfaces.Base
{
	public interface IAppReportServiceBase<TReportParamsViewModel, TReportResultViewModel> 
		where TReportParamsViewModel: class
		where TReportResultViewModel : class
	{
		/// <summary>
		/// Método que retorna um item de resultado sem receber parâmetro
		/// </summary>
		/// <returns></returns>
		//TReportResultViewModel Get();

		/// <summary>
		/// Método que retorna um item de resultado a partir do parâmetro
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		TReportResultViewModel Execute(TReportParamsViewModel param);

		/// <summary>
		/// Método que retorna uma lista de resultados a partir do parâmetro
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		//IList<TReportResultViewModel> GetLists(TReportParamsViewModel param);

		/// <summary>
		/// Retorna como um arquivo pdf com formato influenciado pelo passado em param.
		/// </summary>
		/// Ver https://stackoverflow.com/questions/40486431/return-pdf-to-the-browser-using-asp-net-core
		/// <param name="param"></param>
		/// <returns></returns>
		//IActionResult GetPdf(TReportParamsViewModel param);
	}
}
