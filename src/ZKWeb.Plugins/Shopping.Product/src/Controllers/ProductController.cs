﻿using System;
using ZKWebStandard.Ioc;
using ZKWeb.Web.ActionResults;
using ZKWeb.Web;
using System.ComponentModel;

namespace ZKWeb.Plugins.Shopping.Product.src.Controllers {
	/// <summary>
	/// 商品控制器
	/// </summary>
	[ExportMany]
	public class ProductController : IController {
		/// <summary>
		/// 前台商品详情页
		/// </summary>
		/// <returns></returns>
		[Action("product/view")]
		[Description("ProductViewPage")]
		public IActionResult View() {
			return new TemplateResult("shopping.product/product_view.html");
		}

		/// <summary>
		/// 前台商品列表页
		/// </summary>
		/// <returns></returns>
		[Action("product/list")]
		[Description("ProductListPage")]
		public IActionResult List() {
			return new TemplateResult("shopping.product/product_list.html");
		}
	}
}
