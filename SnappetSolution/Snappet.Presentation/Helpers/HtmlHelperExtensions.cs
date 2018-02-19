using Snappet.Infrastructure.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Snappet.Presentation.Helpers
{
	public static class HtmlHelperExtensions
	{
		private const string _filterColumnSuffix = "Column";

		public static MvcHtmlString FilterBoxFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, Dimensions dimensionType)
		{
			string propertVal = expression.Body.ToString().Split('.')
				.FirstOrDefault(x => x.Contains(_filterColumnSuffix))?.Replace(_filterColumnSuffix, "") ?? string.Empty;

			var div = new TagBuilder("div")
			{
				InnerHtml =
					string.Join("",
						helper.Label($"{propertVal} Filter").ToHtmlString(),
						helper.DropDownListFor(expression, new List<SelectListItem>(), new { multiple = "multiple", @class = "form-control filter-box", data_dimension = (int)dimensionType, data_bind = $"options: {propertVal}{_filterColumnSuffix}.Filter(), selectedOptions: {propertVal}{_filterColumnSuffix}.Filter()" }).ToHtmlString())
			};

			div.Attributes.Add("class", "form-group");
			div.Attributes.Add("data-bind", $"visible: {propertVal}{_filterColumnSuffix}.IsActive");

			return new MvcHtmlString(div.ToString());
		}
	}
}